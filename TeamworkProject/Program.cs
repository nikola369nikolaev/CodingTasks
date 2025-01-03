/*
 * It's time for the teamwork projects and you are responsible for gathering the teams. First, you will receive an integer – the count of the teams you will have to register. You will be given a user and a team, separated with "-". The user is the creator of the team. For every newly created team you should print a message:

"Team {teamName} has been created by {user}!".

Next, you will receive а user with a team, separated with "->", which means that the user wants to join that team. Upon receiving the command: "end of assignment", you should print every team, ordered by the count of its members (descending) and then by name (ascending). For each team, you have to print its members sorted by name (ascending). However, there are several rules:

· If а user tries to create a team more than once, a message should be displayed:

- "Team {teamName} was already created!"

· A creator of a team cannot create another team – the following message should be thrown:

- "{user} cannot create another team!"

· If а user tries to join a non-existent team, a message should be displayed:

- "Team {teamName} does not exist!"

· A member of a team cannot join another team – the following message should be thrown:

- "Member {user} cannot join team {team Name}!"

· In the end, teams with zero members (with only a creator) should disband and you have to print them ordered by name in ascending order.

· Every valid team should be printed ordered by name (ascending) in the following format:

"{teamName} - {creator} -- {member}…"
 */

class Team
{
    public Team(string name,string creatorName)
    {
        Name = name;
        Creator = creatorName;
        Members = new List<string>();
    }

    public string Name { get; set; }
    public string Creator { get; set; }
    public List<string> Members { get; set; }
    
    public override string ToString()
    {
        return $"{Name}\n" +
               $"- {Creator}\n" +
               $"{GetMembersString()}";
    }

    public string GetMembersString()
    {
        Members = Members
            .OrderBy(name => name)
            .ToList();

        string result = string.Empty;

        for (int i = 0; i < Members.Count-1; i++)
        {
            result += $"-- {Members[i]}\n";
        }

        result += $"-- {Members[Members.Count - 1]}";
        return result;
    }
}

class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        List<Team> teams = new List<Team>();

        for (int i = 0; i < n; i++)
        {
            string[] teamCommands = Console.ReadLine().Split("-");
            Team team = new Team(teamCommands[1], teamCommands[0]);

            Team sameTeamFound = teams.Find(t => t.Name == team.Name);
            Team sameCreatorFound = teams.Find(t => t.Creator == team.Creator);

            if (sameTeamFound !=null)
            {
                Console.WriteLine($"Team {sameTeamFound.Name} was already created!");
                continue;
            }

            if (sameCreatorFound !=null)
            {
                Console.WriteLine($"{sameCreatorFound.Creator} cannot create another team!");
                continue;
            }
            
            teams.Add(team);
            Console.WriteLine($"Team {team.Name} has been created by {team.Creator}!");
        }

        string command;

        while ((command = Console.ReadLine())!="end of assignment")
        {
            string[] arguments = command.Split("->");

            string joinerName = arguments[0];

            string teamName = arguments[1];

            bool hasAnyTeamWithSameName = teams.Any(t => t.Name == teamName);

            if (hasAnyTeamWithSameName == false)
            {
                Console.WriteLine($"Team {teamName} does not exist!");
                continue;
            }

            if (teams.Any(team => team.Creator == joinerName) ||
                teams.Any(team=> team.Members.Contains(joinerName)))
            {
                Console.WriteLine($"Member {joinerName} cannot join team {teamName}!");
                continue;
            }
            teams.First(t=> t.Name == teamName).Members.Add(joinerName);
            
        }

        List<Team> leftTeams = teams.Where(t => t.Members.Count > 0).ToList();

        List<Team> orderedTeams = leftTeams
            .OrderByDescending(t => t.Members.Count)
            .ThenBy(t => t.Name)
            .ToList();
        orderedTeams.ForEach(team => Console.WriteLine(team));

        List<Team> disbandTeams = teams.Where(t => t.Members.Count <= 0).ToList();
        Console.WriteLine("Teams to disband:");
        disbandTeams = disbandTeams.OrderBy(t => t.Name).ToList();
        
        disbandTeams.ForEach(team =>Console.WriteLine(team));
    }
}