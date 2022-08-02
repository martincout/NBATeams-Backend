use NBATeams;
go

SELECT * FROM [Stats];
SELECT * FROM Players;
SELECT * FROM OfficialTeams;
SELECT * FROM Off

SELECT * FROM dbo.Players
JOIN [Stats] ON Players.StatsID = [Stats].Id

-------------------------------------------------------------------------------------------------------------------------------------

INSERT INTO [Location] (City,Street) VALUES ('Toronto, Ontario','40 Bay St')
INSERT INTO [Location] (City,Street) VALUES ('Memphis, Tennessee','191 Beale St')

INSERT INTO Court ([Name],LocationId) VALUES ('Scotiabank Arena',1)
INSERT INTO Court ([Name],LocationId) VALUES ('FedExForum',2)

INSERT INTO OfficialTeams ([Name],Wins,Lost,LogoPath,CourtId) VALUES ('Toronto Raptors',15,17,'', 1)
INSERT INTO OfficialTeams ([Name],Wins,Lost,LogoPath,CourtId) VALUES ('Memphis Grizzlies',15,17,'', 2)

INSERT INTO Teams (OfficialTeamId) VALUES (1)
INSERT INTO Teams (OfficialTeamId) VALUES (2) -- Depends on the id of the second one
INSERT INTO Teams (CustomTeamId) VALUES (1) -- Depends on the id of the second one


--- Players Of Team -> Toronto Raptors
INSERT INTO [Stats] (PPG,RPG,APG,PIE,Assists,Points) 
VALUES (9.1,6.5,1.1,8.9,20,20)
INSERT INTO Players ([Name],LastName,Number,Height,[Weight],ImageProfilePath,Position,StatsId,BirthDate,Experience,TeamId) 
VALUES ('Precious',' Achiuwa',5, 2.3, 102,'https://cdn.nba.com/headshots/nba/latest/1040x760/1630173.png','F',1,'1999-09-19','2 years',1)

INSERT INTO [Stats] (PPG,RPG,APG,PIE,Assists,Points) 
VALUES (4.3,2.4,0.6,7.5,10,5)
INSERT INTO Players ([Name],LastName,Number,Height,[Weight],ImageProfilePath,Position,StatsId,BirthDate,Experience,TeamId) 
VALUES ('Yuta',' Watanabe',18, 2.06, 98,'https://cdn.nba.com/headshots/nba/latest/1040x760/1629139.png','GF',2,'1994-10-13','4 years',1)

--- Players Of Team -> Memphis Grizzlies
INSERT INTO [Stats] (PPG,RPG,APG,PIE,Assists,Points) 
VALUES (6.9,10,3.4,10.8,15,20)
INSERT INTO Players ([Name],LastName,Number,Height,[Weight],ImageProfilePath,Position,StatsId,BirthDate,Experience,TeamId) 
VALUES ('Steven',' Adams',4, 2.11, 120,'https://cdn.nba.com/headshots/nba/latest/1040x760/203500.png','C',3,'1993-07-20','9 years',2)

INSERT INTO [Stats] (PPG,RPG,APG,PIE,Assists,Points) 
VALUES (8.1,2.1,1.0,5.5,15,20)
INSERT INTO Players ([Name],LastName,Number,Height,[Weight],ImageProfilePath,Position,StatsId,BirthDate,Experience,TeamId) 
VALUES ('Ziaire',' Williams',8, 2.06, 84,'https://cdn.nba.com/headshots/nba/latest/1040x760/1630533.png','F',4,'2001-09-12','1 year',2)


--DELETE FROM Players WHERE Id = 2;
--DELETE FROM [Stats];


---- Reset indexes to 0
--DBCC CHECKIDENT ('Players', RESEED, 0);
--DBCC CHECKIDENT ('Stats', RESEED, 0);


UPDATE [Stats]
SET PPG = 10
WHERE Id = 1;
