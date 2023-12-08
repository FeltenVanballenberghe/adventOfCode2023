using Helpers;

Console.WriteLine("Hello, AdventOfCode \n\n");
List<string> lineList = new List<string>();
lineList = InputTools.ReadAllLines("dayThree");

#region starFive
Console.WriteLine(lineList);
//ycoordinaat
int mapHeight = lineList.Count;
//xcoordinaat
int mapWidth = lineList[0].Length;

//map[y,x]
string[,] map = new string[mapHeight, mapWidth];
map = fillMap(lineList, map);

Console.WriteLine(map);

for (int y = 0; y < mapHeight; y++)
{
    for (int x = 0; x < mapWidth; x++)
    {
        Console.WriteLine(map[y, x]);
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
            width++;
        }
        height++;
    }
    height = 0;
    width = 0;
    return map;
}

#endregion