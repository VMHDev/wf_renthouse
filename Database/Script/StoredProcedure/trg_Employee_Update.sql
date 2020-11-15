--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE name = 'trg_Employee_Update' AND OBJECTPROPERTY(id, 'IsTrigger') = 1)
DROP TRIGGER [dbo].[trg_Employee_Update]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[trg_Employee_Update]
ON [dbo].[Employee]
FOR UPDATE
AS
    IF((Select Salary From inserted ) < 0)
    BEGIN
		WAITFOR DELAY '0:0:5'	-- Test Dirty read
		ROLLBACK TRAN
	END
GO
