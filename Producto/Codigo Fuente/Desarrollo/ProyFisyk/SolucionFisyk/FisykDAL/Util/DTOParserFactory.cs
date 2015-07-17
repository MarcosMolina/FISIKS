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
                case "PacienteOsDto":
                    return new DpPacienteOs();
                case "ObraSocialDto":
                    return new DpObraSocial();
                case "OcupacionesDto":
                   return new DpOcupaciones();
                case "AntecedenteMedicoDto":
                   return new DpAntecedenteMedico();
            }

            throw new Exception("Unknown Type");
        }
    }
}
