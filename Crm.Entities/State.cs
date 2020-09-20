using System;
using System.Collections.Generic;
using System.Text;

namespace Crm.Entities
{
    public class State
    {
        public int Id { get; set; }
        public string StateName { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }

    }
}
