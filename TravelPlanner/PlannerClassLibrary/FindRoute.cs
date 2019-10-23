using System;
using System.Collections.Generic;
using System.Text;

namespace PlannerClassLibrary
{
    public class FindRoute
    {
        public List<Route> RouteList;

        public FindRoute(List<Route> RouteList)
        {
            this.RouteList = RouteList;
        }

        public Trip GetTrip(string Dep, string Dest, string Time)
        {
            if (Dest.Equals("Linz"))
            {
                return FindFastestRoute(Dest, Dep, Time);
            }else if (Dep.Equals("Linz"))
            {
                return FindFastestRoute(Dep, Dest, Time);
            }
            return null;
        }

        public Trip FindFastestRoute(string Dep, string Dest, string Time)
        {
            foreach (Route r in RouteList)
            {
                if (r.City.Equals(Dep))
                {
                    foreach(Times t in r.ToLinz)
                    {
                        if(t.Leave.CompareTo(Time) >= 0)
                        {
                            return new Trip()
                            {
                                fromCity = Dep,
                                toCity = Dest,
                                Leave = t.Leave,
                                Arrive = t.Arrive
                            };
                        }
                    }
                }
            }
            return null;
        }
    }
}
