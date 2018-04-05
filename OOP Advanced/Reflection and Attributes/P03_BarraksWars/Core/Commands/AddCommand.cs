using System;
using System.Collections.Generic;
using System.Text;
using _03BarracksFactory.Contracts;

namespace _03BarracksFactory.Core.Commands
{
    public class AddCommand : Command
    {
        public AddCommand(string[] data, IRepository repository, IUnitFactory unitfactory) 
            : base(data)
        {
            this.Repository = repository;
            this.UnitFactory = unitfactory;
        }

        [Inject]
        private IRepository repository;

        public IRepository Repository
        {
            get { return repository; }
            private set { repository = value; }
        }

        [Inject]
        private IUnitFactory unitFactory;

        public IUnitFactory UnitFactory
        {
            get { return unitFactory; }
            private set { unitFactory = value; }
        }

        public override string Execute()
        {
            string unitType = this.Data[1];
            IUnit unitToAdd = this.UnitFactory.CreateUnit(unitType);
            this.Repository.AddUnit(unitToAdd);
            string output = unitType + " added!";
            return output;
        }
    }
}
