using Assignment0.Appliances;

internal class Microwave : Appliance
{
    public float _capacity { get; set; }
    public char _roomType { get; set; }

    public const char RoomTypeWorkSite = 'W';
    public const char RoomTypeKitchen = 'K';

    public string getRoomType()
    {
        switch (_roomType)
        {
            case RoomTypeWorkSite:
                return "Work Site";
            case RoomTypeKitchen:
                return "Kitchen";
            default:
                return "Not a valid type of room";
        }
    }

    public Microwave(long itemNumber, string brand, int quantity, double wattage, string color, decimal price, float capacity, char roomType) : base(itemNumber, brand, quantity, wattage, color, price)
    {
        this._capacity = capacity;
        this._roomType = roomType;
    }

    public override string FormatForFile()
    {
        string baseFormat = base.FormatForFile();
        string microwaveFormat = string.Join(';', baseFormat, _capacity, _roomType);

        return microwaveFormat;
    }

    public override string ToString()
    {
        return $"Item Number: {ItemNumber}\n" +
               $"Brand: {Brand}\n" +
               $"Quantity: {Quantity}\n" +
               $"Wattage: {Wattage}\n" +
               $"Color: {Color}\n" +
               $"Price: {Price}\n" +
               $"Capacity: {_capacity}\n" +
               $"Room Type: {getRoomType()}\n";
    }


}
