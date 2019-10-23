using System;
using System.Collections.Generic;

namespace PlannerClassLibrary
{
    public class Route
    {
        public string City { get; set; }
        public List<Times> ToLinz { get; set; }
        public List<Times> FromLinz { get; set; }
    }

    public class Times
    {
        public string Arrive { get; set; }
        public string Leave { get; set; }
    }

    public class Trip : Times
    {
        public string fromCity { get; set; }
        public string toCity { get; set; }
    }
}
