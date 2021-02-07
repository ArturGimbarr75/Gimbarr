using Assets.Scripts.ModelControllers;
using Assets.Scripts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.SingletoneModel
{
    class SelectedElement
    {
        public static SelectedElement Instance { get; set; }

        public Element Selected;

        static SelectedElement()
        {
            Instance = new SelectedElement()
            {
                Selected = GimbarrElements.AllElements.First()
            };
        }

        private SelectedElement()
        {

        }
    }
}
