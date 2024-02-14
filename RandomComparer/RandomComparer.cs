using System;
using ModernAppliances.Appliances;

namespace ModernAppliances.Randomize
{
    public class RandomComparer
    {
        private Random _random = new Random();

        public List<Appliance> Compare(List<Appliance> unsortedList)
        {
            List<Appliance> sortedList = unsortedList.OrderBy(x => _random.Next()).ToList();
            return sortedList;
        }
    }
}

