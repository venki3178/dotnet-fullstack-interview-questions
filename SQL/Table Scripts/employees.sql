USE [practice]
GO

/****** Object:  Table [dbo].[employees]    Script Date: 08-07-2025 05:37:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[employees](
	[emp_id] [numeric](18, 0) NOT NULL,
	[name] [nchar](50) NULL,
	[salary] [numeric](18, 2) NULL
) ON [PRIMARY]
GO

