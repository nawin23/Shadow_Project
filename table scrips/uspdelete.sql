USE [StepUp]
GO

/****** Object:  StoredProcedure [dbo].[Usp_InsertUpdateDelete_Customer]    Script Date: 31-03-2022 12:33:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Usp_InsertUpdateDelete_Customer]  

@Psno int NULL,
@employee_name varchar(50) NULL,
@email_id varchar(50) NULL,
@current_skills varchar(50) NULL,
@excepted_training varchar(50) NULL,
@excepted_1 varchar(50) NULL,
@excepted_2 varchar(50)  NULL,
@excepted_3 varchar(50) NULL,
@Query INT  
    AS  
    BEGIN  
    
    IF (@Query = 3)  
    BEGIN  
    DELETE  
    FROM Employee  
    WHERE Employee.Psno = @Psno 
    SELECT 'Deleted'  
    END  
    END
GO

