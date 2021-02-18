using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Models
{
    class Translation
    {
        public int ID { get; set; }
        public int KeyID { get; set; }
        public string Lang { get; set; }
        public string TranslationText { get; set; }
    }
}
