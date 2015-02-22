/* EXECUTE Persons-DB-Schema-and-Data.sql IN ORDER TO CREATE Persons DB */

-- 01. Write a stored procedure that selects the full names of all persons.
USE [Persons]
GO

CREATE PROC dbo.usp_FullNamesOfAllPersons
AS
	SELECT p.FirstName + ' ' + p.LastName AS [Persons Full Name]
	FROM Persons p
GO

EXEC usp_FullNamesOfAllPersons
GO

-- 02. create a stored procedure that accepts a number as a parameter and returns
-- all persons who have more money in their accounts than the supplied number.
USE Persons
GO

CREATE PROC dbo.usp_AllPersonsWithMoreMoneyThan
(@moneyLevel MONEY) 
AS
	SELECT p.FirstName + ' ' + p.LastName, a.Balance
	FROM Persons p
	JOIN Accounts a
	ON p.ID = a.PersonID
	WHERE a.Balance > @moneyLevel
GO

EXEC usp_AllPersonsWithMoreMoneyThan 200
GO

-- 03. create a function that accepts as parameters � sum, yearly interest rate
-- and number of months. It should calculate and return the new sum. Write a SELECT
-- to test whether the function works as expected.
USE Persons
GO

CREATE FUNCTION usf_CalcInterest
(@sum money, @rate money, @numberOfMonths money) 
RETURNS money
AS
BEGIN
  DECLARE @result money;
  DECLARE @r money SET @r = @rate/100;
  DECLARE @t money SET @t = @numberOfMonths/12;

  SET @result = @sum*(1+(@r * @t));
  RETURN @result;
END
GO

DROP FUNCTION usf_CalcInterest
-- to execute function we have to assign it to scalar variable with the params
-- and then SELECT variable
-- execute all three following rows together in order to recieve result
DECLARE @interestCalc MONEY;
EXEC @interestCalc = usf_CalcInterest @sum=100, @rate = 4, @numberOfMonths=6
SELECT @interestCalc AS [Interest]
GO

-- 04 Your task is to create a stored procedure that uses the function from 
-- the previous example to give an interest to a person's account for one month.
-- It should take the AccountId and the interest rate as parameters.
USE Persons
GO

CREATE PROC usp_PersonsInterest
(@accountId INT, @interestRate MONEY)
AS
	DECLARE @personAccountAmount MONEY
	SET @personAccountAmount = 
	(SELECT a.Balance FROM Accounts a WHERE a.ID = @accountId)

	DECLARE @interestCalc MONEY;
	EXEC @interestCalc = usf_CalcInterest @sum = @personAccountAmount, @rate = @interestRate, @numberOfMonths = 1

	SELECT p.FirstName + ' ' + p.LastName AS [Person Name], @interestCalc AS [Interest Per Month] 
	FROM Persons p
	JOIN Accounts a 
	ON a.PersonID = p.ID
	WHERE a.ID = @accountId
GO

EXEC usp_PersonsInterest @accountId = 1, @interestRate = 3
GO

-- 05. Add two more stored procedures WithdrawMoney (AccountId, money)
-- and DepositMoney (AccountId, money) that operate in transactions. 
USE Persons
GO

CREATE PROC usp_WithdrawMoney
(@accounId INT, @moneyWithdrawAmmount MONEY)
AS
	DECLARE @accountAvailabilityBefore MONEY
	SET @accountAvailabilityBefore = 
	(SELECT a.Balance FROM Accounts a WHERE a.ID = @accounId)

	DECLARE @accountAvailabilityAfter MONEY
	SET @accountAvailabilityAfter = @accountAvailabilityBefore - @moneyWithdrawAmmount
	
	BEGIN TRAN 
		IF NOT (EXISTS (SELECT * FROM Accounts WHERE ID = @accounId))
		BEGIN
			PRINT 'No such account ! Please try another account.'
			ROLLBACK TRAN
		END
		ELSE IF (@accountAvailabilityAfter < 0)
			BEGIN
				PRINT 'No enought money in the account !' +
				' Current Availability - ' + convert(varchar(50), @accountAvailabilityBefore, 1) +
				' You tryed to withdraw - ' + convert(varchar(50), @moneyWithdrawAmmount, 1);
				ROLLBACK TRAN 			
			END
		ELSE IF (@moneyWithdrawAmmount < 1)
			BEGIN
				PRINT 'Amount '+ convert(varchar(50), @moneyWithdrawAmmount, 1) +' Try another amount !';
				ROLLBACK TRAN 				
			END
		ELSE
			BEGIN
				UPDATE [Accounts]
				SET [Balance] = @accountAvailabilityBefore - @moneyWithdrawAmmount
				WHERE ID = @accounId;
				COMMIT TRAN 
			END
