using Mono.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.DataBase
{
    static class DataBase
    {
        private static string DataBasePath { get; set; }
        private static SqliteConnection Connection { get; set; }
        private static SqliteCommand Command { get; set; }

        private const string FILE_NAME = "GimbarrProjDB.db";

        static DataBase()
        {
            DataBasePath = GetDatabasePath();
        }

        private static string GetDatabasePath()
        {
        #if UNITY_EDITOR
            return Path.Combine(Application.streamingAssetsPath, FILE_NAME);
        #elif UNITY_STANDALONE
            string filePath = Path.Combine(Application.dataPath, FILE_NAME);
            if(!File.Exists(filePath)) UnpackDatabase(filePath);
            return filePath;
        #endif
        }

        private static void OpenConnection()
        {
            Connection = new SqliteConnection("Data Source=" + DataBasePath);
            Command = new SqliteCommand(Connection);
            Connection.Open();
        }

        private static void CloseConnection()
        {
            Connection.Close();
            Command.Dispose();
        }

        public static void ExecuteQueryWithoutAnswer(string query)
        {
            OpenConnection();
            Command.CommandText = query;
            Command.ExecuteNonQuery();
            CloseConnection();
        }

        public static string ExecuteQueryWithAnswer(string query)
        {
            OpenConnection();
            Command.CommandText = query;
            var answer = Command.ExecuteScalar();
            CloseConnection();

            if (answer != null)
                return answer.ToString();
            else
                return null;
        }
    }
}
