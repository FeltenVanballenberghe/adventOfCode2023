// See https://aka.ms/new-console-template for more information
using System.Collections;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Xml.Linq;

Console.WriteLine("Hello, AdventOfCode \n\n");

    #region VARS
    List<string> lineList = new List<string>();
    string[] lines = new string[0];

    #endregion

    #region filereaderArray
    try
    {
        String file = "StarOne.txt";
        String folder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        String filePath = Path.Combine(folder, "Assets/StarsInput/", file);
    
    
        using (var reader = new StreamReader(filePath))
        {
            while (!reader.EndOfStream)
            {
                string oneLine = reader.ReadLine();
                lineList.Add(oneLine);
            }  
        }
        lines = lineList.ToArray();
        Console.Write("#####File reader####\n");
        Console.Write($"\tFile read:: {file}");
        Console.WriteLine($"\tNumber of lines read into an array:: {lines.Length}");
        Console.Write("#####End of file reader####\n\n");
    }
    catch(Exception ex)
    {
        Console.WriteLine($"File not read:: {ex.Message}");
    }

    #endregion

    #region star_One
    //char[] numbersArray = new char[0];
    //int sumOfList = 0;

    //foreach (string line in lines)
    //{
    //    //only digits
    //    string numbersOnly = new string(line.Where(char.IsDigit).ToArray());
    //    int numbersOnlyLength = numbersOnly.Length;

    //    if (numbersOnlyLength > 0)
    //    {
    //        //only first and last number
    //        numbersArray = numbersOnly.ToCharArray(0, numbersOnlyLength);
    //        string firstNummer = numbersArray[0].ToString();
    //        string lastNummer = numbersArray[numbersOnlyLength - 1].ToString();
    //        //concat
    //        string newJoinedNumber = string.Concat(firstNummer, lastNummer);
    //        //concat parse to int
    //        int newNumber = int.Parse(newJoinedNumber);
    //        sumOfList = sumOfList + newNumber;
    //    }

    //}
    //Console.WriteLine($"\n>>>> SOLUTION TO STAR_ONE:: {sumOfList}\n\n");
    #endregion

    //#region star_two
    //int SumOfListStar2 = 0;
    //string[][] jaggedArray ={
    //    new string [] {"one", "1" },
    //    new string [] {"two", "2" },
    //    new string [] {"six", "6" },
    //    new string [] {"nine", "9" },
    //    new string [] {"four", "4" },
    //    new string [] {"five", "5" },
    //    new string [] {"seven", "7" },
    //    new string [] {"three", "3" },
    //    new string [] {"eight", "8" },
    //};

    //string letterListFct(string[][] jaggedArray, List<string> lettersList, string line, string First, string Last)
    //{
    //    bool LetterListreversed = false;
    //    string Word = "";
    //    string WordToCheck;
    //    foreach (char element in line)
    //    {
    //        if (char.IsDigit(element))
    //        {
    //            if (First != null)
    //            {
    //                return element.ToString();
    //            }
    //            else
    //            {
    //                return  element.ToString();
    //            }
    //        }
    //        else
    //        {
    //            lettersList.Add(element.ToString());
    //            if (First != null)
    //            {
    //                lettersList.Reverse();
    //                LetterListreversed = true;
    //            }
    //            if(lettersList.Count >= 3)
    //            {
    //                foreach (string letter in lettersList)
    //                {
    //                    Word = string.Concat(Word, letter);
    //                }
    //                //check if first letter is in array
    //                foreach (var item in jaggedArray)
    //                {
    //                    int Found = Word.IndexOf(item[0]);
    //                    if (Found != -1)
    //                    {
    //                        WordToCheck = Word.Substring(Found, item[0].Length);
    //                        if (WordToCheck == item[0])
    //                        {
    //                            if (First == null)
    //                            {
    //                                return item[1];
    //                            }
    //                            else
    //                            {
    //                                return item[1];
    //                            }
    //                        }
    //                    }
    //                }
    //            }
    //        }
    //        if (LetterListreversed)
    //        {
    //            lettersList.Reverse();
    //            LetterListreversed = false;
    //        }
    //    }
    //    return null;
    //}

    //foreach (string line in lines)
    //{
    //    List<string> lettersList = new List<string>();
    //    string? First = null;
    //    string? Last = null;
        
    //    //FIRST LETTER
    //    First = letterListFct(jaggedArray, lettersList, line, First, Last);
    //    lettersList.Clear();

    //    //SECOND LETTER
    //    //// reverse
    //    char[] charArray = line.ToCharArray();
    //    Array.Reverse(charArray);
    //    string reversedLine = new string(charArray);
    //    Last = letterListFct(jaggedArray, lettersList, reversedLine, First, Last);
    //    lettersList.Clear();
    
    //    //COUNTER
    //    if(First != null & Last != null)
    //    {
    //        string newJoinedNumber = string.Concat(int.Parse(First), int.Parse(Last));
    //        int newNumber = int.Parse(newJoinedNumber);
    //        SumOfListStar2 = SumOfListStar2 + newNumber;
    //    }
    
    //}
    
    //Console.WriteLine($"\n>>>> SOLUTION TO STAR_TWO:: {SumOfListStar2}");
    //#endregion

    //#region star_three

    ///* standard game 11: Game 1: 20 green, 3 red, 2 blue; 9 red, 16 blue, 18 green; 6 blue, 19 red, 10 green; 12 red, 19 green, 11 blue */

    //List<round> roundList = new List<round>();
    //List<game> gameList= new List<game>();
    //games playedGames = new games();

    //#region gamesLevel
    //foreach (string line in lines)
    //{
    //#region gameLevel
    
    //    //game level
    //    int GameId;
    //    game playedGame = new game();
    //    char[] delimters = { ':', ';' };
    //    string[] result = line.ToLower().Split(delimters);
    
    //    //round level
    //    int GreenBalls = 0;
    //    int RedBalls = 0;
    //    int BlueBalls = 0;

    //    //game and round level
    //    foreach (string word in result)
    //    {
    //        //game level
    //        if (word.Contains("game"))
    //        {
    //            string gameIdPattern = @"[a-z]\S";
    //            IEnumerable<string> resultGameNumber = Regex.Split(word, gameIdPattern, RegexOptions.IgnoreCase).Where(n => !string.IsNullOrWhiteSpace(n));
    //            try
    //            {
    //                GameId = int.Parse(resultGameNumber.First().ToString());
    //                //Console.WriteLine($"GameNumber:: {GameId}");
    //                playedGame.gameId= GameId;
    //            }
    //            catch (Exception ex)
    //            {
    //                Console.WriteLine($"Game is null number {ex.Message}");
    //            }
    //        }
    //        //round level
    //        else
    //        {
    //            char[] roundDelimters = { ',' };
    //            string[] BallsInBags = word.ToLower().Split(roundDelimters);
    //            //ballsInBag level
    //            foreach (string ballsInBag in BallsInBags)
    //            {
    //                try
    //                {
    //                    //BallColors
    //                    string ColorPattern = @"\d*\s";
    //                    string NumberPattern = @"\s[a-z]*";
    //                    IEnumerable<string> BallColor = Regex.Split(ballsInBag, ColorPattern, RegexOptions.IgnoreCase).Where(n => !string.IsNullOrWhiteSpace(n));
    //                    IEnumerable<string> ballNumber = Regex.Split(ballsInBag, NumberPattern, RegexOptions.IgnoreCase).Where(n => !string.IsNullOrWhiteSpace(n));
    //                    //BallNumbers - Pattern matching
    //                    if (BallColor.First() is "green")
    //                    {
    //                        GreenBalls = int.Parse(ballNumber.First());
    //                    }
    //                    if (BallColor.First() is "blue")
    //                    {
    //                        BlueBalls = int.Parse(ballNumber.First());
    //                    }
    //                    if (BallColor.First() is "red")
    //                    {
    //                        RedBalls = int.Parse(ballNumber.First());
    //                    }
    //                }
    //                catch(Exception ex)
    //                {
    //                    Console.WriteLine($"No balls in bag:: {ex.Message}");
    //                }
    //            }
    //            roundList.Add(new round(RedBalls, GreenBalls, BlueBalls));
    //        }
    //    }
    //    foreach(round round in roundList)
    //    {
    //        playedGame.addRounds(round);
    //    }
    //    gameList.Add(playedGame);
    //    roundList.Clear();
    //# endregion
    //}
    ////game level
    //foreach (game game in gameList)
    //{
    //    playedGames.addGame(game);
    //}
    //#endregion
    ////results
    //Console.WriteLine($"GamesID sum of games passed:: {playedGames.sumOfIdGamesPassed}");

    //public static class cubeLimits
    //{
    //    public static int redCubes = 12;
    //    public static int greenCubes = 13;
    //    public static int blueCubes = 14;
    //}

    //public class round
    //{
    //    public int? red { get; set; }
    //    public int? green { get; set; }
    //    public int? bleu { get; set; }

    //    public round(int red, int green, int bleu)
    //    {
    //        this.red = red;
    //        this.green = green;
    //        this.bleu = bleu;
    //    }
    //};

    //public class game
    //{
    //    public List<round> _allRounds = new List<round>();

    //    public int gameId { get; set; }
    //    public bool redPassed
    //    {
    //        get
    //        {

    //            bool redPassed = true;

    //            foreach (var item in _allRounds)
    //            {
    //                if (item.red == null)
    //                {
    //                    redPassed = true;
    //                    break;
    //                }
    //                else
    //                {
    //                    if (item.red > cubeLimits.redCubes)
    //                    {
    //                        redPassed = false;
    //                        break;
    //                    }
    //                }
    //            }
    //            return redPassed;
    //        }
    //    }
    //    public bool greenPassed
    //    {
    //        get
    //        {
    //            bool greenPassed = true;
    //            foreach (var item in _allRounds)
    //            {
    //                if (item.green == null)
    //                {
    //                    greenPassed = true;
    //                    break;
    //                }
    //                else
    //                {
    //                    if (item.green > cubeLimits.greenCubes)
    //                    {
    //                        greenPassed = false;
    //                        break;
    //                    }
    //                }
    //            }
    //           return greenPassed;
    //        }
    //    }
    //    public bool bleuPassed
    //    {
    //        get
    //        {
    //            bool bleuPassed = true;
    //            foreach (var item in _allRounds)
    //            {
    //                if (item.bleu == null)
    //                {
    //                    bleuPassed = true;
    //                    break;
    //                }
    //                else
    //                {
    //                    if (item.bleu > cubeLimits.blueCubes)
    //                    {
    //                        bleuPassed = false;
    //                        break;
    //                    }
    //                }
    //            }
    //            return bleuPassed;
    //        }
    //    }
    
    //    public game() { }
    
    //    public void addRounds(round round)
    //    {
    //        _allRounds.Add(round);
    //    }
    //};

    //public class games
    //{
    //    private List<game> _allGames = new List<game>();
    
    //    public int gamesPassed { get; set; }
    //    public int sumOfIdGamesPassed
    //    {
    //        get {
    //            int sumOfIdGamesPassed = 0;
    //            if (_allGames.Count > 0)
    //            {
    //                foreach (var game in _allGames)
    //                {
    //                    if (game.redPassed && game.greenPassed && game.bleuPassed)
    //                    {
    //                        sumOfIdGamesPassed = sumOfIdGamesPassed + game.gameId;
    //                    }
    //                }
    //            }
    //            return sumOfIdGamesPassed;
    //        }
    //    }

    //    public void addGame(game game)
    //    {
    //        _allGames.Add(game);
    //    }

    //};

    //#endregion