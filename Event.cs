using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_FE_24_25
{
    internal class Event
    {
        #region Properties
        public string Name { get; set; }
        public DateTime EventDate { get; set; }
        public List<Ticket> Tickets { get; set; }
        public TypeOfEvent EventType { get; set; }
        
        public enum TypeOfEvent
        {
            Music,
            Comedy,
            Theatre
        }
        #endregion

        public Event(string name, DateTime eventDate, TypeOfEvent eventType)
        {
            this.Name = name;
            this.EventDate = eventDate;
            this.EventType = eventType;
        }

        public override string ToString()
        {
            return $"{Name} - {EventDate}";
        }
    }
}
