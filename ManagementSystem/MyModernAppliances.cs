using System;
using System.Globalization;
using ModernAppliances.Appliances;
using ModernAppliances.Randomize;

namespace ModernAppliances
{
    internal class MyModernAppliances : ModernAppliances
    {
        // CHECKOUT
        public override void Checkout()
        {
            Console.WriteLine("Enter the item number of an appliance");
            long itemNumber;
            string input = Console.ReadLine();

            if (long.TryParse(input, out itemNumber))
            {
                Console.WriteLine($"Results for Item #{itemNumber}");
                Appliance foundAppliance = null;
                foreach (Appliance appliance in appliances)
                {
                    if (itemNumber == appliance.ItemNumber)
                    {
                        foundAppliance = appliance;
                        break;
                    }
                }

                if (foundAppliance != null)
                {
                    Console.WriteLine($"Checkout for appliance: {foundAppliance.ItemNumber} - {foundAppliance.Brand}");

                    if (foundAppliance.IsAvailable)
                    {
                        foundAppliance.Checkout();
                        Console.WriteLine("The Appliance has been checked out!");
                        Console.WriteLine($"Appliance Quantity: {foundAppliance.Quantity}");
                    }

                }

                else
                {
                    Console.WriteLine($"The number: {itemNumber} is not a valid item number.");
                }

            }
            else
            {
                // The input couldn't be parsed as a long.
                Console.WriteLine("Invalid input. Please enter a valid long value.");
            }

            Console.WriteLine("\n");
        }

        public override void Find()
        {
            Console.WriteLine("Enter the name of the brand that you want to search for: ");

            // Converts user input to Title Case:
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

            string brandName = textInfo.ToTitleCase(Console.ReadLine());
            Console.WriteLine("\n");

            List<Appliance> brandAppliances = new List<Appliance>();

            foreach (Appliance appliance in appliances)
            {
                if (appliance.Brand == brandName)
                {
                    brandAppliances.Add(appliance);
                }
            }

            if (brandAppliances.Count > 0)
            {
                // Counts loop iterations
                int totalAppliances = 1;
                foreach (Appliance brandAppliance in brandAppliances)
                {
                    Console.WriteLine($"{totalAppliances}. {brandAppliance.ItemNumber}");
                    Console.WriteLine($"{brandAppliance}\n");
                    totalAppliances++;
                }
            }

            else { Console.WriteLine($"There are no appliances with the brand name: {brandName}"); }

            Console.WriteLine("\n");
        }

        // RANDOM LIST 

        public override void RandomList()
        {
            Console.WriteLine($"Appliance Types: \n0 - Any \n1 - Refrigerators \n2 - Vacuums \n3 - Microwaves \n4 - Dishwashers");
            Console.WriteLine("Enter type of appliance:");
            string applianceType = Console.ReadLine();
            Console.WriteLine("Enter number of appliances");
            int applianceNum = int.Parse( Console.ReadLine() );

            List<Appliance> foundappliances = new List<Appliance>();
            switch ( applianceType )
            {
                case "0":
                    foundappliances = appliances;
                    break;
                case "1":
                    foreach (Refrigerator appliance in appliances)
                    {
                        foundappliances.Add(appliance);
                    } 
                    break;
                case "2":
                    foreach (Vacuum appliance in appliances)
                    {
                        foundappliances.Add(appliance);
                    }
                    break;
                case "3":
                    foreach (Microwave appliance in appliances)
                    {
                        foundappliances.Add(appliance);
                    }
                    break;
                case "4":
                    foreach (Dishwasher appliance in appliances)
                    {
                        foundappliances.Add(appliance);
                    }
                    break;                
            }

            RandomComparer randomComparer = new RandomComparer();

            List<Appliance> randomizedList = randomComparer.Compare(foundappliances);

            DisplayAppliancesFromList(randomizedList, applianceNum);
        }

        // DISPLAYS 

