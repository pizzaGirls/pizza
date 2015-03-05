using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Feonufry.CUI.Menu.Builders;
using Hecsit.PizzaGirls.UI.Actions;

namespace Hecsit.PizzaGirls.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            new MenuBuilder()
                    .Title("MENU")
                    .Repeatable()
                    .Item("Foo", new FooAction())
                    .Item("Bar", new BarAction())
                    .Exit("Exit")
                    .GetMenu().Run();
        }
    }
}
