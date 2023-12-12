using Helpers;

using System.Text.RegularExpressions;

Console.WriteLine("Hello, AdventOfCode \n\n");
List<string> lineList = new List<string>();
lineList = InputTools.ReadAllLines("dayFour");
List<string> SymbolList = new List<string>();
List<int> LotterRangeList = new List<int>();
int TotalSum = 0;


string linePattern = @"[a-z]|:|[|]";
string numbersPattern = @"\s+";



foreach (var line in lineList)
{
    //split game + nr
    IEnumerable<string> Results = Regex.Split(line.ToLower(), linePattern, RegexOptions.IgnoreCase).Where((n) => !string.IsNullOrWhiteSpace(n));
    Results.ToList();
    string gameNr = Results.First();
    //split winning numbers + lotteryNummers
    IEnumerable<string> WinningNumbers = Regex.Split(Results.ElementAt(1), numbersPattern, RegexOptions.IgnoreCase).Where((n)=> !string.IsNullOrWhiteSpace(n));
    IEnumerable<string> LotteryNumbers = Regex.Split(Results.Last(), numbersPattern, RegexOptions.IgnoreCase).Where((n) => !string.IsNullOrWhiteSpace(n));

    //Tolist
    List<int> WinningNumbersIntList = WinningNumbers.ToList().Select(int.Parse).ToList();
    List<int> LotteryNumbersIntList = LotteryNumbers.ToList().Select(int.Parse).ToList();
    //sorting
    WinningNumbersIntList.Sort();
    LotteryNumbersIntList.Sort();
    //Beperk lotteryList
    int LastIndexLottery = LotteryNumbersIntList.FindIndex(s => s.Equals(WinningNumbersIntList.Last()));
    int FirstIndexLottery = LotteryNumbersIntList.FindIndex(s => s.Equals(WinningNumbersIntList.First()));

    
    int[] LotteryNumbersIntArray = LotteryNumbersIntList.ToArray();
    if(LastIndexLottery != -1)
    {
        int[] LotteryRange = LotteryNumbersIntArray[0..LastIndexLottery];
        LotterRangeList = LotteryRange.ToList();
    }
    else
    {
        int[] LotteryRange = LotteryNumbersIntArray[FirstIndexLottery..(LotteryNumbersIntList.Count()-1)];
        LotterRangeList = LotteryRange.ToList();
    }
    
    //Winnende numbers lijst
    
    List<int> indexList = new List<int>();

    foreach(int lotteryNumber in WinningNumbersIntList)
    {
        int IndexLotteryNumber = LotteryNumbersIntList.FindIndex(s => s.Equals(lotteryNumber));
        if (IndexLotteryNumber != -1)
        {
            indexList.Add(IndexLotteryNumber);
        }
    }
    indexList.ForEach(x=> Console.WriteLine(x));
    int count = indexList.Count;
    int starCounter = 1;
    for (int x = 2; x <= count; x++)
    {
        starCounter = starCounter * 2;
    }
    TotalSum = TotalSum + starCounter;
    Console.WriteLine("break");
}

Console.WriteLine($"\n>>>> SOLUTION TO STAR_SEVEB:: {TotalSum}");