DECLARE @@status VARCHAR(10);
DECLARE @@message VARCHAR(MAX);
DECLARE @@err VARCHAR(MAX);
DECLARE @@LECTURER_ID INT;

BEGIN TRY
	BEGIN TRANSACTION

	INSERT INTO [TB_LECTURER] (LECTURER_NAME) VALUES (@LECTURER_NAME);
	SET @@LECTURER_ID = (SELECT SCOPE_IDENTITY());
	INSERT INTO [TB_LECTURER_DETAIL] 
		(LECTURER_ID, 
		LECTURER_ADDRESS, 
		LECTURER_TELP, 
		LECTURER_EMAIL)
	VALUES (@@LECTURER_ID, @LECTURER_ADDRESS, @LECTURER_TELP, @LECTURER_EMAIL);

	SET @@status = 'true';
	SET @@message = 'Sukses Tambah Data';

	COMMIT TRANSACTION
END TRY
BEGIN CATCH 
	ROLLBACK TRANSACTION
	SET @@status = 'false';
	SET @@message = 'Gagal Tambah Data';
	SET @@err = (SELECT ERROR_MESSAGE());
	
END CATCH

SELECT @@status AS [status], @@message AS [message], @@err AS error;

