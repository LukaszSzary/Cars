using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Domain
{
    public enum fuel {Petrol, Disel,Hybrid};
    class Car
    {
        public int id { get; set; }
        public DateTime productionYear { get; set; }
        public fuel fuelType { get; set; }
        public int nuberOfDors { get; set; }
}
}
