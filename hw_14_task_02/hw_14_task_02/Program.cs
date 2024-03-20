using System.Reflection;

namespace Task2
{

    class CustomAttribute : Attribute
    {

        public string[] Values { get; }

        public CustomAttribute(params string[] values)
        {
            this.Values = values;
        }

    }

    [Custom("Joe", "2", "Class to work with health data.", "Arnold", "Bernard")]
    public class HealthScore
    {

        [Custom("Andrew", "3", "Method to collect health data.", "Sam", "Alex")]
        public static long CalcScoreData()
        {
            return 0;
        }

    }

    public class Program
    {

        public static void Main()
        {
            
            Console.WriteLine("HealthScore:");
            Type type = typeof(HealthScore);
            PrintAttr(type.GetCustomAttributes(false));

            MemberInfo[] members = type.GetMethods();

            foreach (MemberInfo memberInfo in members)
            {
                Console.WriteLine("{0} info:", memberInfo.Name);
                PrintAttr(memberInfo.GetCustomAttributes(false));
            }
        }

        private static void PrintAttr(object[] atts)
        {
            bool containsData = false;

            foreach (Attribute attr in atts)
            {
                if (attr is CustomAttribute customAttribute)
                {
                    containsData = true;
                    foreach (string value in customAttribute.Values)
                    {
                        Console.WriteLine("  {0}", value);
                    }
                }
            }

            if (!containsData)
            {
                Console.WriteLine("  0 info");
            }
        }
    }

}