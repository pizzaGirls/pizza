using System;
using Feonufry.CUI.Actions;

namespace Hecsit.PizzaGirls.UI.Actions
{
    public class BarAction : IAction
    {
        public void Perform(ActionExecutionContext context)
        {
            context.Out.WriteLine(ConsoleColor.Green, "BAR");
        }
    }
}