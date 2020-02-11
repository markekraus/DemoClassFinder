using System;

namespace ClassScan
{
    [Dummy("dumbest")]
    public class Dummy : IDummy
    {
        public Dummy(){}
        public string Get()
        {
            return nameof(Dummy);
        }
    }
}