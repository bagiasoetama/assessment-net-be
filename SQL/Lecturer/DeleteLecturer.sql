DECLARE @@status VARCHAR(10);
DECLARE @@message VARCHAR(MAX);
DECLARE @@err VARCHAR(MAX);

IF EXISTS (SELECT 1 FROM TB_LECTURER WHERE LECTURER_ID = @LECTURER_ID) 
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION

		DELETE FROM TB_LECTURER_DETAIL WHERE LECTURER_ID = @LECTURER_ID
		DELETE FROM TB_LECTURER WHERE LECTURER_ID = @LECTURER_ID

		SET @@status = 'true';
		SET @@message = 'Sukses Delete Data';

		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH 
		ROLLBACK TRANSACTION
		SET @@status = 'false';
		SET @@message = 'Gagal Delete Data';
		SET @@err = (SELECT ERROR_MESSAGE());
	
	END CATCH
END
ELSE
BEGIN
    SET @@status = 'false';
	SET @@message = 'Gagal Delete Data';
	SET @@err = 'Data Lecturer Tidak Ditemukan';
END

SELECT @@status AS [status], @@message AS [message], @@err AS error;

