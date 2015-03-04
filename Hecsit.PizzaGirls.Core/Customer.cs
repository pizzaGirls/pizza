using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hecsit.PizzaGirls.UI
{
    class Customer
    {
         #region constructor

        public Customer(string address, string phone, bool card)
        {
            Address = address;
            Phone = phone;
            Card = card;
            
        }

        #endregion constructor

        #region properties

        public string Address { get; set; }

        public string Phone { get; set; }

        public bool Card { get; set; }

        #endregion properties
    }
}
