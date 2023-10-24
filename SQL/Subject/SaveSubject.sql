DECLARE @@status VARCHAR(10);
DECLARE @@message VARCHAR(MAX);
DECLARE @@err VARCHAR(MAX);
DECLARE @@querySubjectLecturer VARCHAR(MAX);
DECLARE @@QUERY VARCHAR(MAX);
DECLARE @@SUBJECT_ID INT;
SET @@querySubjectLecturer = @querySubjectLecturer;

BEGIN TRY
	INSERT INTO [TB_SUBJECT] (SUBJECT_NAME) VALUES (@SUBJECT_NAME);
	SET @@SUBJECT_ID = (SELECT SCOPE_IDENTITY());

	IF(@@querySubjectLecturer <> '') BEGIN
			SET @@querySubjectLecturer = (SELECT REPLACE(@@querySubjectLecturer, 'SUBJECT_ID', @@SUBJECT_ID));
			SET @@QUERY = '
			INSERT INTO [dbo].[TB_SUBJECT_LECTURER] (
			SUBJECT_ID,
			LECTURER_ID
		) VALUES' + @@querySubjectLecturer ;

		EXEC(@@QUERY);
	END

	SET @@status = 'true';
	SET @@message = 'Sukses Tambah Data';
END TRY
BEGIN CATCH 
	SET @@status = 'false';
	SET @@message = 'Gagal Tambah Data';
	SET @@err = (SELECT ERROR_MESSAGE());
	
END CATCH

SELECT @@status AS [status], @@message AS [message], @@err AS error;

