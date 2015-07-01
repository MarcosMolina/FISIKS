using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using FisiksAppWeb;

namespace FisykDAL
{
    internal abstract class DTOParserSQLOracle : DTOParser
    {
        abstract internal DTOBase PopulateDTO(OracleDataReader reader);
        abstract internal void PopulateOrdinals(OracleDataReader reader);
        internal int GetOrdinalOrThrow(OracleDataReader reader, string columnName)
        {
            try
            {
                return reader.GetOrdinal(columnName);
            }
            catch (IndexOutOfRangeException)
            {
                return -1;
            }
        }
    }
}
