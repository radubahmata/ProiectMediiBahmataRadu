CREATE TABLE [dbo].[Activitati]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [id_contact] INT NOT NULL,  
    [data] DATETIME NOT NULL, 
    [id_proprietate] INT NULL, 
    [descriere] VARCHAR(MAX) NULL, 

	CONSTRAINT fk_activitati_id_contact
	FOREIGN KEY (id_contact)
	REFERENCES Contacte(Id)
	ON DELETE CASCADE
	ON UPDATE CASCADE,
	CONSTRAINT fk_activitati_id_proprietate
	FOREIGN KEY (id_proprietate)
	REFERENCES Proprietati(Id)
	ON DELETE CASCADE
	ON UPDATE CASCADE
)
