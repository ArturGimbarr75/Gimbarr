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
            var dbPath = string.Format(@"Assets/StreamingAssets/{0}", FILE_NAME);
        #else
        var filepath = string.Format("{0}/{1}", Application.persistentDataPath, FILE_NAME);

        if (!File.Exists(filepath))
        {

        #if UNITY_ANDROID
            var loadDb = new WWW("jar:file://" + Application.dataPath + "!/assets/" + FILE_NAME);
            while (!loadDb.isDone) { }
            File.WriteAllBytes(filepath, loadDb.bytes);
        #elif UNITY_IOS
                 var loadDb = Application.dataPath + "/Raw/" + FILE_NAME;
                File.Copy(loadDb, filepath);
        #elif UNITY_WP8
                var loadDb = Application.dataPath + "/StreamingAssets/" + FILE_NAME;
                File.Copy(loadDb, filepath);

        #elif UNITY_WINRT
		    var loadDb = Application.dataPath + "/StreamingAssets/" + FILE_NAME;
		    File.Copy(loadDb, filepath);
        #else
	        var loadDb = Application.dataPath + "/StreamingAssets/" + FILE_NAME;
	        File.Copy(loadDb, filepath);

        #endif

            Debug.Log("Database written");
        }

        var dbPath = filepath;
        #endif
            return dbPath;
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

        public static object ExecuteQueryWithAnswer(string query, Func<SqliteDataReader, object> funcRes)
        {
            OpenConnection();
            Command.CommandText = query;
            var answer = funcRes(Command.ExecuteReader());
            CloseConnection();

            return answer;
        }
    }
}
