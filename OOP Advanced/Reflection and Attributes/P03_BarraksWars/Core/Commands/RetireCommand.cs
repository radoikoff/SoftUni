using System;
using System.Collections.Generic;
using System.Text;
using _03BarracksFactory.Contracts;

namespace _03BarracksFactory.Core.Commands
{
    public class RetireCommand : Command
    {
        public RetireCommand(string[] data, IRepository repository)
            : base(data)
        {
            this.Repository = repository;
        }

        [Inject]
        private IRepository repository;

        public IRepository Repository
        {
            get { return repository; }
            private set { repository = value; }
        }

        public override string Execute()
        {
            string unitType = Data[1];
            try
            {
                this.Repository.RemoveUnit(unitType);
                return $"{unitType} retired!";
            }
            catch (Exception ex)
            {
                throw new ArgumentException("No such units in repository.", ex);
            }

        }
    }
}
