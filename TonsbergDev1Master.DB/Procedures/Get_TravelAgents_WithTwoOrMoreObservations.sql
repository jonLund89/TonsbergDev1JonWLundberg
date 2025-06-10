CREATE PROCEDURE Get_TravelAgents_WithTwoOrMoreObservations
AS
BEGIN
    SET NOCOUNT ON;

    SELECT ta.*
    FROM TravelAgent ta
    WHERE (
        SELECT COUNT(*) 
        FROM Observation o 
        WHERE o.TravelAgent = ta.TravelAgent
    ) > 2;
END;