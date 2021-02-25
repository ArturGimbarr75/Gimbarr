using Assets.Scripts.Models;
using Mono.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.DataBase.WorkoutElementTableNS
{
    static class WorkoutElementTable
    {
        public static int CurrentWorkoutID { get; set; }

        public static WorkoutElement GetWorkoutElementByID(int id)
        {
            string query =
                String.Format(
                "SELECT * FROM WorkoutElement " +
                "WHERE id == '{0}'",
                id);
            Func<SqliteDataReader, object> func =
                x => x.ConvertToWorkoutElement();

            var res = DataBase.ExecuteQueryWithAnswer(query, func) as WorkoutElement;

            return res;
        }

        public static List<WorkoutElement> GetWorkoutElements()
        {
            string query =
                String.Format(
                "SELECT * FROM WorkoutElement " +
                "WHERE workout_id == '{0}'",
                CurrentWorkoutID);
            Func<SqliteDataReader, object> func =
                x => x.ConvertToWorkoutElementList();

            var res = DataBase.ExecuteQueryWithAnswer(query, func) as List<WorkoutElement>;

            return res;
        }

        public static List<WorkoutElement> GetWorkoutElements(int workoutId)
        {
            string query =
                String.Format(
                "SELECT * FROM WorkoutElement " +
                "WHERE workout_id == '{0}'",
                workoutId);
            Func<SqliteDataReader, object> func =
                x => x.ConvertToWorkoutElementList();

            var res = DataBase.ExecuteQueryWithAnswer(query, func) as List<WorkoutElement>;

            return res;
        }

        public static int GetLastOrderIndex()
        {
            string query =
                String.Format(
                "SELECT MAX(element_order) FROM WorkoutElement " +
                "WHERE workout_id == '{0}'",
                CurrentWorkoutID);
            Func<SqliteDataReader, object> func =
                x => x["MAX(element_order)"];

            Int32.TryParse(DataBase.ExecuteQueryWithAnswer(query, func).ToString(), out int res);

            return res;
        }

        public static int GetCountOfCompletedElements()
        {
            string query =
                "SELECT COUNT(*) " +
                "FROM WorkoutElement";
 
            Func<SqliteDataReader, object> func =
                x => x["COUNT(*)"];

            Int32.TryParse(DataBase.ExecuteQueryWithAnswer(query, func).ToString(), out int res);

            return res;
        }

        public static int GetCountOfCompletedElementsInWorkout(int workoutId)
        {
            string query =
                String.Format(
                "SELECT COUNT(*) " +
                "FROM WorkoutElement " +
                "WHERE workout_id == '{0}'",
                workoutId);

            Func<SqliteDataReader, object> func =
                x => x["COUNT(*)"];

            Int32.TryParse(DataBase.ExecuteQueryWithAnswer(query, func).ToString(), out int res);

            return res;
        }

        public static int GetCountOfDifferentCompletedElements()
        {
            string query =
                "SELECT COUNT(DISTINCT(element_id)) " +
                "FROM WorkoutElement";

            Func<SqliteDataReader, object> func =
                x => x["COUNT(DISTINCT(element_id))"];

            Int32.TryParse(DataBase.ExecuteQueryWithAnswer(query, func).ToString(), out int res);

            return res;
        }

        public static void AddElementToWorkout(int order, int elementId)
        {
            string query =
                String.Format(
                "INSERT INTO WorkoutElement(workout_id, element_id, element_order) " +
                "VALUES ('{0}', '{1}', '{2}')",
                CurrentWorkoutID, elementId, order);
            DataBase.ExecuteQueryWithoutAnswer(query);
        }

        public static void AddElementToWorkout(int elementId)
        {
            int order = GetLastOrderIndex() + 1;
            AddElementToWorkout(order, elementId);
        }

        public static void DeleteElement(int id)
        {
            string query =
                String.Format(
                "DELETE FROM WorkoutElement " +
                "WHERE id == '{0}'",
                id);
            DataBase.ExecuteQueryWithoutAnswer(query);
        }

        public static void DeleteAllElements()
        {
            string query = "DELETE FROM WorkoutElement";
            DataBase.ExecuteQueryWithoutAnswer(query);
        }

        public static void DeleteAllWorkoutElements()
        {
            string query =
                String.Format(
                "DELETE FROM WorkoutElement " +
                "WHERE workout_id == '{0}'",
                CurrentWorkoutID);
            DataBase.ExecuteQueryWithoutAnswer(query);
        }

    }
}