GO

-- asure the account have enought cash to experiment with
UPDATE Accounts
SET Balance = 23413423
WHERE ID = 1
GO
-- withdraw available sum
SELECT a.Balance FROM Accounts a WHERE a.ID = 1;
EXEC usp_WithdrawMoney @accounId = 1, @moneyWithdrawAmmount = 13413423;
SELECT a.Balance FROM Accounts a WHERE a.ID = 1;
GO
-- withdraw unavailable sum
SELECT a.Balance FROM Accounts a WHERE a.ID = 1;
EXEC usp_WithdrawMoney @accounId = 1, @moneyWithdrawAmmount = 33413423;
SELECT a.Balance FROM Accounts a WHERE a.ID = 1;
GO

CREATE PROC usp_DepositMoney
(@accountId INT, @moneyToDeposit MONEY)
AS
	DECLARE @accountAvailabilityBefore MONEY
	SET @accountAvailabilityBefore = 
	(SELECT a.Balance FROM Accounts a WHERE a.ID = @accountId)
	BEGIN TRAN
	IF NOT (EXISTS (SELECT * FROM Accounts WHERE ID = @accountId))
		BEGIN
			PRINT 'No such account ! Please try another account.'
			ROLLBACK TRAN
		END
	ELSE IF (@moneyToDeposit <= 0)
		BEGIN
			PRINT 'Non supported amount for deposit. Please select oter amount.'
			ROLLBACK TRAN
		END
	ELSE
		BEGIN
			UPDATE [Accounts]
			SET [Balance] = @accountAvailabilityBefore + @moneyToDeposit
			WHERE ID = @accountId;
			COMMIT TRAN
		END 
GO

-- deposit available sum
SELECT a.Balance FROM Accounts a WHERE a.ID = 1;
EXEC usp_DepositMoney @accountId = 1, @moneyToDeposit = 10000000;
SELECT a.Balance FROM Accounts a WHERE a.ID = 1;
GO
-- deposit unavailable sum
SELECT a.Balance FROM Accounts a WHERE a.ID = 1;
EXEC usp_DepositMoney @accountId = 1, @moneyToDeposit = -30;
SELECT a.Balance FROM Accounts a WHERE a.ID = 1;
GO

-- 06 Create another table � Logs (LogID, AccountID, OldSum, NewSum).
-- Add a trigger to the Accounts table that enters a new entry into 
-- the Logs table every time the sum on an account changes. 
USE Persons
GO

CREATE TABLE Logs
(
	LogId INT IDENTITY,
	AccountID INT NOT NULL,
	OldSum MONEY,
	NewSum MONEY,
	CONSTRAINT PK_LogId PRIMARY KEY(LogId),	
	CONSTRAINT FK_Logs_Account FOREIGN KEY(AccountID) REFERENCES Accounts(ID)
)
GO

CREATE TRIGGER tr_AccountLogs 
ON [Accounts]
FOR UPDATE, INSERT
AS
BEGIN
	DECLARE @accountID INT;
	SET @accountID = (SELECT i.ID FROM INSERTED i);

	DECLARE @newBallance MONEY;
	SET @newBallance = (SELECT i.Balance FROM INSERTED i)

    IF EXISTS(SELECT * FROM DELETED)
    BEGIN
		DECLARE @oldBallance MONEY;
		SET @oldBallance = (SELECT d.Balance FROM DELETED d);
    END

	INSERT INTO dbo.Logs
	(
	    dbo.Logs.AccountID,
	    dbo.Logs.OldSum,
	    dbo.Logs.NewSum
	)
	VALUES
	(
	    @accountID, -- AccountID - INT
	    @oldBallance, -- OldSum - MONEY
	    @newBallance -- NewSum - MONEY
	)
END
GO

-- withdraw available sum
SELECT * FROM Logs l
EXEC usp_WithdrawMoney @accounId = 1, @moneyWithdrawAmmount = 13413423;
SELECT * FROM Logs l
GO
-- deposit money
SELECT * FROM Logs l
EXEC usp_DepositMoney @accountId = 1, @moneyToDeposit = 10000000;
SELECT * FROM Logs l
GO

