DROP TABLE IF EXISTS datetext;

CREATE TABLE `datetext` (
`col_date` DATE,
`col_text` VARCHAR(1000)
);

DROP PROCEDURE IF EXISTS usp_filltable;

DELIMITER $$
CREATE PROCEDURE usp_filltable
(IN repeat_length INT UNSIGNED,
IN in_date date,
IN in_text VARCHAR(1000)) 
BEGIN
	DECLARE W_CUS INT UNSIGNED;
	START TRANSACTION;
	  WHILE repeat_length > 0 DO   
		INSERT INTO datetext 
		( col_date, col_text)
		VALUES
		( in_date, in_text);	   
		SET repeat_length = repeat_length - 1;
	  END WHILE;
	COMMIT;
END $$
DELIMITER ;

DROP PROCEDURE IF EXISTS usp_fill_whole_table;

DELIMITER $$
CREATE PROCEDURE usp_fill_whole_table()
BEGIN
SET @u_text = "Lorem ipsum dolor sit amet, conse etur adipisicing elit,
sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.";
CALL usp_filltable (100000, "1990-01-01", @u_text);
CALL usp_filltable (100000, "1992-01-01", @u_text);
CALL usp_filltable (100000, "1994-01-01", @u_text);
CALL usp_filltable (100000, "1996-01-01", @u_text);
CALL usp_filltable (100000, "1998-01-01", @u_text);
CALL usp_filltable (100000, "2000-01-01", @u_text);
CALL usp_filltable (100000, "2002-01-01", @u_text);
CALL usp_filltable (100000, "2004-01-01", @u_text);
CALL usp_filltable (100000, "2006-01-01", @u_text);
CALL usp_filltable (100000, "2008-01-01", @u_text);
CALL usp_filltable (100000, "2010-01-01", @u_text);
END $$
DELIMITER ;

CALL usp_fill_whole_table();

ALTER TABLE datetext
PARTITION BY RANGE ( YEAR(col_date) )
(
	PARTITION p0 VALUES LESS THAN (1996),
    PARTITION p1 VALUES LESS THAN (2000),
	PARTITION p2 VALUES LESS THAN MAXVALUE
);


DELIMITER $$
CREATE PROCEDURE usp_test_expression()
BEGIN
	
    SELECT col_date, col_text  
    FROM datetext 
    WHERE col_date = YEAR(1994);
    
END $$
DELIMITER ;

SET profiling=1; 
    SELECT col_date, col_text  
    FROM datetext 
    WHERE col_date = YEAR(1994);
show profile;

    SELECT col_date, col_text  
    FROM datetext 
    WHERE col_date = YEAR(1999);
show profile;
 
    SELECT col_date, col_text  
    FROM datetext 
    WHERE col_date = YEAR(2004);
show profile;
SET profiling=0;


