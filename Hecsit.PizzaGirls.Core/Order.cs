using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hecsit.PizzaGirls.UI
{
    class Order
    {
        #region constructor

        public Order(string numberOrder, string date, string statusOrder, double costDelivery)
        {
            NumberOrder=numberOrder;
            Date=date;
            StatusOrder=statusOrder;
            CostDelivery = costDelivery;
        }

        #endregion constructor

        #region properties

        public string NumberOrder { get; set; }

        public string Date { get; set; }

        public string StatusOrder { get; set; }

        public double CostDelivery { get; set; }

        #endregion properties
    }
}
