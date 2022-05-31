USE [StepUp]
GO

/****** Object:  StoredProcedure [dbo].[uspUpdateEmp]    Script Date: 31-03-2022 12:34:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspUpdateEmp]
(@Psno int , @employee_name VARCHAR(50),@email_id VARCHAR(50),@current_skill VARCHAR(50),@expected_training VARCHAR(50),@expected_1 VARCHAR(50),@expected_2 VARCHAR(50),@expected_3 VARCHAR(50))
AS
BEGIN 
    BEGIN TRY
	   UPDATE Employee SET current_skills = @current_skill,excepted_training =@expected_training ,excepted_1 = @expected_1,excepted_2 = @expected_2 ,excepted_3 = @expected_3, email_id = @email_id  WHERE Psno  =@Psno  ;
	   RETURN 1
	   END TRY
	   BEGIN CATCH
	       RETURN -99
	   END CATCH
END
GO

