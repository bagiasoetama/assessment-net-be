using System;
using assessment_net_be.Models.Student;
using assessment_net_be.Models;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using Dapper;

namespace assessment_net_be.Models.Student
{
    public class StudentRepo
    {
        private readonly IConfiguration _configuration;

        public StudentRepo(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IEnumerable<Student> GetStudents()
        {
            string connectionString = _configuration.GetConnectionString("DB_ASSESSMENT_CON");
            using IDbConnection dbConnection = new SqlConnection(connectionString);
            dbConnection.Open();
            string sqlQuery = File.ReadAllText("SQL/Student/GetStudents.sql");
            IEnumerable<Student> Students = dbConnection.Query<Student>(sqlQuery);
            return Students;
        }

        public Student GetStudentById(int STUDENT_ID)
        {
            string connectionString = _configuration.GetConnectionString("DB_ASSESSMENT_CON");
            using IDbConnection dbConnection = new SqlConnection(connectionString);
            dbConnection.Open();
            string sqlQuery = File.ReadAllText("SQL/Student/GetStudentById.sql");
            Student Student = dbConnection.Query<Student>(sqlQuery, new { STUDENT_ID }).FirstOrDefault();
            return Student;
        }

        public ResponseMessage Save(Student student)
        {
            string connectionString = _configuration.GetConnectionString("DB_ASSESSMENT_CON");
            using IDbConnection dbConnection = new SqlConnection(connectionString);
            dbConnection.Open();
            string sqlQuery = File.ReadAllText("SQL/Student/SaveStudent.sql");
            ResponseMessage result = dbConnection.Query<ResponseMessage>(sqlQuery, student).FirstOrDefault();
            return result;
        }

        public ResponseMessage Delete(int STUDENT_ID)
        {
            string connectionString = _configuration.GetConnectionString("DB_ASSESSMENT_CON");
            using IDbConnection dbConnection = new SqlConnection(connectionString);
            dbConnection.Open();
            string sqlQuery = File.ReadAllText("SQL/Student/DeleteStudent.sql");
            ResponseMessage result = dbConnection.Query<ResponseMessage>(sqlQuery, new { STUDENT_ID }).FirstOrDefault();
            return result;
        }

        public ResponseMessage Update(Student student)
        {
            string connectionString = _configuration.GetConnectionString("DB_ASSESSMENT_CON");
            using IDbConnection dbConnection = new SqlConnection(connectionString);
            dbConnection.Open();
            string sqlQuery = File.ReadAllText("SQL/Student/UpdateStudent.sql");
            ResponseMessage result = dbConnection.Query<ResponseMessage>(sqlQuery, student).FirstOrDefault();
            return result;
        }
    }
}

