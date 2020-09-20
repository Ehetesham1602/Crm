using System;
using System.Collections.Generic;
using System.Text;

namespace Crm.Entities
{
    public class City
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public int StateId { get; set; }
        public State State { get; set; }

    }
}
