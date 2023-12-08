// See https://aka.ms/new-console-template for more information
using System.Collections;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using Helpers;


Console.WriteLine("Hello, AdventOfCode \n\n");
List<string> lineList = new List<string>();
lineList = InputTools.ReadAllLines("dayOne");

#region star_One
char[] numbersArray = new char[0];
int sumOfList = 0;

foreach (string line in lineList)
{
    //only digits
    string numbersOnly = new string(line.Where(char.IsDigit).ToArray());
    int numbersOnlyLength = numbersOnly.Length;

    if (numbersOnlyLength > 0)
    {
        //only first and last number
        numbersArray = numbersOnly.ToCharArray(0, numbersOnlyLength);
        string firstNummer = numbersArray[0].ToString();
        string lastNummer = numbersArray[numbersOnlyLength - 1].ToString();
        //concat
        string newJoinedNumber = string.Concat(firstNummer, lastNummer);
        //concat parse to int
        int newNumber = int.Parse(newJoinedNumber);
        sumOfList = sumOfList + newNumber;
    }
}
Console.WriteLine($"\n>>>> SOLUTION TO STAR_ONE:: {sumOfList}\n\n");
#endregion

#region star_two
int SumOfListStar2 = 0;
//TODO 2D array instead of jaggedArray
string[][] jaggedArray ={
    new string [] {"one", "1" },
    new string [] {"two", "2" },
    new string [] {"six", "6" },
    new string [] {"nine", "9" },
    new string [] {"four", "4" },
    new string [] {"five", "5" },
    new string [] {"seven", "7" },
    new string [] {"three", "3" },
    new string [] {"eight", "8" },
};

string letterListFct(string[][] jaggedArray, List<string> lettersList, string line, string First, string Last)
{
    bool LetterListreversed = false;
    string Word = "";
    string WordToCheck;
    foreach (char element in line)
    {
        if (char.IsDigit(element))
        {
            if (First != null)
            {
                return element.ToString();
            }
            else
            {
                return element.ToString();
            }
        }
        else
        {
            lettersList.Add(element.ToString());
            if (First != null)
            {
                lettersList.Reverse();
                LetterListreversed = true;
            }
            if (lettersList.Count >= 3)
            {
                foreach (string letter in lettersList)
                {
                    Word = string.Concat(Word, letter);
                }
                //check if first letter is in array
                foreach (var item in jaggedArray)
                {
                    int Found = Word.IndexOf(item[0]);
                    if (Found != -1)
                    {
                        WordToCheck = Word.Substring(Found, item[0].Length);
                        if (WordToCheck == item[0])
                        {
                            if (First == null)
                            {
                                return item[1];
                            }
                            else
                            {
                                return item[1];
                            }
                        }
                    }
                }
            }
        }
        if (LetterListreversed)
        {
            lettersList.Reverse();
            LetterListreversed = false;
        }
    }
    return null;
}

foreach (string line in lineList)
{
    List<string> lettersList = new List<string>();
    string? First = null;
    string? Last = null;

    //FIRST LETTER
    First = letterListFct(jaggedArray, lettersList, line, First, Last);
    lettersList.Clear();

    //SECOND LETTER
    //// reverse
    char[] charArray = line.ToCharArray();
    Array.Reverse(charArray);
    string reversedLine = new string(charArray);
    Last = letterListFct(jaggedArray, lettersList, reversedLine, First, Last);
    lettersList.Clear();

    //COUNTER
    if (First != null & Last != null)
    {
        string newJoinedNumber = string.Concat(int.Parse(First), int.Parse(Last));
        int newNumber = int.Parse(newJoinedNumber);
        SumOfListStar2 = SumOfListStar2 + newNumber;
    }

}

Console.WriteLine($"\n>>>> SOLUTION TO STAR_TWO:: {SumOfListStar2}");
#endregion