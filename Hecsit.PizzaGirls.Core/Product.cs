using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hecsit.PizzaGirls.UI;

namespace Hecsit.PizzaGirls.Core
{
    class Product
    {
        #region constructor

        public Product(string name, double price, string descr)
        {
            _name = name;
            _unitPrice = price;
            _description = descr;
        }
        #endregion

        #region prorerties

        private string _name ;
        private double _unitPrice;
        private string _description;
        //??
        private ICollection<OrderLine> _orderLines;

        #endregion

    }
}
