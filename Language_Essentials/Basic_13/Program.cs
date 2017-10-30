using System;
using System.Collections.Generic;

namespace Basic_13
{
    class Program
    {
        public static void printAll(){
            for (int i=1; i<=255; i++){
                System.Console.WriteLine(i);
            }
        }
        public static void printOdds(){
            for (int i=1; i<=255; i++){
                if(i%2 != 0){
                    System.Console.WriteLine(i);;
                }
            }
        }
        public static void printSum(){
            int sum = 0;
            for (int i=1; i<=255; i++){
                sum += i;
                System.Console.WriteLine("The number is {0} and the sum so far is {1}",i,sum);
            }
        }
        public static void iterateThru(int[] arr){
            foreach(int element in arr){
                System.Console.WriteLine(element);
            }
        }
        public static void findMax(int[] arr){
            int max = arr[0];
            for(int i=1;i<arr.Length;i++){
                if(arr[i]>max){
                    max = arr[i];
                }
            }
            System.Console.WriteLine(max);
        }
        public static void getAvg(int[] arr){
            int sum = 0;
            for(int i=1;i<arr.Length;i++){
                sum += arr[i];
            }
            System.Console.WriteLine(sum/arr.Length);
        }
        public static int[] arrayOfOdds(){
            List<int> myList = new List<int>();
            for(int i=1;i<=255;i++){
                if(i%2==1){
                    myList.Add(i);
                }
            }
            int[] myArr = myList.ToArray();
            return myArr;
        }
        public static void greaterThanY(int[] arr, int y){
            int count = 0;
            for(int i=0;i<arr.Length;i++){
                if (arr[i] > y){
                    count++;
                }
            }
            System.Console.WriteLine("There are {0} numbers greater than {1}",count,y);
        }
        public static void squareArr(int[] arr){
            for(int i=0;i<arr.Length;i++){
                arr[i] *= arr[i];
                System.Console.WriteLine(arr[i]);
            }
        }
        public static void removeNegatives(int[] arr){
            for(int i=0;i<arr.Length;i++){
                if(arr[i]<0){
                    arr[i] = 0;
                }
                System.Console.WriteLine(arr[i]);
            }
        }
        public static void minMaxAvg(int[] arr){
            int min=arr[0];
            int max=arr[0];
            int sum=arr[0];
            for(int i=1;i<arr.Length;i++){
                if(arr[i]<min){
                    min = arr[i];
                }
                if(arr[i]>max){
                    max = arr[i];
                }
                sum += arr[i];
            }
            System.Console.WriteLine("Max: {0}, Min: {1}, Avg: {2}",max,min,sum/arr.Length);
        }
        public static void shiftArr(int[] arr){
            for(int i=0;i<arr.Length;i++){
                if(arr[i]<0){
                    arr[i] = 0;
                }
                System.Console.WriteLine(arr[i]);
            }
        }
        public static List<object> numToStr(int[] arr){
            List<object> newList = new List<object>();
            for(int i=0;i<arr.Length;i++){
                if (arr[i]<0){
                    newList.Add("String");
                } else {
                    newList.Add(arr[i]);
                }
            }
            return newList;
        }
        static void Main(string[] args)
        {
            int[] newArr = {1,-2,3,-4,5,-6,7,-8,100};
            List<object> newList = numToStr(newArr);
            foreach(object element in newList){
                System.Console.WriteLine(element);
            }
        }
    }
}
