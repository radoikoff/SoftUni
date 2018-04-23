namespace FestivalManager.Entities.Factories
{
    using Contracts;
    using Entities.Contracts;
    using Sets;
    using System;
    using System.Linq;
    using System.Reflection;

    public class SetFactory : ISetFactory
    {

        public ISet CreateSet(string name, string type)
        {
            Assembly assembly = Assembly.GetCallingAssembly();
            Type setType = assembly.GetTypes().FirstOrDefault(t => t.Name == type);

            if (setType == null)
            {
                throw new InvalidOperationException("Set not found!");
            }

            if (!typeof(ISet).IsAssignableFrom(setType))
            {
                throw new InvalidOperationException($"{setType} is not a set!");
            }

            

            ISet set = (ISet)Activator.CreateInstance(setType, name);
            return set;
        }
    }




}
