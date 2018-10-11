
*****************************************************	 Database 	******************************************************

CREATE DATABASE ProjectManager;

*******************************************************   Tables 	**********************************************************

******************* Parent Task *******************

USE [ProjectManager]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Parent_Task](
	[Parent_ID] [int] IDENTITY(1,1) NOT NULL,
	[Parent_Task] [varchar](500) NULL,
 CONSTRAINT [PK_Parent_Task_Parent_ID] PRIMARY KEY CLUSTERED 
(
	[Parent_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO

******************* Task *******************

USE [ProjectManager]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Task](
	[Task_ID] [int] IDENTITY(1,1) NOT NULL,
	[Task] [varchar](500) NULL,
	[Project_ID] [int] NOT NULL,
	[Priority] [int] NULL,
	[Parent_ID] [int] NULL,
	[Start_Date] [date] NULL,
	[End_Date] [date] NULL,
	[User_ID] [int] NULL,
	[Status] [int] NULL,
	[Is_Active] [int] NULL,
	[Action] [varchar](50) NULL,
 CONSTRAINT [PK_Task_Task_Id] PRIMARY KEY CLUSTERED 
(
	[Task_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO

*************************** Project *************************
USE [ProjectManager]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Project](
	[Project_ID] [int] IDENTITY(1,1) NOT NULL,
	[Project] [varchar](500) NULL,
	[Start_Date] [date] NULL,
	[End_Date] [date] NULL,
	[Priority] [int] NULL,
	[Manager_ID] [int] NULL,
	[Is_Active] [int] NULL,
	[Status] [varchar](50) NULL,
 CONSTRAINT [PK_Project_Project_ID] PRIMARY KEY CLUSTERED 
(
	[Project_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO

********************* Users ***********************
USE [ProjectManager]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[User_ID] [int] IDENTITY(1,1) NOT NULL,
	[First_Name] [varchar](100) NULL,
	[Last_Name] [varchar](100) NULL,
	[Employee_ID] [int] NULL,
	[Project_ID] [int] NULL,
	[Task_ID] [int] NULL,
 CONSTRAINT [PK_Users_User_Id] PRIMARY KEY CLUSTERED 
(
	[User_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO


*******************************************************  Constariants 			**********************************************************
USE [ProjectManager]
GO
ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_Parent_ID] FOREIGN KEY([Parent_ID])
REFERENCES [dbo].[Parent_Task] ([Parent_ID])
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_Parent_ID]
GO
ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_Project_ID] FOREIGN KEY([Project_ID])
REFERENCES [dbo].[Project] ([Project_ID])
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_Project_ID]
GO
ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_User_ID] FOREIGN KEY([User_ID])
REFERENCES [dbo].[Users] ([User_ID])
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_User_ID]
GO

****************************************************		 Procedures 		************************************************************

/****** Object:  StoredProcedure [dbo].[GET_MANAGER_DETAILS]   ******/

USE [ProjectManager]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GET_MANAGER_DETAILS]

AS

BEGIN

	SELECT Employee_ID AS Manager_ID FROM Users order by Employee_ID asc

END

GO

/****** Object:  StoredProcedure [dbo].[GET_PROJECT_DETAILS]     ******/
USE [ProjectManager]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GET_PROJECT_DETAILS]

AS

BEGIN

	SELECT DISTINCT PJ.Project_ID,PJ.Project,CONVERT(date, PJ.Start_Date) AS Start_Date ,CONVERT(date, PJ.End_Date) AS End_Date,PJ.Priority,PJ.Manager_ID,
	TK.Status,(select count(*) from Task where Project_ID = PJ.Project_ID) AS TaskCount,CASE TK.Status WHEN 1 THEN 'Completed' ELSE 'Pending' END AS ProjStatus
	 FROM Project PJ INNER JOIN Task TK ON TK.Project_ID = PJ.Project_ID;

END
GO
/****** Object:  StoredProcedure [dbo].[GET_PROJECTNAME_DETAILS]    ******/


USE [ProjectManager]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GET_PROJECTNAME_DETAILS]

AS

BEGIN

	SELECT Project_ID,Project FROM Project;

END
GO

/****** Object:  StoredProcedure [dbo].[GET_TASK_DETAILS]     ******/
USE [ProjectManager]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GET_TASK_DETAILS]

AS

