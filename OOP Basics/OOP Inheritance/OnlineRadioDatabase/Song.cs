using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Song
{
    private string artist;
    private string name;
    private string lenght;
    private int minutes;
    private int seconds;

    public Song(string artist, string name, string lenght)
    {
        this.Artist = artist;
        this.Name = name;
        this.Lenght = lenght;
    }

    public string Artist
    {
        get { return this.artist; }
        private set
        {
            if (value.Length < 3 || value.Length > 20)
            {
                throw new InvalidArtistNameException();
            }

            this.artist = value;
        }
    }

    public string Name
    {
        get { return this.name; }
        private set
        {
            if (value.Length < 3 || value.Length > 30)
            {
                throw new InvalidSongNameException();
            }

            this.name = value;
        }
    }

    public string Lenght
    {
        get { return this.lenght; }
        private set
        {
            var tokens = value.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

            if (tokens.Length != 2)
            {
                throw new InvalidSongLengthException();
            }

            int minutes;
            int seconds;

            bool isMinValid = int.TryParse(tokens[0], out minutes);
            bool isSecValid = int.TryParse(tokens[1], out seconds);

            if (!(isMinValid && isSecValid))
            {
                throw new InvalidSongLengthException();
            }

            this.lenght = value;
            this.Minutes = minutes;
            this.Seconds = seconds;
        }
    }

    public int Minutes
    {
        get { return this.minutes; }
        private set
        {
            if (value < 0 || value > 14)
            {
                throw new InvalidSongMinutesException();
            }
            this.minutes = value;
        }
    }

    public int Seconds
    {
        get { return this.seconds; }
        private set
        {
            if (value < 0 || value > 59)
            {
                throw new InvalidSongSecondsException();
            }
            this.seconds = value;
        }
    }
}

