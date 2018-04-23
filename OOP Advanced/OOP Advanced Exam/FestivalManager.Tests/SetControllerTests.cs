// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to your project (entities/controllers/etc)
namespace FestivalManager.Tests
{
    using FestivalManager.Core.Controllers;
    using FestivalManager.Entities;
    using FestivalManager.Entities.Instruments;
    using FestivalManager.Entities.Sets;
    using NUnit.Framework;


    [TestFixture]
    public class SetControllerTests
    {
        [Test]
        public void Test()
        {
            var stage = new Stage();
            var song1 = new Song("Song1", new System.TimeSpan(0, 10, 5));
            var song2 = new Song("Song2", new System.TimeSpan(0, 2, 0));



            var drums = new Drums();
            var guitar1 = new Guitar();
            var guitar2 = new Guitar();
            var mic = new Microphone();

            var performer1 = new Performer("Pesho", 20);
            performer1.AddInstrument(drums);
            performer1.AddInstrument(guitar1);

            var performer2 = new Performer("Gosho", 60);
            performer2.AddInstrument(mic);
            performer2.AddInstrument(guitar2);

            var set1 = new Medium("Set1");
            var set2 = new Medium("Set2");

            set1.AddPerformer(performer1);
            set1.AddPerformer(performer2);
            set1.AddSong(song1);

            set2.AddPerformer(performer1);
            set2.AddSong(song2);

            stage.AddSet(set1);
            stage.AddSet(set2);
            stage.AddPerformer(performer1);
            stage.AddPerformer(performer2);
            stage.AddSong(song1);
            stage.AddSong(song2);


            var SetCtr = new SetController(stage);
            string result = SetCtr.PerformSets();



            Assert.That(drums.Wear, Is.EqualTo(60));
            Assert.That(guitar1.Wear, Is.EqualTo(0));
            Assert.That(guitar2.Wear, Is.EqualTo(40));
            Assert.That(mic.Wear, Is.EqualTo(20));


        }

        [Test]
        public void Test2()
        {
            var stage = new Stage();
            var song1 = new Song("Song1", new System.TimeSpan(0, 10, 5));
            var song2 = new Song("Song2", new System.TimeSpan(0, 2, 0));



            var drums = new Drums();
            var guitar1 = new Guitar();
            var guitar2 = new Guitar();
            var mic = new Microphone();

            var performer1 = new Performer("Pesho", 20);
            performer1.AddInstrument(drums);
            performer1.AddInstrument(guitar1);

            var performer2 = new Performer("Gosho", 60);
            performer2.AddInstrument(mic);
            performer2.AddInstrument(guitar2);

            var set1 = new Medium("Set1");
            var set2 = new Medium("Set2");

            set1.AddPerformer(performer1);
            set1.AddPerformer(performer2);
            set1.AddSong(song1);

            set2.AddPerformer(performer1);
            set2.AddSong(song2);

            stage.AddSet(set1);
            stage.AddSet(set2);
            stage.AddPerformer(performer1);
            stage.AddPerformer(performer2);
            stage.AddSong(song1);
            stage.AddSong(song2);

            var expectedResult = "1. Set1:\r\n-- 1. Song1 (10:05)\r\n-- Set Successful\r\n2. Set2:\r\n-- 1. Song2 (02:00)\r\n-- Set Successful";

            var SetCtr = new SetController(stage);
            string result = SetCtr.PerformSets();

            //FieldInfo info = SetCtr.GetType().GetField("sortedSets", BindingFlags.NonPublic | BindingFlags.Instance);
            //var value = info.GetValue(SetCtr);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Test3()
        {
            var stage = new Stage();
            var song1 = new Song("Song1", new System.TimeSpan(0, 10, 5));
            var song2 = new Song("Song2", new System.TimeSpan(0, 0, 0));



            var drums = new Drums();
            var guitar1 = new Guitar();
            var guitar2 = new Guitar();
            var mic = new Microphone();

            var performer1 = new Performer("Pesho", 20);
            performer1.AddInstrument(drums);
            performer1.AddInstrument(guitar1);

            var performer2 = new Performer("Gosho", 60);
            performer2.AddInstrument(mic);
            performer2.AddInstrument(guitar2);

            var set1 = new Medium("Set1");
            var set2 = new Medium("Set2");

            set1.AddPerformer(performer1);
            set1.AddPerformer(performer2);

            set2.AddPerformer(performer1);
            set2.AddSong(song2);
            set2.AddSong(song1);

            stage.AddSet(set1);
            stage.AddSet(set2);
            stage.AddPerformer(performer1);
            stage.AddPerformer(performer2);
            stage.AddSong(song1);
            stage.AddSong(song2);

            var expectedResult = "1. Set2:\r\n-- 1. Song2 (00:00)\r\n-- 2. Song1 (10:05)\r\n-- Set Successful\r\n2. Set1:\r\n-- Did not perform";

            var SetCtr = new SetController(stage);
            string result = SetCtr.PerformSets();

            //FieldInfo info = SetCtr.GetType().GetField("sortedSets", BindingFlags.NonPublic | BindingFlags.Instance);
            //var value = info.GetValue(SetCtr);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

    }
}