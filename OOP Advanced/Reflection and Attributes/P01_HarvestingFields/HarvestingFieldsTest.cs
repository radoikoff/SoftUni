namespace P01_HarvestingFields
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            string command;
            Type type = typeof(HarvestingFields);
            FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance | BindingFlags.NonPublic);
            FieldInfo[] fieldsToDisplay = null;

            while ((command = Console.ReadLine()) != "HARVEST")
            {
                switch (command)
                {
                    case "private":
                        fieldsToDisplay = fields.Where(f => f.IsPrivate).ToArray();
                        break;

                    case "protected":
                        fieldsToDisplay = fields.Where(f => f.IsFamily).ToArray();
                        break;

                    case "public":
                        fieldsToDisplay = fields.Where(f => f.IsPublic).ToArray();
                        break;

                    case "all":
                        fieldsToDisplay = fields;
                        break;
                }

                foreach (var field in fieldsToDisplay)
                {
                    string fieldType = "";
                    if (field.IsPublic)
                    {
                        fieldType = "public";
                    }
                    if (field.IsFamily)
                    {
                        fieldType = "protected";
                    }
                    if (field.IsPrivate)
                    {
                        fieldType = "private";
                    }

                    Console.WriteLine($"{fieldType} {field.FieldType.Name} {field.Name}");
                }

            }

        }
    }
}
