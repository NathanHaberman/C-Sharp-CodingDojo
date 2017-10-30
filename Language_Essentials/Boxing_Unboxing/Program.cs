using System;
using System.Collections.Generic;

namespace Boxing_Unboxing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<object> myList = new List<object>();
            myList.Add(7);
            myList.Add(28);
            myList.Add(-1);
            myList.Add(true);
            myList.Add("chair");

            int sum = 0;
            foreach(object element in myList){
                System.Console.WriteLine(element);
                if (element is int){
                    sum += Convert.ToInt32(element);
                }
            }
            System.Console.WriteLine(sum);
        }
    }
}
