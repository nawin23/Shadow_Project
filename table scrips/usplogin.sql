USE [StepUp]
GO

/****** Object:  StoredProcedure [dbo].[uspLogin]    Script Date: 31-03-2022 12:37:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspLogin]
(@Username VARCHAR(50),@Password VARCHAR(50))
AS 
BEGIN
	BEGIN TRY
	
		IF @Username  IS NOT NULL and @Password IS NOT NULL 
		BEGIN
		INSERT INTO LoginUser VALUES(@Username , @Password)
		SELECT @Username= Username FROM StepUp.dbo.LoginUser where Username = @Username and Password = @Password
          SELECT * FROM StepUp.dbo.LoginUser
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

