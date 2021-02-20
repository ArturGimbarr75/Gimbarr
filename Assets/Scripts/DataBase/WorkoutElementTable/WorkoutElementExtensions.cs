using Assets.Scripts.Models;
using Mono.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.DataBase.WorkoutElementTableNS
{
    static class WorkoutElementExtensions
    {
        public static WorkoutElement ConvertToWorkoutElement(this SqliteDataReader reader)
        {
            Int32.TryParse(reader["id"].ToString(), out int id);
            Int32.TryParse(reader["workout_id"].ToString(), out int workoutID);
            Int32.TryParse(reader["element_id"].ToString(), out int elementID);
            Int32.TryParse(reader["element_order"].ToString(), out int order);

            return new WorkoutElement()
            {
                ID = id,
                WorkoutId = workoutID,
                ElementId = elementID,
                Order = order
            };
        }

        public static List<WorkoutElement> ConvertToWorkoutElementList(this SqliteDataReader reader)
        {
            List<WorkoutElement> res = new List<WorkoutElement>();
            while (reader.Read())
                res.Add(reader.ConvertToWorkoutElement());

            return res;
        }
    }
}
