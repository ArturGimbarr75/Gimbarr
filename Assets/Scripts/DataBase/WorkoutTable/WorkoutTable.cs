using Assets.Scripts.DataBase.WorkoutElementTableNS;
using Assets.Scripts.Models;
using Mono.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.DataBase.WorkoutTableNS
{
    static class WorkoutTable
    {
        public static bool HasUnfinishedWorkout()
            => HasUnfinishedWorkouts(out int x);

        public static bool HasUnfinishedWorkouts(out int workoutId)
        {
            string query =
                "SELECT * " +
                "FROM Workout " +
                "WHERE end IS NULL";
            Func<SqliteDataReader, object> func =
                x => x.ConvertToWorkoutList();

            var resList = DataBase.ExecuteQueryWithAnswer(query, func) as List<Workout>;
            var res =
                resList.Count > 1 ?
                    resList.Find(x => x.Start == resList.Max(y => y.Start))
                :
                    resList.First();

            if (resList.Count > 1)
                EndWorkouts(resList.Where(x => x.ID != res.ID).ToList());

            if (res != null)
            {
                workoutId = res.ID;
                return true;
            }
            else
            {
                workoutId = -1;
                return false;
            }
        }

        public static void StartWorkout(out int workoutId)
        {
            string query =
                "INSERT INTO Workout(start) " +
                "VALUES (CURRENT_TIMESTAMP)";
            DataBase.ExecuteQueryWithoutAnswer(query);

            HasUnfinishedWorkouts(out workoutId);
        }

        public static void EndWorkout()
        {
            int id;
            if (!HasUnfinishedWorkouts(out id))
                return;
            EndWorkout(id);
        }

        private static void EndWorkout(int workoutId)
        {
            string query = String.Format(
                "UPDATE Workout " +
                "SET end = CURRENT_TIMESTAMP " +
                "WHERE id == '{0}'"
                , workoutId);

            DataBase.ExecuteQueryWithoutAnswer(query);
        }

        public static void DeleteWorkout(int workoutId)
        {
            string query = String.Format(
                "DELETE FROM Workout " +
                "WHERE id == '{0}'"
                , workoutId);

            WorkoutElementTable.CurrentWorkoutID = workoutId;
            WorkoutElementTable.DeleteAllWorkoutElements();

            DataBase.ExecuteQueryWithoutAnswer(query);
        }

        public static void DeleteAllWorkouts()
        {
            string query = "DELETE FROM Workout";

            WorkoutElementTable.DeleteAllElements();
            DataBase.ExecuteQueryWithoutAnswer(query);
        }

        public static List<Workout> GetAllCompletedWorkoutsWithElementsCount(out List<int> elements)
        {
            var resList = GetAllCompletedWorkouts();
            elements = new List<int>();

            for (int i = 0; i < resList.Count; i++)
                elements.Add(WorkoutElementTable.GetCountOfCompletedElementsInWorkout(resList[i].ID));

            return resList;
        }

        public static List<Workout> GetAllCompletedWorkouts()
        {
            string query =
                "SELECT * " +
                "FROM Workout " +
                "WHERE end NOT NULL";
            Func<SqliteDataReader, object> func =
                x => x.ConvertToWorkoutList();

            var resList = DataBase.ExecuteQueryWithAnswer(query, func) as List<Workout>;

            return resList;
        }

        public static Workout GetWorkoutByID(int workoutId)
        {
            string query =
                String.Format(
                "SELECT * " +
                "FROM Workout " +
                "WHERE id == '{0}'"
                , workoutId);
            Func<SqliteDataReader, object> func =
                x => x.ConvertToWorkout();

            var res = DataBase.ExecuteQueryWithAnswer(query, func) as Workout;

            return res;
        }

        public static int GetCountOfCompletedWorkouts()
        {
            string query =
                "SELECT COUNT(*) " +
                "FROM Workout " +
                "WHERE end NOT NULL";

            Func<SqliteDataReader, object> func =
                x => x["COUNT(*)"];

            Int32.TryParse(DataBase.ExecuteQueryWithAnswer(query, func).ToString(), out int res);

            return res;
        }

        private static void EndWorkouts(List<Workout> workouts)
        {
            foreach (var workout in workouts)
                EndWorkout(workout.ID);
        }
    }
}
