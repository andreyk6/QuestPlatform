
DECLARE @myNewPKTable TABLE (myNewPK UNIQUEIDENTIFIER)
DELETE FROM @myNewPKTable;
INSERT INTO Questions (Id, Title) OUTPUT INSERTED.Id INTO @myNewPKTable VALUES(NEWID(), 'QUESTION1')
INSERT INTO Options (Id, Content, IsCorrect, QuestionId) VALUES(NEWID(), 'VALUE1(Correct)', 1, (select TOP 1 myNewPK from @myNewPKTable));
INSERT INTO Options (Id, Content, IsCorrect, QuestionId) VALUES(NEWID(), 'VALUE1', 0, (select TOP 1 myNewPK from @myNewPKTable));

DELETE FROM @myNewPKTable;
INSERT INTO Questions (Id, Title) OUTPUT INSERTED.Id INTO @myNewPKTable VALUES(NEWID(), 'QUESTION2')
INSERT INTO Options (Id, Content, IsCorrect, QuestionId) VALUES(NEWID(), 'VALUE1(Correct)', 1, (select TOP 1 myNewPK from @myNewPKTable));
INSERT INTO Options (Id, Content, IsCorrect, QuestionId) VALUES(NEWID(), 'VALUE1', 0, (select TOP 1 myNewPK from @myNewPKTable));

DELETE FROM @myNewPKTable;
INSERT INTO Questions (Id, Title) OUTPUT INSERTED.Id INTO @myNewPKTable VALUES(NEWID(), 'QUESTION3')
INSERT INTO Options (Id, Content, IsCorrect, QuestionId) VALUES(NEWID(), 'VALUE1(Correct)', 1, (select TOP 1 myNewPK from @myNewPKTable));
INSERT INTO Options (Id, Content, IsCorrect, QuestionId) VALUES(NEWID(), 'VALUE1', 0, (select TOP 1 myNewPK from @myNewPKTable));

DELETE FROM @myNewPKTable;
INSERT INTO Questions (Id, Title) OUTPUT INSERTED.Id INTO @myNewPKTable VALUES(NEWID(), 'QUESTION4')
INSERT INTO Options (Id, Content, IsCorrect, QuestionId) VALUES(NEWID(), 'VALUE1(Correct)', 1, (select TOP 1 myNewPK from @myNewPKTable));
INSERT INTO Options (Id, Content, IsCorrect, QuestionId) VALUES(NEWID(), 'VALUE1', 0, (select TOP 1 myNewPK from @myNewPKTable));

DELETE FROM @myNewPKTable;
INSERT INTO Questions (Id, Title) OUTPUT INSERTED.Id INTO @myNewPKTable VALUES(NEWID(), 'QUESTION5')
INSERT INTO Options (Id, Content, IsCorrect, QuestionId) VALUES(NEWID(), 'VALUE1(Correct)', 1, (select TOP 1 myNewPK from @myNewPKTable));
INSERT INTO Options (Id, Content, IsCorrect, QuestionId) VALUES(NEWID(), 'VALUE1', 0, (select TOP 1 myNewPK from @myNewPKTable));

DELETE FROM @myNewPKTable;
INSERT INTO Questions (Id, Title) OUTPUT INSERTED.Id INTO @myNewPKTable VALUES(NEWID(), 'QUESTION6')
INSERT INTO Options (Id, Content, IsCorrect, QuestionId) VALUES(NEWID(), 'VALUE1(Correct)', 1, (select TOP 1 myNewPK from @myNewPKTable));
INSERT INTO Options (Id, Content, IsCorrect, QuestionId) VALUES(NEWID(), 'VALUE1', 0, (select TOP 1 myNewPK from @myNewPKTable));

DELETE FROM @myNewPKTable;
INSERT INTO Questions (Id, Title) OUTPUT INSERTED.Id INTO @myNewPKTable VALUES(NEWID(), 'QUESTION7')
INSERT INTO Options (Id, Content, IsCorrect, QuestionId) VALUES(NEWID(), 'VALUE1(Correct)', 1, (select TOP 1 myNewPK from @myNewPKTable));
INSERT INTO Options (Id, Content, IsCorrect, QuestionId) VALUES(NEWID(), 'VALUE1', 0, (select TOP 1 myNewPK from @myNewPKTable));

