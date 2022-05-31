USE [StepUp]
GO

/****** Object:  Table [dbo].[Employee]    Script Date: 31-03-2022 12:30:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Employee](
	[Psno] [int] NOT NULL,
	[employee_name] [varchar](50) NOT NULL,
	[email_id] [varchar](50) NOT NULL,
	[current_skills] [varchar](50) NOT NULL,
	[excepted_training] [varchar](50) NOT NULL,
	[excepted_1] [varchar](50) NOT NULL,
	[excepted_2] [varchar](50) NOT NULL,
	[excepted_3] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Employee_1] PRIMARY KEY CLUSTERED 
(
	[Psno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

