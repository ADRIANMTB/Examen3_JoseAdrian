CREATE DATABASE BD_JoseAdrian;
USE BD_JoseAdrian;

CREATE TABLE Encuestas (
    NumeroEncuesta INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL,
    FechaNacimiento DATE NOT NULL,
    CorreoElectronico NVARCHAR(50) NOT NULL,
    PartidoID NVARCHAR(10) NOT NULL
);

CREATE TABLE PartidosPoliticos (
    PartidoID INT IDENTITY(1,1) PRIMARY KEY,
    NombrePartido NVARCHAR(50) NOT NULL
);

INSERT INTO PartidosPoliticos (NombrePartido) VALUES ('PUSC'), ('PAC'), ('PLN');

CREATE PROCEDURE AgregarEncuesta (
    @p_Nombre NVARCHAR(50),
    @p_FechaNacimiento DATE,
    @p_CorreoElectronico NVARCHAR(50),
    @p_PartidoID NVARCHAR(10)
)
AS
BEGIN
    IF (DATEDIFF(YEAR, @p_FechaNacimiento, GETDATE()) BETWEEN 18 AND 50)
    BEGIN
        INSERT INTO Encuestas (Nombre, FechaNacimiento, CorreoElectronico, PartidoID)
        VALUES (@p_Nombre, @p_FechaNacimiento, @p_CorreoElectronico, @p_PartidoID);
    END
END;

CREATE PROCEDURE GenerarReporte
AS
BEGIN
    SELECT E.NumeroEncuesta, E.Nombre, E.FechaNacimiento, E.CorreoElectronico, P.NombrePartido AS PartidoPolitico
    FROM Encuestas E
    INNER JOIN PartidosPoliticos P ON E.PartidoID = P.PartidoID;
END;
