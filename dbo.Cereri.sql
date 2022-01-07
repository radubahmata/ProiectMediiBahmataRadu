CREATE TABLE [dbo].[Cereri]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [id_contact] INT NOT NULL, 
    [buget] INT NULL, 
    [nr_camere_min] INT NULL, 
    [nr_camere_max] INT NULL, 
    [suprafata_min] INT NULL, 
    [suprafata_max] INT NULL, 
    [tranzactie] VARCHAR(50) NULL
)
