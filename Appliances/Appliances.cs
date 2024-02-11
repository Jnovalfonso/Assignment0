namespace Assignment0.Appliances
{

    public abstract class Appliance
    {

        public enum ApplianceTypes
        {
            Unknown,
            Refrigerator = 1,
            Vacuum = 2,
            Microwave = 3,
            Dishwasher = 4
        }

        private long _itemNumber;
        private string _brand;
        private int _quantity;
        private double _wattage;
        private string _color;
        private decimal _price;

        public long ItemNumber
        {
            get { return _itemNumber; }
        }

        public string Brand
        {
            get { return _brand; }
        }

        public int Quantity
        {
            get { return _quantity; }
        }

        public double Wattage
        {
            get { return _wattage; }
        }

        public string Color
        {
            get { return _color; }
        }

        public decimal Price
        {
            get { return _price; }
        }

        public ApplianceTypes Type
        {
            get
            {
                return DetermineAppliance(_itemNumber);
            }
        }


        public bool IsAvailable
        {
            get
            {
                bool isAvailable = _quantity > 0 ? true : false;
                return isAvailable;
            }
        }


        public Appliance(long itemNumber, string brand, int quantity, double wattage, string color, decimal price)
        {
            _itemNumber = itemNumber;
            _brand = brand;
            _quantity = quantity;
            _wattage = wattage;
            _color = color;
            _price = price;
        }

        public void Checkout()
        {
            if (IsAvailable)
            {
                _quantity -= 1;
            }
            else
            {
                Console.WriteLine("No product availability!");
            }
        }

        public virtual string FormatForFile()
        {
            return string.Join(';', _itemNumber, _brand, _quantity, _wattage, _color, _price);
        }


        public ApplianceTypes DetermineAppliance(long itemNumber)
        {
            char firstDigitChar = itemNumber.ToString()[0];
            ushort firstDigit = Convert.ToUInt16(firstDigitChar);

            if (firstDigit == 1)
            {
                return ApplianceTypes.Refrigerator;
            }
            else if (firstDigit == 2)
            {
                return ApplianceTypes.Vacuum;
            }
            else if (firstDigit == 3)
            {
                return ApplianceTypes.Microwave;
            }
            else if (firstDigit == 4 || firstDigit == 5)
            {
                return ApplianceTypes.Dishwasher;
            }
            else
            {
                Console.WriteLine("Not a valid type of Appliance");
                return ApplianceTypes.Unknown;
            }
        }
    }
}