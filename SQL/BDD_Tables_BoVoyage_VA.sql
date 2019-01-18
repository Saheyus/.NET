

--CREATE DATABASE BoVoyage_VA;

--USE BoVoyage_VA;

/*

DROP TABLE Individus;
DROP TABLE Participants;
DROP TABLE Personnel;
DROP TABLE Liste_Participants;
DROP TABLE Dossiers;
DROP TABLE Assurances;
DROP TABLE Voyages;
DROP TABLE Destinations;
DROP TABLE Enquetes;

*/


/*
------------------------TABLE INDIVIDUS-------------------------
CREATE TABLE Individus  
(
ID_Individu INT IDENTITY,
Civilite NVARCHAR(5)  NOT NULL,  
Nom NVARCHAR(32) NOT NULL,  
Prenom NVARCHAR(32) NOT NULL,  
DateNaissance DATE NOT NULL,
Adresse NVARCHAR(50) NOT NULL,
Telephone NVARCHAR(15) NOT NULL,
PRIMARY KEY(ID_Individu)
)



------------------------TABLE PARTICIPANTS-----------------------
CREATE TABLE Participants  
(
ID_Participant INT IDENTITY,
Client BIT NOT NULL,  
CoordonneesBancaires NVARCHAR(32), --TRIGGER si client TRUE
Solvabilite BIT, --TRIGGER si client TRUE
ID_Individu INT, --FOREIGN KEY
ID_Client INT, --FOREIGN KEY --TRIGGER si client FALSE
PRIMARY KEY(ID_Participant)
)


ALTER TABLE Participants ADD CONSTRAINT Fk_1 FOREIGN KEY(ID_Individu) REFERENCES Individus(ID_Individu);
ALTER TABLE Participants ADD CONSTRAINT Fk_2 FOREIGN KEY(ID_Client) REFERENCES Participants(ID_Participant);



------------------------TABLE PERSONNEL--------------------------
CREATE TABLE Personnel
(
ID_Personnel INT IDENTITY,
Fonction NVARCHAR(20), --ENUM "Commercial / Marketing / Direction Generale / Conseil Client"
ID_Individu INT, --FOREIGN KEY
PRIMARY KEY(ID_Personnel)
)

ALTER TABLE Personnel ADD CONSTRAINT Fk_3 FOREIGN KEY(ID_Individu) REFERENCES Individus(ID_Individu);


------------------------TABLE ASSURANCES--------------------------
CREATE TABLE Assurances 
(
ID_Assurance INT IDENTITY,
Categorie NVARCHAR(20), --ENUM "Annulation / Vol / Rapatriement / Deces ..."
Prix FLOAT,
PRIMARY KEY(ID_Assurance)
)


------------------------TABLE DESTINATIONS----------------------
CREATE TABLE Destinations  
(
ID_Destination INT IDENTITY,
Continent NVARCHAR(20) NOT NULL,
Pays NVARCHAR(32) NOT NULL,
Region NVARCHAR(20),
DescriptionVoyage NVARCHAR(500),
PRIMARY KEY(ID_Destination)
)



------------------------TABLE LISTE_ACCOMPAGNATEURS----------------------------
CREATE TABLE Liste_Accompagnateurs  
(
ID_Liste_Accompagnateurs INT IDENTITY,
ID_Participant_1 INT, --FOREIGN KEY
ID_Participant_2 INT, --FOREIGN KEY
ID_Participant_3 INT, --FOREIGN KEY
ID_Participant_4 INT, --FOREIGN KEY
ID_Participant_5 INT, --FOREIGN KEY
ID_Participant_6 INT, --FOREIGN KEY
ID_Participant_7 INT, --FOREIGN KEY
ID_Participant_8 INT, --FOREIGN KEY
PRIMARY KEY(ID_Liste_Accompagnateurs)
)

ALTER TABLE Liste_Accompagnateurs ADD CONSTRAINT Fk_6 FOREIGN KEY(ID_Participant_1) REFERENCES Participants(ID_Participant);
ALTER TABLE Liste_Accompagnateurs ADD CONSTRAINT Fk_7 FOREIGN KEY(ID_Participant_2) REFERENCES Participants(ID_Participant);
ALTER TABLE Liste_Accompagnateurs ADD CONSTRAINT Fk_8 FOREIGN KEY(ID_Participant_3) REFERENCES Participants(ID_Participant);
ALTER TABLE Liste_Accompagnateurs ADD CONSTRAINT Fk_9 FOREIGN KEY(ID_Participant_4) REFERENCES Participants(ID_Participant);
ALTER TABLE Liste_Accompagnateurs ADD CONSTRAINT Fk_10 FOREIGN KEY(ID_Participant_5) REFERENCES Participants(ID_Participant);
ALTER TABLE Liste_Accompagnateurs ADD CONSTRAINT Fk_11 FOREIGN KEY(ID_Participant_6) REFERENCES Participants(ID_Participant);
ALTER TABLE Liste_Accompagnateurs ADD CONSTRAINT Fk_12 FOREIGN KEY(ID_Participant_7) REFERENCES Participants(ID_Participant);
ALTER TABLE Liste_Accompagnateurs ADD CONSTRAINT Fk_13 FOREIGN KEY(ID_Participant_8) REFERENCES Participants(ID_Participant);




------------------------TABLE VOYAGES---------------------------
CREATE TABLE Voyages  
(
ID_Voyage INT IDENTITY,
DateAller DATE NOT NULL,
DateRetour DATE NOT NULL,
NbVoyageurs INT NOT NULL,
NbPlaces INT NOT NULL,
PrixBtoC FLOAT,
PrixBtoB FLOAT,
ID_Destination INT, --FOREIGN KEY
PRIMARY KEY(ID_Voyage)
)

ALTER TABLE Voyages ADD CONSTRAINT Fk_5 FOREIGN KEY(ID_Destination) REFERENCES Destinations(ID_Destination);




------------------------TABLE DOSSIERS----------------------------
CREATE TABLE Dossiers  
(
ID_Dossier INT IDENTITY,
Statut NVARCHAR(20), --ENUM "En attente / En cours / Refusé / Accepté / Clos / Supprimé"
--PrixTotal FLOAT,
ID_Personnel INT, --FOREIGN KEY
ID_Client INT, --FOREIGN KEY
ID_Liste_Accompagnateurs INT, --FOREIGN KEY
ID_Voyage INT, --FOREIGN KEY
ID_Assurance INT, --FOREIGN KEY
PRIMARY KEY(ID_Dossier)
)


ALTER TABLE Dossiers ADD CONSTRAINT Fk_14 FOREIGN KEY(ID_Personnel) REFERENCES Personnel(ID_Personnel);
ALTER TABLE Dossiers ADD CONSTRAINT Fk_15 FOREIGN KEY(ID_Client) REFERENCES Participants(ID_Participant);
ALTER TABLE Dossiers ADD CONSTRAINT Fk_16 FOREIGN KEY(ID_Liste_Accompagnateurs) REFERENCES Liste_Accompagnateurs(ID_Liste_Accompagnateurs);
ALTER TABLE Dossiers ADD CONSTRAINT Fk_17 FOREIGN KEY(ID_Voyage) REFERENCES Voyages(ID_Voyage);
ALTER TABLE Dossiers ADD CONSTRAINT Fk_18 FOREIGN KEY(ID_Assurance) REFERENCES Assurances(ID_Assurance);




------------------------TABLE ENQUETES----------------------
CREATE TABLE Enquetes  
(
ID_Enquete INT IDENTITY,
TauxSatisfaction FLOAT, --POURCENTAGE??
ID_Participant INT, --FOREIGN KEY
PRIMARY KEY(ID_Enquete)
)

ALTER TABLE Enquetes ADD CONSTRAINT Fk_4 FOREIGN KEY(ID_Participant) REFERENCES Participants(ID_Participant);


*/




