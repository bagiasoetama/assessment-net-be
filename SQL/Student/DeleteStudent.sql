DECLARE @@status VARCHAR(10);
DECLARE @@message VARCHAR(MAX);
DECLARE @@err VARCHAR(MAX);

IF EXISTS (SELECT 1 FROM TB_STUDENT WHERE STUDENT_ID = @STUDENT_ID) 
BEGIN
	BEGIN TRY

		DELETE FROM TB_STUDENT WHERE STUDENT_ID = @STUDENT_ID

		SET @@status = 'true';
		SET @@message = 'Sukses Delete Data';

	END TRY
	BEGIN CATCH 
		
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

