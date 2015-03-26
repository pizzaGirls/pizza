using System;
using System.Collections.Generic;
using Hecsit.PizzaGirls.Core.Api;

namespace Hecsit.PizzaGirls.Core.Domain
{
    public class Order : Entity
    {
        private string _number;
        private DateTime _date;
        private OrderStatus _status;
        private decimal _deliveryCost;
        private Customer _customer;
        private decimal _price;
        private readonly List<OrderLine> _orderLines = new List<OrderLine>();

        #region constructor

        public Order(string number, Customer customer, decimal deliveryPrice)
        {
            _deliveryCost = deliveryPrice;
            _number = number;
            _customer = customer;
            _date = DateTime.Now;
            _status = OrderStatus.New;
        }

        public Order(Customer customer)
        {
            _customer = customer;
            _date = DateTime.Now;
            _status = OrderStatus.New;
        }

        #endregion constructor

        #region methods

        public void AddLine(Product product, int quantity)
        {
            if (_status != OrderStatus.New)
            {
                throw new InvalidOperationException("");
            }

            var line = new OrderLine(this, product, quantity);
            _orderLines.Add(line);
        }

       #endregion

        #region properties

        public string Number
        {
            get { return _number; }
            set { _number = value; }
        }

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public OrderStatus Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public decimal DeliveryCost
        {
            get { return _deliveryCost; }
            set { _deliveryCost = value; }
        }

        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public Customer Customer
        {
            get { return _customer; }
            set { _customer = value; }
        }

        public ICollection<OrderLine> OrderLines
        {
            get { return _orderLines; }
        }

        #endregion properties
    }
}
