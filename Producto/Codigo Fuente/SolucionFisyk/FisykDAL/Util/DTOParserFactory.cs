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
                case "PacienteDTO":
                    return new DP_Paciente();
                case "ObraSocialDTO":
                    return new DP_ObraSocial();
                case "OcupacionesDTO":
                   return new DP_Ocupaciones();
               /*case "PriorityDTO":
                   return new DTOParser_Priority();
               case "SeverityDTO":
                   return new DTOParser_Severity();
           */
            }

            throw new Exception("Unknown Type");
        }
    }
}
