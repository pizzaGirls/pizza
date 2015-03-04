using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hecsit.PizzaGirls.UI
{
    class OrderLine
    {
        #region constructor

        public OrderLine(int quantity, double cost, string status)
        {
            Quantity = quantity;
            Cost = cost;
            Status = status;
            
        }

        #endregion constructor

        #region properties

        public int Quantity { get; set; }

        public double Cost { get; set; }

        public string Status { get; set; }

        #endregion properties
    }
}
