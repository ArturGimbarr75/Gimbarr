using Assets.Scripts.ModelControllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Models
{
    public class Element
    {
        public int ID { get; set; }
        public string ElementName { get; set; }
        public string Url { get; set; }
        public GimbarrElements.GimbarrStyle Style { get; set; }

        public override string ToString()
        {
            return $"{ElementName} ID: {ID}";
        }
    }
}
