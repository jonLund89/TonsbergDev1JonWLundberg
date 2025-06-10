CREATE TABLE Observation (
    ObservationId INT IDENTITY(1,1) PRIMARY KEY,
    InvoiceId INT NOT NULL,
    TravelAgent NVARCHAR(100) NOT NULL,
    GuestName NVARCHAR(100) NOT NULL,
    NumberOfNights INT NOT NULL,
    FOREIGN KEY (TravelAgent) REFERENCES TravelAgent(TravelAgent)
);