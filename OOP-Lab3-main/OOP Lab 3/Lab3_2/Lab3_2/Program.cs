using System;

namespace Lab3_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

            //Main time
            Console.Write("Введiть через пробiл: години, хвилини та секунди(в форматi 24 години): ");
            string[] temp = Console.ReadLine().Split(' ');
            int h = Convert.ToInt32(temp[0]);
            int m = Convert.ToInt32(temp[1]);
            int s = Convert.ToInt32(temp[2]);
            MyTime t = new MyTime(h, m, s);

            Console.WriteLine("{0} - час  (в секундах - {1})", t, t.TimeSinceMidnight(t));
            Console.WriteLine("{0} - додає до часу одну секунду", t.AddOneSecond(t));
            Console.WriteLine("{0} - додає до часу одну хвилину", t.AddOneMinute(t));
            Console.WriteLine("{0} - додає до часу одну годину", t.AddOneHour(t));
            Console.WriteLine("{0} - додає до часу рандомну кiлькiсть секунд", t.AddSeconds(t, rnd.Next(60)));
            Console.WriteLine();

            //First moment of time
            Console.Write("Введiть через пробiл перший момент: години, хвилини та секунди(в форматi 24 години), для знаходження рiзницi двух моментiв: ");
            string[] temp1 = Console.ReadLine().Split(' ');
            int h1 = Convert.ToInt32(temp1[0]);
            int m1 = Convert.ToInt32(temp1[1]);
            int s1 = Convert.ToInt32(temp1[2]);
            MyTime mt1 = new MyTime(h1, m1, s1);

            //Second moment of time.
            Console.Write("Введiть через пробiл другий момент: години, хвилини та секунди(в форматi 24 години), для знаходження рiзницi двух моментiв: ");
            string[] temp2 = Console.ReadLine().Split(' ');
            int h2 = Convert.ToInt32(temp2[0]);
            int m2 = Convert.ToInt32(temp2[1]);
            int s2 = Convert.ToInt32(temp2[2]);
            MyTime mt2 = new MyTime(h2, m2, s2);

            Console.WriteLine("Перший момент часу {0}; другий момент часу {1} ({2} - рiзниця мiж цими моментами)", mt1, mt2, t.TimeSinceMidnight(t.Difference(mt1, mt2)));
            Console.WriteLine();
            Console.Write("Введiть через пробiл: години, хвилини та секунди(в форматi 24 години), щоб вbзнати розклад дзвiнкiв: ");

            string[] temp3 = Console.ReadLine().Split(' ');
            int hourlesson = Convert.ToInt32(temp3[0]);
            int minuteslesson = Convert.ToInt32(temp3[1]);
            int secondslesson = Convert.ToInt32(temp3[2]);
            MyTime lesson = new MyTime(hourlesson, minuteslesson, secondslesson);

            Console.WriteLine("{0} - {1}", lesson, lesson.WhatLesson(lesson));

            Console.ReadKey();
        }
    }
}
