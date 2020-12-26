using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    class Redo
    {
        List<DailyItem> notReadyItems = new List<DailyItem>();

        public void AddNotReadyItems(DailyItem dailyItem)
        {
            notReadyItems.Add(dailyItem);
        }

        public void Display()
        {
            Console.WriteLine("-----------------------------");
            foreach (DailyItem item in notReadyItems)
            {
                item.Display();
            }
        }
    }
}
