using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalonAppointment
{
    public class Slot
    {
        public int SlotId { get; set; }
        public TimeSpan StartTime { get; set; }
        public string SlotType { get; set; }
        public string Service { get; set; }
    }
}