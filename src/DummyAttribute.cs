using System;

namespace ClassScan
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class DummyAttribute : Attribute
    {
        public string Dumb { get; set; }

        public DummyAttribute(string dumb)
        {
            Dumb = dumb;
        }
    }
}