using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hecsit.PizzaGirls.UI
{
    class Menu
    {
         #region constructor

        public Menu(string name, double unitPrice, string description)
        {
            Name = name;
            UnitPrice = unitPrice;
            Description = description;
            
        }

        #endregion constructor

        #region properties

        public string Name { get; set; }

        public double UnitPrice { get; set; }

        public string Description { get; set; }

        #endregion properties
    }
}
