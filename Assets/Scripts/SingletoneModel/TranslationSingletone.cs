using Assets.Scripts.DataBase.TranslationsTableNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.SingletoneModel
{
    class TranslationSingletone
    {
        public static TranslationSingletone Instance { get; private set; }

        public event EventHandler OnLanguageChanged;
        public Language CurrentLanguage { get; private set; }

        private Language[] AllLanguages;
        private int Index;

        public string GetTranslation(int keyId)
        {
            return TranslationsTable.GetTranslation(CurrentLanguage, keyId);
        }

        public void NextLanguage()
        {
            Index++;
            if (Index >= AllLanguages.Length)
                Index = 0;
            CurrentLanguage = AllLanguages[Index];
            OnLanguageChanged(null, null);
        }

        

        public enum Language
        {
            RU = 1,
            LT = 2,
            EN = 4,
            PL = 8
        }

        static TranslationSingletone()
        {
            Instance = new TranslationSingletone()
            {
                AllLanguages = (Language[])Enum.GetValues(typeof(Language)).Cast<Language>(),
                Index = 0
            };
        }
    }
}
