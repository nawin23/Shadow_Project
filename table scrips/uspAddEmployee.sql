USE [StepUp]
GO

/****** Object:  StoredProcedure [dbo].[uspAddEmployee]    Script Date: 19-05-2022 15:03:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspAddEmployee]
(@Psno int,@employee_name VARCHAR(50),@email_id VARCHAR(50),@current_skill VARCHAR(50),@expected_training VARCHAR(50),@expected_1 VARCHAR(50),@expected_2 VARCHAR(50),@expected_3 VARCHAR(50))
AS 
BEGIN
	BEGIN TRY
	
		IF @Psno  IS NOT NULL and @employee_name IS NOT NULL and @email_id IS NOT NULL and @current_skill  IS NOT NULL and @expected_training  IS NOT NULL and @expected_1 IS NOT NULL and @expected_2 IS NOT NULL and @expected_3 IS NOT NULL
		BEGIN
		INSERT INTO Employee VALUES(@Psno , @employee_name ,@email_id ,@current_skill ,@expected_training ,@expected_1 ,@expected_2 ,@expected_3)
		RETURN 1
		END
		ELSE
		RETURN -2
	END TRY
	BEGIN CATCH
		RETURN -99
    END CATCH
END
GO

