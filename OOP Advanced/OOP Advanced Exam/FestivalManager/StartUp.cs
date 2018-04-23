namespace FestivalManager
{
    using System;
    using System.IO;
    using System.Linq;
    using Core;
    using Core.Contracts;
    using Core.Controllers;
    using Core.Controllers.Contracts;
    using Core.IO;
    using Core.IO.Contracts;
    using Entities;
    using Entities.Contracts;
    using FestivalManager.Entities.Factories;
    using FestivalManager.Entities.Factories.Contracts;


    public static class StartUp
    {
        public static void Main(string[] args)
        {

            IStage stage = new Stage();
            IInstrumentFactory instrumentFactory = new InstrumentFactory();
            IPerformerFactory performerFactory = new PerformerFactory();
            ISetFactory setFactory = new SetFactory();
            ISongFactory songFactory = new SongFactory();

            IFestivalController festivalController = new FestivalController(stage, instrumentFactory, performerFactory, setFactory, songFactory);
            ISetController setController = new SetController(stage);
            IReader reader = new Reader();
            IWriter writer = new Writer();

            Engine engine = new Engine(festivalController, setController, reader, writer);

            engine.Run();
        }

    }
}