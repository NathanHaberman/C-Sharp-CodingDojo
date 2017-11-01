using System;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Collections to work with
            List<Artist> Artists = JsonToFile<Artist>.ReadJson();
            List<Group> Groups = JsonToFile<Group>.ReadJson();

            //========================================================
            //Solve all of the prompts below using various LINQ queries
            //========================================================

            //There is only one artist in this collection from Mount Vernon, what is their name and age?
            var mountVernonArtist = 
                from guy in Artists
                where guy.Hometown == "Mount Vernon"
                select new {guy.RealName, guy.Age};

            //Who is the youngest artist in our collection of artists?
            var youngestArtists =
                from person in Artists
                orderby person.Age ascending
                select new {person.RealName, person.Age};

            var theYoungest = youngestArtists.First();

            //Display all artists with 'William' somewhere in their real name
            var william = 
                from person in Artists
                where person.RealName.Contains("William")
                select new {person.RealName, person.Hometown};

            //Display the 3 oldest artist from Atlanta
            var oldestAtlantaArtists = 
                from person in Artists
                orderby person.Age descending
                where person.Hometown == "Atlanta"
                select new {person.RealName, person.Hometown, person.Age};

            var threeOldest = oldestAtlantaArtists.Take(3);

            //(Optional) Display the Group Name of all groups that have members that are not from New York City
            var groupsNotFromNYC =
                from person in Artists
                where person.Hometown != "New York City"
                join team in Groups on person.GroupId equals team.Id
                select new {team.GroupName};

            var notNYC = groupsNotFromNYC.Distinct();

            //(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'
            var wuTangClanMembers =
                from team in Groups
                where team.GroupName == "Wu-Tang Clan"
                join person in Artists on team.Id equals person.GroupId
                select new {person.RealName, team.GroupName};
        }
    }
}