        public override void DisplayRefrigerators()
        {
            Console.WriteLine("Possible options: \n0 - Any \n2 - Double Doors \n3 - Three Doors \n4 - Fours Doors");

            Console.Write("Enter number of doors: ");
            
            string input = Console.ReadLine();
            int doors = int.Parse(input);
            List<Appliance> found = new List<Appliance>();

            if (doors > 0)
            {
                foreach (Appliance appliance in appliances)
                {
                    if (appliance is Refrigerator)
                    {
                        Refrigerator refrigerator = (Refrigerator)appliance;

                        if (refrigerator.doors == doors)
                        {
                            found.Add(refrigerator);
                        }
                    }
                }
            }
            else
            {
                foreach (Appliance appliance in appliances)
                {
                    if (appliance is Refrigerator)
                    {
                        Refrigerator allrefrigerator = (Refrigerator)appliance;
                        found.Add(allrefrigerator);
                    }
                }
            }

            DisplayAppliancesFromList(found);
        }

        public override void DisplayVacuums()
        {
            
            Console.WriteLine("Possible options: \n0 - Any\n1 - Residential\n2 - commercial");  
            Console.Write("Enter grade: ");
            string grade = "";
            string inputGrade = Console.ReadLine();

            switch (inputGrade)
            {
                case "0":
                    grade = null;
                    break;

                case "1":
                    grade = "Residential";
                    break;

                case "2":
                    grade = "Commercial";
                    break;

                default:
                    Console.WriteLine("Invalid input for grade");
                    break;
            }

            Console.WriteLine("Possible options: \n0 - Any\n1 - 18 Volt\n2 - 24 Volt");
            
            Console.Write("Enter voltage: ");                    
            string inputVoltage = Console.ReadLine();
            short voltage = 0;

            switch (inputVoltage)
            {
                case "0":
                    voltage = 0;
                    break;

                case "1":
                    voltage = 18;
                    break;

                case "2":
                    voltage = 24;
                    break;

                default:
                    Console.WriteLine("Invalid option for voltage");
                    break;
            }

            List<Appliance> found = new List<Appliance>();

            foreach (Appliance appliance in appliances)
            {
                if (appliance is Vacuum)
                {
                    Vacuum vacuum = (Vacuum)appliance;

                    bool gradeCondition = grade == null || vacuum.grade == grade;
                    bool voltageCondition = voltage == 0 || vacuum.voltage == voltage;

                    if (gradeCondition && voltageCondition)
                    {
                        found.Add(vacuum);
                    }
                }
            }

            DisplayAppliancesFromList(found);
        }

        public override void DisplayMicrowaves()
        {            
            Console.WriteLine("Possible options: \n0 - Any \n1 - Kitchen \n2 - Work site");            
            Console.Write("Enter room type: ");
            string userinput = Console.ReadLine();
            char room;

            switch (userinput)
            {
                case "0":
                    room = 'A';
                    break;

                case "1":
                    room = 'K';
                    break;

                case "2":
                    room = 'W';
                    break;

                default:
                    Console.WriteLine("Invalid option: ");
                    DisplayMicrowaves();
                    return;
            }

            List<Appliance> found = new List<Appliance>();

            foreach (Appliance appliance in appliances)
            {
                if (appliance is Microwave)
                {
                    Microwave microwave = (Microwave)appliance;

                    if (room == 'A' || microwave.room == room)
                    {
                        found.Add(microwave);
                    }
                }
            }

            DisplayAppliancesFromList(found);
        }

        public override void DisplayDishwashers()
        {            
            Console.WriteLine("Possible options: \n0 - Any\n1 - Quietest\n2 - Quieter\n3 - Quiet\n4 - Moderate");           
           
            Console.WriteLine("Enter sound rating:");                    
            string input = Console.ReadLine();
            string soundRating = "Any";

            switch (input)
            {
                case "0":
                    soundRating = "Any";
                    break;

                case "1":
                    soundRating = "Qt";
                    break;

                case "2":
                    soundRating = "Qr";
                    break;

                case "3":
                    soundRating = "Qu";
                    break;

                case "4":
                    soundRating = "M";
                    break;

                default:
                    Console.WriteLine("Invalid Option.");
                    break;
            }
           
            List<Appliance> found = new List<Appliance>();
            foreach (Appliance appliance in appliances)
            {
                if (appliance is Dishwasher)
                {
                    Dishwasher dishwasher = (Dishwasher)appliance;

                    if (soundRating == "Any" || dishwasher.soundRating == soundRating)
                    {
                        found.Add(dishwasher);
                    }                    
                }
            }
            DisplayAppliancesFromList(found);
        }
    }
}
