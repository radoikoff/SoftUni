namespace FestivalManager.Core.Controllers
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Entities.Contracts;
    using FestivalManager.Entities.Factories.Contracts;

    public class FestivalController : IFestivalController
    {
        private const string TimeFormat = "mm\\:ss";
        //private const string TimeFormatLong = "{0:2D}:{1:2D}";
        //private const string TimeFormatThreeDimensional = "{0:3D}:{1:3D}";

        private IStage stage;
        private IInstrumentFactory instrumentFactory;
        private IPerformerFactory performerFactory;
        private ISetFactory setFactory;
        private ISongFactory songFactory;

        public FestivalController(IStage stage, IInstrumentFactory instrumentFactory, IPerformerFactory performerFactory, ISetFactory setFactory, ISongFactory songFactory)
        {
            this.stage = stage;
            this.instrumentFactory = instrumentFactory;
            this.performerFactory = performerFactory;
            this.setFactory = setFactory;
            this.songFactory = songFactory;
        }

        public string RegisterSet(string[] args)
        {
            string name = args[0];
            string type = args[1];

            ISet set = this.setFactory.CreateSet(name, type);
            this.stage.AddSet(set);

            return $"Registered {type} set";
        }

        public string SignUpPerformer(string[] args)
        {
            string name = args[0];
            int age = int.Parse(args[1]);

            IPerformer performer = this.performerFactory.CreatePerformer(name, age);

            if (args.Length > 2)
            {
                string[] instrumentsString = args.Skip(2).ToArray();

                IInstrument[] instruments = instrumentsString.Select(i => this.instrumentFactory.CreateInstrument(i)).ToArray();
                foreach (var instrument in instruments)
                {
                    performer.AddInstrument(instrument);
                }
            }

            this.stage.AddPerformer(performer);

            return $"Registered performer {performer.Name}";
        }

        public string RegisterSong(string[] args)
        {
            string songName = args[0];

            var time = args[1].Split(':');
            int minutes = int.Parse(time[0]);
            int seconds = int.Parse(time[1]);

            var duration = new TimeSpan(0, minutes, seconds);

            ISong song = this.songFactory.CreateSong(songName, duration);


            this.stage.AddSong(song);
            return $"Registered song {songName} ({duration:mm\\:ss})";
        }

        public string AddPerformerToSet(string[] args)
        {
            var performerName = args[0];
            var setName = args[1];

            if (!this.stage.HasPerformer(performerName))
            {
                throw new InvalidOperationException("Invalid performer provided");
            }

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException("Invalid set provided");
            }

            var performer = this.stage.GetPerformer(performerName);
            var set = this.stage.GetSet(setName);

            set.AddPerformer(performer);

            return $"Added {performerName} to {setName}";
        }

        public string RepairInstruments(string[] args)
        {
            var instrumentsToRepair = this.stage.Performers
                .SelectMany(p => p.Instruments)
                .Where(i => i.Wear < 100)
                .ToArray();

            foreach (var instrument in instrumentsToRepair)
            {
                instrument.Repair();
            }

            return $"Repaired {instrumentsToRepair.Length} instruments";
        }

        public string ProduceReport()
        {
            var result = string.Empty;

            var totalFestivalLength = new TimeSpan(this.stage.Sets.Sum(s => s.ActualDuration.Ticks));

            if (totalFestivalLength.TotalMinutes >= 60)
            {
                result += ($"Festival length: {totalFestivalLength.TotalMinutes}:{totalFestivalLength.Seconds:D2}") + "\n";
            }
            else
            {
                result += ($"Festival length: {totalFestivalLength.ToString(TimeFormat)}") + "\n";
            }

            

            foreach (var set in this.stage.Sets)
            {
                if (set.ActualDuration.TotalMinutes >= 60)
                {
                    result += ($"--{set.Name} ({set.ActualDuration.TotalMinutes}:{set.ActualDuration.Seconds:D2}):") + "\n";
                }
                else
                {
                    result += ($"--{set.Name} ({set.ActualDuration.ToString(TimeFormat)}):") + "\n";
                }

                //result += ($"--{set.Name} ({set.ActualDuration.ToString(TimeFormat)}):") + "\n";

                var performersOrderedDescendingByAge = set.Performers.OrderByDescending(p => p.Age);
                foreach (var performer in performersOrderedDescendingByAge)
                {
                    var instruments = string.Join(", ", performer.Instruments
                        .OrderByDescending(i => i.Wear));

                    result += ($"---{performer.Name} ({instruments})") + "\n";
                }

                if (!set.Songs.Any())
                    result += ("--No songs played") + "\n";
                else
                {
                    result += ("--Songs played:") + "\n";
                    foreach (var song in set.Songs)
                    {
                        result += ($"----{song.Name} ({song.Duration.ToString(TimeFormat)})") + "\n";
                    }
                }
            }

            return result.ToString();
        }

        public string AddSongToSet(string[] args)
        {
            var songName = args[0];
            var setName = args[1];

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException("Invalid set provided");
            }

            if (!this.stage.HasSong(songName))
            {
                throw new InvalidOperationException("Invalid song provided");
            }

            var set = this.stage.GetSet(setName);
            var song = this.stage.GetSong(songName);

            set.AddSong(song);

            return $"Added {songName} ({song.Duration:mm\\:ss}) to {setName}";
        }
    }
}