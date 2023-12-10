using Helpers;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;

Console.WriteLine("Hello, AdventOfCode \n\n");
List<string> lineList = new List<string>();
lineList = InputTools.ReadAllLines("dayThree");
List<string> SymbolList = new List<string>();

#region starFive
Console.WriteLine(lineList);
//ycoordinaat
int mapHeight = lineList.Count;
//xcoordinaat
int mapWidth = lineList[0].Length;

//map[y,x]
string[,] map = new string[mapHeight, mapWidth];
map = fillMap(lineList, map);
//SymbolList.ForEach(x => Console.WriteLine(x));
int totalSum = 0;
int TotalRatio = 0;
int previousHeight = 0;
int previousNumber = 0;

Console.WriteLine(map);

for (int y = 0; y < mapHeight; y++)
{
    for (int x = 0; x < mapWidth; x++)
    {
        if (SymbolList.Contains(map[y, x]))
        {
            Console.WriteLine($"Coordinates of match:: height:{y}  width:{x}");
            gearMachineSymbol(y, x);    
        };
    }
}
Console.WriteLine($"\n>>>> SOLUTION TO STAR_FIVE/SIX:: {totalSum}");

void gearMachineSymbol(int MatchHeight, int MatchWidth)
{
    int startHeight = -1;
    int startWidth = -1;
    //edgecases height

    if (MatchHeight == 0)
       startHeight = 0;
    
    if (MatchWidth == 0)
       startWidth = 0;
    

    for (int y = startHeight; (y < 2) && (y < (mapHeight - MatchHeight)) && (mapHeight >=(MatchHeight + y)); y++)
    {
        for (int x = startWidth; (x < 2) && (x <= ((mapWidth-1) - MatchWidth)) && ((mapWidth-1) >= (MatchWidth + x)); x++)
        {
            //Console.WriteLine($"checkCoordinates:: y{MatchHeight + y} x{MatchWidth + x}");
            //Console.WriteLine($"Y:: {y} X:: {x}");
            var check = Regex.IsMatch(map[(MatchHeight + y), (MatchWidth + x)], @"\d");
            if (check)
            {
                //Console.WriteLine($"\tSymbol matches with Number coordinates:: height:{MatchHeight + y}  wdith::{MatchWidth + x}");
                gearMachineNumber(MatchHeight, MatchWidth, (MatchHeight+y), (MatchWidth+x)); ;
            }
        }
    }
    
}

List<string> fillList(int heightLine)
{
    List<string> yline = new List<string>();
    yline.Clear();
    for (int x = 0; x < mapWidth; x++)
    {
        string charachter = map[heightLine, x];
        yline.Add(charachter);
    }
    return yline;
}

void gearMachineNumber(int MatchHeight, int MatchWidth,int NumberMatchHeight, int NumberMatchWidth)
{
    //getLineWithMatchedNumber
    List<string> yOpNumber = new List<string>();
    yOpNumber = fillList(NumberMatchHeight);
    var rangeYOpNumber = yOpNumber.ToArray();

    //Vars
    int number;
    string[] YopNumber = new string[] { };
    StringBuilder TekstWithNumberBuilder = new StringBuilder();
   
    if (NumberMatchWidth == MatchWidth)
    {
       
        int start = NumberMatchWidth-2;
        start = start < 0 ? 0 : start;
        int stop = NumberMatchWidth + 2;
        stop = stop > mapWidth - 1 ? mapWidth : stop;
        YopNumber = rangeYOpNumber[start..stop];
        int count = 0;
        for(int x = 0; x< YopNumber.Length;x++)
        {
            bool isNumeric = int.TryParse(YopNumber[x], out number);
            if (isNumeric)
            {
                count++;
            }
        }
        if(count > 1)
        {
            Console.WriteLine("Not printing: double");
            Array.Clear(YopNumber);
        }
    }
    else if (MatchHeight == NumberMatchHeight)
    {
        //769*148...
        //rightFromSymbol
        if (MatchWidth < NumberMatchWidth)
        {
            int start = NumberMatchWidth;
            start = start < 0 ? 0 : start;
            int stop = NumberMatchWidth + 3;
            stop = stop > mapWidth - 1 ? mapWidth : stop;
            YopNumber = rangeYOpNumber[start..stop];

        }
        //LeftFromSymbol
        else
        {
            int start = NumberMatchWidth - 2;
            start = start < 0 ? 0 : start;
            int stop = NumberMatchWidth+1;
            YopNumber = rangeYOpNumber[start..stop];
        }

    }
    else if (NumberMatchWidth != MatchWidth)
    {

        //Console.WriteLine($"numberMatched {NumberMatchWidth}");
        int start = NumberMatchWidth - 2;
        start = start < 0 ? 0 : start;
        int stop = NumberMatchWidth + 3;
        stop = stop > mapWidth - 1 ? mapWidth : stop;
        YopNumber = rangeYOpNumber[start..stop];
    }
    //StringBuilder TekstWithNumberBuilder = new StringBuilder();
    foreach (string str in YopNumber)
    {
        TekstWithNumberBuilder.Append(str);
    }
    string TekstWithNumber = TekstWithNumberBuilder.ToString();
    if(TekstWithNumber.Length > 0)
    {
        string Pattern = @"\D+";
        var tekstOnlyNumber = Regex.Split(TekstWithNumber, Pattern, RegexOptions.IgnoreCase).Where(x => !string.IsNullOrEmpty(x));
        if (tekstOnlyNumber.First().Length > 1)
        {
            number = int.Parse(tekstOnlyNumber.First());
        }
        else
        {
            number = int.Parse(tekstOnlyNumber.Last());
            //string test = tekstOnlyNumber[1];
        }
        Console.WriteLine($"Number::{number}");
        if(NumberMatchHeight == 135)
        {
            Console.WriteLine("Stop");
        }
        if (previousHeight == NumberMatchHeight)
        {
            if(previousNumber == number)
            {
                Console.WriteLine($"Not printing: Previous number the same on the same height:: {number}");
                previousHeight = NumberMatchHeight;
            }
            else
            {
                Console.WriteLine($"\tNumber to Write:: {number}");
                totalSum = totalSum + number;
                previousNumber = number;
                previousHeight = NumberMatchHeight;
            }
        }
        else
        {
            Console.WriteLine($"\tNumber to Write:: {number}");
            totalSum = totalSum + number;
            previousNumber = number;
            previousHeight = NumberMatchHeight;
        }
        Array.Clear(YopNumber);
        TekstWithNumberBuilder.Clear();
    }
   
}

string[,] fillMap(List<String> lineList, string[,] map)
{
    int height = 0;
    int width;
    foreach (string line in lineList)
    {
        width = 0;
        foreach (char oneChar in line)
        {
            map[height, width] = oneChar.ToString();
            MakeSymbolList(oneChar.ToString());

            width++;
        }
        height++;
    }
    height = 0;
    width = 0;
    return map;
}

List<string> MakeSymbolList(string charachter)
{
    var pattern = @"\d+|[.]";
    bool symbolMatch = Regex.IsMatch(charachter, pattern);
    if (!symbolMatch)
    {;
        if (!SymbolList.Contains(charachter))
        {
            SymbolList.Add(charachter.ToString());
        };
    }
    SymbolList.Add("*");
    return SymbolList;
}

#endregion