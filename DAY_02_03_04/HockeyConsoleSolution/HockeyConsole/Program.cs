Console.WriteLine("Hello, Hockey World!");

string playerName = "";
string teamName = "";
int playerNumber = 0;
int goals = 0;
int assists = 0;
decimal contractWage = 0;

string inputValue = null;

Console.WriteLine("\tObtain player information\n");
Console.Write("Enter player name:\t\t");
playerName = Console.ReadLine();
Console.Write("Enter current team name:\t");
teamName = Console.ReadLine();
Console.Write("Enter player number:\t\t");
inputValue = Console.ReadLine();
playerNumber = int.Parse(inputValue);
Console.Write("Enter season goal count:\t");
inputValue = Console.ReadLine();
goals = int.Parse(inputValue);
Console.Write("Enter season assists count:\t");
inputValue = Console.ReadLine();
assists = int.Parse(inputValue);
Console.Write("Enter season cap hit (eg 3.76):\t");
inputValue = Console.ReadLine();
contractWage = decimal.Parse(inputValue);

Console.WriteLine("\n\nPlayer Information\n");
Console.WriteLine("\tName: " + playerName);
Console.WriteLine("\tTeam: {0}",teamName);
Console.WriteLine($"\tNumber: {playerNumber}");
Console.WriteLine($"\tGoals: {goals}");
Console.WriteLine($"\tAssists: {assists}");
Console.WriteLine($"\tCap Hit: ${contractWage}");
