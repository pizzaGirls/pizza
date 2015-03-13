using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Hecsit.PizzaGirls.Core.Api
{
    public class CustomerDto
    {
        public Guid Id { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public bool Card { get; set; }
    }
}
