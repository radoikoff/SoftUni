using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class InvalidArtistNameException : InvalidSongException
{
    public override string Message
    {
        get
        {
            return "Artist name should be between 3 and 20 symbols.";
        }
    }
}
