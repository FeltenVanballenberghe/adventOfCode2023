// See https://aka.ms/new-console-template for more information
using System.Collections;
using System.Globalization;
using System.Reflection;
using System.Runtime.Serialization;

Console.WriteLine("Hello, AdventOfCode \n\n");

#region VARS
List<string> lineList = new List<string>();
string[] lines = new string[0];

#endregion

#region filereaderArray
try
{
    String file = "firstStar_test.txt";
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

#region star_two

string[][] jaggedArray={
    new string [] {"one", "1" },
    new string [] {"two", "2" },
    new string [] {"three", "3" },
    new string [] {"four", "4" },
    new string [] {"five", "5" },
    new string [] {"six", "6" },
    new string [] {"seven", "7" },
    new string [] {"eight", "8" },
    new string [] {"nine", "9" },
};

foreach (string line in lines)
{
    int positionInLine = 0;
    int lineLength = 0;

    foreach (char element in line)
    {
        lineLength = line.Length;
        positionInLine += 1;
        string[] word = new string [0];
        List<int> numbers = new List<int>();
        
        if(char.IsDigit(element)){
            Console.WriteLine($"Element is digit:: {element}");
            string[] positionNumber = new string[1];
            
            positionNumber[0] = positionInLine.ToString();
            positionNumber[1] = element.ToString();

            if (word.Count > 0)
            {
                Console.WriteLine(word[0]);
            }
        }
        else
        {
            Console.WriteLine($"Elemenet is string:: {element}");
            word.Add(element.ToString());
        }

        
    }
}


#endregion