-- 07. Define a function in the database SoftUni that returns all 
-- Employee's names (first or middle or last name) and all town's 
-- names that are comprised of given set of letters. 
-- Example: 'oistmiahf' will return 'Sofia', 'Smith', but not 'Rob' and 'Guy'.
use SoftUni
GO

CREATE FUNCTION fn_FilterTownsEmployees
  ( @filterString nvarchar(50))
RETURNS @tbl_FilteredNames TABLE
(Name NVARCHAR(50))
AS
BEGIN
	
	RETURN
END
GO

	DECLARE @filterString NVARCHAR(20)
	SET @filterString = 'oistmiahf'

	DECLARE @filterChar NCHAR
	-- extract every chracter from @filterString into table @charTable
	-- on single row. For future iterating on.
	DECLARE @charTable TABLE (Characters NCHAR)
	INSERT INTO @charTable
	SELECT SUBSTRING(a.b, v.number+1, 1) 
	FROM (SELECT @filterString b) a
	JOIN MASTER..spt_values v ON v.number < LEN(a.b)
	WHERE v.TYPE = 'P'

	-- use cursor to iterate through character rows of @charTable
	DECLARE charCursor CURSOR READ_ONLY FOR
	SELECT Characters FROM @charTable
	OPEN charCursor

	DECLARE @FilteredNames TABLE (Name NVARCHAR(50)) 
	--CREATE TABLE #FilteredNamesTwo(Name NVARCHAR(50))

	DECLARE @currentChar char(1)
	FETCH NEXT FROM charCursor 
	INTO @currentChar

	-- FirstName filter
	INSERT INTO @FilteredNames
	SELECT e.FirstName
	FROM Employees e
	WHERE e.FirstName LIKE '%['+@currentChar+']%'
	-- LastName filter
	INSERT INTO @FilteredNames
	SELECT e.LastName
	FROM Employees e
	WHERE e.LastName LIKE '%['+@currentChar+']%'
	-- Town Name filter
	INSERT INTO @FilteredNames
	SELECT t.Name
	FROM Towns t
	WHERE t.Name LIKE '%['+@currentChar+']%'  

	DECLARE @currentTableName NVARCHAR(20)
	SET @currentTableName = 'One';

	WHILE @@FETCH_STATUS = 0
	  BEGIN
		
			INSERT INTO @FilteredNames
			SELECT f.Name
			FROM @FilteredNames f
			WHERE f.Name LIKE '%['+@currentChar+']%'

		FETCH NEXT FROM charCursor 
		INTO @currentChar
	  END
	CLOSE charCursor
	DEALLOCATE charCursor

	SELECT * FROM @FilteredNames
GO

	
	----------------------------

		DECLARE @filterString NVARCHAR(20)
	SET @filterString = 'oistmiahf'

	-- extract every chracter from @filterString into table @charTable
	-- on single row. For future iterating on.
	DECLARE @charTable TABLE (Characters NCHAR)
	INSERT INTO @charTable
	SELECT SUBSTRING(a.b, v.number+1, 1) 
	FROM (SELECT @filterString b) a
	JOIN MASTER..spt_values v ON v.number < LEN(a.b)
	WHERE v.TYPE = 'P'

	------------------------------
	DECLARE @FilteredNames TABLE (Name NVARCHAR(50)) 

		-- FirstName filter
	INSERT INTO @FilteredNames
	SELECT e.FirstName
	FROM Employees e
	WHERE e.FirstName LIKE '%['+@filterString+']%'
	-- LastName filter
	INSERT INTO @FilteredNames
	SELECT e.LastName
	FROM Employees e
	WHERE e.LastName LIKE '%['+@filterString+']%'
	-- Town Name filter
	INSERT INTO @FilteredNames
	SELECT t.Name
	FROM Towns t
	WHERE t.Name LIKE '%['+@filterString+']%'

	-----------------------

	-- use cursor to iterate through character rows of @charTable
	DECLARE charCursor CURSOR READ_ONLY FOR
	SELECT Characters FROM @charTable
	OPEN charCursor

	DECLARE @Table1 TABLE (Name NVARCHAR(50))
	DECLARE @Table2 TABLE (Name NVARCHAR(50))

	DECLARE @currentChar char(1)
	FETCH NEXT FROM charCursor 
	INTO @currentChar

	INSERT INTO @Table1
	SELECT f.Name
	FROM @FilteredNames f
	WHERE f.Name LIKE '%'+@currentChar+'%'

	WHILE @@FETCH_STATUS = 0
	  BEGIN		

			INSERT INTO @Table2
			SELECT f.Name
			FROM @Table1 f
			WHERE f.Name LIKE '%'+@currentChar+'%'

			DELETE FROM @Table1

			INSERT INTO @Table1
			SELECT * FROM @Table2

			DELETE FROM @Table2

				SELECT * FROM @Table1
		FETCH NEXT FROM charCursor 
		INTO @currentChar
	  END
	CLOSE charCursor
	DEALLOCATE charCursor

	SELECT * FROM @Table1

