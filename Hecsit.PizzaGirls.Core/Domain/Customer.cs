using System.Collections.Generic;

namespace Hecsit.PizzaGirls.Core.Domain
{
    public class Customer : Entity
    {
        private string _address;
        private string _phone;
        private bool _card;

         #region constructor

        public Customer(string address, string phone, bool card)
        {
            _address = address;
            _phone = phone;
            _card = card;
        }

        #endregion constructor

        #region properties

        public string Address 
        { 
            get { return _address; } 
            set { _address = value; } 
        }

        public string Phone
        {
            get { return _phone; } 
            set { _phone = value; }
        }

        public bool Card 
        {
            get { return _card; }
            set { _card = value; }
        }

        #endregion properties
    }
}
