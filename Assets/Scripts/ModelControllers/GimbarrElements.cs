using Assets.Scripts.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.ModelControllers
{
    public class GimbarrElements
    {
        public static List<Element> AllElements { get; private set; }

        static GimbarrElements()
        {
            string json = (Resources.Load("Elements") as TextAsset).ToString();
            AllElements = JsonConvert.DeserializeObject<List<Element>>(json);
        }

        public enum GimbarrStyle
        {
            Figuras = 1,
            Giros = 2,
            Yoyos = 4,

            All = Figuras | Giros | Yoyos,
            None = 0
        }
    }
}
