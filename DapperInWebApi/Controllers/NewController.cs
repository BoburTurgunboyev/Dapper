using Dapper;
using DapperInWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace DapperInWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NewController : ControllerBase
    {
        public string? connectionString = WebApplication.CreateBuilder().Configuration.GetConnectionString("DefaultConnection");
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                /**

                // Task1
                string query = "select * from userTable";
                IEnumerable<User> users = connection.Query<User>(query);

                // Task2
                int count = connection.ExecuteScalar<int>("select count(userId) from userTable");
                double countAsync = await connection.ExecuteScalarAsync<double>("select sum(userId) from userTable");

                // Task3
                int IsDone = connection.Execute("Delete from userTable where userId = 2");
                int resultAsync = await connection.ExecuteAsync("Delete from userTable where userId = 2");

                // Task4
                User user = connection.QueryFirst<User>("SELECT * FROM userTable");
                User userAsync = await connection.QueryFirstAsync<User>("SELECT * FROM userTable");

                // Task5
                User user2 = connection.QuerySingle<User>("SELECT * FROM userTable WHERE Id = 2");
                User user2Async = await connection.QuerySingleAsync<User>("SELECT * FROM userTable WHERE userId = 3");

                // Task6
                IEnumerable<User> users3 = connection.Query<User>("SELECT * FROM userTable");
                IEnumerable<User> users3Async = await connection.QueryAsync<User>("SELECT * FROM userTable");

                */




                // Task7
                using (SqlMapper.GridReader common = connection.QueryMultiple("select * from userTable order by userId asc;select * from userTable order by userId desc"))
                {
                    IEnumerable<User> userAsc = common.Read<User>();
                    IEnumerable<User> userDesc= common.Read<User>();

                    return Ok(new
                    {
                        UserAsc = userAsc,
                        UserDesc = userDesc
                    });
                }

                // Task8
                using (SqlMapper.GridReader common = await connection.QueryMultipleAsync("select * from userTable order by userId asc;select * from userTable order by userId desc"))
                {
                    IEnumerable<User> userAsc = await common.ReadAsync<User>();
                    IEnumerable<User> userDesc = await common.ReadAsync<User>();

                    return Ok(new
                    {
                        UserAsc = userAsc,
                        UserDesc = userDesc
                    });
                }

                // Task9
                using (SqlMapper.GridReader common = await connection.QueryMultipleAsync("select * from userTable order by userId asc;select * from userTable order by userId desc"))
                {
                    IEnumerable<User> userAsc = await common.ReadAsync<User>();
                    IEnumerable<User> userDesc = await common.ReadAsync<User>();

                    return Ok(new
                    {
                        UserAsc = userAsc,
                        UserDesc = userDesc
                    });
                }
                
                // Task10
                using (SqlMapper.GridReader common = connection.QueryMultiple("select * from userTable order by userId asc;select * from userTable order by userId desc"))
                {
                    User userAsc = common.ReadFirst<User>();
                    User userDesc = common.ReadFirst<User>();

                    return Ok(new
                    {
                        UserAsc = userAsc,
                        UserDesc = userDesc
                    });
                }

                // Task11
                using (SqlMapper.GridReader common = await connection.QueryMultipleAsync("select * from userTable order by userId asc;select * from userTable order by userId desc"))
                {
                    User userAsc = await common.ReadFirstAsync<User>();
                    User userDesc = await common.ReadFirstAsync<User>();

                    return Ok(new
                    {
                        UserAsc = userAsc,
                        UserDesc = userDesc
                    });
                }


                // Task12
                using (SqlMapper.GridReader common = connection.QueryMultiple("select * from userTable order by userId asc;select * from userTable order by userId desc"))
                {
                    User userAsc = common.ReadFirstOrDefault<User>();
                    User userDesc = common.ReadFirstOrDefault<User>();

                    return Ok(new
                    {
                        UserAsc = userAsc,
                        UserDesc = userDesc
                    });
                }

                // Task13
                using (SqlMapper.GridReader common = await connection.QueryMultipleAsync("select * from userTable order by userId asc;select * from userTable order by userId desc"))
                {
                    User userAsc = await common.ReadFirstOrDefaultAsync<User>();
                    User userDesc = await common.ReadFirstOrDefaultAsync<User>();

                    return Ok(new
                    {
                        UserAsc = userAsc,
                        UserDesc = userDesc
                    });
                }

                // Task14
                using (SqlMapper.GridReader common = connection.QueryMultiple("select * from userTable order by userId asc;select * from userTable order by userId desc"))
                {
                    User userAsc = common.ReadSingle<User>();
                    User userDesc = common.ReadSingle<User>();

                    return Ok(new
                    {
                        UserAsc = userAsc,
                        UserDesc = userDesc
                    });
                }

                // Task15
                using (SqlMapper.GridReader common = await connection.QueryMultipleAsync("select * from userTable order by userId asc;select * from userTable order by userId desc"))
                {
                    User userAsc = await common.ReadSingleAsync<User>();
                    User userDesc = await common.ReadSingleAsync<User>();

                    return Ok(new
                    {
                        UserAsc = userAsc,
                        UserDesc = userDesc
                    });
                }

            }
        }
    }
}
