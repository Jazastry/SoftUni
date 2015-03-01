/* Problem 1. All Question Titles
Display all question titles in descending order. Name the columns exactly
like in the table below.
Steps:
1. Select all question titles from questions table.
2. Add order by descending statement. */
SELECT q.Title
FROM Questions q
ORDER BY q.Title 

/*Problem 2. Answers in Date Range
Find all answers created between 15-June-2012 (00:00:00) and 21-Mart-2013 (23:59:59)
sorted by date. Name the columns exactly like in the table below.
Steps:
1. Select all answers (only Content and CreatedOn columns).
2. Add where filter by CreatedOn column. You can use between or comparison statements.*/
SELECT q.Content, q.CreatedOn
FROM Answers q
WHERE q.CreatedOn between '2012-6-15 00:00:00' 
and '2013-3-21 23:59:59'
ORDER BY q.CreatedOn

/*Problem 3. Users with "1/0" Phones
Display all user username and last names along with a column named "Has Phone" 
holding "1" or "0" for all users sorted by their last name. Name the columns
exactly like in the table below.
Steps:
1. Select all users (only Username and LastName columns).
2. Add order by last name statement.
3. Add “Has Phone” column. You can use case statement in select to check 
is there a phone and set 1 or 0.*/
SELECT u.Username,
	u.LastName,
	[Has Phone] =
	  CASE
		WHEN u.PhoneNumber IS NULL THEN '0'
		ELSE '1'
	  END
FROM Users u
ORDER BY u.LastName

/*
Problem 4. Questions with their Author
Find all questions along with their user sorted by Id.
Display the question title and author username. Name the 
columns exactly like in the table below.
Steps:
1. Select all columns from Questions table.
2. Join Users table.
3. Add only the required columns in the expression.
4. Add the required aliases.
*/
SELECT q.Title AS [Question Title],
 u.Username AS [Author]
FROM Questions q
JOIN Users u
ON q.UserId = u.Id

/*
Problem 5. Answers with their Question with their Category and User 
Find
 all answers
 along with their questions,
 along with question category,
 along with question author
 sorted by Category Name. 
 Display the answer content, created on, question title,
  category name and author username. Name the columns
   exactly like in the table below.
Steps:
1. Select all columns from Answers table.
2. Join Questions table by QuestionId foreign key.
3. Join Categories table by CategoryId foreign key.
4. Join Users table by UserId foreign key in Answers table.
5. Add order by statement by category name.
6. Select only the required columns with their aliases.
*/

SELECT a.Content as [Answer Content],
	a.CreatedOn AS [CreatedOn],
	u.Username AS [Answer Author],
	q.Title AS [Question Title],
	c.Name AS [Category Name]
FROM Answers a
JOIN Questions q
ON q.Id = a.QuestionId
JOIN Categories c
ON c.Id = q.CategoryId
JOIN Users u
ON a.UserId = u.Id
ORDER BY c.Name

/*
Problem 6. Category with Questions
Find all categories along with their questions sorted by category name.
 Display the category name, question title and created on columns.
  Name the columns exactly like in the table below.
1. Select all Questions.
2. Join Categories table (think how to display null values).
3. Add order by statement by category name.
4. Select only required columns.
*/
SELECT c.Name AS [Name],
	q.Title AS [Title],
	q.CreatedOn AS [CreatedOn]
FROM Questions q
RIGHT OUTER JOIN Categories c
ON c.Id = q.CategoryId
ORDER BY c.Name

/*
07.
Find all users that have no phone and no questions sorted by RegistrationDate. 
Show all user data. Name the columns exactly like in the table below.
1. Select all users.
2. Add where filter by null phone number.
3. Add order by statement by RegistrationDate.
4. Join Questions table and display all users with questions for each user (with questions with null values).
5. Add filter to show only users with no questions.
*/

SELECT DISTINCT u.Id,
	u.Username,
	u.FirstName,
	u.PhoneNumber,
	u.RegistrationDate,
	u.Email
FROM Users u
LEFT OUTER JOIN Questions q
ON q.UserId = u.Id
WHERE u.PhoneNumber IS NULL
AND q.UserId IS NULL
ORDER BY u.RegistrationDate

/*
Problem 8. Earliest and Latest Answer Date
Find the dates of the earliest answer for 2012 year and
the latest answer for 2014 year. Name the columns exactly 
like in the table below.
Steps:
1. Select min and max date from Answers.
2. Add where filter by year.
*/
SELECT MIN(a.CreatedOn) AS [MinDate],
	MAX(a.CreatedOn) AS [MaxDate]
FROM Answers a
WHERE a.CreatedOn BETWEEN '2012' and '2015'

/*
Problem 9. 
Find the latest 10 answers sorted by date of creation 
in descending order. Display for each ad its content, date and author.
 Name the columns exactly like in the table below.
*/
SELECT TOP 10 a.Content,
		a.CreatedOn,
		u.Username
FROM Answers a
JOIN Users u
ON u.Id = a.UserId
ORDER BY a.CreatedOn ASC

/*
Problem 10.
Find the answers which is hidden from the first and last month 
where there are any published answer, from the last year where there 
are any published answers. Display for each ad its answer content, 
question title and category name. Sort the results by category name. 
Name the columns exactly like in the table below.
Steps:
1. Select all data from Answers.
2. Join Questions and Categories by foreign keys.
3. Add order by statement by category name.
4. Select only needed columns.
5. Add where statement. You can use MONTH and YEAR functions and nested select statements.
*/
SELECT a.Content [Answer Content],
	q.Title AS [Question],
	c.Name AS [Category]
