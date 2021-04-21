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
    public class CustomerDAL : _BaseDAL, ICustomerDAL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        public CustomerDAL(string connectionString) : base(connectionString)
        {

        }

        public int Add(Customer data)
        {
            throw new NotImplementedException();
        }

        public int Count(string searchValue)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int customerID)
        {
            throw new NotImplementedException();
        }

        public Customer Get(int customerID)
        {
            throw new NotImplementedException();
        }

        public List<Customer> List(int page, int pageSize, string searchValue)
        {
            if (searchValue != "")
                searchValue = "%" + searchValue + "%";

            List<Customer> data = new List<Customer>();
            using (SqlConnection cn = GetConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"SELECT*
                                    FROM
                                    (
                                        SELECT *, ROW_NUMBER() OVER(ORDER BY CustomerName) AS RowNumber

                                        FROM Customers

                                        WHERE(@searchValue = '')

                                            OR(
                                                    CustomerName LIKE @searchValue    
                                                    OR  ContactName LIKE @searchValue
                                                    OR  Country LIKE @searchValue
                                                    
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

                        data.Add(new Customer()
                        {
                            CustomerName = Convert.ToString(dbReader["CustomerName"]),
                            ContactName = Convert.ToString(dbReader["ContactName"]),
                            Address = Convert.ToString(dbReader["Address"]),
                            City = Convert.ToString(dbReader["City"]),
                            PostalCode = Convert.ToString(dbReader["PostalCode"]),
                            Country = Convert.ToString(dbReader["Country"]),
                            Email = Convert.ToString(dbReader["Email"]),
                            Password = Convert.ToString(dbReader["Password"])
                        });

                    }
                }

                cn.Close();
            }
            return data;
        }

        public bool Update(Customer data)
        {
            throw new NotImplementedException();
        }
    }
}
