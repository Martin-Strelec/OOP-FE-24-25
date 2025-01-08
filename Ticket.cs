using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_FE_24_25
{
    internal class Ticket
    {
        #region Properties
        public string Name { get; set; } 
        public decimal Price { get; set; }
        public int AvailableTickets { get; set; }
        #endregion

        public Ticket (string name, decimal price, int availableTickets)
        {
            this.Name = name;
            this.Price = price;
            this.AvailableTickets = availableTickets;
        }
        public Ticket() { }

        public override string ToString()
        {
            return $"{this.Name} - {this.Price}[AVAILABLE - {this.AvailableTickets}]";
        }
    }
}
