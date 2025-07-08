USE [practice]
GO

/****** Object:  Table [dbo].[employees]    Script Date: 08-07-2025 05:37:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[employeesA1](
	[emp_id] [numeric](18, 0) NOT NULL,
	[name] [nchar](50) NULL,
	[salary] [numeric](18, 2) NULL
) ON [PRIMARY]
GO



--Insert Data-----------------------
INSERT INTO [dbo].[employeesA1] (emp_id, name, salary, New_Salary)
VALUES 
(1, 'Luis', 6142.00, 7370.000),
(2, 'Den', 11259.00, 13511.000),
(3, 'Alexander', 5374.00, 6449.000),
(4, 'Shelli', 12572.00, 15086.000),
(5, 'Sigal', 6897.00, 8276.000);