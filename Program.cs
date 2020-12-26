using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            DailySchedule ds = new DailySchedule() { Day = "Monday" };
            ds.AddDailyItem(new DailyItem(new Time("6:00:00"), new Time("6:15:00"), "Проснуться", false));
            ds.AddDailyItem(new DailyItem(new Time("6:14:00"), new Time("6:40:00"), "Приговить и поесть", false));
            ds.AddDailyItem(new DailyItem(new Time("6:15:00"), new Time("6:40:00"), "Приговить и поесть", false));
            ds.Display();

            ds.RemoveDailyItem("Проснуться");
            ds.Display();

            ds.EditRemoveDailyItem("Приговить и поесть", "Почистить зубы", false);
            ds.Display();

            DailyItem di = ds.FindFreeTime(new Time("2:00:00"), new Time("8:00:00"), new Time("10:00:00"));
            di.Display();

            Console.WriteLine("\n\n\n\n\n             Redo");
            ds.DoRedo().Display();

            DailySchedule ds1 = new DailySchedule() { Day = "Monday" };
            ds.AddDailyItem(new DailyItem(new Time("6:00:00"), new Time("6:15:00"), "Проснуться", false));
            ds1.AddDailyItem(new DailyItem(new Time("6:00:00"), new Time("6:15:00"), "Проснуться", false));
            ds1.AddDailyItem(new DailyItem(new Time("6:15:00"), new Time("6:30:00"), "Приговить", false));
            ds1.AddDailyItem(new DailyItem(new Time("6:15:00"), new Time("6:40:00"), "Поесть", false));
            ds1.AddDailyItem(new DailyItem(new Time("6:40:00"), new Time("6:50:00"), "Почистить зубы", false));
            (ds + ds1).Display();
        }
    }
}
