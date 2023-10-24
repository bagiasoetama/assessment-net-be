DECLARE @@status VARCHAR(10);
DECLARE @@message VARCHAR(MAX);
DECLARE @@err VARCHAR(MAX);
DECLARE @@count_lecturer int = (SELECT COUNT(1) FROM TB_LECTURER WHERE LECTURER_ID = @LECTURER_ID );
DECLARE @@count_subject int = (SELECT COUNT(1) FROM TB_SUBJECT WHERE SUBJECT_ID = @SUBJECT_ID);

BEGIN TRY
	IF(@@count_lecturer > 0 and @@count_subject > 0) BEGIN
		INSERT INTO [TB_SUBJECT_LECTURER] (SUBJECT_ID, LECTURER_ID) VALUES (@SUBJECT_ID, @LECTURER_ID);

		SET @@status = 'true';
		SET @@message = 'Sukses Tambah Data';
	END ELSE BEGIN
		SET @@status = 'false';
		SET @@message = 'Subject atau Lecturer tidak ditemukan';
	END
	
END TRY
BEGIN CATCH 
	SET @@status = 'false';
	SET @@message = 'Gagal Tambah Data';
	SET @@err = (SELECT ERROR_MESSAGE());
	
END CATCH

SELECT @@status AS [status], @@message AS [message], @@err AS error;

