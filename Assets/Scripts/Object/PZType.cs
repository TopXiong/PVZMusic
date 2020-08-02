using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace PZObject
{
    public enum PlantType
    {
        NULL,SunFlower,Shovel,Marigold
    }

    public static class DataValue
    {
        public static Color deep = new Color(52f / 255f, 68f / 255f, 78f / 255f);
        public static Color light = new Color(65f / 255f, 84f / 255f, 96f / 255f);
    }
}
