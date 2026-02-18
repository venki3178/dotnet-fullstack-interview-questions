--Q1.  Write an SQL query to fetch the names of the customer that are not referred by the customer with id = 102.

--SELECT * FROM [dbo].[customer]

--Answer

SELECT name FROM [dbo].[customer]
WHERE referee_id <> 102