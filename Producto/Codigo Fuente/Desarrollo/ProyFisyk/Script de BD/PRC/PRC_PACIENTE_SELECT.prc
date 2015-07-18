CREATE OR REPLACE PROCEDURE FISIKS.PRC_PACIENTE_SELECT (
    iPsnnrodcto               IN PERSONA.PSNNRODCTO %TYPE,
    oCursorPersona          OUT sys_refcursor)
AS
BEGIN
    
    OPEN oCursorPersona FOR 
   SELECT   *
   FROM     PERSONA , PACIENTE 
   WHERE   PAE_PSNID = PSNID 
   AND       PSNNRODCTO = iPsnnrodcto
   AND       ROWNUM < 2;
END;
/
