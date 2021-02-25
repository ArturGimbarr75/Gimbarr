using Assets.Scripts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.SingletoneModel
{
    class SelectedWorkout
    {
        public static SelectedWorkout Instance { get; set; }

        public Workout Selected;

        static SelectedWorkout()
        {
            Instance = new SelectedWorkout()
            {
                Selected = new Workout()
                {
                    ID = 1
                }
            };
        }
    }
}