/* 08. Using database cursor write a T-SQL script that scans all employees
 and their addresses and prints all pairs of employees that live in the same town.*/
 USE SoftUni
 GO

 /* PROCEDURE TO ASSIGN FIrst+Last name to string searched by EmployeeID */
----------------------------------------------------------
CREATE PROCEDURE dbo.usp_EmployeeFirstLastNameByID
   @employeeID INT,
   @result NVARCHAR(50) OUTPUT
AS
   SET @result = 
   (SELECT e.FirstName + ' ' + e.LastName
	FROM Employees e
	JOIN Addresses a
	ON a.AddressID = e.AddressID
	JOIN Towns t
	ON t.TownID = a.TownID
	WHERE e.EmployeeID = @employeeID)
GO
-----------------------------------------------------------

 /* PROCEDURE TO ASSIGN Name+Name to string searched by EmployeeID, EmployeeID */
----------------------------------------------------------
CREATE PROCEDURE dbo.usp_ConcatenateNamesByID
   @firstEmployeeID INT,
   @secondEmployeeID INT,
   @result NVARCHAR(50) OUTPUT
AS

	DECLARE @firstEmp NVARCHAR(50)
	EXECUTE usp_EmployeeFirstLastNameByID @firstEmployeeID,  @firstEmp OUTPUT


	DECLARE @secondEmp NVARCHAR(50)
	EXECUTE usp_EmployeeFirstLastNameByID @secondEmployeeID,  @secondEmp OUTPUT

   SET @result = @firstEmp + @secondEmp
GO
-----------------------------------------------------------

 /* PROCEDURE TO ASSIGN TownID by EmployeeID */
----------------------------------------------------------
CREATE PROCEDURE dbo.usp_TownIDByEmployeeID
   @EmployeeID INT,
   @result INT OUTPUT
AS 
	SET @result =
		(SELECT t.TownID 
		FROM Employees e
		JOIN Addresses a
		ON a.AddressID = e.AddressID
		JOIN Towns t
		ON t.TownID = a.TownID
		WHERE e.EmployeeID = @EmployeeID)
GO
-----------------------------------------------------------

 /* PROCEDURE Town Name By EmployeeID */
----------------------------------------------------------
CREATE PROCEDURE dbo.usp_TownNameByEmployeeID
   @employeeID INT,
   @result NVARCHAR(50) OUTPUT
AS 
	SET @result =
		(SELECT t.Name
		FROM Employees e
		JOIN Addresses a
		ON a.AddressID = e.AddressID
		JOIN Towns t
		ON t.TownID = a.TownID
		WHERE e.EmployeeID = @employeeID)
GO
-----------------------------------------------------------

 /* PROCEDURE Employee First+Last Name by TownID */
----------------------------------------------------------
CREATE PROCEDURE dbo.usp_EmployeesByTownID
   @TownID INT
AS 
	SELECT e.FirstName + ' ' + e.LastName
	FROM Employees e
	JOIN Addresses a
	ON a.AddressID = e.AddressID
	JOIN Towns t
	ON t.TownID = a.TownID
	WHERE t.TownID = @TownID
GO
-----------------------------------------------------------

