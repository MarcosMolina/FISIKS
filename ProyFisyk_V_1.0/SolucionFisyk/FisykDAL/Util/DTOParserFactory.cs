using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FisykDAL
{
    internal static class DTOParserFactory
    {
        // GetParser
        internal static DTOParserSQLOracle GetParserOracleClient(System.Type DTOType)
        {
            switch (DTOType.Name)
            {
                /*case "CaseDTO":
                    return new DTOParser_Case();
                case "CaseTypeDTO":
                    return new DTOParser_CaseType();
                case "ClientDTO":
                    return new DTOParser_Client();
                case "PriorityDTO":
                    return new DTOParser_Priority();
                case "SeverityDTO":
                    return new DTOParser_Severity();
            */
            }
       
            throw new Exception("Unknown Type");
        }
    }
}
