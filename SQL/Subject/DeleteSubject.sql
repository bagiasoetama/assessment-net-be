DECLARE @@status VARCHAR(10);
DECLARE @@message VARCHAR(MAX);
DECLARE @@err VARCHAR(MAX);


IF EXISTS (SELECT 1 FROM TB_SUBJECT WHERE SUBJECT_ID = @SUBJECT_ID) 
BEGIN
	BEGIN TRANSACTION;
	BEGIN TRY	
		
		DELETE FROM TB_SUBJECT_LECTURER WHERE SUBJECT_ID = @SUBJECT_ID
		DELETE FROM TB_SUBJECT WHERE SUBJECT_ID = @SUBJECT_ID

		SET @@status = 'true';
		SET @@message = 'Sukses Delete Data';

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH 
		ROLLBACK TRANSACTION;
		
		SET @@status = 'false';
		SET @@message = 'Gagal Delete Data';
		SET @@err = (SELECT ERROR_MESSAGE());
	
	END CATCH
END
ELSE
BEGIN
    SET @@status = 'false';
	SET @@message = 'Gagal Delete Data';
	SET @@err = 'Data Student Tidak Ditemukan';
END

SELECT @@status AS [status], @@message AS [message], @@err AS error;

