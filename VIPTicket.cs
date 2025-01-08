using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_FE_24_25
{
    internal class VIPTicket : Ticket
    {
        #region Properties
        public string AdditionalCosts { get; set; }
        public string AdditionalExtras { get; set; }
        #endregion

        public VIPTicket(string name, decimal price, int availableTickets, string addtitionalExtras, string additionalCosts) : base(name, price, availableTickets) 
        {
            this.AdditionalExtras = addtitionalExtras;
            this.AdditionalCosts = additionalCosts;
        }
    }
}
