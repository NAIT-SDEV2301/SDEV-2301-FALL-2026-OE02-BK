// Model from the Lesson 13 LINQ Basics with Pokemon exercise.
// Source link is in README.md.
public class Pokemon
{
    public int Dex { get; }
    public string Name { get; }
    public string Type1 { get; }
    public string? Type2 { get; }
    public int Attack { get; }
    public int Defense { get; }
    public int Speed { get; }
    public int Total { get; }
    public bool IsLegendary { get; }

    public Pokemon(int dex, string name, string type1, string? type2,
        int attack, int defense, int speed, int total, bool isLegendary)
    {
        Dex = dex;
        Name = name;
        Type1 = type1;
        Type2 = type2;
        Attack = attack;
        Defense = defense;
        Speed = speed;
        Total = total;
        IsLegendary = isLegendary;
    }
}
