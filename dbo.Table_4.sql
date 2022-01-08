CREATE TABLE [dbo].[Facturi]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [id_contact] INT NOT NULL, 
    [suma] INT NOT NULL, 
    [data] DATE NOT NULL, 
    [id_proprietate] INT NOT NULL

	CONSTRAINT fk_facturi_id_contact
 FOREIGN KEY (id_contact)
 REFERENCES Contacte (Id)
 ON DELETE CASCADE
ON UPDATE CASCADE,
CONSTRAINT fk_facturi_id_proprietate
FOREIGN KEY (id_proprietate)
 REFERENCES Proprietati (Id)
 ON DELETE CASCADE
ON UPDATE CASCADE
)

