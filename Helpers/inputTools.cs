using System.Reflection;

namespace Helpers;

public static class InputTools
{
    public static List<string> ReadAllLines(string fileName)
    {
        #region VARS
        List<string> lineList = new List<string>();
        #endregion

        #region filereaderArray
        try
        {
            //String file = "fifthStar_test.txt";
            string file = string.Concat(fileName, ".txt");
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
            Console.Write("#####File reader####\n");
            Console.Write($"\tFile read:: {file}\n");
            Console.WriteLine($"\tNumber of lines (array):: {lineList.Count}");
            Console.WriteLine($"\tLength one one line:: {lineList[0].Length}");
            Console.Write("#####End of file reader####\n\n");
            return lineList;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"File not read:: {ex.Message}");
        }
        return null;
        #endregion
    }
}

