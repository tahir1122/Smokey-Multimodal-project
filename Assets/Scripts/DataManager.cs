using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour {

    public static List<double> longitude;
    public static List<double> lattitude;

    public static int samples;
    public static string dataSet;

    //Smokey App specific map values used for normalization
    //public static double xLLCorner = -84.000170502881;     //map corner, longitude value
    //public static double yLLCorner = 35.42670692277;       //map corner, lattitude value
    //public static double cellSize = 0.000308;              //cell size in degrees (meridian values)
    //public static double tarCols = 457;                    //number of columns on target image
    //public static double tarRows = 320;                    //number of rows on target image
    //public static double nCols = 3128;                     //number of columns on background
    //public static double nRows = 1192;                     //number of rows on background


    public static double xLLCorner = -84.060170502881;     //map corner, longitude value
    public static double yLLCorner = 35.49670692277;       //map corner, lattitude value
    public static double cellSize = 0.000305;              //cell size in degrees (meridian values)
    public static double tarCols = 3400;                    //number of columns on target image
    public static double tarRows = 1;                    //number of rows on target image
    public static double nCols = 3128;                     //number of columns on background
    public static double nRows = 1200;

    public static List<List<double>> envData;
    public static List<List<double>> axisRanges;
    public static List<List<double>> envData_new;
    public static List<List<double>> axisRanges_new;

    public static SmokeyController SC = new SmokeyController();

    // Load selected data
    public static void LoadData(string selection){
        longitude = new List<double>();
        lattitude = new List<double>();
        samples = 0;
        dataSet = selection;

        List<string> tempList = new List<string>();
        TextAsset mydata = Resources.Load(selection) as TextAsset;
        tempList = TextAssetToList(mydata);

        bool firstPass = true;
        foreach (string line in tempList)
        {   
            if (firstPass == false && line.Length != 0)
            {
                var values = line.Split(',');
                longitude.Add(double.Parse(values[6]));
                lattitude.Add(double.Parse(values[7]));
                samples += 1;
            }
            firstPass = false;
        }

        //longitude = MinMaxNormalize(longitude);
        //lattitude = MinMaxNormalize(lattitude);
        longitude = NormalizeSmokeyLon(longitude);
        lattitude = NormalizeSmokeyLat(lattitude);
    }
	
    //load environmental data
    public static void LoadEnvData(string selection, int columns, List<string> speciesList){
        envData = new List<List<double>>();
        axisRanges = new  List<List<double>>();

        samples = 0;
        dataSet = selection;

        List<string> tempList = new List<string>();
        TextAsset mydata = Resources.Load(selection) as TextAsset;
        tempList = TextAssetToList(mydata);

        List<double> tempData;

        bool firstPass = true;
        foreach (string line in tempList)
        {   
            if (firstPass == false && line.Length != 0)
            {
                var values = line.Split(',');

                if (speciesList.Contains(values[0]))
                {   
                    tempData = new List<double>();

                    for (int i = 1; i < columns+1; i++)
                    {
                        tempData.Add(double.Parse(values[i]));
                    }
                    envData.Add(tempData);
                } 
                samples += 1;
            }
            firstPass = false;
        }
        axisRanges = FindRanges(envData);
    }

    public static void LoadEnvData_new(string selection, int columns, List<string> speciesList)
    {
        envData_new = new List<List<double>>();
        axisRanges_new = new List<List<double>>();

        samples = 0;
        dataSet = selection;

        List<string> tempList = new List<string>();
        TextAsset mydata = Resources.Load(selection) as TextAsset;
        tempList = TextAssetToList(mydata);

        List<double> tempData;

        bool firstPass = true;
        foreach (string line in tempList)
        {
            if (firstPass == false && line.Length != 0)
            {
                var values = line.Split(',');

                if (speciesList.Contains(values[0]))
                {
                    tempData = new List<double>();

                    for (int i = 1; i < columns + 1; i++)
                    {
                        tempData.Add(double.Parse(values[i]));
                    }
                    envData_new.Add(tempData);
                }
                samples += 1;
            }
            firstPass = false;
        }
        axisRanges_new = FindRanges(envData_new);
    }


    //Converst text asset (data set) to list
    private static List<string> TextAssetToList(TextAsset ta)
    {
        return new List<string>(ta.text.Split('\n'));
    }


    public static List<double> MinMaxNormalize(List<double> list)
    {
        double maxValue = list.Max();
        double minValue = list.Min();

        for (int i = 0; i < list.Count; i++)
        {
            list[i] = (list[i] - minValue) / (maxValue - minValue);
        } 
        return list; 
    }


    public static List<double> NormalizeSmokeyLon(List<double> list)
    {
        for (int i = 0; i < list.Count; i++)
        {   //normalize[  (X     -    Xmin)   /  (Xmax - Xmin)  ]  #Scale to map size    #Adjust for central orgin on target image
            list[i] = (((list[i] - xLLCorner) / (nCols*cellSize))  *  (nCols/tarCols)     - .5f);
        } 
        return list; 
    }


    public static List<double> NormalizeSmokeyLat(List<double> list)
    {
        for (int i = 0; i < list.Count; i++)
        {    //normalize[  (X    -    Xmin)   /  (Xmax - Xmin)  ]  #change range (-1 to 0)   #Scale to map size   #target height is < 1, scale    #Adjust for central orgin on target image
            list[i] = ((((list[i] - yLLCorner) / (nRows*cellSize))       -   1f  )           *  (nRows/tarRows)    *  (tarRows/tarCols)             +0.3496);
        } 
        return list; 
    }

    public static List<List<double>> FindRanges(List<List<double>> dataList)
    {   
        List<List<double>> ranges = new List<List<double>>();
        double max = -9999;
        double min = 9999;

        for (int j = 0; j < dataList[0].Count; j++)
        {
            for (int i = 0; i < dataList.Count; i++)
            {
                if (dataList[i][j] > max)
                {
                    max = dataList[i][j];
                }
                if (dataList[i][j] < min)
                {
                    min = dataList[i][j];
                }
            }
            ranges.Add(new List<double> {min,max});

        }
        return ranges;
    }
}
