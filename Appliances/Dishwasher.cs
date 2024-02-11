using Assignment0.Appliances;

internal class Dishwasher : Appliance
{
    private string _feature { get; set; }
    private string _soundRating { get; set; }


    public Dishwasher(int itemNumber, string brand, int quantity, double wattage, string color, decimal price, string feature, string soundRating) : base(itemNumber, brand, quantity, wattage, color, price)
    {
        this._feature = feature;
        this._soundRating = soundRating;
    }

    public override string FormatForFile()
    {
        string baseFormat = base.FormatForFile();
        string dishFormat = string.Join(';', baseFormat, _feature, _soundRating);

        return dishFormat;
    }

    public override string ToString()
    {
        return $"Item Number: {ItemNumber}\n" +
               $"Brand: {Brand}\n" +
               $"Quantity: {Quantity}\n" +
               $"Wattage: {Wattage}\n" +
               $"Color: {Color}\n" +
               $"Price: {Price}\n" +
               $"Feature: {_feature}\n" +
               $"Sound Rating: {_soundRating}\n";
    }


}
