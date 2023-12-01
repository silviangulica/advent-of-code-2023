namespace AdventOfCode;

public class DayOne : IRun
{
    private readonly IDictionary<string, int> _wordToNumbers;
    public DayOne()
    {
        _wordToNumbers = new Dictionary<string, int>();
        _wordToNumbers.Add("one", 1);
        _wordToNumbers.Add("two", 2);
        _wordToNumbers.Add("three", 3);
        _wordToNumbers.Add("four", 4);
        _wordToNumbers.Add("five", 5);
        _wordToNumbers.Add("six", 6);
        _wordToNumbers.Add("seven", 7);
        _wordToNumbers.Add("eight", 8);
        _wordToNumbers.Add("nine", 9);
    }
    private int FindTheCalibrationPart1(string message)
    {
        var firstNumber = -1;
        var lastNumber = -1;

        foreach (var c in message.Where(char.IsDigit))
        {
            lastNumber = (int)char.GetNumericValue(c);
            if (firstNumber == -1)
            {
                firstNumber = lastNumber;
            }
        }

        return firstNumber * 10 + lastNumber;
    }


    private int CheckWordOf3(string message, int pos)
    {
        if (message.Length - pos < 3) return 0;
        var wordOf3 = string.Concat(message[pos], message[pos + 1], message[pos + 2]);
        try
        {
            return _wordToNumbers[wordOf3];
        }
        catch (Exception e)
        {
            return 0;
        }
    }
    private int CheckWordOf4(string message, int pos)
    {
        if (message.Length - pos < 4) return 0;
        var wordOf4 = string.Concat(message[pos], message[pos + 1], message[pos + 2], message[pos + 3]);
        try
        {
            return _wordToNumbers[wordOf4];
        }
        catch (Exception e)
        {
            return 0;
        }
    }
    private int CheckWordOf5(string message, int pos)
    {
        if (message.Length - pos < 5) return 0;
        var wordOf5 = string.Concat(message[pos], message[pos + 1], message[pos + 2], message[pos + 3], message[pos + 4]);
        try
        {
            return _wordToNumbers[wordOf5];
        }
        catch (Exception e)
        {
            return 0;
        }
    }
    
    private int FindTheCalibrationPart2(string message)
    {
        var firstNumber = -1;
        var lastNumber = -1;
        for (var i = 0; i < message.Length; i++)
        {

            if (char.IsDigit(message[i]))
            {
                lastNumber = (int)char.GetNumericValue(message[i]);   
            }
            else
            {
                var check1 = CheckWordOf3(message, i);
                var check2 = CheckWordOf4(message, i);
                var check3 = CheckWordOf5(message, i);
                
                if (check1 != 0) lastNumber = check1;
                else if (check2 != 0) lastNumber = check2;
                else if (check3 != 0) lastNumber = check3;
            }
            
            if (firstNumber == -1)
            {
                firstNumber = lastNumber;
            }
        }

        return firstNumber * 10 + lastNumber;
    }
    
    public void Run()
    {
        try
        {
            var streamReader = new StreamReader("./../../../input.txt");
            var line = streamReader.ReadLine();

            var calibrationSum = 0;
            while (line != null)
            {
                //calibrationSum += FindTheCalibrationPart1(line);
                calibrationSum += FindTheCalibrationPart2(line);
                line = streamReader.ReadLine();
            }
         
            Console.WriteLine($"Calibration sum :  >>> {calibrationSum} <<<");
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception at reading file + " + e.Message);
        }
    }
}