using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.SingletoneModel
{
    class FunctionInElementsList
    {
        public static FunctionInElementsList Instance { get; private set; }
        public FunctionType Function { get; set; }

        static FunctionInElementsList()
        {
            Instance = new FunctionInElementsList()
            {
                Function = FunctionType.Info
            };
        }

        public enum FunctionType
        {
            Info,
            Choice
        }
    }
}
