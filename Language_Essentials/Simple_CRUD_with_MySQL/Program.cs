using System;
using DbConnection;
using System.Collections.Generic;

namespace Simple_CRUD_with_MySQL
{
    class Program
    {
        static void Read(){
            var allUsers = DbConnector.Query("select id ,FirstName, LastName from Users");
            System.Console.WriteLine("All Users in DB:");
            System.Console.WriteLine("----------------");
            for (int i=0; i<allUsers.Count; i++){
                System.Console.WriteLine($"{i+1}.) {allUsers[i]["FirstName"]} {allUsers[i]["LastName"]} (id:{allUsers[i]["id"]})");
            }
            System.Console.WriteLine();
        }
        static void Create(){
            System.Console.WriteLine("Enter First Name");
            string theFirstName = Console.ReadLine();
            System.Console.WriteLine("Enter Last Name");
            string theLastName = Console.ReadLine();
            System.Console.WriteLine("Enter Favorite Number");
            string FavoriteNumberString = Console.ReadLine();
            int theFavoriteNumber = Int32.Parse(FavoriteNumberString);
            System.Console.WriteLine("Dummy1");
            string theDummy1 = Console.ReadLine();
            System.Console.WriteLine("Dummy2");
            string theDummy2 = Console.ReadLine();
            System.Console.WriteLine("Dummy3");
            string theDummy3 = Console.ReadLine();
            System.Console.WriteLine();

            DbConnector.Execute($"insert into Users (FirstName, LastName, FavoriteNumber, Dummy1, Dummy2, Dummy3) values ('{theFirstName}', '{theLastName}', {theFavoriteNumber}, '{theDummy1}', '{theDummy2}', '{theDummy3}')");
            Read();
        }
        static void Update(int id){
            System.Console.WriteLine("Enter First Name");
            string theFirstName = Console.ReadLine();
            System.Console.WriteLine("Enter Last Name");
            string theLastName = Console.ReadLine();
            System.Console.WriteLine("Enter Favorite Number");
            string FavoriteNumberString = Console.ReadLine();
            int theFavoriteNumber = Int32.Parse(FavoriteNumberString);
            System.Console.WriteLine("Dummy1");
            string theDummy1 = Console.ReadLine();
            System.Console.WriteLine("Dummy2");
            string theDummy2 = Console.ReadLine();
            System.Console.WriteLine("Dummy3");
            string theDummy3 = Console.ReadLine();
            System.Console.WriteLine();

            DbConnector.Execute($"update Users set FirstName='{theFirstName}', LastName='{theLastName}', FavoriteNumber={theFavoriteNumber}, Dummy1='{theDummy1}', Dummy2='{theDummy2}', Dummy3='{theDummy3}' where id = {id} ");
            Read();
        }
        static void Delete(int id){
            DbConnector.Execute($"delete from Users where id = {id}");
            Read();
        }
        static void Main(string[] args)
        {
            Read();
            System.Console.WriteLine("What do you want to do? create/update/delete/stop");
            string next = Console.ReadLine();
            while(next == "create"){
                Create();
                System.Console.WriteLine("What do you want to do? create/update/delete/stop");
                next = Console.ReadLine();
                System.Console.WriteLine();
            }
            while (next == "update"){
                System.Console.WriteLine("What user do you want to delete? (Enter id number)");
                string id = Console.ReadLine();
                int intId = Int32.Parse(id);
                Update(intId);
                System.Console.WriteLine("What do you want to do? create/update/delete/stop");
                next = Console.ReadLine();
                System.Console.WriteLine();
            }
            while (next == "delete"){
                System.Console.WriteLine("What user do you want to delete? (Enter id number)");
                string id = Console.ReadLine();
                int intId = Int32.Parse(id);
                Delete(intId);
                System.Console.WriteLine("What do you want to do? create/update/delete/stop");
                next = Console.ReadLine();
                System.Console.WriteLine();
            }
        }
    }
}
