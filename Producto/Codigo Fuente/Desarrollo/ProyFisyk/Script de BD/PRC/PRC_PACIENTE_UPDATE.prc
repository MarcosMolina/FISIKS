CREATE OR REPLACE PROCEDURE FISIKS.PRC_PACIENTE_UPDATE (
    iPAEID                     IN PACIENTE.PAEID%TYPE :=NULL,
    iPAEPESO                IN PACIENTE.PAEPESO%TYPE :=NULL,
    iPAEALTURA            IN PACIENTE.PAEALTURA%TYPE := NULL,
    iPAETENSIONMAX    IN PACIENTE.PAETENSIONMAX%TYPE :=NULL,
    iPAETENSIONMIN     IN PACIENTE.PAETENSIONMIN%TYPE :=NULL,
    iPAEACTFISICA        IN PACIENTE.PAEACTFISICA%TYPE := NULL,
    iPAEPERIODICIDAD   IN PACIENTE.PAEPERIODICIDAD%TYPE := NULL,
    iPAE_OCUID             IN PACIENTE.PAE_OCUID %TYPE := NULL,
    iPAE_PSNID             IN PACIENTE.PAE_PSNID%TYPE)
AS
BEGIN
           
        UPDATE PACIENTE SET
            PAEPESO = iPAEPESO,
            PAEALTURA = iPAEALTURA,
            PAETENSIONMAX = iPAETENSIONMAX,
            PAETENSIONMIN = iPAETENSIONMIN,
            PAEACTFISICA = iPAEACTFISICA,
            PAEPERIODICIDAD = iPAEPERIODICIDAD,
            PAE_OCUID = iPAE_OCUID,
            PAE_PSNID =iPAE_PSNID
        WHERE PAEID = iPAEID;
        
END;
/
