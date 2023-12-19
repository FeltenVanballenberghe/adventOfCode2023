using Helpers;
using System.Text.RegularExpressions;
//ReadFile
List<string> lineList = new List<string>();
lineList = InputTools.ReadAllLines("inputTest");
bool SeedsLineFlag = true;
bool SoilFlag = false;
bool FertilizerFlag = false;
bool WaterFlag = false;
bool LightFlag = false;
bool TemperatureFlag = false;
bool HumidityFlag = false;
bool locationFlag = false;

string seedPattern = @"(^[a-z]+:)";
string mapPattern = @"([a-z]+.+[a-z]+:)";


List<Seed> Seeds = new List<Seed>();
Dictionary<int[], int[]> SoilDictionary = new Dictionary<int[], int[]>();
Dictionary<int[], int[]> FertilizerDictionary = new Dictionary<int[], int[]>();
Dictionary<int[], int[]> WaterDictionary = new Dictionary<int[], int[]>();
Dictionary<int[], int[]> LightDictionary = new Dictionary<int[], int[]>();
Dictionary<int[], int[]> TemperatureDictionary = new Dictionary<int[], int[]>();
Dictionary<int[], int[]> HumidityDictionary = new Dictionary<int[], int[]>();
Dictionary<int[], int[]> locationDictionary = new Dictionary<int[], int[]>();

foreach (string line in lineList)
{
    //regex
    
    List<string>? SeedsLineResult = Regex.Split(line, seedPattern, RegexOptions.IgnorePatternWhitespace).Where((x)=>!string.IsNullOrWhiteSpace(x)).ToList();
    if(SeedsLineResult.Count > 0)
    {
        if (SeedsLineResult.First() is "seeds:" && SeedsLineFlag)
        {
            string seedNrPattern = @"\s+";
            List<string>? SeedsNrs = Regex.Split(SeedsLineResult.Last(), seedNrPattern, RegexOptions.IgnorePatternWhitespace).Where((x) => !string.IsNullOrWhiteSpace(x)).ToList();
            foreach (string SeedNr in SeedsNrs)
            {
                Seed newSeed = new Seed()
                {
                    seedId = int.Parse(SeedNr),
                };
                Seeds.Add(newSeed);
            }
            SeedsLineFlag = false;
        }
        else
        {
            switch (SeedsLineResult.First())
            {
                case "seed-to-soil map:":
                    SoilFlag= true;break;
                case "soil-to-fertilizer map:":
                    FertilizerFlag= true; break;
                case "fertilizer-to-water map:":
                    WaterFlag= true;break;
                case "water-to-light map:":
                    LightFlag= true;break;
                case "light-to-temperature map:":
                    TemperatureFlag= true;break;
                case "temperature-to-humidity map":
                    HumidityFlag= true;break;
                case "humidity-to-location map":
                    locationFlag= true; break;
                default:
                    break;

            }

            bool IsMatch = Regex.Match(SeedsLineResult.First(), mapPattern).Success;
            if (!IsMatch && SeedsLineResult.First() != "")
            {
                string mapPatternNrs = @"\s+";
                List<string> soilResult = Regex.Split(SeedsLineResult.First(), mapPatternNrs, RegexOptions.IgnorePatternWhitespace).Where((x) => !string.IsNullOrWhiteSpace(x)).ToList();

                int DestionationElement = int.Parse(soilResult.First());
                int SourceElement = int.Parse(soilResult.ElementAt(1));
                int RangeElement = int.Parse(soilResult.Last()) > 0 ? int.Parse(soilResult.Last()) - 1 : 0;
                int[] Key = new int[] { DestionationElement, DestionationElement + RangeElement };
                int[] Value = new int[] { SourceElement, SourceElement + RangeElement }; ;
                //TODO CHECK LOGIC!
                if (locationFlag)
                {
                    locationDictionary[Key] = Value;
                }
                else if (HumidityFlag)
                {
                    HumidityDictionary[Key] = Value;
                }
                else if (TemperatureFlag)
                {
                    TemperatureDictionary[Key] = Value;
                }
                else if (LightFlag)
                {
                    LightDictionary[Key] = Value;

                }
                else if (WaterFlag)
                {
                    WaterDictionary[Key] = Value;
                }
                else if (FertilizerFlag)
                {
                    SoilDictionary[Key] = Value;
                }
                else if (SoilFlag)
                {
                    SoilDictionary[Key] = Value;
                }
                                        
            }
            //LIST {DICTIONARY SOIL - DICTIONARY FERTIZ - ...} MATCHED on destination
        }
    }
  


}


public class Seed
{
    public int seedId { get; set;}
}

public class RangeMap
{
    public int RangeMapId { get; set; }
    public string? RangeMapName { get; set;}
    int[,] FirstWord { get; set;}
    int[,] lastWord { get; set; }
}

