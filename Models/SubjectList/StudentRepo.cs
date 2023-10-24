using System;
using assessment_net_be.Models.SubjectList;
using assessment_net_be.Models;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using Dapper;

namespace assessment_net_be.Models.SubjectList
{
    public class SubjectListRepo
    {
        private readonly IConfiguration _configuration;

        public SubjectListRepo(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IEnumerable<SubjectList> GetSubjectLists()
        {
            string connectionString = _configuration.GetConnectionString("DB_ASSESSMENT_CON");
            using IDbConnection dbConnection = new SqlConnection(connectionString);
            dbConnection.Open();
            string sqlQuery = File.ReadAllText("SQL/SubjectList/GetSubjectLists.sql");
            IEnumerable<SubjectList> SubjectLists = dbConnection.Query<SubjectList>(sqlQuery);
            return SubjectLists;
        }

        public SubjectList GetSubjectListById(int SUBJECT_LIST_ID)
        {
            string connectionString = _configuration.GetConnectionString("DB_ASSESSMENT_CON");
            using IDbConnection dbConnection = new SqlConnection(connectionString);
            dbConnection.Open();
            string sqlQuery = File.ReadAllText("SQL/SubjectList/GetSubjectListById.sql");
            SubjectList SubjectList = dbConnection.Query<SubjectList>(sqlQuery, new { SUBJECT_LIST_ID }).FirstOrDefault();
            return SubjectList;
        }

        public ResponseMessage Save(SubjectList subjectList)
        {
            string connectionString = _configuration.GetConnectionString("DB_ASSESSMENT_CON");
            using IDbConnection dbConnection = new SqlConnection(connectionString);
            dbConnection.Open();
            string sqlQuery = File.ReadAllText("SQL/SubjectList/SaveSubjectList.sql");
            ResponseMessage result = dbConnection.Query<ResponseMessage>(sqlQuery, subjectList).FirstOrDefault();
            return result;
        }

        public ResponseMessage Delete(int SUBJECT_LIST_ID)
        {
            string connectionString = _configuration.GetConnectionString("DB_ASSESSMENT_CON");
            using IDbConnection dbConnection = new SqlConnection(connectionString);
            dbConnection.Open();
            string sqlQuery = File.ReadAllText("SQL/SubjectList/DeleteSubjectList.sql");
            ResponseMessage result = dbConnection.Query<ResponseMessage>(sqlQuery, new { SUBJECT_LIST_ID }).FirstOrDefault();
            return result;
        }
    }
}

