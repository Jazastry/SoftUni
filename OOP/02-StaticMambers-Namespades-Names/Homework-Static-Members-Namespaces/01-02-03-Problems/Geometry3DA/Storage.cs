using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;


namespace Geometry3DA
{
    static class Storage
    {

        public static List<Point3D> ExtractPointListFromTxt(string file)
        {
            string path = file;

            // Open the file to read from. 
            using (StreamReader sr = File.OpenText(path))
            {
                string s = "";
                char delimeter = ',';
                List<Point3D> outPointsList = new List<Point3D>();
                Point3D currPoint = new Point3D(0, 0, 0);
                Regex matchRegex = new Regex(@"([XYZ= ]+[-\d]*[\.\d,]*)+");
                string replacePattern = @"[XYZ= ]+";
                double currX;
                double currY;
                double currZ;

                // Convert text lines to Point3D parameters
                while ((s = sr.ReadLine()) != null)
                {
                    Match myMatch = matchRegex.Match(s);
                    string matched = myMatch.Groups[0].Value;
                    string cleaned = Regex.Replace(matched, replacePattern, "");
                    string[] currNumbs = cleaned.Split(delimeter);
                    currX = Convert.ToDouble(currNumbs[0]);
                    currY = Convert.ToDouble(currNumbs[1]);
                    currZ = Convert.ToDouble(currNumbs[2]);
                    // Assign parameters to Point3D
                    currPoint = new Point3D(currX, currY, currZ);
                    // Add to Point3D List
                    outPointsList.Add(currPoint);
                }

                return outPointsList;
            }
        }

        public static void SavePathToTxt(string file, Path3D inPath)
        {
            string path = file;
            if (!File.Exists(path))
            {
                // Create a file to write to. 
                using (StreamWriter sw = File.CreateText(path))
                {
                    foreach (var item in inPath.PointsList3D)
                    {
                        sw.WriteLine(item);
                    }
                }
            }
        }
    }
}
