namespace P02_BlackBoxInteger
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            var type = typeof(BlackBoxInteger);
            FieldInfo innerValue = type.GetField("innerValue", BindingFlags.NonPublic | BindingFlags.Instance);
            MethodInfo[] methods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

            var instance = Activator.CreateInstance(type, true);

            string command = "";
            while ((command = Console.ReadLine()) !="END")
            {
                var args = command.Split('_');

                var methodName = args[0];
                int value = int.Parse(args[1]);

                MethodInfo method = methods.FirstOrDefault(m => m.Name == methodName);

                method.Invoke(instance, new object[] { value });

                Console.WriteLine(innerValue.GetValue(instance));
            }
        }
    }
}
