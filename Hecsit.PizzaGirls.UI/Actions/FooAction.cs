using System;
using Feonufry.CUI.Actions;

namespace Hecsit.PizzaGirls.UI.Actions
{
    public class FooAction : IAction
    {
        public void Perform(ActionExecutionContext context)
        {
            context.Out.WriteLine(ConsoleColor.Yellow, "FOO");
        }
    }
}