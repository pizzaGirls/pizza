namespace Hecsit.PizzaGirls.Core.Domain
{
    public class OrderLine : Entity
    {
        private int _quantity;
        private decimal _cost;
        private bool _ready;
        private Order _order;
        private Product _product;

        #region constructor

        public OrderLine(Order order, Product product, int quantity)
        {
            _order = order;
            _product = product;
            _quantity = quantity;
            _cost = product.UnitPrice;
            _ready = false;
        }

        #endregion constructor

        #region properties

        public int Quantity 
        {
            get { return _quantity; }
            set { _quantity = value; }
        }
        
        public decimal Cost 
        {
            get { return _cost; }
        }

        public bool Ready
        {
            get { return _ready; }
            set { _ready = value; }
        }

        public Order Order
        {
            get { return _order; }
        }

        public Product Product
        {
            get { return _product; }
        }

        #endregion properties
    }
}
