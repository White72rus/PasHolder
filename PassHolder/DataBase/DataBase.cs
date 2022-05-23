using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassHolder.DataBase
{
    internal class DataBase
    {
        #region Private properties

        #endregion

        #region Public properties

        #endregion

        internal DataBase()
        {
            Initialize();
        }

        private void Initialize()
        {
            if (!DataFiles.IsDataFileExists())
            {
                IEnumerable<string> temp = new List<string>
                {
                    DataFiles.Hash,
                    "Line 2",
                    "Line 3",
                    "Line 4",
                };

                DataFiles.WriteLinesToFile(ref temp);
            }
        }

        internal string GetDataForAuth()
        {
            return DataFiles.ReadLinesFromFile(1, 1).ToArray()[0];
        }
    }
}
