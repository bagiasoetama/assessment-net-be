DECLARE @@status VARCHAR(10);
DECLARE @@message VARCHAR(MAX);
DECLARE @@err VARCHAR(MAX);

BEGIN
	BEGIN TRY

		DELETE FROM TB_SUBJECT_LIST WHERE SUBJECT_LIST_ID = @SUBJECT_LIST_ID

		SET @@status = 'true';
		SET @@message = 'Sukses Delete Data';

	END TRY
	BEGIN CATCH 
		
		SET @@status = 'false';
		SET @@message = 'Gagal Delete Data';
		SET @@err = (SELECT ERROR_MESSAGE());
	
	END CATCH
END

SELECT @@status AS [status], @@message AS [message], @@err AS error;

