using System;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;

namespace ClassScan
{
    class Program
    {
        public static IDictionary<string,IDummy> dummies;
        static void Main(string[] args)
        {
            var classes = Assembly.GetExecutingAssembly().GetTypes().Where( x => !x.IsInterface && typeof(IDummy).IsAssignableFrom(x));
            foreach (var dummy in classes)
            {
                if (dummies == null)
                {
                    dummies = new Dictionary<string,IDummy>();
                }
                System.Console.WriteLine($"class name: {dummy.Name}");
                var instance = (IDummy)Activator.CreateInstance(dummy);
                System.Console.WriteLine(instance.Get());
                foreach (var attrib in dummy.GetCustomAttributes(true))
                {
                    var dummyAttribute = attrib as DummyAttribute;
                    if (dummyAttribute != null)
                    {
                        System.Console.WriteLine($"Dumb attrib: {dummyAttribute.Dumb}");
                        dummies.Add(dummyAttribute.Dumb,instance);
                    }
                }
                System.Console.WriteLine($"Number of dummies: {dummies.Count}");
                System.Console.WriteLine($"Test: {dummies["dumbest"].Get()}");
            }
        }
    }
}
