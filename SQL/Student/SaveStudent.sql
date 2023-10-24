DECLARE @@status VARCHAR(10);
DECLARE @@message VARCHAR(MAX);
DECLARE @@err VARCHAR(MAX);

BEGIN TRY
	INSERT INTO [TB_STUDENT] (STUDENT_NAME) VALUES (@STUDENT_NAME);

	SET @@status = 'true';
	SET @@message = 'Sukses Tambah Data';
END TRY
BEGIN CATCH 
	SET @@status = 'false';
	SET @@message = 'Gagal Tambah Data';
	SET @@err = (SELECT ERROR_MESSAGE());
	
END CATCH

SELECT @@status AS [status], @@message AS [message], @@err AS error;

