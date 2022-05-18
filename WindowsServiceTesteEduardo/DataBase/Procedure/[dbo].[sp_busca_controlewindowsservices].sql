USE WINDOWSSERVICESTesteEduardo
GO
IF(EXISTS(SELECT 1 FROM sys.objects WHERE name='sp_busca_controlewindowsservices' AND type='P' AND schema_id=SCHEMA_ID('dbo')))
	DROP procedure [dbo].[sp_busca_controlewindowsservices]
GO
CREATE procedure [dbo].[sp_busca_controlewindowsservices]
	@ID BIGINT = NULL
AS

	SELECT * FROM [dbo].[ControleWindowsServices] (READPAST)