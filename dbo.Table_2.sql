CREATE TABLE [dbo].[Cereri]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [id_contact] INT NOT NULL, 
    [buget] INT NULL, 
    [nr_camere_min] INT NULL, 
    [nr_camere_max] INT NULL, 
    [suprafata_min] INT NULL, 
    [suprafata_max] INT NULL, 
    [descriere] TEXT NULL

	CONSTRAINT fk_cereri_id_contact
	FOREIGN KEY (id_contact)
	REFERENCES Contacte (Id)
	ON DELETE CASCADE
	ON UPDATE CASCADE
)
