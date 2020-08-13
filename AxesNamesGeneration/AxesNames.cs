using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AxesNamesGeneration
{
    public class AxesNames
    {
        static void Main(string[] args)
        {
/*
            string csvPath = @"C:\Users\Настя\Desktop\axesName.csv";
            string[] allLines;
            allLines = System.IO.File.ReadAllLines(csvPath, Encoding.Default);

            var names = new List<string>();

            foreach (string line in allLines)
            {
                string id = line.Split(';')[0];
                string floor = line.Split(';')[1];
                int floorNum = int.Parse(floor);
                names.Add(GenerateAxesName(id, floorNum));

            }
            names.ToList().ForEach(i => Console.WriteLine(i.ToString()));
*/
        }



        /// <summary>
        /// Выдает название файла осей
        /// </summary>
        /// <param name="hblockId">Hblock Id</param>
        /// <param name="floor">Количество этажей в Hblock</param>
        /// <returns></returns>
        public static string GenerateAxesName(string hblockId, int floor)
        {
            if (string.IsNullOrEmpty(hblockId)) return null;
            if (hblockId.Split('_').Length < 3) return null;

            string axesName = string.Empty;

            if (hblockId.Contains("_A_"))
                axesName = $"Axes_A_{RoundFloorNumber(floor)}_{hblockId.Split('_')[2]}.rvt";

            else if (hblockId.Contains("_T_") && hblockId.Contains("x"))
                axesName = $"Axes_T_{hblockId.Split('_')[2]}_{RoundFloorNumber(floor)}LD.rvt";

            else if (hblockId.Contains("_T_") && !(hblockId.Contains("x")))
                axesName = $"Axes_T_{RoundFloorNumber(floor)}_{hblockId.Split('_')[2]}.rvt";

            else if (hblockId.Contains("_M_") || hblockId.Contains("_S_"))
                axesName = $"Axes_{RoundFloorNumber(floor)}_{hblockId.Split('_')[2]}.rvt";

            return axesName;

        }
        private static int RoundFloorNumber(int floor)
        {
            int stFloor = 0;
            if (floor <= 0)
                stFloor = 0;
            else if (floor <= 9)
                stFloor = 9;
            else if (floor <= 16)
                stFloor = 16;
            else if (floor <= 24)
                stFloor = 24;

            return stFloor;
        }
    }
    }