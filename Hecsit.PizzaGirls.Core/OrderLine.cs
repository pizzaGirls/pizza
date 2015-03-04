using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hecsit.PizzaGirls.Core;

namespace Hecsit.PizzaGirls.UI
{
    class OrderLine
    {
        #region constructor

        public OrderLine(int quantity, double cost, string status)
        {
            _quantity = quantity;
            _cost = cost;
            _status = status;
            
        }

        #endregion constructor

        #region properties

        private int _quantity { get; set; }
        private double _cost { get; set; }
        private string _status { get; set; }
        //????
        private Order _order {get;set;}
        //??
        private Product _product;


        #endregion properties
    }
}
