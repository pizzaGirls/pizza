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
            _numberOrder=numberOrder;
            _date=date;
            _statusOrder=statusOrder;
            _costDelivery = costDelivery;
        }

        #endregion constructor

        #region properties

        private string _numberOrder { get; set; }

        private string _date { get; set; }

        private string _statusOrder { get; set; }

        private double _costDelivery { get; set; }

        //???
        private Customer _customer { get; set; }
        private ICollection<OrderLine> _orderLines { get; set; }


        #endregion properties
    }
}
