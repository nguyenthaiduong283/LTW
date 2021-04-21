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
    public class CategoryDAL : _BaseDAL, ICategoryDAL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        public CategoryDAL(string connectionString) : base(connectionString)
        {

        }

        public int Add(Category data)
        {
            int CategoryID = 0;
            using (SqlConnection cn = GetConnection())
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = @"INSERT INTO Categories(
                                                            
                                                            CategoryName,
                                                            Description,
                                                            ParentCategoryId
                                                           )

                                                    VALUES (
                                                            @CategoryName,
                                                            @Description,
                                                            @ParentCategoryId );
                      
                                     SELECT @@IDENTITY;";
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Parameters.AddWithValue("@CategoryName", data.CategoryName);
                cmd.Parameters.AddWithValue("@Description", data.Description);
                cmd.Parameters.AddWithValue("@ParentCategoryId", data.ParentCategoryId);
                

                CategoryID = Convert.ToInt32(cmd.ExecuteScalar());
                cn.Close();
            }

            return CategoryID;
        }

        public int Count(string searchValue)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int categoryID)
        {
            throw new NotImplementedException();
        }

        public Category Get(int categoryID)
        {
            throw new NotImplementedException();
        }

        public List<Category> List(int page, int pageSize, string searchValue)
        {
            if (searchValue != "")
                searchValue = "%" + searchValue + "%";

            List<Category> data = new List<Category>();
            using (SqlConnection cn = GetConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"SELECT*
                                    FROM
                                    (
                                        SELECT *, ROW_NUMBER() OVER(ORDER BY CategoryName) AS RowNumber

                                        FROM Categories

                                        WHERE(@searchValue = '')

                                            OR(
                                                    CategoryName LIKE @searchValue    
                                                    OR  Description LIKE @searchValue
                                                    
                                                    
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

                        data.Add(new Category()
                        {
                            CategoryName = Convert.ToString(dbReader["CategoryName"]),
                            Description = Convert.ToString(dbReader["Description"])
                        });

                    }
                }

                cn.Close();
            }
            return data;
        }

        public bool Update(Category data)
        {
            throw new NotImplementedException();
        }
    }
}