CREATE PROCEDURE usp_ExtractEmployeesPairsByTown
AS
	SET NOCOUNT ON
	DECLARE @resultTable TABLE (Strings NVARCHAR(200))

	DECLARE employeesCursor CURSOR READ_ONLY FOR
	SELECT EmployeeID FROM Employees
	OPEN employeesCursor

	DECLARE @currentEmployeeId INT
	FETCH NEXT FROM employeesCursor 
	INTO @currentEmployeeId

		DECLARE @currentEmpTownID INT
		DECLARE @currentEmployeTownName NVARCHAR(50)
		DECLARE @employeesFromTown TABLE (EmployeeNames NVARCHAR(50))
		DECLARE @currentEmployeeNames NVARCHAR(50)

		WHILE @@FETCH_STATUS = 0
			BEGIN
		  /* UPDATE VARIABLES BLOCK */
		----------------------------------------------------------------------------------------------
				EXECUTE usp_TownIDByEmployeeID @currentEmployeeId, @currentEmpTownID OUTPUT
				EXECUTE usp_TownNameByEmployeeID @currentEmployeeId, @currentEmployeTownName OUTPUT
				INSERT INTO @employeesFromTown 
				EXECUTE usp_EmployeesByTownID @currentEmpTownID
				EXECUTE usp_EmployeeFirstLastNameByID @currentEmployeeId, @currentEmployeeNames OUTPUT
				
				INSERT INTO @resultTable
				SELECT @currentEmployeTownName + ': ' + @currentEmployeeNames + ' ' + em.EmployeeNames
				FROM @employeesFromTown	em
		----------------------------------------------------------------------------------------------

				DELETE FROM @EmployeesFromTown

			FETCH NEXT FROM employeesCursor 
			INTO @currentEmployeeId
			END
		CLOSE employeesCursor
	DEALLOCATE employeesCursor

		/* PRINT RESULT TABLE */
	------------------------------------------------------------------------
	DECLARE resultTableCursor CURSOR READ_ONLY FOR
	SELECT Strings FROM @resultTable
	OPEN resultTableCursor

	DECLARE @currentResultString NVARCHAR(200)
	FETCH NEXT FROM resultTableCursor 
	INTO @currentResultString

	WHILE @@FETCH_STATUS = 0
		BEGIN		

		PRINT @currentResultString

		FETCH NEXT FROM resultTableCursor 
		INTO @currentResultString
		END
	CLOSE resultTableCursor
	DEALLOCATE resultTableCursor
	GO
	-----------------------------------------------------------------------------------	
GO

/* EXECUTE TO OBTAIN THE RESULTS */
EXECUTE usp_ExtractEmployeesPairsByTown
GO
/* 09. Define a .NET aggregate function StrConcat that takes as input a sequence of 
strings and return a single string that consists of the input strings separated by ','.*/

USE [SoftUni] 
GO

/* ENABLE CLR EXTERNAL USE */
sp_configure 'clr enabled', 1
GO
RECONFIGURE
GO

/* LOAD EXTERNAL ASSEMBLY PATH SHOUD ASSSIGN THE PATH TO StrConcat.dll (FROM Homework-Transact-SQL FOLDER) */
CREATE ASSEMBLY StrConcat 
FROM 'C:\StrConcat.dll'
WITH permission_set = Safe;
GO

CREATE AGGREGATE StrConcat (@input nvarchar(200)) RETURNS nvarchar(max)
EXTERNAL NAME StrConcat.StrConcat;
GO

SELECT dbo.StrConcat(FirstName + ' ' + LastName)
FROM Employees
GO

/* 10. Write a T-SQL script that shows for each town a 
list of all employees that live in it.*/

CREATE PROCEDURE usp_TownEmployeesList
AS
	SET NOCOUNT ON
	DECLARE @resultTable TABLE (Result NVARCHAR(MAX))
	INSERT INTO @resultTable
	SELECT t.Name + ' -> ' + dbo.StrConcat(FirstName + ' ' + LastName)
	FROM Employees e
	JOIN Addresses a
	ON e.AddressID = a.AddressID
	JOIN Towns t
	ON t.TownID = a.TownID
	GROUP BY t.Name

	/* PRINT RESULT TABLE */
	------------------------------------------------------------------------
	DECLARE resultTableCursor CURSOR READ_ONLY FOR
	SELECT Result FROM @resultTable
	OPEN resultTableCursor

	DECLARE @currentResultString NVARCHAR(MAX)
	FETCH NEXT FROM resultTableCursor 
	INTO @currentResultString

	WHILE @@FETCH_STATUS = 0
		BEGIN		

		PRINT @currentResultString

		FETCH NEXT FROM resultTableCursor 
		INTO @currentResultString
		END
	CLOSE resultTableCursor
	DEALLOCATE resultTableCursor
GO

EXECUTE usp_TownEmployeesList
