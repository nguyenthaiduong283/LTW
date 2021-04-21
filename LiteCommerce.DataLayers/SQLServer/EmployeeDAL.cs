using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteCommerce.DataLayers.SQLServer
{
    public class EmployeeDAL : _BaseDAL, IEmployeeDAL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        public EmployeeDAL(string connectionString) : base(connectionString)
        {

        }

        public int Add(Employee data)
        {
            throw new NotImplementedException();
        }

        public int Count(string searchValue)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int employeeID)
        {
            throw new NotImplementedException();
        }

        public Employee Get(int employeeID)
        {
            throw new NotImplementedException();
        }
        public List<Employee> List()
        {
            List<Employee> data = new List<Employee>();
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = this.connectionString;
                cn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM Employees";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = cn;


                using (SqlDataReader dbReader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    while (dbReader.Read())
                    {
                        data.Add(new Employee()
                        {
                            EmployeeID = Convert.ToInt32(dbReader["EmployeeID"]),
                            FirstName = Convert.ToString(dbReader["FirstName"]),
                            LastName = Convert.ToString(dbReader["LastName"]),
                            BirthDate = Convert.ToDateTime(dbReader["BirthDate"]),
                            Photo = Convert.ToString(dbReader["Photo"]),
                            Notes = Convert.ToString(dbReader["Notes"]),
                            Email = Convert.ToString(dbReader["Email"]),
                            Password = Convert.ToString(dbReader["Password"]),
                        });
                    }
                }


                cn.Close();
            }

            return data;

        }

        public List<Employee> List(int page, int pageSize, string searchValue)
        {
            if (searchValue != "")
                searchValue = "%" + searchValue + "%";

            List<Employee> data = new List<Employee>();
            using (SqlConnection cn = GetConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"SELECT*
                                    FROM
                                    (
                                        SELECT *, ROW_NUMBER() OVER(ORDER BY EmployeeID) AS RowNumber

                                        FROM Employees

                                        WHERE(@searchValue = '')

                                            OR(
                                                    LastName LIKE @searchValue    
                                                    OR  FirstName LIKE @searchValue
                                                    OR  Email LIKE @searchValue
                                                    
                                                )
                                    ) AS s
                                    WHERE s.RowNumber BETWEEN(@page -1)*@pageSize + 1 AND @page*@pageSize";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = cn;

                cmd.Parameters.AddWithValue("@page", page);
                cmd.Parameters.AddWithValue("@pageSize", pageSize);
                cmd.Parameters.AddWithValue("@searchValue", searchValue);
                using (SqlDataReader dbReader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (dbReader.Read())
                    {
                        /* Country country = new Country();
                         country.CountryName = Convert.ToString(dbReader["CountryName"]);
                         data.Add(country);*/

                        /*Country country = new Country()
                        {
                            CountryName = Convert.ToString(dbReader["CountryName"])
                        };
                        data.Add(country);*/

                        data.Add(new Employee()
                        {
                            EmployeeID = Convert.ToInt32(dbReader["EmployeeID"]),
                            LastName = Convert.ToString(dbReader["LastName"]),
                            FirstName = Convert.ToString(dbReader["FirstName"]),
                            BirthDate = Convert.ToDateTime(dbReader["BirthDate"]),
                            Photo = Convert.ToString(dbReader["Photo"]),
                            Notes = Convert.ToString(dbReader["Notes"]),
                            Email = Convert.ToString(dbReader["Email"]),
                            Password = Convert.ToString(dbReader["Password"])
                        });

                    }
                }

                cn.Close();
            }
            return data;
        }


        public bool Update(Employee data)
        {
            throw new NotImplementedException();
        }
    }
}
