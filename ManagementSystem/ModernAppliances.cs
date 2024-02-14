using ModernAppliances.Appliances;
using System;
using System.IO;

namespace ModernAppliances
{
    public abstract class ModernAppliances
    {
        
        public enum Options
        {
            None,
            Checkout = 1,
            Find = 2,
            DisplayType = 3,
            RandomList = 4,
            SaveExit = 5,
        }

        public string currentDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        public const string applianceFileName = "ManagementSystem\\appliances.txt";
        

        public List<Appliance> appliances = new List<Appliance>();
        public ModernAppliances()
        {
            this.appliances = this.ReadAppliances();
        }

        public void DisplayMenu()
        {
            Console.WriteLine("Welcome to Modern Appliances!\n" +
                  "How May We Assist You ?\n" +
                  "1 – Check out appliance\n" +
                  "2 – Find appliances by brand\n" +
                  "3 – Display appliances by type\n" +
                  "4 – Produce random appliance list\n" +
                  "5 – Save & exit");

        }
        public abstract void Checkout();
        public abstract void Find();
        public void DisplayType()
        {
            Console.WriteLine("Appliance Types\n" +
                  "1 – Refrigerators\n" +
                  "2 – Vacuums\n" +
                  "3 – Microwaves\n" +
                  "4 – Dishwashers");

            Console.Write("Enter type of appliance:");

            int applianceTypeNum;
            bool parsedApplianceType = int.TryParse(Console.ReadLine(), out applianceTypeNum);

            if (!parsedApplianceType || applianceTypeNum < 0 || applianceTypeNum > 4)
            {
                Console.WriteLine("Invalid appliance type entered.");
                return;
            }

            switch (applianceTypeNum)
            {
                case 1:
                    {
                        this.DisplayRefrigerators();

                        break;
                    }

                case 2:
                    {
                        this.DisplayVacuums();

                        break;
                    }

                case 3:
                    {
                        this.DisplayMicrowaves();

                        break;
                    }

                case 4:
                    {
                        this.DisplayDishwashers();

                        break;
                    }

                default:
                    {
                        Console.WriteLine("Invalid appliance type entered.");

                        break;
                    }
            }
        }

        public abstract void DisplayRefrigerators();

        public abstract void DisplayVacuums();

        public abstract void DisplayMicrowaves();

        public abstract void DisplayDishwashers();

        public abstract void RandomList();

        public void Save()
        {
            string applianceFile = Path.Combine(currentDirectory, applianceFileName);

            Console.WriteLine("Saving the file...");

            StreamWriter fileStream = File.CreateText(applianceFile);

            foreach (Appliance appliance in appliances)
            {
                fileStream.WriteLine(appliance.FormatForFile());
            }

            fileStream.Close();

            Console.WriteLine("File Saved.");
        }

        private List<Appliance> ReadAppliances()
        {
            string applianceFile = Path.Combine(currentDirectory, applianceFileName);

            List<Appliance> fileAppliances = new List<Appliance>();
            string[] lines = File.ReadAllLines(applianceFile);

            foreach (string line in lines)
            {
                Appliance appliance = this.CreateApplianceFromLine(line);

                if (appliance != null)
                {
                    fileAppliances.Add(appliance);
                }
            }

            return fileAppliances;
        }

        private Appliance CreateApplianceFromLine(string line)
        {
            string[] applianceProperties = line.Split(';');

            char firstDigit = line[0];

            Appliance appliance;

            switch (firstDigit)
            {
                case '1':
                    // Refrigerator

                    return CreateRefrigerator(applianceProperties);
                case '2':
                    // Vacuum
                    appliance = CreateVacuum(applianceProperties);
                    break;
                case '3':
                    // Microwave
                    appliance = CreateMicrowave(applianceProperties);
                    break;
                case '4' or '5':
                    // Dishwasher
                    appliance = CreateDishwasher(applianceProperties);
                    break;
                default:
                    appliance = null;
                    break;
            }

            return appliance;

        }
        private Refrigerator CreateRefrigerator(string[] properties)
        {
            if (properties.Length == 9)
            {
                long itemNumber = long.Parse(properties[0]);
                string brand = properties[1];
                int quantity = int.Parse(properties[2]);
                double wattage = double.Parse(properties[3]);
                string color = properties[4];
                decimal price = decimal.Parse(properties[5]);
                short doors = short.Parse(properties[6]);
                int width = int.Parse(properties[7]);
                int height = int.Parse(properties[8]);

                // Create and return the Refrigerator instance
                return new Refrigerator(itemNumber, brand, quantity, wattage, color, price, doors, width, height);
            }
            else
            {
                Console.WriteLine($"Not a valid input to create an instance of 'Refrigerator' \n{properties}");
                return null;
            }
        }

        private Vacuum CreateVacuum(string[] properties)
        {
            if (properties.Length == 8)
            {
                long itemNumber = long.Parse(properties[0]);
                string brand = properties[1];
                int quantity = int.Parse(properties[2]);
                double wattage = double.Parse(properties[3]);
                string color = properties[4];
                decimal price = decimal.Parse(properties[5]);
                string grade = properties[6];
                short batteryVoltage = short.Parse(properties[7]);

                // Create and return the Vacuum instance
                return new Vacuum(itemNumber, brand, quantity, wattage, color, price, grade, batteryVoltage);

                
            }
                
            else
            {
                Console.WriteLine($"Not a valid input to create an instance of 'Vacuum' \n{properties}");
                return null;
            }
            
        }

        private Microwave CreateMicrowave(string[] properties)
        {
            if (properties.Length == 8)
            {
                long itemNumber = long.Parse(properties[0]);
                string brand = properties[1];
                int quantity = int.Parse(properties[2]);
                double wattage = double.Parse(properties[3]);
                string color = properties[4];
                decimal price = decimal.Parse(properties[5]);
                float capacity = float.Parse(properties[6]);
                char roomType = char.Parse(properties[7]);

                // Create and return the Microwave instance
                return new Microwave(itemNumber, brand, quantity, wattage, color, price, capacity, roomType);
            }

            else
            {
                Console.WriteLine($"Not a valid input to create an instance of 'Microwave' \n{properties}");
                return null;
            }
        }

        private Dishwasher CreateDishwasher(string[] properties)
        {
            if (properties.Length == 8)
            {
                long itemNumber = long.Parse(properties[0]);
                string brand = properties[1];
                int quantity = int.Parse(properties[2]);
                double wattage = double.Parse(properties[3]);
                string color = properties[4];
                decimal price = decimal.Parse(properties[5]);
                string feature = properties[6];
                string soundRating = properties[7];

                // Create and return the Dishwasher instance
                return new Dishwasher(itemNumber, brand, quantity, wattage, color, price, feature, soundRating);
            }
            else
            {
                Console.WriteLine($"Not a valid input to create an instance of 'Microwave' \n{properties}");
                return null;
            }
        }

        public void DisplayAppliancesFromList(List<Appliance> appliances, int max = -1)
        {
            if (max == -1)
            {
                max = appliances.Count;
            }

            if (appliances.Count > 0)
            {
                Console.WriteLine("Found appliances: \n");

                int count = 0;

                while (count < max)
                {
                    foreach (Appliance appliance in appliances.Take(max))
                    {
                        Console.WriteLine($"{appliance}\n");
                        count += 1;
                    }
                }
            }
            else
            {
                Console.WriteLine("No appliances found. \n");
            }            
        }
    }
}