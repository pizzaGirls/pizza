namespace Hecsit.PizzaGirls.Core.Domain
{
    public class Product : Entity
    {
        private string _name;
        private decimal _unitPrice;
        private string _description;

        #region constructor

        public Product(string name, decimal price, string description)
        {
            _name = name;
            _unitPrice = price;
            _description = description;
        }
        #endregion

        #region prorerties

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public decimal UnitPrice
        {
            get { return _unitPrice; }
            set { _unitPrice = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        #endregion

    }
}
