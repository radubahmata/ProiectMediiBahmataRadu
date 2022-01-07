CREATE TABLE [dbo].[Activitati]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [id_contact1] INT NOT NULL, 
    [id_contact2] INT NULL, 
    [data] DATETIME NOT NULL, 
    [id_proprietate] INT NULL, 
)
