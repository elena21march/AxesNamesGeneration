
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AxesNamesGeneration
{
   
    public static class AxesNames
    {
        /// <summary>
        /// Выдает название файла осей
        /// </summary>
        /// <param name="hb">Hblock </param>
        /// <param name="classType">Комфорт или Стандарт класс</param>
        /// <returns></returns>
        /// 
        public static string GetAxes(HBlock hb, string classType)
        {
            string axesName;
            if (!String.IsNullOrEmpty(classType) && classType == "Стандарт")
                axesName = AxesNames.GenerateStandardAxesName(hb);
            else
                axesName = AxesNames.GenerateComfortAxesName(hb);
       
            return axesName;

        }

        private static string GenerateComfortAxesName(HBlock hb)
        {
            string hblockId = hb.Id;
            if (string.IsNullOrEmpty(hblockId)) return null;
            if (hblockId.Split('_').Length < 3) return null;

            if (hblockId.Contains("_T_"))
                return $"Axes_T_{hblockId.Split('_')[2]}.rvt";

           

            string lluId = hb.Levels
                .Where(lev=>lev.Llu!=null)
                .Select(lev=>lev.Llu.Id)
                .FirstOrDefault();

            if (string.IsNullOrEmpty(lluId)) return null;
            if (lluId.Split('_').Length < 2) return null;

            string lluSize = lluId.Split('_')[1];

            string axesName = string.Empty;

            
            if(hblockId.Contains("_A_") && !lluId.Contains("XL"))
                axesName = $"Axes_A_{hblockId.Split('_')[2]}.rvt";

            else if (hblockId.Contains("_A_") && lluId.Contains("XL"))
                axesName = $"Axes_AXL_{hblockId.Split('_')[2]}.rvt";

            else if (hblockId.Contains("_M_") || hblockId.Contains("_S_"))
                axesName = $"Axes_{lluSize}_{hblockId.Split('_')[2]}.rvt";

            return axesName;

        }

        



        private static string GenerateStandardAxesName(HBlock hb)
        {
            string hblockId = hb.Id;
            int floor = hb.StoreyNum;

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