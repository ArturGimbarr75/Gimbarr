using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Models
{
    class WorkoutElement
    {
        public int ID { get; set; }
        public int WorkoutId { get; set; }
        public int ElementId { get; set; }
        public int Order { get; set; }

    }
}
