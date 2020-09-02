using Common.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Sort.Sample
{
    public static class NaturalComparerSample
    {
        public static void SortSample()
        {
            var orgList = new List<string>
            {
                "1abc",
                "1bcd",
                "2abc",
                "10abc",
                "1abc1",
                "1abc2abc",
                "1abc10abc",
                "1bcd1",
                "1bcd10",
            };

            Console.WriteLine("orglist");
            orgList.ForIndexEach((str, ii) => { Console.WriteLine($"{ii}:{str}"); });

            // 複製.
            var sortedList = orgList.ToList();

            // 単純ソート.
            sortedList.Sort();
            Console.WriteLine("\nSimple Sorted");
            sortedList.ForIndexEach((str, ii) => { Console.WriteLine($"{ii}:{str}"); });

            // 自然ソート.
            sortedList.Sort(new NaturalComparer<string>(str => str));
            Console.WriteLine("\nNatural Sorted");
            sortedList.ForIndexEach((str, ii) => { Console.WriteLine($"{ii}:{str}"); });
        }

        private class NcsDat
        {
            public int  No { get; set; }
            public string Text { get; set; }

            public NcsDat(int no, string text)
            {
                this.No = no;
                this.Text = text;
            }
        }
    }
}
