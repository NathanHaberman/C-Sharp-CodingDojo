using System;
using System.Collections.Generic;

namespace Collections_Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numberArr = {1,2,3,4,5,6,7,8,9};
            string[] stringArr = {"Tim","Martin","Nikki","Sara"};
            bool[] booleanArr = {true,false,true,false,true,false,true,false,true,false};

            // int[,] multiTable = new int[10,10];
            // for (int i=1; i<=10; i++){
            //     for (int j=1; j<=10; j++){
            //         multiTable[i-1,j-1] = i*j;
            //     }
            // }
            // foreach (int current in multiTable){
            //     System.Console.WriteLine(current);
            // }



            List<string> flavors = new List<string>();
            flavors.Add("Chocolate");
            flavors.Add("Strawberry");
            flavors.Add("Cookie Dough");
            flavors.Add("Cookies and Cream");
            flavors.Add("Vanilla");

            // System.Console.WriteLine("The flavor list has {0} flavor(s) in it", flavors.Count);
            // System.Console.WriteLine("The third flavor is {0}", flavors[3]);
            // flavors.RemoveAt(3);
            // System.Console.WriteLine("The flavor list now has {0} flavor(s) in it", flavors.Count);


            // Random randNum = new Random();
            // Dictionary<string,string> stringDict = new Dictionary<string,string>();

            // foreach(string name in stringArr){
            //     stringDict.Add(name, flavors[randNum.Next(0,4)]);
            // }
            // foreach(KeyValuePair<string,string> entry in stringDict){
            //     System.Console.WriteLine(entry.Key + " likes " + entry.Value);
            // }
        }
    }
}
