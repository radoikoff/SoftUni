using System;
using System.Collections.Generic;
using System.Linq;

public class Team
{
    public string TeamName { get; set; }
    public List<string> TeamMembers { get; set; }
    public string CreatorName { get; set; }
}

namespace _9.Teamwork_projects
{
    class TeamworkProject
    {
        public static void Main()
        {
            var teams = new List<Team>();
            //Create teams
            int numberOfCreators = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfCreators; i++)
            {
                var tokens = Console.ReadLine().Split('-');
                string user = tokens[0];
                string teamName = tokens[1];
                if (teams.Count(x => x.TeamName == teamName) != 0)
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                    continue;
                }
                if (teams.Count(x => x.CreatorName == user) != 0)
                {
                    Console.WriteLine($"{user} cannot create another team!");
                    continue;
                }
                var currentTeam = new Team
                {
                    CreatorName = user,
                    TeamName = teamName,
                    TeamMembers = new List<string>()
                };
                teams.Add(currentTeam);
                Console.WriteLine($"Team {teamName} has been created by {user}!");
            }

            //Assign users
            var input = Console.ReadLine();
            while (input != "end of assignment")
            {
                var tokens = input.Split(new char[] { '-', '>' }, StringSplitOptions.RemoveEmptyEntries);
                string user = tokens[0];
                string teamName = tokens[1];
                if (teams.Count(x => x.TeamName == teamName) == 0)
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                    input = Console.ReadLine();
                    continue;
                }
                if (teams.Count(x => x.CreatorName == user) != 0 || teams.Count(x => x.TeamMembers.Contains(user)) != 0)
                {
                    Console.WriteLine($"Member {user} cannot join team {teamName}!");
                    input = Console.ReadLine();
                    continue;
                }

                var currentTeam = teams.FirstOrDefault(x => x.TeamName == teamName);
                currentTeam.TeamMembers.Add(user);

                input = Console.ReadLine();
            }
            //Print
            foreach (var team in teams.Where(x => x.TeamMembers.Count > 0).OrderByDescending(x => x.TeamMembers.Count).ThenBy(x => x.TeamName)) //where user count >0
            {
                Console.WriteLine(team.TeamName);
                Console.WriteLine($"- {team.CreatorName}");
                foreach (var user in team.TeamMembers.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {user}");
                }
            }

            //where user count = 0
            //if (teams.Count(x => x.TeamMembers.Count == 0) > 0)
            //{
                Console.WriteLine("Teams to disband:");
                foreach (var team in teams.Where(x => x.TeamMembers.Count == 0).OrderBy(x=>x.TeamName))
                {
                    Console.WriteLine(team.TeamName);
                }
            //}
        }
    }
}
