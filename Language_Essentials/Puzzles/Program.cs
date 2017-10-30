using System;
using System.Collections.Generic;

namespace Puzzles
{
    class Program
    {
        public static int[] randomArr(){
            Random randNum = new Random();
            int[] arr = new int[10];
            for (int i=0;i<arr.Length;i++){
                arr[i] = randNum.Next(5,25);
            }
            return arr;
        }
        public static void coinFlip(){
            System.Console.WriteLine("Flipping your coin!");
            Random randNum = new Random();
            int num = randNum.Next(1,3);
            if(num == 1){
                System.Console.WriteLine("Heads");
            } else {
                System.Console.WriteLine("Tails");
            }
        }
        public static void multiCoinFlips(int times){
            Random randNum = new Random();
            double heads = 0;
            double tails = 0;
            for (int i=0; i<=times;i++){
                int num = randNum.Next(1,3);
                if(num == 1){
                    heads++;
                } else {
                    tails++;
                }
            }
            System.Console.WriteLine(heads/tails);
        }
        public static void shuffleNames(string[] arr){
            Random rand = new Random();
            for(int i=0; i<arr.Length;i++){
                int index = rand.Next(arr.Length);
                string temp = arr[i];
                arr[i] = arr[index];
                arr[index] = temp;
            }
            foreach (string element in arr){
                System.Console.WriteLine(element);
            }
        }
        public static List<string> removeLongNames(string[] arr){
            List<string> newList = new List<string>();
            Random rand = new Random();
            for(int i=0; i<arr.Length;i++){
                if(arr[i].Length < 5){
                    newList.Add(arr[i]);
                }
            }
            return newList;
        }

        static void Main(string[] args)
        { }
    }
}
