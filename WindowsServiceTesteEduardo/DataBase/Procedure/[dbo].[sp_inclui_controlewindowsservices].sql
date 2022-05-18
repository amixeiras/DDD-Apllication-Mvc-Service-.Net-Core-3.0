USE WINDOWSSERVICESTesteEduardo
GO
IF(EXISTS(SELECT 1 FROM sys.objects WHERE name='sp_inclui_controlewindowsservices' AND type='P' AND schema_id=SCHEMA_ID('dbo')))
	DROP procedure [dbo].[sp_inclui_controlewindowsservices]
GO
CREATE procedure [dbo].[sp_inclui_controlewindowsservices]
(
	@NMSERVICO VARCHAR(1000),
	@NMMAQUINA VARCHAR(1000),
	@DTULTIMAEXECUCAO VARCHAR(200)
)
AS

	INSERT INTO [dbo].[ControleWindowsServices]
		(NMSERVICO, NMMAQUINA, DTULTIMAEXECUCAO)
	VALUES
		(@NMSERVICO, @NMMAQUINA, @DTULTIMAEXECUCAO);