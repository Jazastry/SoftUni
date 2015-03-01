/* 01. */
SELECT a.Title
FROM dbo.Ads a
ORDER BY a.Title

/* 02. 
26-December-2014 (00:00:00) and 1-January-2015 (23:59:59)
Title Date */
SELECT a.Title, a.[Date]
FROM dbo.Ads a
WHERE a.[Date] BETWEEN '2014-12-26 00:00:00' AND '2015-1-1 23:59:59'
ORDER BY a.[Date]



/* 03.*    Display all ad titles and dates along with a 
column named "Has Image" holding "yes" or "no" 
for all ads sorted by their Id. Submit for evaluation
 the result grid with headers.*/

SELECT Salary, [Salary Level] =
  CASE
    WHEN Salary BETWEEN 0 and 9999 THEN 'Low'
    WHEN Salary BETWEEN 10000 and 30000 THEN 'Average'
    WHEN Salary > 30000 THEN 'High'
    ELSE 'Unknown'
  END
FROM Employees

SELECT a.Title, a.[Date],  
	(CASE 
		WHEN a.ImageDataURL IS NOT NULL THEN 'no'
		ELSE 'yes' 
	END) AS [Has Image] 
FROM Ads a
order by a.Id 
GO
/* 04. Find all ads that have no town, no category or no image sorted
 by Id. Show all their data. Submit for evaluation the result grid with headers. */
--SELECT a.Id, a.Title,a.[Text],a.ImageDataURL,a.OwnerId,a.CategoryId,a.TownId,a.[Date],a.StatusId
--FROM Ads 

SELECT a.Id, a.Title,a.[Text],a.ImageDataURL,a.OwnerId,a.CategoryId,a.TownId,a.[Date],a.StatusId
FROM dbo.Ads a
WHERE a.TownId IS NULL 
AND a.CategoryId IS NULL
OR a.ImageDataURL IS NULL
ORDER BY a.Id

/* 05. */

SELECT a.Title, t.Name AS [Town]
FROM Ads a
LEFT JOIN Towns t
ON a.TownId = t.Id
ORDER BY a.Id

/* 06.  */
SELECT a.Title, c.Name AS CategoryName,
		t.Name AS TownName,
		s.Status 
FROM Ads a
LEFT JOIN Categories c
ON a.CategoryId = c.Id
LEFT JOIN Towns t
ON a.TownId = t.Id
LEFT JOIN AdStatuses s
ON a.StatusId = s.Id
ORDER BY a.Id



/* 07. */
SELECT a.Title,
		c.Name AS CategoryName,
		t.Name AS TownName,
		s.Status
FROM Ads a
JOIN Categories c
ON a.CategoryId = c.Id
JOIN Towns t
ON a.TownId = t.Id
JOIN AdStatuses s
ON a.StatusId = s.Id
WHERE a.TownId IN (SELECT Id FROM Towns WHERE Name IN ('Sofia', 'Blagoevgrad', 'Stara Zagora'))
AND a.StatusId = (SELECT Id FROM AdStatuses WHERE Status = 'Published')
ORDER BY a.Title

/* 08 */

SELECT MIN(a.Date) AS MinDate, MAX(a.Date) AS MaxDate
FROM Ads a

/* 09 */

SELECT TOP (10) a.Title, a.Date, s.Status
FROM Ads a
JOIN AdStatuses s
ON a.StatusId = s.Id
ORDER BY a.Date DESC

/* 10. */
SELECT a.Id, a.Title, a.Date, s.Status
FROM 
((SELECT * FROM Ads a WHERE a.StatusId IN ((SELECT Id FROM AdStatuses WHERE Status <> 'Published'))))
 a
JOIN AdStatuses s
ON a.StatusId = s.Id
WHERE Year(a.Date) = YEAR(((SELECT MIN(Date)FROM Ads)))
AND MONTH(a.Date) = MONTH(((SELECT MIN(Date)FROM Ads)))

