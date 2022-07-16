// See https://aka.ms/new-console-template for more information
using NBATeams.Data.Data;
using NBATeams.Data.Models;
using TestingConsole;

Stat stat = new Stat()
{
    Height = 1.8,
    Weight = 100,
    RPG = 3,
    APG = 3,
    PIE = 3,
    PPG = 3.5m,
    Assists = 3,
    Score = 3,
};

Console.WriteLine("Created Successfully");

Court court = new Court()
{
    Name = "Courttest",
    Location = new Location()
    {
        City = "New York",
        Street = "Street 123"
    }
};

Team team = new Team()
{
    Name = "Toronto Raptors",
    LogoPath = "",
    Court = court,
};

Team team2 = new Team()
{
    Name = "Memphis Grizzlies",
    LogoPath = "",
    Court = court,
};

#region Players
Player player = new Player()
{
    Name = "Mariano",
    LastName = "Piris",
    Number = "2",
    ImageProfilePath = "",
    Position = "F",
    BirthDate = new DateTime(1980, 1, 1),
    Experience = "2 Years",
    Stats = stat,
};

Player player2 = new Player()
{
    Name = "Steven",
    LastName = "Adams",
    Number = "1",
    ImageProfilePath = "",
    Position = "S",
    BirthDate = new DateTime(1990, 1, 1),
    Experience = "Rookie",
    Stats = stat,
};

Player player3 = new Player()
{
    Name = "Lucas",
    LastName = "Adrian",
    Number = "2",
    ImageProfilePath = "",
    Position = "F",
    BirthDate = new DateTime(1980, 1, 1),
    Experience = "2 Years",
    Stats = stat,
};

Player player4 = new Player()
{
    Name = "Juan",
    LastName = "Ruthford",
    Number = "2",
    ImageProfilePath = "",
    Position = "F",
    BirthDate = new DateTime(1980, 1, 1),
    Experience = "3 Years",
    Stats = stat,
};
#endregion
team.Players.Add(player);
team.Players.Add(player2);
team2.Players.Add(player3);
team2.Players.Add(player4);

Game game = new Game()
{
    DateGame = DateTime.Now,
    ScoreLocal = 10,
    ScoreVisit = 9,
    Local = team,
    Visit = team2
};

//Testing convertion of Weight
Console.WriteLine(player.Stats.WeightInLB());

//Testing convertion of Height
Console.WriteLine(player.Stats.HeightInFeet());

//CreateDatabase.Insert(); //inserts test data to database