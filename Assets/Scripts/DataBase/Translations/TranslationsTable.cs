using Mono.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Assets.Scripts.SingletoneModel.TranslationSingletone;

namespace Assets.Scripts.DataBase.TranslationsTableNS
{
    static class TranslationsTable
    {
        public static string GetTranslation(Language language, int key_id)
        {
            string query =
                String.Format(
                "SELECT translation " +
                "FROM Translations " +
                "WHERE lang == '{0}' AND key_id == {1}",
                language.ToString(),
                key_id);

            Func<SqliteDataReader, object> func =
                x => x["translation"];

            var res = DataBase.ExecuteQueryWithAnswer(query, func) as string;

            return res;
        }

    }
}
