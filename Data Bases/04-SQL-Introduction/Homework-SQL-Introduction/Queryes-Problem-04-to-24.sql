-- Problem 5. ... all department names. 
SELECT depart.Name
FROM Departments depart;

-- Problem 6. ... the salary of each employee. 
SELECT employee.FirstName + ' ' +
	   employee.LastName as [Employee Full Name] ,
	   employee.Salary
FROM Employees employee

-- Problem 7. ... find the full name of each employee. 
SELECT employee.FirstName + ' ' + employee.LastName 
	   as [Employee Full Name]
FROM Employees employee

-- Problem 8.	... find the email addresses of each employee.
SELECT emp.FirstName +'.'+ emp.LastName + '@softuni.bg' 
	as [Full Email Addres]
FROM Employees emp;

-- Problem 9.	... find all different employee salaries. 
SELECT DISTINCT emplo.Salary
FROM Employees emplo;

-- Problem 10.	... find all information about the employees
-- whose job title is “Sales Representative“.
SELECT *
FROM Employees emp
WHERE emp.JobTitle = 'Sales Representative';

-- Problem 12.	... find the names of all employees
-- whose last name contains "ei".
SELECT *
FROM Employees emp
WHERE emp.LastName LIKE '%ei%';

-- Problem 13.	... find the salary of all employees whose 
-- salary is in the range [20000…30000].
SELECT empl.Salary
FROM Employees empl
WHERE empl.Salary BETWEEN 20000 AND 30000
ORDER BY empl.Salary ASC;

-- Problem 14. ... find the names of all employees whose
-- salary is 25000, 14000, 12500 or 23600.
SELECT emplo.FirstName + ' ' + emplo.LastName as [Full Name],
	emplo.Salary
FROM Employees emplo
WHERE emplo.Salary IN (25000, 14000, 12500, 23600)
ORDER BY emplo.Salary ASC;

-- Problem 15. ... all employees that do not have manager.
SELECT *
FROM Employees emp
WHERE emp.ManagerID IS NULL;

-- Problem 16. ... find all employees that have salary more 
-- than 50000. Order them in decreasing order by salary.
SELECT emplo.FirstName + ' ' +
	emplo.LastName as [Full Name],
	emplo.Salary
FROM Employees emplo
WHERE emplo.Salary > 50000
ORDER BY emplo.Salary DESC;

-- Problem 17. ... find the top 5 best paid employees.
SELECT TOP 5 emplo.Salary, 
	emplo.FirstName + ' ' +
	emplo.LastName as [Full Name],
	emplo.JobTitle
FROM Employees emplo
ORDER BY emplo.Salary DESC;

-- Problem 18.	... all employees along with their address.
SELECT emplo.FirstName + ' ' +
	emplo.LastName as [Full Name],
	addres.AddressText
FROM Employees emplo
JOIN Addresses addres
ON emplo.AddressID = addres.AddressID;

-- Problem 19. ... find all employees and their address.
SELECT emplo.FirstName + ' ' +
	emplo.LastName as [Full Name],
	addres.AddressText
FROM Employees emplo, Addresses addres
WHERE addres.AddressID = emplo.AddressID
ORDER BY emplo.FirstName ASC;

-- Problem 20. ... find all employees along with their manager.
SELECT emplo.FirstName + ' ' +
	emplo.LastName as [Employee Full Name],
	manager.FirstName + ' ' +
	manager.LastName as [Manager Full Name]
FROM Employees emplo
JOIN Employees manager
ON manager.EmployeeID = emplo.ManagerID;

-- Problem 21. ... find all employees, along with their manager 
-- and their address.
SELECT emplo.FirstName + ' ' +
	emplo.LastName as [Employee Full Name],
	addres.AddressText as [Address],
	manager.FirstName + ' ' +
	manager.LastName as [Manager Full Name]
FROM Employees emplo
JOIN Employees manager
ON manager.EmployeeID = emplo.ManagerID
JOIN Addresses addres
ON emplo.AddressID = addres.AddressID;

-- Problem 22.	... find all departments and all town names
-- as a single list.

SELECT dep.Name, 'Department' as [Type]
FROM Departments dep
UNION
SELECT town.Name, 'Town Name' as [Type]
FROM Towns town;

-- Problem 23. ... find all the employees and the manager 
-- for each of them along with the employees that do not have manager. 

SELECT emplo.FirstName + ' ' +
	emplo.LastName as [Employee Full Name],
	manager.FirstName + ' ' +
	manager.LastName as [Manager Full Name]
FROM Employees emplo
LEFT OUTER JOIN Employees manager
ON manager.EmployeeID = emplo.ManagerID;

-- Problem 24. ... find the names of all employees from the departments 
-- "Sales" and "Finance" whose hire year is between 1995 and 2005.
SELECT emplo.FirstName + ' ' +
	emplo.LastName as [Employee Full Name],
	emplo.HireDate
FROM Employees emplo
JOIN Departments d
ON d.Name IN ('Sales', 'Finance')
WHERE emplo.HireDate BETWEEN '1995/01/01' AND '2006/01/01';
