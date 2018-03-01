using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class InvalidSongSecondsException : InvalidSongLengthException
{
    public override string Message
    {
        get
        {
            return "Song seconds should be between 0 and 59.";
        }
    }
}

