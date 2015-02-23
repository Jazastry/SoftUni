CREATE DATABASE TestsDB
GO

USE TestsDB
GO

CREATE TABLE DatesAndText
(
	[Date] DATE,
	[Text] TEXT
)
GO

CREATE PROC usp_PopulateDatesAndText
	@repeat INT,
	@text NVARCHAR(MAX),
	@date DATE
AS
	BEGIN TRANSACTION
		WHILE (@repeat > 0)
		BEGIN
			INSERT INTO DatesAndText ([Date], [Text])
			VALUES (@date, @text)
			SET @repeat = @repeat - 1
		END
	COMMIT TRANSACTION
GO

CREATE PROC usp_FullDatesAndText
AS
	DECLARE @i INT
	SET @i = 1000000;

	DECLARE @txt NVARCHAR(MAX)
	SET @txt = 'Lorem ipsum dolor sit amet, consectetur adipisicing elit,
	 sed do eiusmod tempor.';

	/* creation time is measured on Solid State Drive approx - 160mb/s(read,write)*/
	EXECUTE usp_PopulateDatesAndText @repeat = @i, @text = @txt, @date = '1990-1-1'
	EXECUTE usp_PopulateDatesAndText @repeat = @i, @text = @txt, @date = '1992-1-1'
	EXECUTE usp_PopulateDatesAndText @repeat = @i, @text = @txt, @date = '1994-1-1'
	EXECUTE usp_PopulateDatesAndText @repeat = @i, @text = @txt, @date = '1996-1-1' /*creation time - 00:02:07*/
	EXECUTE usp_PopulateDatesAndText @repeat = @i, @text = @txt, @date = '1998-1-1' /*creation time - 00:01:30*/
	EXECUTE usp_PopulateDatesAndText @repeat = @i, @text = @txt, @date = '2000-1-1'
	EXECUTE usp_PopulateDatesAndText @repeat = @i, @text = @txt, @date = '2002-1-1'
	EXECUTE usp_PopulateDatesAndText @repeat = @i, @text = @txt, @date = '2004-1-1' /*creation time - 00:02:05 */
	EXECUTE usp_PopulateDatesAndText @repeat = @i, @text = @txt, @date = '2006-1-1' /*creation time - 00:03:02 */
	EXECUTE usp_PopulateDatesAndText @repeat = @i, @text = @txt, @date = '2008-1-1' /*creation  - 00:02:31 */
	EXECUTE usp_PopulateDatesAndText @repeat = @i, @text = @txt, @date = '2010-1-1' /*creation time - 00:03:18 */
GO

EXECUTE usp_FullDatesAndText;
GO

/* CHECK SPEED TESTS NON INDEXED */
-- clear cache --
CHECKPOINT; 
DBCC DROPCLEANBUFFERS; 
GO
SELECT [Date], [Text]	/* time - 65351 ms */
FROM DatesAndText
WHERE Date < '1994-1-1'
GO
CHECKPOINT; 
DBCC DROPCLEANBUFFERS; 
GO
SELECT [Date], [Text]   /* time - 124560 ms */
FROM DatesAndText
WHERE [Date] > '1994-1-1'
AND [Date] < '2000-1-1'
GO
CHECKPOINT; 
DBCC DROPCLEANBUFFERS; 
GO
SELECT [Date], [Text]	/* time - 49455 ms */
FROM DatesAndText
WHERE [Date] > '2008-1-1'
GO


CREATE NONCLUSTERED INDEX IDX_Date 
    ON DatesAndText([Date]); 
GO

/* CHECK SPEED TESTS INDEXED */
-- clear cache --
CHECKPOINT; 
DBCC DROPCLEANBUFFERS; 
GO
SELECT [Date], [Text]	/* time - 24562 */
FROM DatesAndText
WHERE Date < '1994-1-1'
GO
CHECKPOINT; 
DBCC DROPCLEANBUFFERS; 
GO
SELECT [Date], [Text]	/* time - 44281 */
FROM DatesAndText
WHERE [Date] > '1994-1-1'
AND [Date] < '2000-1-1'
GO
CHECKPOINT; 
DBCC DROPCLEANBUFFERS; 
GO
SELECT [Date], [Text]	/* time - 22812 */
FROM DatesAndText
WHERE [Date] > '2008-1-1'
GO