/* 11. */
SELECT s.Status, COUNT(a.Id) AS Count
FROM AdStatuses s
JOIN Ads a
ON a.StatusId = s.Id
GROUP BY s.Status
ORDER BY s.Status

/* 12. */
SELECT t.Name AS [Town Name], s.Status, COUNT(a.Id) AS Count
FROM Ads a
JOIN Towns t
ON a.TownId = t.Id
JOIN AdStatuses s
ON a.StatusId = s.Id
GROUP BY t.Name, s.Status
ORDER BY t.Name, s.Status

/* 13 */
SELECT u.UserName, COUNT(a.Id) AS AdsCount,
	(CASE 
		WHEN u.Id = '39b7333d-664b-428d-9e11-4cde699d5e5e' OR u.Id = '956b34b3-d4dc-4601-a248-9bc7a6723611'
			THEN 'yes'
		ELSE 'no' 
	END) AS [IsAdministrator]
FROM AspNetUsers u
LEFT JOIN Ads a
ON a.OwnerId = u.Id 
GROUP BY u.UserName, u.Id
ORDER BY u.UserName
GO
(SELECT UserId FROM AspNetUserRoles ur WHERE ur.RoleId = ((SELECT Id FROM AspNetRoles r WHERE r.Name = 'Administrator')))

/* 14. */
SELECT COUNT(a.Id) AS AdsCount, 
	(CASE
		WHEN t.Name IS NULL THEN '(no town)'
		ELSE t.Name 
	END) AS Town
FROM Ads a
LEFT JOIN Towns t
ON a.TownId = t.Id
GROUP BY t.Name
HAVING COUNT(a.Id) BETWEEN 2 AND 3
ORDER BY t.Name
GO

/* 15. */
SELECT a.Date AS FirstDate, a2.Date AS SecondDate
FROM Ads a
JOIN Ads a2
ON a.Date < a2.Date
WHERE a2.Date <= DATEADD(hh, 12, a.Date) 
ORDER BY FirstDate, SecondDate

/* 16. */

CREATE TABLE Countries 
(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(100) NOT NULL
)

INSERT INTO Countries (Name)
VALUES('Bulgaria'), ('Germany');
GO

DELETE FROM Countries;

ALTER TABLE Towns 
ADD CountryId INT NULL;

ALTER TABLE Towns 
ADD CONSTRAINT FK_Towns_Countries
FOREIGN KEY (CountryId)
REFERENCES Countries(Id);

INSERT INTO Countries(Name) VALUES ('Bulgaria'), ('Germany'), ('France')

UPDATE Towns SET CountryId = (SELECT Id FROM Countries WHERE Name='Bulgaria')

INSERT INTO Towns VALUES
('Munich', (SELECT Id FROM Countries WHERE Name='Germany')),
('Frankfurt', (SELECT Id FROM Countries WHERE Name='Germany')),
('Berlin', (SELECT Id FROM Countries WHERE Name='Germany')),
('Hamburg', (SELECT Id FROM Countries WHERE Name='Germany')),
('Paris', (SELECT Id FROM Countries WHERE Name='France')),
('Lyon', (SELECT Id FROM Countries WHERE Name='France')),
('Nantes', (SELECT Id FROM Countries WHERE Name='France'))

UPDATE Ads 
SET TownId = (SELECT Id FROM Towns WHERE Name = 'Paris')
WHERE Id IN (SELECT Id FROM Ads WHERE DATENAME(dw, Date) = 'Friday')

UPDATE Ads 
SET TownId = (SELECT Id FROM Towns WHERE Name = 'Hamburg')
WHERE Id IN (SELECT Id FROM Ads WHERE DATENAME(dw, Date) = 'Thursday')

DELETE FROM Ads
WHERE Id IN
(SELECT a.Id
FROM Ads a
WHERE a.OwnerId IN (SELECT ur.UserId
			FROM AspNetUserRoles ur 
			JOIN AspNetRoles r 
			ON ur.RoleId = r.Id 
			WHERE r.Name = 'Partner'))

