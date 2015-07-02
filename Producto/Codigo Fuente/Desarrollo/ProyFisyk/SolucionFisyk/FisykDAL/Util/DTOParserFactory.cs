using System;
using FisykDAL.Parsers;
using FisykDAL.Util;

namespace FisykDAL
{
    internal static class DtoParserFactory
    {
        // GetParser
        internal static DtoParserSqlOracle GetParserOracleClient(Type dtoType)
        {
            switch (dtoType.Name)
            {
                case "PacienteDto":
                    return new DpPaciente();
                case "ObraSocialDto":
                    return new DpObraSocial();
                case "OcupacionesDto":
                   return new DpOcupaciones();
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
