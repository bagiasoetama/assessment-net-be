DECLARE @@status VARCHAR(10);
DECLARE @@message VARCHAR(MAX);
DECLARE @@err VARCHAR(MAX);
DECLARE @@querySubjectLecturer VARCHAR(MAX);
DECLARE @@QUERY VARCHAR(MAX);
SET @@querySubjectLecturer = @querySubjectLecturer;

IF EXISTS (SELECT 1 FROM TB_SUBJECT WHERE SUBJECT_ID = @SUBJECT_ID) 
BEGIN
	BEGIN TRANSACTION;
	BEGIN TRY
		DELETE FROM TB_SUBJECT_LECTURER WHERE SUBJECT_ID = @SUBJECT_ID

		UPDATE TB_SUBJECT
		SET SUBJECT_NAME = @SUBJECT_NAME
		WHERE SUBJECT_ID = @SUBJECT_ID

		SET @@status = 'true';
		SET @@message = 'Sukses Update Data';

		IF(@@querySubjectLecturer <> '') BEGIN
				SET @@querySubjectLecturer = (SELECT REPLACE(@@querySubjectLecturer, 'SUBJECT_ID', @SUBJECT_ID));
				SET @@QUERY = '
				INSERT INTO [dbo].[TB_SUBJECT_LECTURER] (
					SUBJECT_ID,
					LECTURER_ID
				) VALUES' + @@querySubjectLecturer ;
			EXEC(@@QUERY);
		END

		COMMIT TRANSACTION;

	END TRY
	BEGIN CATCH 
		ROLLBACK TRANSACTION;
		SET @@status = 'false';
		SET @@message = 'Gagal Update Data';
		SET @@err = (SELECT ERROR_MESSAGE());
	
	END CATCH
END
ELSE
BEGIN
    SET @@status = 'false';
	SET @@message = 'Gagal Update Data';
	SET @@err = 'Data SUBJECT Tidak Ditemukan';
END

SELECT @@status AS [status], @@message AS [message], @@err AS error;
