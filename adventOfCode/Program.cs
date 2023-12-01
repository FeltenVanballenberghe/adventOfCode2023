// See https://aka.ms/new-console-template for more information
using System.Globalization;
using System.Reflection;

Console.WriteLine("Hello, World!");

try
{
    String file = "testFile.txt";
    String folder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    String filePath = Path.Combine(folder, "Assets/StarsInput/", file);
    String[] lines;
    
    using (var src = new StreamReader(filePath))
    {
        lines = src.ReadToEnd().Split(new char[] { '\n' });
    }
}
catch(Exception ex)
{
    Console.WriteLine(ex);
}
