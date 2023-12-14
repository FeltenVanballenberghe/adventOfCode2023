using Helpers;
using System.Text.RegularExpressions;

//ReadFile
List<string> lineList = new List<string>();
lineList = InputTools.ReadAllLines("dayFour");
int TotalSum = 0;

//Functie MakeCard
ScratchCard GetCard(string line)
{
    //Regex
    string LinePattern = @"[a-z]|:|[|]";
    string NumbersPattern = @"\s+";

    //Lees line
    IEnumerable<string> Results = Regex.Split(line.ToLower(), LinePattern, RegexOptions.IgnoreCase).Where((n) => !string.IsNullOrWhiteSpace(n));
    IEnumerable<string> WinningNumbers = Regex.Split(Results.ElementAt(1), NumbersPattern, RegexOptions.IgnoreCase).Where((n) => !string.IsNullOrWhiteSpace(n));
    IEnumerable<string> LotteryNumbers = Regex.Split(Results.Last(), NumbersPattern, RegexOptions.IgnoreCase).Where((n) => !string.IsNullOrWhiteSpace(n));
    //Tolist
    string GameNr = Results.First();
    List<int> WinningNumbersIntList = WinningNumbers.Select(int.Parse).ToList();
    List<int> LotteryNumbersIntList = LotteryNumbers.Select(int.Parse).ToList();
    //Sorting
    WinningNumbersIntList.Sort();
    LotteryNumbersIntList.Sort();
    //Return new scratchCard object
    return new ScratchCard()
    {
        CardNumber = int.Parse(GameNr),
        WinningNumbers = WinningNumbersIntList.Intersect(LotteryNumbersIntList).ToList()
    };
}

//Get Total score from each ScratchCard
foreach (string line in lineList)
{
    int result = GetCard(line).Score;
    TotalSum = TotalSum + result;
}

Console.WriteLine($"\n>>>> SOLUTION TO STAR_SEVEN:: {TotalSum}");

//PART TWO
/* Of each card make a list of 'matching cards', 
 * check Matching cards again and again, 
 * and number of cards each time to the 'result.list' 
 * containing all cards*/
List<ScratchCard> DownTheRabbitHole(List<ScratchCard> AllCards, ScratchCard SingleCard)
{
    //if(SingleCard.CardNumber == 95)
    //{
    //    Console.WriteLine("stop");
    //}
    //Console.WriteLine($"cardNumber:: {SingleCard.CardNumber}");
    //SingleCard.WinningNumbers.ForEach(x => Console.WriteLine($"Matched Numbers {x.ToString()}"));

    //math CLAMP(input, out(range[0, allCards.count]) making sure that input is in the output range
    int StartRange = Math.Clamp(SingleCard.CardNumber, 0, AllCards.Count);
    //Of the rabbit card, get the all matching cards representing the (rabbit) winningNumbers.count, dont max allCards orginal list
    int StopRange = Math.Clamp(SingleCard.CardNumber + SingleCard.WinningNumbers.Count, 0, AllCards.Count);
    int CountForRange= StopRange - StartRange;

    //Of all the winning cards - get all matching cards within the rabbit range
    //Console.WriteLine(AllCards.AsReadOnly());
    List<ScratchCard> cardCopies = AllCards.GetRange(StartRange, CountForRange);

    //Initiate countingCardsList with orginal list (first counts)
    var Result = new List<ScratchCard>(cardCopies);

    //each time a card has matching cards check each matching card down the rabbit hole.
    foreach (var copy in cardCopies)
    {
        //add returned result to current result
        Result.AddRange(DownTheRabbitHole(AllCards, copy));
    }
    //eventually return list
    return Result;
}

//allCards from txt
var allCards = new List<ScratchCard>();
lineList.ForEach(line => allCards.Add(GetCard(line)));

//inital list
List<ScratchCard> allMatchingCards = new List<ScratchCard>(allCards);

foreach (ScratchCard card in allCards)
{
    allMatchingCards.AddRange(DownTheRabbitHole(allCards, card));
}

Console.WriteLine($"\n>>>> SOLUTION TO STAR_EIGHT:: {allMatchingCards.Count}");

public class ScratchCard
{
    public int CardNumber;
    public List<int> WinningNumbers = new List<int>();
    public int Score => (int)Math.Pow(2, WinningNumbers.Count - 1);
}











