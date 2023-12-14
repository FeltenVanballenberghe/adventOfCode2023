using Helpers;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text.RegularExpressions;

Console.WriteLine("Hello, AdventOfCode \n\n");
List<string> lineList = new List<string>();
lineList = InputTools.ReadAllLines("dayFour");
List<string> SymbolList = new List<string>();
List<int> LotterRangeList = new List<int>();
int TotalSum = 0;
int LastIndexLottery = -1;
int FirstIndexLottery = -1;

string linePattern = @"[a-z]|:|[|]";
string numbersPattern = @"\s+";



foreach (var line in lineList)
{
    //split game + nr
    IEnumerable<string> Results = Regex.Split(line.ToLower(), linePattern, RegexOptions.IgnoreCase).Where((n) => !string.IsNullOrWhiteSpace(n));
    Results.ToList();
    string GameNr = Results.First();
    Console.WriteLine($"GameNr:: {GameNr}");
    IEnumerable<string> WinningNumbers = Regex.Split(Results.ElementAt(1), numbersPattern, RegexOptions.IgnoreCase).Where((n)=> !string.IsNullOrWhiteSpace(n));
    IEnumerable<string> LotteryNumbers = Regex.Split(Results.Last(), numbersPattern, RegexOptions.IgnoreCase).Where((n) => !string.IsNullOrWhiteSpace(n));

    //Tolist
    List<int> WinningNumbersIntList = WinningNumbers.ToList().Select(int.Parse).ToList();
    List<int> LotteryNumbersIntList = LotteryNumbers.ToList().Select(int.Parse).ToList();
    //sorting
    WinningNumbersIntList.Sort();
    LotteryNumbersIntList.Sort();

    for(int n = 0; n < WinningNumbersIntList.Count; n++)
    {
        FirstIndexLottery = LotteryNumbersIntList.FindIndex(s => s.Equals(WinningNumbersIntList.ElementAt(n)));
        if (FirstIndexLottery == -1)
        {
            continue;
        }
        else
        {
            break;
        }
    }

    for (int t = WinningNumbersIntList.Count - 1; t >= 0; t--)
    {
        LastIndexLottery = LotteryNumbersIntList.FindIndex(s=> s.Equals(WinningNumbersIntList.ElementAt(t)));
        if (LastIndexLottery == -1)
        {
            continue;
        }
        else
        {
            break;
        }
    }
    
    
    int[] LotteryNumbersIntArray = LotteryNumbersIntList.ToArray();
    var Mynumbers = WinningNumbersIntList.Intersect(LotteryNumbersIntList).ToList();
    
    if (FirstIndexLottery == -1 && LastIndexLottery == -1)
    {
        Console.WriteLine("No Match");
    }
    else if (FirstIndexLottery == LastIndexLottery)
    {
        // FirstIndexLottery count +1
        int LotteryRangeSingleNumber = LotteryNumbersIntArray.ElementAt((FirstIndexLottery));
        LotterRangeList.Add(LotteryRangeSingleNumber);
    }
    else
    {
        int[] LotteryRange = LotteryNumbersIntArray[FirstIndexLottery..(LastIndexLottery+1)];
        LotterRangeList = LotteryRange.ToList();
    }
    
    //Winnende numbers lijst
    List<int> indexList = new List<int>();
    foreach(int win in WinningNumbersIntList)
    {
        
        int IndexLotteryNumber = LotterRangeList.FindIndex(s => s.Equals(win));
        if (IndexLotteryNumber != -1)
        {
            //Console.WriteLine($"winningNumber:: {win}");
            indexList.Add(IndexLotteryNumber);
        }
    }
    //indexList.ForEach(x=> Console.WriteLine(x));
    int count = indexList.Count;
    if (count > 0)
    {
        int startCount =(int)Math.Pow(2, indexList.Count-1);
        int Score = (int)Math.Pow(2, Mynumbers.Count - 1);
        Console.WriteLine(startCount);
        Console.WriteLine(Score);
        TotalSum = TotalSum + startCount;
        LotterRangeList.Clear();
    }
}

Console.WriteLine($"\n>>>> SOLUTION TO STAR_SEVEN:: {TotalSum}");