FROM (SELECT * 
	FROM Answers a
	WHERE YEAR(a.CreatedOn) = '2015'
	AND a.IsHidden = 1) a	
JOIN Questions q
ON a.QuestionId = q.Id
JOIN Categories c
ON c.Id = q.CategoryId
ORDER BY c.Name

SELECT TOP 1 * FROM Answers ORDER BY CreatedOn DESC

/*
11.
Display the count of answers in each category. Sort the results 
by answers count in descending order. Name the columns exactly 
like in the table below.
Steps:
1. Select all data from Categories.
2. Join Questions and Answers (What type of join do you need?).
3. Order results.
4. Group results and add COUNT column in select statement.
*/
SELECT c.Name AS [Category],
	COUNT(a.Id) AS [Answers Count]
FROM Categories c
LEFT OUTER JOIN Questions q
ON q.CategoryId = c.Id
LEFT OUTER JOIN Answers a
ON a.QuestionId = q.Id
GROUP BY c.Name
ORDER BY [Answers Count] DESC

/*
12. 
Display the count of answers for category and each username. 
Sort the results by Answers count. Display only non-zero counts. 
Display only users with phone number. Name the columns exactly like 
in the table below. 
Steps:
1. Select all data from Categories.
2. Join Questions, Answers and Users (What type of joins do you need?).
3. Add needed columns in select statement and group by them.
4. Add order by statement by answers count.
*/
SELECT c.Name AS [Category],
	u.Username AS [Username],
	u.PhoneNumber AS [PhoneNumber],
	COUNT(a.Id) AS [Answers Count]
FROM Categories c
RIGHT OUTER JOIN Questions q
ON q.CategoryId = c.Id
RIGHT OUTER JOIN Answers a
ON q.Id = a.QuestionId
RIGHT OUTER JOIN (SELECT * FROM Users WHERE PhoneNumber IS NOT NULL) u
ON u.Id = a.UserId
GROUP BY c.Name, u.Username, u.PhoneNumber
ORDER BY [Answers Count] DESC

/*
 13. 

*/

INSERT INTO Towns(Name) 
VALUES ('Sofia'), ('Berlin'), ('Lyon')

UPDATE Users 
SET TownId = (SELECT Id FROM Towns WHERE Name='Sofia')

INSERT INTO Towns 
VALUES
('Munich'), ('Frankfurt'), ('Varna'), ('Hamburg'), ('Paris'), ('Lom'), ('Nantes')

UPDATE Users
SET TownId = (SELECT Id FROM Towns WHERE Name = 'Berlin')
WHERE Id IN (SELECT u.Id
			FROM Users u
			WHERE DATENAME( DW, u.RegistrationDate) = 'Wednesday')
-- 04. Problem

UPDATE Answers
SET QuestionId = (SELECT q.Id
				  FROM Questions q
				  WHERE q.Title = 'Java += operator')
WHERE Id IN (SELECT Id
				FROM (SELECT *
					FROM Answers a
					WHERE DATENAME( MM, a.CreatedOn) = 'February') a
				WHERE DATENAME( DW, a.CreatedOn) = 'Monday' 
				OR DATENAME( DW, a.CreatedOn) = 'Sunday')

SELECT a.CreatedOn, a.Id
FROM Answers a
WHERE DATENAME( MM, a.CreatedOn) = 'February'

SELECT a.CreatedOn, a.Id
FROM Answers a
WHERE DATENAME( DW, a.CreatedOn) = 'Monday' 
OR DATENAME( DW, a.CreatedOn) = 'Sunday'

SELECT q.Id
FROM Questions q
WHERE q.Title = 'Java += operator'


-- 05. Problem
DECLARE @distinctAnswers TABLE (Id INT)
INSERT INTO @distinctAnswers
SELECT DISTINCT v.AnswerId AS [Id] FROM Votes v 

DECLARE resultVotesValue CURSOR READ_ONLY FOR
SELECT Id FROM @distinctAnswers
OPEN resultVotesValue

DECLARE @currentAnswerId NVARCHAR(MAX)
FETCH NEXT FROM resultVotesValue 
INTO @currentAnswerId

DECLARE @resultValue INT

WHILE @@FETCH_STATUS = 0
	BEGIN		

	SET @resultValue =
	(SELECT SUM(v.Value)
	FROM Votes v
	WHERE v.AnswerId = @currentAnswerId)

	IF (@resultValue < 0)
		BEGIN
			DELETE FROM Answers
			WHERE Id = @currentAnswerId
		END


	FETCH NEXT FROM resultVotesValue 
	INTO @currentAnswerId
	END
CLOSE resultVotesValue
DEALLOCATE resultVotesValue
GO

-- 06. Problem
INSERT INTO dbo.Questions
(
    --Id - this column value is auto-generated
    dbo.Questions.Title,
    dbo.Questions.Content,
    dbo.Questions.CategoryId,
    dbo.Questions.UserId,
    dbo.Questions.CreatedOn
)
VALUES
(
    -- Id - int
    N'Fetch NULL values in PDO query', -- Title - nvarchar
    N'When I run the snippet,
	  NULL values are converted to empty strings.
	  How can fetch NULL values?', -- Content - ntext
    (SELECT Id FROM Categories WHERE Name = 'Databases'), -- CategoryId - int
    (SELECT Id FROM Users WHERE Username = 'darkcat'), -- UserId - int
    GETDATE() -- CreatedOn - datetime
)

-- 07. 
SELECT t.Name AS Town, u.Username, COUNT(a.Id) AS AnswersCount
FROM Answers a
JOIN Users u
ON a.UserId = u.Id
JOIN Towns t
ON t.Id = u.TownId
GROUP BY t.Name, u.Username
ORDER BY AnswersCount DESC

