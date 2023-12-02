namespace AdventOfCode;

public class DayTwo : IRun
{
    private readonly IDictionary<string, int> _maxVals;
    private readonly List<Tuple<string, int>> _cubeSets;
    public DayTwo()
    {
        _cubeSets = new List<Tuple<string, int>>();
        _maxVals = new Dictionary<string, int>();
        _maxVals.Add("blue", 14);
        _maxVals.Add("red", 12);
        _maxVals.Add("green", 13);
    }
    private int GetGameId(string gameName)
    {
        return int.Parse(gameName.Split(" ")[1]);
    }

    private void FillSets(string gameSets)
    {
        var stringSets = gameSets.Split(";");
        foreach (var set in stringSets)
        {
            var randomCubes = set.Split(",");
            foreach (var cubes in randomCubes)
            {
                var trim = cubes.Trim();
                var pair = trim.Split(" ");
                Console.WriteLine($"{pair[0]}, {pair[1]}");
                _cubeSets.Add(new Tuple<string, int>(pair[1], int.Parse(pair[0])));
            }
        }

    }

    private int VerifyGame(string game)
    {
        string[] gameObjects = game.Split(":");
        var gameId = GetGameId(gameObjects[0]);
        FillSets(gameObjects[1]);
        foreach (var set in _cubeSets)
        {
            if (_maxVals[set.Item1] < set.Item2)
            {
                return 0;
            }
        }
        return gameId;
    }

    private int getPower()
    {
        var max_blue = _cubeSets.Where(set => set.Item1 == "blue").Select(set => set.Item2).Prepend(-1).Max();
        var max_red = _cubeSets.Where(set => set.Item1 == "red").Select(set => set.Item2).Prepend(-1).Max();
        var max_green = _cubeSets.Where(set => set.Item1 == "green").Select(set => set.Item2).Prepend(-1).Max();

        return max_red * max_green * max_blue;
    }
    public void Run()
    {
        try
        {
            var streamReader = new StreamReader("./../../../input.txt");
            var line = streamReader.ReadLine();

            var sumIds = 0;
            var powerSums = 0;
            while (line != null)
            {
                Console.WriteLine(line);
                var gameId = VerifyGame(line);
                powerSums += getPower();
                if (gameId > 0)
                {
                    sumIds += gameId;
                }
                _cubeSets.Clear();
                line = streamReader.ReadLine();
            }
            
            Console.WriteLine($"Sum of good games: {sumIds}, Sum of all powers: {powerSums}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"[Err]: Fatal error on reading >>>> ({e.Message})");
        }
    }   
}