INSERT INTO Ads (Title, Text, Date, OwnerId, StatusId)
VALUES('Free Book', 'Free C# Book', GETDATE(),
(SELECT Id FROM AspNetUsers WHERE UserName = 'nakov'),
(SELECT Id FROM AdStatuses WHERE Status = 'Waiting Approval')
)

SELECT t.Name AS Town, c.Name AS Country, COUNT(a.Id) AS AdsCount
FROM Ads a
FULL JOIN Towns t
on t.Id = a.TownId 
FULL JOIN Countries c
ON t.CountryId = c.Id
GROUP BY t.Name, c.Name
ORDER BY t.Name, c.Name
GO
/* 17. */

CREATE VIEW AllAds 
AS
	SELECT a.Id, a.Title,
		u.UserName AS Author, a.Date,
		t.Name AS Town,
		c.Name AS Category,
		s.Status
	FROM Ads a
	JOIN AspNetUsers u
	ON a.OwnerId = u.Id
	LEFT JOIN Towns t
	ON a.TownId = t.Id
	LEFT JOIN Categories c
	ON a.CategoryId = c.Id
	JOIN AdStatuses s
	ON a.StatusId = s.Id
	GROUP BY a.Id, a.Title,
		u.UserName, a.Date,
		t.Name,
		c.Name,
		s.Status
GO

SELECT * FROM AllAds
GO

USE Ads
GO

CREATE FUNCTION fn_ListUsersAds
  ()
RETURNS @tbl_ResultTable TABLE
(UserName NVARCHAR(50), AdDates NVARCHAR(300) NULL)
AS
BEGIN
	DECLARE @datesResultString NVARCHAR(200);
	SET @datesResultString = '';
------------------------------------------------------------
	DECLARE usersCursor CURSOR READ_ONLY FOR
	SELECT a.Author FROM (SELECT DISTINCT Author FROM AllAds) a
	OPEN usersCursor

	DECLARE @currentUserName NVARCHAR(50)
	FETCH NEXT FROM usersCursor 
	INTO @currentUserName

	WHILE @@FETCH_STATUS = 0
		BEGIN		

	--		DECLARE @datesResultString NVARCHAR(200);
	--SET @datesResultString = '';
		-----------------------------------------------------------------
		DECLARE datesCursor CURSOR READ_ONLY FOR
		SELECT a.Date FROM (SELECT Date FROM AllAds WHERE Author = @currentUserName GROUP BY Date) a
		OPEN datesCursor
		--(SELECT Id FROM AspNetUsers WHERE UserName = @currentUserName)
		DECLARE @currentDate DATE
		FETCH NEXT FROM datesCursor 
		INTO @currentDate

		WHILE @@FETCH_STATUS = 0
			BEGIN		

			SET @datesResultString += FORMAT(@currentDate, 'yyyymmdd') + '; '

			FETCH NEXT FROM datesCursor 
			INTO @currentDate
			END
		CLOSE datesCursor
		DEALLOCATE datesCursor
		IF (@datesResultString <> '')
			BEGIN
				SET @datesResultString = LEFT(@datesResultString, LEN(@datesResultString) - 2)
			END
		-----------------------------------------------------------------
		IF (@datesResultString = '')
			BEGIN
			INSERT INTO @tbl_ResultTable (UserName, AdDates)
			VALUES (@currentUserName, NULL)
			END
		ELSE 
			BEGIN
			INSERT INTO @tbl_ResultTable (UserName, AdDates)
			VALUES (@currentUserName, @datesResultString)
			END

		SET @datesResultString = '';

		FETCH NEXT FROM usersCursor 
		INTO @currentUserName
		END
	CLOSE usersCursor
	DEALLOCATE usersCursor

------------------------------------------------------------	
	RETURN 
END
GO

DROP FUNCTION fn_ListUsersAds

SELECT * FROM fn_ListUsersAds() ORDER BY UserName DESC