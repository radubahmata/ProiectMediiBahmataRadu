CREATE TABLE [dbo].[Proprietati]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [tip_oferta] VARCHAR(50) NOT NULL, 
    [zona] VARCHAR(50) NOT NULL, 
    [nr_camere] INT NOT NULL, 
    [suprafata] INT NOT NULL, 
    [amplasament] VARCHAR(50) NULL, 
    [adresa] TEXT NOT NULL, 
    [pret] INT NOT NULL, 
    [comision] INT NULL, 
    [id_contact] INT NOT NULL
	
	CONSTRAINT fk_proprietati_id_contact
	FOREIGN KEY (id_contact)
	REFERENCES Contacte (Id)
	ON DELETE CASCADE
	ON UPDATE CASCADE
)
