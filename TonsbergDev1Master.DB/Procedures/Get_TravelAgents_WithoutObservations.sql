CREATE PROCEDURE Get_TravelAgents_WithoutObservations
AS
BEGIN
    SET NOCOUNT ON;

    SELECT ta.*
    FROM TravelAgent ta
    WHERE NOT EXISTS (
        SELECT 1
        FROM Observation o
        WHERE o.TravelAgent = ta.TravelAgent
    );
END;