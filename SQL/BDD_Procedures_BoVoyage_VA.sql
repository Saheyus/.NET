
--USE BoVoyage_VA;

/*
CREATE FUNCTION ListeParticipantsDossier(@Dossier INT)

RETURNS TABLE
AS
RETURN( 

SELECT 'Client' AS Statut, Prenom, Nom 
FROM Individus I, Participants P, Liste_Accompagnateurs LA, Dossiers D
WHERE D.ID_Dossier = @Dossier
AND I.ID_Individu = P.ID_Individu
AND P.ID_Individu = P.ID_Client
AND D.ID_Client = P.ID_Client
AND D.ID_Liste_Accompagnateurs = LA.ID_Liste_Accompagnateurs

UNION 

SELECT 'Accompagnant' AS Statut, Prenom, Nom 
FROM Individus I, Participants P, Liste_Accompagnateurs LA, Dossiers D
WHERE D.ID_Dossier = @Dossier
AND D.ID_Client = P.ID_Client
AND I.ID_Individu = P.ID_Individu 
AND D.ID_Liste_Accompagnateurs = LA.ID_Liste_Accompagnateurs
AND (P.ID_Participant = LA.ID_Participant_1
OR P.ID_Participant = LA.ID_Participant_2
OR P.ID_Participant = LA.ID_Participant_3
OR P.ID_Participant = LA.ID_Participant_4
OR P.ID_Participant = LA.ID_Participant_5
OR P.ID_Participant = LA.ID_Participant_6
OR P.ID_Participant = LA.ID_Participant_7
OR P.ID_Participant = LA.ID_Participant_8)

);
GO


CREATE FUNCTION NbParticipantsDossier(@Dossier INT)
RETURNS INT
AS
BEGIN

DECLARE @ID_Doss INT;
DECLARE @Nb INT;

SET @ID_Doss = @Dossier; 

SET @Nb = 
(SELECT(
SELECT COUNT(*)
FROM (VALUES (LA.ID_Participant_1), (LA.ID_Participant_2), (LA.ID_Participant_3), (LA.ID_Participant_4),(LA.ID_Participant_5),(LA.ID_Participant_6),(LA.ID_Participant_7),(LA.ID_Participant_8)) 
AS V(COL)
WHERE V.COL is not null)

FROM Liste_Accompagnateurs AS LA, Dossiers AS D
WHERE LA.ID_Liste_Accompagnateurs = D.ID_Liste_Accompagnateurs
AND D.ID_Dossier = @ID_Doss) 
+ 1

RETURN (@Nb);
END;
GO



DROP FUNCTION ListeParticipants;
DROP PROCEDURE NbParticipants;
DROP FUNCTION NbParticipantsDossier;
DROP FUNCTION dbo.ListeParticipantsDossier;


SELECT * FROM ListeParticipants();
SELECT * FROM NbParticipants();



SELECT * FROM ;
SELECT * FROM Liste_Accompagnateurs;
SELECT * FROM Dossiers;
SELECT * FROM Individus;
SELECT * FROM Participants;


SELECT dbo.NbParticipantsDossier(4);
SELECT * FROM dbo.ListeParticipantsDossier(4);
*/



EXECUTE InsertIndividus 'M', 'BLABLIBLOU', 'BLOBLO', '15/01/1920', '99 chemin de Traverse', '0203040506';

SELECT * FROM Individus;