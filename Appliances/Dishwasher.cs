using Assignment0.Appliances;

internal class Dishwasher : Appliance
{
    private string _feature { get; set; }
    private string _soundRating { get; set; }
    public const string Quietest = "Qt"; 
    public const string Quieter = "Qr";
    public const string Quiet = "Qu";
    public const string Moderate = "M";

    public string SoundRatingDisplay
    {
        get
        {
            switch (_soundRating)
            {
                case Quietest:
                    return "Quietest";
                case Quieter:
                    return "Quieter";
                case Quiet:
                    return "Quiet";
                case Moderate:
                    return "Moderate";
                default:
                    return "Invalid Sound Rating Input";
            }
        }
    }
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
               $"Sound Rating: {SoundRatingDisplay}\n";
    }


}