DELETE FROM @myNewPKTable;
INSERT INTO Questions (Id, Title) OUTPUT INSERTED.Id INTO @myNewPKTable VALUES(NEWID(), 'QUESTION8')
INSERT INTO Options (Id, Content, IsCorrect, QuestionId) VALUES(NEWID(), 'VALUE1(Correct)', 1, (select TOP 1 myNewPK from @myNewPKTable));
INSERT INTO Options (Id, Content, IsCorrect, QuestionId) VALUES(NEWID(), 'VALUE1', 0, (select TOP 1 myNewPK from @myNewPKTable));

DELETE FROM @myNewPKTable;
INSERT INTO Questions (Id, Title) OUTPUT INSERTED.Id INTO @myNewPKTable VALUES(NEWID(), 'QUESTION9')
INSERT INTO Options (Id, Content, IsCorrect, QuestionId) VALUES(NEWID(), 'VALUE1(Correct)', 1, (select TOP 1 myNewPK from @myNewPKTable));
INSERT INTO Options (Id, Content, IsCorrect, QuestionId) VALUES(NEWID(), 'VALUE1', 0, (select TOP 1 myNewPK from @myNewPKTable));

DELETE FROM @myNewPKTable;
INSERT INTO Questions (Id, Title) OUTPUT INSERTED.Id INTO @myNewPKTable VALUES(NEWID(), 'QUESTION10')
INSERT INTO Options (Id, Content, IsCorrect, QuestionId) VALUES(NEWID(), 'VALUE1(Correct)', 1, (select TOP 1 myNewPK from @myNewPKTable));
INSERT INTO Options (Id, Content, IsCorrect, QuestionId) VALUES(NEWID(), 'VALUE1', 0, (select TOP 1 myNewPK from @myNewPKTable));

DELETE FROM @myNewPKTable;
INSERT INTO Questions (Id, Title) OUTPUT INSERTED.Id INTO @myNewPKTable VALUES(NEWID(), 'QUESTION11')
INSERT INTO Options (Id, Content, IsCorrect, QuestionId) VALUES(NEWID(), 'VALUE1(Correct)', 1, (select TOP 1 myNewPK from @myNewPKTable));
INSERT INTO Options (Id, Content, IsCorrect, QuestionId) VALUES(NEWID(), 'VALUE1', 0, (select TOP 1 myNewPK from @myNewPKTable));

DELETE FROM @myNewPKTable;
INSERT INTO Questions (Id, Title) OUTPUT INSERTED.Id INTO @myNewPKTable VALUES(NEWID(), 'QUESTION12')
INSERT INTO Options (Id, Content, IsCorrect, QuestionId) VALUES(NEWID(), 'VALUE1(Correct)', 1, (select TOP 1 myNewPK from @myNewPKTable));
INSERT INTO Options (Id, Content, IsCorrect, QuestionId) VALUES(NEWID(), 'VALUE1', 0, (select TOP 1 myNewPK from @myNewPKTable));


select * from Questions Q LEFT JOIN Options O ON Q.Id = O.QuestionId


Declare @beaconId UNIQUEIDENTIFIER;
SET @beaconId = NEWID();

INSERT INTO Beacons (Id, UUID, TresholdRSSI)
VALUES(@beaconId, 'ACACAC#DS#', 'fdhkfkjsdfh')

INSERT INTO BeaconInParks (Id, ParkId, SequenceNumber, NextBeaconLocationTip)
VALUES(@beaconId, 'aa48be75-1347-e711-a2cf-28d2444d67c1', 1, 'text')


SET @beaconId = NEWID();

INSERT INTO Beacons (Id, UUID, TresholdRSSI)
VALUES(@beaconId, 'ACACAC#DS#', 'fdhkfkjsdfh')
INSERT INTO BeaconInParks (Id, ParkId, SequenceNumber, NextBeaconLocationTip)
VALUES(@beaconId, 'aa48be75-1347-e711-a2cf-28d2444d67c1', 2, 'text')


SET @beaconId = NEWID();

INSERT INTO Beacons (Id, UUID, TresholdRSSI)
VALUES(@beaconId, 'ACACAC#DS#', 'fdhkfkjsdfh')

INSERT INTO BeaconInParks (Id, ParkId, SequenceNumber, NextBeaconLocationTip)
VALUES(@beaconId, 'aa48be75-1347-e711-a2cf-28d2444d67c1', 3, 'text')

SELECT * FROM Beacons
select * from BeaconInParks BP JOIN Beacons B ON BP.Id=B.Id;

select * from UserInGames
delete from QuizTasks