using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());

        var songs = new List<Song>();

        for (int i = 0; i < n; i++)
        {
            try
            {
                var songArgs = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                if (songArgs.Length != 3)
                {
                    throw new InvalidSongException();
                }

                var artist = songArgs[0];
                var songName = songArgs[1];
                var lenght = songArgs[2];

                var currSong = new Song(artist, songName, lenght);

                songs.Add(currSong);
                Console.WriteLine("Song added.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        Console.WriteLine($"Songs added: {songs.Count}");

        var totalSeconds = songs.Sum(s => s.Minutes) * 60 + songs.Sum(s => s.Seconds);
        var timespan = TimeSpan.FromSeconds(totalSeconds);

        Console.WriteLine($"Playlist length: {timespan.Hours}h {timespan.Minutes}m {timespan.Seconds}s");
    }
}

