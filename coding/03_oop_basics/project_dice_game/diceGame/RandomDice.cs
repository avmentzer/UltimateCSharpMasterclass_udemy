using System;

public class RandomDice
{
    private readonly Random _rnd;
    private const int SidesCount = 6;

    public RandomDice(Random random)
    {
        _rnd = random;
    }

    public int Roll() => _rnd.Next(1, SidesCount + 1);

}
