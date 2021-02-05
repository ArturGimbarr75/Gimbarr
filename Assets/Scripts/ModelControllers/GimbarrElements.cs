using Assets.Scripts.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.ModelControllers
{
    public class GimbarrElements
    {
        public static List<Element> AllElements { get; private set; }

        static GimbarrElements()
        {
            AllElements = new List<Element>();

            string json =
                "[{\"ID\":1,\"ElementName\":\"FK\",\"Url\":\"https://youtu.be/dG9FltncCcg?list=PLfyQgVxGVzz0VPL07KKzV-G6qngrfXm7j\",\"Style\":4}," +
                "{\"ID\":2,\"ElementName\":\"Lifestealer\",\"Url\":\"https://youtu.be/SbQW5kigOpc?list=PLfyQgVxGVzz0VPL07KKzV-G6qngrfXm7j\",\"Style\":4}," +
                "{\"ID\":3,\"ElementName\":\"Baler\",\"Url\":\"https://youtu.be/_3iUxXdzNxk?list=PLfyQgVxGVzz0VPL07KKzV-G6qngrfXm7j\",\"Style\":4}," +
                "{\"ID\":4,\"ElementName\":\"Granat\",\"Url\":\"https://youtu.be/SC197FYzV8s?list=PLfyQgVxGVzz0VPL07KKzV-G6qngrfXm7j\",\"Style\":4}," +
                "{\"ID\":5,\"ElementName\":\"Julia\",\"Url\":\"https://youtu.be/RYmR2pJ2pLk?list=PLfyQgVxGVzz0VPL07KKzV-G6qngrfXm7j\",\"Style\":4}," +
                "{\"ID\":6,\"ElementName\":\"Nekr Huisas\",\"Url\":\"https://youtu.be/Srt4BcnLWoA?list=PLfyQgVxGVzz0VPL07KKzV-G6qngrfXm7j\",\"Style\":4}," +
                "{\"ID\":7,\"ElementName\":\"Inframundo Big May\",\"Url\":\"https://youtu.be/iazJrnTrwWw?list=PLfyQgVxGVzz0VPL07KKzV-G6qngrfXm7j\",\"Style\":4}," +
                "{\"ID\":8,\"ElementName\":\"Encontrar\",\"Url\":\"https://youtu.be/n0L586IhQsg?list=PLfyQgVxGVzz0VPL07KKzV-G6qngrfXm7j\",\"Style\":4}," +
                "{\"ID\":9,\"ElementName\":\"Boomerang Slash\",\"Url\":\"https://youtu.be/TsfJnR-qoxI?list=PLfyQgVxGVzz0VPL07KKzV-G6qngrfXm7j\",\"Style\":4}," +
                "{\"ID\":10,\"ElementName\":\"Cocon Nivelado\",\"Url\":\"https://youtu.be/94DYu9jECHI?list=PLfyQgVxGVzz0VPL07KKzV-G6qngrfXm7j\",\"Style\":4}," +
                "{\"ID\":11,\"ElementName\":\"Skotch\",\"Url\":\"https://youtu.be/m8XqI2ZOuAE?list=PLfyQgVxGVzz0VPL07KKzV-G6qngrfXm7j\",\"Style\":4}," +
                "{\"ID\":12,\"ElementName\":\"Furious\",\"Url\":\"https://youtu.be/E2ndn_cxMh4?list=PLfyQgVxGVzz0VPL07KKzV-G6qngrfXm7j\",\"Style\":4}]";

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
