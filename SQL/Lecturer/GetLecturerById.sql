SELECT
	LEC.*,
	LEC_D.LECTURER_DETAIL_ID,
	LEC_D.LECTURER_EMAIL,
	LEC_D.LECTURER_TELP,
	LEC_D.LECTURER_ADDRESS
FROM TB_LECTURER LEC 
INNER JOIN TB_LECTURER_DETAIL LEC_D ON LEC.LECTURER_ID = LEC_D.LECTURER_ID
WHERE LEC.LECTURER_ID = @LECTURER_ID;