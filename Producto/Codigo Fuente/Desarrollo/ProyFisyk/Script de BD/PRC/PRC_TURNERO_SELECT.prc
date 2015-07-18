CREATE OR REPLACE PROCEDURE FISIKS.PRC_TURNERO_SELECT (
    iTurFechaIni                IN TURNERO.TURFECHAINI%TYPE,
    iTurFechaFin               IN TURNERO.TURFECHAFIN%TYPE,
    oCursorTurnero          OUT sys_refcursor)
AS
BEGIN
    
    OPEN oCursorTurnero FOR 
    SELECT * 
    FROM    TURNERO
    WHERE TURFECHAINI >= iturfechaini
    AND     TURFECHAFIN <=iturfechafin;

END;
/
