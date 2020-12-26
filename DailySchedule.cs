using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    struct DailyItem
    {
        public Time StartTime { get; set; }
        public Time EndTime { get; set; }
        public string Info { get; set; }
        public bool Readyness { get; set; }


        public DailyItem(Time startTime, Time endTime, string info, bool readyness)
        {
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.Info = info;
            this.Readyness = readyness;
        }

        public void SetInfo(string info)
        {
            this.Info = info;
        }


        public void SetReadyness(bool readyness)
        {
            this.Readyness = readyness;
        }

        public void Display()
        {
            Console.WriteLine("=============================");
            Console.WriteLine($" Начало: {StartTime, 2}");
            Console.WriteLine($" Конець: {EndTime, 2}");
            Console.WriteLine($" Информация: {Info}");
            Console.WriteLine($" Сделано: {Readyness}");
        }
    }
    
    class DailySchedule
    {
        public List<DailyItem> dailyItems = new List<DailyItem>();
        public string Day { get; set; }

        public void AddDailyItem(DailyItem dailyItem)
        {
            bool exit = true;
            foreach (DailyItem daily in dailyItems)
            {
                if((dailyItem.StartTime > daily.StartTime && dailyItem.StartTime < daily.EndTime) || (dailyItem.EndTime > daily.StartTime && dailyItem.EndTime < daily.EndTime))
                {
                    exit = false;
                    break;
                }
            }
            if(exit)
            {
                dailyItems.Add(dailyItem);
            }
            else
            {
                Console.WriteLine("Добавить нельзя");
            }
        }

        public void RemoveDailyItem(string info)
        {
            bool exit = false;
            foreach (DailyItem item in dailyItems)
            {
                if(item.Info == info)
                {
                    dailyItems.Remove(item);
                    Console.WriteLine("\n Успешно удален");
                    exit = true;
                    break;
                }
            }
            if(!exit)
                Console.WriteLine("\n Такого задания нету");
        }

        public void EditRemoveDailyItem(string info, string infoNew, bool readyness)
        {
            bool exit = false;
            DailyItem di;
            foreach (DailyItem item in dailyItems)
            {
                if (item.Info == info)
                {
                    di = new DailyItem(item.StartTime, item.EndTime, infoNew, readyness);
                    dailyItems.Remove(item);
                    dailyItems.Add(di);
                    Console.WriteLine("\n Успешно изменено");
                    exit = true;
                    break;
                }
            }
            if (!exit)
                Console.WriteLine("\n Такого задания нету");
        }

        public DailyItem FindFreeTime(Time needTime, Time startTime, Time endTime)
        {
            int timeTheNeed = needTime.TranslateToSec();
            List<Time> timeStart = new List<Time>();
            List<Time> timeEnd = new List<Time>();
            foreach (DailyItem daily in dailyItems)
            {
                if(daily.StartTime > startTime && daily.StartTime < endTime)
                {
                    timeStart.Add(daily.StartTime);
                }
                if(daily.EndTime > startTime && daily.EndTime < endTime)
                {
                    timeStart.Add(daily.EndTime);
                }
            }

            if(timeStart.Count == 0 && timeEnd.Count == 0 && timeTheNeed <= endTime - startTime)
            {
                DailyItem di = new DailyItem(new Time(startTime.TranslateToSec()), new Time(startTime.TranslateToSec() + timeTheNeed), "", false);
                return di;
            }
            foreach(Time time1 in timeEnd)
            {
                foreach(Time time2 in timeStart)
                {
                    if(time2 - startTime >= timeTheNeed)
                    {
                        DailyItem di = new DailyItem(new Time(startTime.TranslateToSec()), new Time(startTime.TranslateToSec() + timeTheNeed), "", false);
                        return di;
                    }
                    if(endTime - time1 >= timeTheNeed)
                    {
                        DailyItem di = new DailyItem(new Time(time1.TranslateToSec()), new Time(time1.TranslateToSec() + timeTheNeed), "", false);
                        return di;
                    }
                    if((time2 - time1) >= timeTheNeed)
                    {
                        DailyItem di = new DailyItem(new Time(time1.TranslateToSec()), new Time(time1.TranslateToSec() + timeTheNeed), "", false);
                        return di;
                    }
                }
            }
            DailyItem di1 = new DailyItem(new Time(0), new Time(0), "Мы не можем вернуть null, как могли бы в С++", false);
            return di1;
        }

        public Redo DoRedo()
        {
            Redo redo = new Redo();
            foreach (DailyItem item in dailyItems)
            {
                if (!(item.Readyness))
                {
                    redo.AddNotReadyItems(item);
                }
            }
            return redo;
        }

        public void Display()
        {
            Console.WriteLine($"          {Day}");
            Console.WriteLine("-----------------------------");
            foreach (DailyItem item in dailyItems)
            {
                item.Display();
            }
        }

        public static DailySchedule operator+(DailySchedule d1, DailySchedule d2)
        {
            DailySchedule d3 = new DailySchedule() { Day = d1.Day + " + " + d2.Day };
            int currentTime = 0;
            foreach (DailyItem item in d1.dailyItems)
            {
                d3.dailyItems.Add(new DailyItem(new Time(currentTime), new Time((item.EndTime - item.StartTime)+currentTime), item.Info, item.Readyness));
                currentTime += item.EndTime - item.StartTime;
            }
            foreach(DailyItem item1 in d2.dailyItems)
            {
                foreach(DailyItem item2 in d3.dailyItems)
                {
                    if(item2.Info == item1.Info)
                    {
                        d3.dailyItems.Remove(item2);
                        break;
                    }
                }
            }
            foreach (DailyItem item in d2.dailyItems)
            {
                d3.dailyItems.Add(new DailyItem(new Time(currentTime), new Time((item.EndTime - item.StartTime)+currentTime), item.Info, item.Readyness));
                currentTime += item.EndTime - item.StartTime;
            }
            return d3;
        }
    }
}
