namespace ModernAppliances.Appliances
{
    internal class Refrigerator : Appliance

    {

        private short _doors { get; set; }
        private int _width { get; set; }
        private int _height { get; set; }

        public short doors { get { return _doors; } }

        public Refrigerator(long itemNumber, string brand, int quantity, double wattage, string color, decimal price, short doors, int width, int height)
            : base(itemNumber, brand, quantity, wattage, color, price)
        {
            this._doors = doors;
            this._width = width;
            this._height = height;
        }

        public override string FormatForFile()
        {
            string baseFormat = base.FormatForFile();
            string refrigeratorFormat = string.Join(';', baseFormat, _doors, _width, _height);

            return refrigeratorFormat;
        }

        public override string ToString()

        {

            return $"Item Number: {ItemNumber}\n" +
                   $"Brand: {Brand}\n" +
                   $"Quantity: {Quantity}\n" +
                   $"Wattage: {Wattage}\n" +
                   $"Color: {Color}\n" +
                   $"Price: {Price}\n" +
                   $"Doors: {_doors}\n" +
                   $"Width: {_width}\n" +
                   $"Height: {_height}\n";

        }


    }
}