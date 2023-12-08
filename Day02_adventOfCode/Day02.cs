using Helpers;
using System.Text.RegularExpressions;

Console.WriteLine("Hello, AdventOfCode \n\n");
List<string> lineList = new List<string>();
lineList = InputTools.ReadAllLines("dayTwo");

#region star_three/star_four
///* standard game 11: Game 1: 20 green, 3 red, 2 blue; 9 red, 16 blue, 18 green; 6 blue, 19 red, 10 green; 12 red, 19 green, 11 blue */

List<round> roundList = new List<round>();
List<game> gameList = new List<game>();
games playedGames = new games();

#region gamesLevel
foreach (string line in lineList)
{
#region gameLevel

//game level
int GameId;
game playedGame = new game();
char[] delimters = { ':', ';' };
string[] result = line.ToLower().Split(delimters);

//round level
int GreenBalls = 0;
int RedBalls = 0;
int BlueBalls = 0;

//game and round level
foreach (string word in result)
{
//game level
if (word.Contains("game"))
{
string gameIdPattern = @"[a-z]\S";
IEnumerable<string> resultGameNumber = Regex.Split(word, gameIdPattern, RegexOptions.IgnoreCase).Where(n => !string.IsNullOrWhiteSpace(n));
try
{
GameId = int.Parse(resultGameNumber.First().ToString());
//Console.WriteLine($"GameNumber:: {GameId}");
playedGame.gameId = GameId;
}
catch (Exception ex)
{
Console.WriteLine($"Game is null number {ex.Message}");
}
}
//round level
else
{
char[] roundDelimters = { ',' };
string[] BallsInBags = word.ToLower().Split(roundDelimters);
//ballsInBag level
foreach (string ballsInBag in BallsInBags)
{
try
{
//BallColors
string ColorPattern = @"\d*\s";
string NumberPattern = @"\s[a-z]*";
IEnumerable<string> BallColor = Regex.Split(ballsInBag, ColorPattern, RegexOptions.IgnoreCase).Where(n => !string.IsNullOrWhiteSpace(n));
IEnumerable<string> ballNumber = Regex.Split(ballsInBag, NumberPattern, RegexOptions.IgnoreCase).Where(n => !string.IsNullOrWhiteSpace(n));
//BallNumbers - Pattern matching
if (BallColor.First() is "green")
{
GreenBalls = int.Parse(ballNumber.First());
}
if (BallColor.First() is "blue")
{
BlueBalls = int.Parse(ballNumber.First());
}
if (BallColor.First() is "red")
{
RedBalls = int.Parse(ballNumber.First());
}
}
catch (Exception ex)
{
Console.WriteLine($"No balls in bag:: {ex.Message}");
}
}
roundList.Add(new round(RedBalls, GreenBalls, BlueBalls));
}
}
foreach (round round in roundList)
{
playedGame.addRounds(round);
}
gameList.Add(playedGame);
roundList.Clear();
#endregion
}
//game level
foreach (game game in gameList)
{
playedGames.addGame(game);
}
#endregion

//results
Console.WriteLine($"\n>>>> SOLUTION TO STAR_THREE:: {playedGames.sumOfIdGamesPassed}");
Console.WriteLine($"\n>>>> SOLUTION TO STAR_FOUR:: {playedGames.sumOfThePower}");

#region classes
public static class cubeLimits
{
    public static int redCubes = 12;
    public static int greenCubes = 13;
    public static int blueCubes = 14;
}

public class round
{
    public int red { get; set; }
    public int green { get; set; }
    public int blue { get; set; }

    public round(int red, int green, int blue)
    {
        this.red = red;
        this.green = green;
        this.blue = blue;
    }
};

public class game
{
    public List<round> _allRounds = new List<round>();

    public int gameId { get; set; }
    public bool redPassed
    {
        get
        {

            bool redPassed = true;

            foreach (var item in _allRounds)
            {
                if (item.red == 0)
                {
                    redPassed = true;
                    break;
                }
                else
                {
                    if (item.red > cubeLimits.redCubes)
                    {
                        redPassed = false;
                        break;
                    }
                }
            }
            return redPassed;
        }
    }
    public bool greenPassed
    {
        get
        {
            bool greenPassed = true;
            foreach (var item in _allRounds)
            {
                if (item.green == 0)
                {
                    greenPassed = true;
                    break;
                }
                else
                {
                    if (item.green > cubeLimits.greenCubes)
                    {
                        greenPassed = false;
                        break;
                    }
                }
            }
            return greenPassed;
        }
    }
    public bool bluePassed
    {
        get
        {
            bool bleuPassed = true;
            foreach (var item in _allRounds)
            {
                if (item.blue == 0)
                {
                    bleuPassed = true;
                    break;
                }
                else
                {
                    if (item.blue > cubeLimits.blueCubes)
                    {
                        bleuPassed = false;
                        break;
                    }
                }
            }
            return bleuPassed;
        }
    }

    public int redMaxed
    {

        get
        {
            int redMaxed = 0;
            foreach (var searchMax in _allRounds)
            {
                redMaxed = redMaxed >= searchMax.red ? redMaxed : searchMax.red;
            }

            return redMaxed;
        }

    }
    public int greenMaxed
    {
        get
        {
            int greenMaxed = 0;
            foreach (var searchMax in _allRounds)
            {
                greenMaxed = greenMaxed >= searchMax.green ? greenMaxed : searchMax.green;
            }
            return greenMaxed;
        }
    }
    public int blueMaxed
    {
        get
        {
            int blueMaxed = 0;
            foreach (var searchMax in _allRounds)
            {
                blueMaxed = blueMaxed >= searchMax.blue ? blueMaxed : searchMax.blue;
            }
            return blueMaxed;
        }
    }
    public game() { }

    public void addRounds(round round)
    {
        _allRounds.Add(round);
    }
};

public class games
{
    private List<game> _allGames = new List<game>();

    public int sumOfThePower
    {
        get
        {
            int sumOfThePower = 0;
            foreach (var game in _allGames)
            {
                sumOfThePower = sumOfThePower + (game.redMaxed * game.greenMaxed * game.blueMaxed);
            }
            return sumOfThePower;
        }
    }

    public int sumOfIdGamesPassed
    {
        get
        {
            int sumOfIdGamesPassed = 0;
            if (_allGames.Count > 0)
            {
                foreach (var game in _allGames)
                {
                    if (game.redPassed && game.greenPassed && game.bluePassed)
                    {
                        sumOfIdGamesPassed = sumOfIdGamesPassed + game.gameId;
                    }
                }
            }
            return sumOfIdGamesPassed;
        }
    }

    public void addGame(game game)
    {
        _allGames.Add(game);
    }

};
#endregion

#endregion