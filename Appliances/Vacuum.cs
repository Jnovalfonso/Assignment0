namespace ModernAppliances.Appliances
{
    internal class Vacuum : Appliance
    {
        private string _grade { get; set; }
        private double _batteryVoltage { get; set; }

        public string grade { get { return _grade; } }
        public double voltage { get { return _batteryVoltage; } }


        public Vacuum(long itemNumber, string brand, int quantity, double wattage, string color, decimal price, string grade, short batteryVoltage) : base(itemNumber, brand, quantity, wattage, color, price)
        {
            this._grade = grade;
            this._batteryVoltage = batteryVoltage;
        }

        public override string FormatForFile()
        {
            string baseFormat = base.FormatForFile();
            string vacuumFormat = string.Join(';', baseFormat, _grade, _batteryVoltage);

            return vacuumFormat;
        }

        public override string ToString()
        {
            return $"Item Number: {ItemNumber}\n" +
                   $"Brand: {Brand}\n" +
                   $"Quantity: {Quantity}\n" +
                   $"Wattage: {Wattage}\n" +
                   $"Color: {Color}\n" +
                   $"Price: {Price}\n" +
                   $"Grade: {_grade}\n" +
                   $"Battery Voltage: {_batteryVoltage}\n";
        }


    }
}