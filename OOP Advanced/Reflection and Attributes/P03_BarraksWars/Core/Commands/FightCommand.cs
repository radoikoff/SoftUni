using _03BarracksFactory.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03BarracksFactory.Core.Commands
{
    public class FightCommand : Command
    {
        public FightCommand(string[] data)
            : base(data)
        {
        }

        public override string Execute()
        {
            Environment.Exit(0);
            return null;
        }
    }
}