BEGIN

	SELECT DISTINCT Task_ID,TK.Parent_ID,PT.Parent_Task AS Parent_Task,Task,CONVERT(date, Start_Date) AS Start_Date,CONVERT(date, End_Date) AS End_Date,Priority,Project_ID,Status,User_ID 
	FROM Task TK INNER JOIN Parent_Task PT ON TK.Parent_ID = PT.Parent_ID;

END



GO

/****** Object:  StoredProcedure [dbo].[GET_USER_DETAILS]     ******/
USE [ProjectManager]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GET_USER_DETAILS]

AS

BEGIN

	SELECT User_ID,First_Name,Last_Name,Employee_ID,Project_ID,Task_ID FROM Users;

END
GO
/****** Object:  StoredProcedure [dbo].[INSERT_PROJECT_DETAILS]   ******/
USE [ProjectManager]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[INSERT_PROJECT_DETAILS]
(

@Project_ID INT,
@Project VARCHAR(500),
@Start_Date DATETIME,
@End_Date DATETIME,
@Priority INT,
@Manager_ID INT,
@Is_Active INT,
@Status VARCHAR(50)
)

AS

BEGIN

	IF(@Project_ID=0)
		BEGIN

			INSERT INTO Project(Project_ID,Project,Start_Date,End_Date,Priority,Manager_ID)VALUES ((select COUNT(*)+1 from Project),@Project,@Start_Date,@End_Date,@Priority,@Manager_ID);
			
		END

	ELSE 
		BEGIN
			
		  UPDATE Project SET Project=@Project,Start_Date=@Start_Date,End_Date=@End_Date,Priority=@Priority,Manager_ID=@Manager_ID
		  WHERE Project_ID = @Project_ID;

		END
END
GO
/****** Object:  StoredProcedure [dbo].[INSERT_TASK_DETAILS]     ******/
USE [ProjectManager]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[INSERT_TASK_DETAILS]
(

@Task_ID INT,
@Task VARCHAR(500),
@Project_ID INT,
@Priority INT,
@Parent_ID INT,
@Start_Date DATETIME,
@End_Date DATETIME,
@User_ID INT,
@Status INT,
@Is_Active INT,
@Action VARCHAR(50)
)

AS

BEGIN

	IF(@Task_ID=0)
		BEGIN

			INSERT INTO Task(Task_ID,Task,Project_ID,Priority,Parent_ID,Start_Date,End_Date,User_ID,Status,Is_Active,Action)VALUES 
			((select COUNT(*)+1 from Task),@Task,@Project_ID,@Priority,@Parent_ID,@Start_Date,@End_Date,@User_ID,@Status,@Is_Active,@Action);
			
		END

	ELSE 
		BEGIN
			
		  UPDATE Task SET Task=@Task,Project_ID=@Project_ID,Priority=@Priority,Parent_ID=@Parent_ID,Start_Date=@Start_Date,End_Date=@End_Date,User_ID=@User_ID,
		  Status=@Status,Is_Active=@Is_Active,Action=@Action
		  WHERE Task_ID = @Task_ID;


		END
END
GO
/****** Object:  StoredProcedure [dbo].[INSERT_USER_DETAILS]     ******/
USE [ProjectManager]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[INSERT_USER_DETAILS]
(

@User_ID INT,
@First_Name VARCHAR(100),
@Last_Name VARCHAR(100),
@Employee_ID INT,
@Project_ID INT,
@Task_ID INT,
@Action Varchar(50)
)

AS

BEGIN

IF(@Action='delete')
	BEGIN

		Delete from Users where User_ID = @User_ID;

	END

ELSE

	BEGIN
		IF(@User_ID=0)
		BEGIN

			INSERT INTO Users(User_ID,First_Name,Last_Name,Employee_ID,Project_ID,Task_ID)VALUES ((select COUNT(*)+1 from Users),@First_Name,@Last_Name,@Employee_ID,@Project_ID,@Task_ID);
			
		END

	ELSE 
		BEGIN
			
		  UPDATE Users SET First_Name=@First_Name,Last_Name=@Last_Name,Employee_ID=@Employee_ID,Project_ID=@Project_ID,Task_ID=@Task_ID
		  WHERE User_ID = @User_ID;

		END
	END
END
GO
/****** Object:  StoredProcedure [dbo].[UPDATE_END_TASK]    ******/
USE [ProjectManager]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UPDATE_END_TASK]
(
@Task_ID INT,
@End_Date DATETIME
)

AS

BEGIN

	UPDATE Task SET End_Date=@End_Date,Is_Active=0 WHERE Task_ID = @Task_ID;

END

GO
