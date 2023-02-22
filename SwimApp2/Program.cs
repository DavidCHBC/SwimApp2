using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwimApp2
{
    internal class Program
    {
        //global var
        static List<string> teamA = new List<string>();
        static List<string> teamB = new List<string>();
        static List<string> teamReserve = new List<string>();
        static float fastestTime = 9999;
        static string topSwimmer = "";
        static void OneSwimmer()
        {

            
            string SwimmerName;

            Console.WriteLine("Please enter Swimmer's name.");
            SwimmerName = Console.ReadLine();
            Console.WriteLine($"Swimmer name: {SwimmerName}");

            float sumTotalTime = 0;

            for (int i = 0; i < 4; i++)
            {
                
                int minutes, seconds, TotalTime = 0;
                //generates random num 1-4 (incl)
                Random randomnumber = new Random();
                minutes = randomnumber.Next(1, 4);
                seconds = randomnumber.Next(0, 59);

                TotalTime = (minutes * 60) + seconds;
                Console.WriteLine($"Swimmer time {i+1}: {minutes} min {seconds} sec\tTotal time in seconds: {TotalTime}s");
                sumTotalTime += TotalTime;
                Console.ReadLine();

            }

            float avgTime = sumTotalTime / 4;
            if (avgTime < fastestTime)
            {
                fastestTime = avgTime;
                topSwimmer = SwimmerName;
            }
            //assign the swimmer to a team


            string AllocatedTeam = "Reserve";

            if (avgTime < 160)
            {
                teamA.Add(SwimmerName);
                AllocatedTeam = "TeamA";
            }
            else if (avgTime < 210)
            {
                teamB.Add(SwimmerName);
                AllocatedTeam = "TeamB";
            }
            else
            {
                teamReserve.Add(SwimmerName);

            }
            Console.WriteLine($"Avg time: {avgTime}s \nAllocated team: {AllocatedTeam}");
            
        }

        static string CreateTeamLists() 
        {

            string teamLists = "\nThe teams are: \n\nTeam A\n";

            foreach(string swimmer in teamA)
            {

                teamLists += swimmer + "\t";

            }

            teamLists += $"\nwith {teamA.Count} team member(s)\n\nTeam B\n";


            foreach (string swimmer in teamB)
            {

                teamLists += swimmer + "\t";

            }

            teamLists += $"\nwith {teamB.Count} team member(s)\n\nTeam Reserve\n";


            foreach (string swimmer in teamReserve)
            {

                teamLists += swimmer + "\t";

            }

            teamLists += $"\nwith {teamReserve.Count} team member(s)\n\n";

            return teamLists;

        }



        static void Main(string[] args)
        {
            string flag = "";
            while (!flag.Equals("Stop")) 
            {
                
                OneSwimmer();

                Console.WriteLine("Press <Enter> to add another swimmer or type 'Stop' to end");
                flag = Console.ReadLine();
            }
            Console.WriteLine($"the fastest swimmer was: {topSwimmer} with an average time of {fastestTime} seconds");
            
            
            

            Console.WriteLine(CreateTeamLists());

        }
    
        
    
    }
}
