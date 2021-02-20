using Assets.Scripts.Models;
using Mono.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.DataBase.WorkoutTableNS
{
    static class WorkoutExtensions
    {
        public static Workout ConvertToWorkout(this SqliteDataReader reader)
        {
            Int32.TryParse(reader["id"].ToString(), out int id);
            DateTime.TryParse(reader["start"].ToString(), out DateTime start);
            DateTime.TryParse(reader["end"].ToString(), out DateTime end);

            return new Workout()
               {
                   ID = id,
                   Start = start,
                   End = end
               };
        }
            

        public static List<Workout> ConvertToWorkoutList(this SqliteDataReader reader)
        {
            List<Workout> res = new List<Workout>();
            while (reader.Read())
                res.Add(reader.ConvertToWorkout());

            return res;
        }
    }
}
