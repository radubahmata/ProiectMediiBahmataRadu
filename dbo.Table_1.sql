﻿CREATE TABLE [dbo].[Contacte]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
	[nume] VARCHAR(MAX) NOT NULL,
    [nr_tel] VARCHAR(MAX) NOT NULL, 
    [mail] VARCHAR(MAX) NULL
   
)
