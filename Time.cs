using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    class Time
    {
        private int hours;
        private int minutes;
        private int seconds;

        public Time(string time)
        {
            string[] parts = time.Split(':');
            if(!Int32.TryParse(parts[0], out int hour))
            {
                Console.WriteLine("\n Вы ввели неверный формат времени!!!");
            }
            else if(!Int32.TryParse(parts[1], out int minute))
            {
                Console.WriteLine("\n Вы ввели неверный формат времени!!!");
            }
            else if(!Int32.TryParse(parts[2], out int second))
            {
                Console.WriteLine("\n Вы ввели неверный формат времени!!!");
            }
            else if(parts.Length > 3)
            {
                Console.WriteLine("\n Вы ввели неверный формат времени!!!");
            }
            else
            {
                if(hour > 23 || hour < 0)
                {
                    Console.WriteLine("\n Вы ввели неверный формат времени!!!");
                }
                else if(minute >= 60 || minute < 0)
                {
                    Console.WriteLine("\n Вы ввели неверный формат времени!!!");
                }
                else if(second >= 60 || second < 0)
                {
                    Console.WriteLine("\n Вы ввели неверный формат времени!!!");
                }
                else
                {
                    hours = hour;
                    minutes = minute;
                    seconds = second;
                }

            }
        }

        public Time(int time)
        {
            if(time > 86399 || time < 0)
            {
                Console.WriteLine("\n Вы ввели неверный формат времени!!!");
            }
            else
            {
                hours = time / 3600;
                time = time - (hours * 3600);
                minutes = time / 60;
                time -= (minutes * 60);
                seconds = time;
            }
        }

        public static int operator-(Time t1, Time t2)
        {
            return t1.TranslateToSec() - t2.TranslateToSec();
        }

        public static bool operator>(Time t1, Time t2)
        {
            if(t1-t2 > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static bool operator <(Time t1, Time t2)
        {
            if (t2 - t1 > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public int TranslateToSec()
        {
            return (this.hours * 3600) + (this.minutes * 60) + this.seconds;
        }

        public override string ToString()
        {
            return $"{hours}:{minutes}:{seconds}";
        }
    }
}