INSERT INTO Individus (Civilite, Nom, Prenom, DateNaissance, Adresse, Telephone)
VALUES ('Mme', 'adzd', 'azdazdz', '25/01/1980', '25 zdzdd', '069985756');
--('Mme', 'SSSS', 'XXX', CAST(02/05/1994) AS DATE, '1000 BIS Avenue Albert 1er', '0622334455')


INSERT INTO Participants (Client, CoordonneesBancaires, Solvabilite, ID_Individu, ID_Client)
VALUES (0, null, null, 3, 1);

INSERT INTO Personnel (Fonction, ID_Individu)
VALUES ('Marketing', 3);


INSERT INTO Destinations (Continent, Pays, Region, DescriptionVoyage)
VALUES ('Asie', 'Inde', 'Tamil Nadu', 'Hotel vue sur mer situé à la ville blanche de Pondichéry.');


INSERT INTO Assurances (Categorie, Prix)
VALUES ('Retard', 20);


INSERT INTO Liste_Accompagnateurs (ID_Participant_1, ID_Participant_2, ID_Participant_3, ID_Participant_4, ID_Participant_5, ID_Participant_6, ID_Participant_7, ID_Participant_8)
VALUES (1, 3, 4, null, null, null, null, null);


INSERT INTO Voyages (DateAller, DateRetour, NbVoyageurs, NbPlaces, PrixBtoC, PrixBtoB, ID_Destination)
VALUES ('04/06/2016', '18/07/2016', 1, 7, 2600, 1500, 2);


INSERT INTO Enquetes (TauxSatisfaction, ID_Participant)
VALUES (0.92, 3);


INSERT INTO Dossiers (Statut, ID_Personnel, ID_Client, ID_Liste_Accompagnateurs, ID_Voyage, ID_Assurance)
VALUES ('En cours', 1, 1, 5, 1, 1);



