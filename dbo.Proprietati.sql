CREATE TABLE [dbo].[Proprietati]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [tip_oferta] VARCHAR(50) NULL, 
    [zona] VARCHAR(50) NULL, 
    [nr_camere] INT NULL, 
    [suprafata] INT NULL, 
    [amplasament] VARCHAR(50) NULL, 
    [adresa] TEXT NULL, 
    [pret] INT NULL, 
    [comision] INT NULL, 
    [id_contact] INT NOT NULL

)
