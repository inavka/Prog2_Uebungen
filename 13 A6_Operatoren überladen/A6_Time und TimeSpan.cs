using System;

namespace _13_A6_Operatoren_überladen
{
    class Program
    {
        class Time
        {
            public int hour { get; private set; }
            public int min { get; private set; }
            
            public Time (int Hour, int Min)
            {
                hour = Hour;
                min = Min;
            }
            public Time(string timeData)
            {
                string[] daten = timeData.Split(':');
                hour = Convert.ToInt32(daten[0]);
                min = Convert.ToInt32(daten[1]);
            }

            public static implicit operator Time(string timeData)
            {
                return new Time(timeData);  
            }
            
            public static Time operator +(Time t, int n)
            {
                Time tNeu = new Time(t.hour, t.min);
                tNeu.min += n;
                if (tNeu.min >= 60)
                {
                    tNeu.hour += 1;
                    tNeu.min -= 60;
                    if (tNeu.hour >= 24)
                        tNeu.hour -= 24;
                }
                return tNeu;    
            }
            public static Time operator +(Time t1, Time t2)
            {
                Time t3 = new Time(t1.hour, t1.min);
                t3.min += t2.min;
                if (t3.min >= 60)
                {
                    t3.hour += 1;
                    t3.min -= 60;
                }
                t3.hour += t2.hour;
                if (t3.hour >= 24)
                    t3.hour -= 24;
                return t3;
            }

            public static bool operator true(Time t)
            {
                if (t.hour < 12)
                    return true;
                return false;
            }
            public static bool operator false(Time t)
            {
                if (t.hour < 12)
                    return false;
                return true;
            }
            public static bool operator ==(Time t1, Time t2)
            {
                if (t1.hour == t2.hour && t1.min == t2.min)
                    return true;
                return false;
            }

            public static bool operator !=(Time t1, Time t2)
            {
                if (t1.hour == t2.hour && t1.min == t2.min)
                    return false;
                return true;
            }
            
            public static TimeSpan operator -(Time t1, Time t2)
            {
                int dif = (t1.hour - t2.hour) * 60 + (t1.min - t2.min);
                return new TimeSpan(dif);
            }
            public  override string ToString()
            {
                return $"{hour}:{min}";
            }
        }
        class TimeSpan
        {
            int timespan;
            public TimeSpan() { }
            public TimeSpan(int timespan) { this.timespan = timespan; }


            public int TotalMins
            {
                get
                {
                    return timespan;
                }
            }

            public override string ToString()
            {
                return $"{timespan/60}:{timespan%60}";
            }
        }
        static void Main(string[] args)
        {
            Time t1 = new Time(9, 45);
            Time t2 = t1 + "1:30" + 15;
            Time t3 = "11:30";
            TimeSpan ts1 = t2 - t1;
            Console.WriteLine(t2);
            Console.WriteLine(ts1.TotalMins);
            Console.WriteLine(ts1);
            if (t2)
                Console.WriteLine("Guten Morgen");
            else
                Console.WriteLine("Guten Tag");
            if (t2 == t3)
                Console.WriteLine("Die Uhrzeiten sind gleich!");
            else
                Console.WriteLine("Die Uhrzeiten stimmen nicht überein");
            // 11:30
            // 105
            // 1:45
            // Guten Morgen
            // Die Uhrzeiten sind gleich!
        }

    }
}
