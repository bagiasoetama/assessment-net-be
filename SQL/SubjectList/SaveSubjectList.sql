DECLARE @@status VARCHAR(10);
DECLARE @@message VARCHAR(MAX);
DECLARE @@err VARCHAR(MAX);

BEGIN TRY
	INSERT INTO [TB_SUBJECT_LIST] (STUDENT_ID, SUBJECT_ID) VALUES (@STUDENT_ID, @SUBJECT_ID);

	SET @@status = 'true';
	SET @@message = 'Sukses Tambah Data';
END TRY
BEGIN CATCH 
	SET @@status = 'false';
	SET @@message = 'Gagal Tambah Data';
	SET @@err = (SELECT ERROR_MESSAGE());
	
END CATCH

SELECT @@status AS [status], @@message AS [message], @@err AS error;

