using System;
using assessment_net_be.Models.Subject;
using assessment_net_be.Models;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using Dapper;

namespace assessment_net_be.Models.Subject
{
    public class SubjectRepo
    {
        private readonly IConfiguration _configuration;

        public SubjectRepo(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IEnumerable<Subject> GetSubjects()
        {
            string connectionString = _configuration.GetConnectionString("DB_ASSESSMENT_CON");
            using IDbConnection dbConnection = new SqlConnection(connectionString);
            dbConnection.Open();
            string sqlQuery = File.ReadAllText("SQL/Subject/GetSubjects.sql");
            IEnumerable<Subject> Subjects = dbConnection.Query<Subject>(sqlQuery);
            return Subjects;
        }

        public Subject GetSubjectById(int SUBJECT_ID)
        {
            string connectionString = _configuration.GetConnectionString("DB_ASSESSMENT_CON");
            using IDbConnection dbConnection = new SqlConnection(connectionString);
            dbConnection.Open();
            string sqlQuery = File.ReadAllText("SQL/Subject/GetSubjectById.sql");
            Subject Subject = dbConnection.Query<Subject>(sqlQuery, new { SUBJECT_ID }).FirstOrDefault();
            return Subject;
        }

        public ResponseMessage Save(Subject subject, string querySubjectLecturer)
        {
            string connectionString = _configuration.GetConnectionString("DB_ASSESSMENT_CON");
            using IDbConnection dbConnection = new SqlConnection(connectionString);
            dbConnection.Open();
            string sqlQuery = File.ReadAllText("SQL/Subject/SaveSubject.sql");
            ResponseMessage result = dbConnection.Query<ResponseMessage>(sqlQuery, new { SUBJECT_NAME = subject.SUBJECT_NAME, querySubjectLecturer }).FirstOrDefault();
            return result;
        }

        public ResponseMessage Delete(int SUBJECT_ID )
        {
            string connectionString = _configuration.GetConnectionString("DB_ASSESSMENT_CON");
            using IDbConnection dbConnection = new SqlConnection(connectionString);
            dbConnection.Open();
            string sqlQuery = File.ReadAllText("SQL/Subject/DeleteSubject.sql");
            ResponseMessage result = dbConnection.Query<ResponseMessage>(sqlQuery, new { SUBJECT_ID }).FirstOrDefault();
            return result;
        }

        public ResponseMessage Update(Subject subject, string querySubjectLecturer)
        {
            string connectionString = _configuration.GetConnectionString("DB_ASSESSMENT_CON");
            using IDbConnection dbConnection = new SqlConnection(connectionString);
            dbConnection.Open();
            string sqlQuery = File.ReadAllText("SQL/Subject/UpdateSubject.sql");
            ResponseMessage result = dbConnection.Query<ResponseMessage>(sqlQuery, new { SUBJECT_ID = subject.SUBJECT_ID, SUBJECT_NAME = subject.SUBJECT_NAME, querySubjectLecturer }).FirstOrDefault();
            return result;
        }
    }
}

