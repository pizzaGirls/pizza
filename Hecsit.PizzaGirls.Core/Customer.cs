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
            _address = address;
            _phone = phone;
            _card = card;
            
        }

        #endregion constructor

        #region properties

        private string _address { get; set; }

        private string _phone { get; set; }

        private bool _card { get; set; }

        private ICollection<Order> _orders { get; set; }

        #endregion properties
    }
}
