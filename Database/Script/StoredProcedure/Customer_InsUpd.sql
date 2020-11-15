--=========================================================================================================================================================
--=========================================================================================================================================================
IF EXISTS (SELECT TOP 1 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customer_InsUpd]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Customer_InsUpd]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Customer_InsUpd]
	@pID bigint = -1,
	@pName nvarchar(255) = '',
	@pPhone char(15) = '',
	@pAddress nvarchar(max) = '',
	@pDescription nvarchar(max) = '',
	@pAbilityRent bit = 1,
	@pIDBranchOffice bigint = NULL
AS
BEGIN TRANSACTION
	DECLARE @vMessage nvarchar(4000)
	SET @vMessage = ''

	IF(@pID = -1)
	BEGIN
		INSERT INTO [dbo].[Customer]( [Name],
									  [Phone],
									  [Address],
									  [Description],
									  [AbilityRent],
									  [IDBranchOffice],
									  [IsActive])
		 VALUES(@pName,
		        @pPhone,
		        @pAddress,
		        @pDescription,
				@pAbilityRent,
				@pIDBranchOffice,
		        1)
		IF @@Error <> 0 GOTO ABORT
	END
	ELSE
	BEGIN
		UPDATE [dbo].[Customer]
		SET [Name] = @pName,
			[Phone] = @pPhone,
			[Address] = @pAddress,
			[Description] = @pDescription,
			[AbilityRent] = @pAbilityRent,
			[IDBranchOffice] = @pIDBranchOffice
		WHERE [ID] = @pID
		IF @@Error <> 0 GOTO ABORT
	END

COMMIT TRANSACTION
	SELECT 1 AS Result, @vMessage ErrorDesc
	RETURN 1
ABORT:
BEGIN
	ROLLBACK TRANSACTION
	SET @vMessage = 'Thêm khách hàng thất bại!'
	SELECT 0 AS Result, @vMessage ErrorDesc
	RETURN 0
END
GO
--EXEC Customer_InsUpd -1, N'Hồ Tuấn B', 'B', 'C', 'D', 1, 0
--SELECT * FROM Customer