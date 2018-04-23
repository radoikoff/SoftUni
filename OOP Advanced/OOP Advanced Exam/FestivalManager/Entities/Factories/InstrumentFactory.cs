namespace FestivalManager.Entities.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.InteropServices.WindowsRuntime;
    using Contracts;
    using Entities.Contracts;
    using Instruments;

    public class InstrumentFactory : IInstrumentFactory
    {
        public IInstrument CreateInstrument(string type)
        {
            Assembly assembly = Assembly.GetCallingAssembly();
            Type instrumentType = assembly.GetTypes().FirstOrDefault(t => t.Name == type);

            if (instrumentType == null)
            {
                throw new InvalidOperationException("Instrument not found!");
            }

            if (!typeof(IInstrument).IsAssignableFrom(instrumentType))
            {
                throw new InvalidOperationException($"{instrumentType} is not an instrument!");
            }

            IInstrument instrument = (IInstrument)Activator.CreateInstance(instrumentType);
            return instrument;
        }
    }
}