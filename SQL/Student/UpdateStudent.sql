DECLARE @@status VARCHAR(10);
DECLARE @@message VARCHAR(MAX);
DECLARE @@err VARCHAR(MAX);

IF EXISTS (SELECT 1 FROM TB_STUDENT WHERE STUDENT_ID = @STUDENT_ID) 
BEGIN
	BEGIN TRY

		UPDATE TB_STUDENT
		SET STUDENT_NAME = @STUDENT_NAME
		WHERE STUDENT_ID = @STUDENT_ID

		SET @@status = 'true';
		SET @@message = 'Sukses Update Data';

	END TRY
	BEGIN CATCH 
		SET @@status = 'false';
		SET @@message = 'Gagal Update Data';
		SET @@err = (SELECT ERROR_MESSAGE());
	
	END CATCH
END
ELSE
BEGIN
    SET @@status = 'false';
	SET @@message = 'Gagal Update Data';
	SET @@err = 'Data STUDENT Tidak Ditemukan';
END

SELECT @@status AS [status], @@message AS [message], @@err AS error;
