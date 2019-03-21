﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OrderForm.Data
{
    internal class DBRepository : IReadWriteRepository
    {
        public void Save(string firstName, string lastName, DateTime dateofBirth,
                                        DataGridViewRowCollection productsFromGrid)
        {
            using (SqlConnection sqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.
                    ConnectionStrings["OrderForm.Properties.Settings.OrderFormConnectionString"].ConnectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlSaveToDB = new SqlCommand("NewOrder", sqlConnection);
                sqlSaveToDB.CommandType = System.Data.CommandType.StoredProcedure;
                sqlSaveToDB.Parameters.AddWithValue("@FirstName", firstName); // Wanna try some sql injection? ;)
                sqlSaveToDB.Parameters.AddWithValue("@LastName", lastName);
                sqlSaveToDB.Parameters.AddWithValue("@BirthDate", dateofBirth);
                sqlSaveToDB.Parameters.AddWithValue("@ListOfProduct", GetProductsFromGrid(productsFromGrid));
                sqlSaveToDB.ExecuteNonQuery();
            }
        }

        public DataTable Read()
        {
            using (SqlConnection sqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.
                    ConnectionStrings["OrderForm.Properties.Settings.OrderFormConnectionString"].ConnectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlGetProductList = new SqlCommand("GetProductList", sqlConnection);
                sqlGetProductList.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataAdapter sqlDA = new SqlDataAdapter(sqlGetProductList);
                DataTable dt = new DataTable();
                sqlDA.Fill(dt);
                return dt;
            }
        }

        private DataTable GetProductsFromGrid(DataGridViewRowCollection productsFromGrid)
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("ProductId");
            dataTable.Columns.Add("Quantity");

            foreach (DataGridViewRow row in productsFromGrid)
            {
                DataRow dataRow = dataTable.NewRow();
                dataRow["ProductId"] = row.Cells[0].Value;
                dataRow["Quantity"] = row.Cells[1].Value;
                dataTable.Rows.Add(dataRow);
            }

            return dataTable;
        }
    }
}