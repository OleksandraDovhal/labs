using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3_2
{
    class MyTime
    {
        public int hour, minute, second;
        public MyTime(int h, int m, int s)
        {
            hour = h; minute = m; second = s;
        }
        public override string ToString()
        {
            return string.Format("{0}:{1:00}:{2:00}", hour, minute, second);
        }
        public int TimeSinceMidnight(MyTime t)
        {
            return t.hour * 3600 + t.minute * 60 + t.second;
        }
        public MyTime TimeSinceMidnight(int t)
        {
            int secPerDay = 60 * 60 * 24;
            t = ((t % secPerDay) + secPerDay) % secPerDay;
            int h = t / 3600;
            int m = (t / 60) % 60;
            int s = t % 60;
            return new MyTime(h, m, s);
        }
        public MyTime AddOneMinute(MyTime t)
        {
            return TimeSinceMidnight(TimeSinceMidnight(t) + 60);
        }
        public MyTime AddOneHour(MyTime t)
        {
            return TimeSinceMidnight(TimeSinceMidnight(t) + 3600);
        }
        public MyTime AddOneSecond(MyTime t)
        {
            return TimeSinceMidnight(TimeSinceMidnight(t) + 1);
        }
        public MyTime AddSeconds(MyTime t, int s)
        {
            return TimeSinceMidnight(TimeSinceMidnight(t) + s);
        }
        public int Difference(MyTime mt1, MyTime mt2)
        {
            return TimeSinceMidnight(mt1) - TimeSinceMidnight(mt2);
        }
        public string WhatLesson(MyTime mt)
        {
            MyTime F_les = new MyTime(8, 0, 0);
            if (Difference(mt, F_les) <= 0)
            {
                return "Пари ще не почались";
            }
            int[] breaksLengthsMinutes = { 20, 20, 20, 20, 10, 0 };
            for (int lessNumb = 0; lessNumb < breaksLengthsMinutes.Length; lessNumb++)
            {
                F_les = AddSeconds(F_les, 80 * 60);
                if (Difference(mt, F_les) < 0)
                {
                    return string.Format("Зараз {0}-а(я) пара", lessNumb + 1);
                }
                F_les = AddSeconds(F_les, breaksLengthsMinutes[lessNumb] * 60);
                if (lessNumb == breaksLengthsMinutes.Length - 1)
                {
                    break;
                }
                if (Difference(mt, F_les) <= 0)
                {
                    return string.Format("Зараз перерва мiж {0}-ю та {1}-ю парами", lessNumb + 1, lessNumb + 2);
                }
            }
            return "Пари вже закiнчились";
        }
    }
}
