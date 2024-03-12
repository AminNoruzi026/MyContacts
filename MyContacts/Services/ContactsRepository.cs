using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyContacts
{
    class ContactsRepository : IContactsRepository
    {
        private string connectionString = "Data Source=.;Initial Catalog=Contact_DB;Integrated Security=true";

        public bool Delete(int contactId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                string query = "Delete From MyContact Where ContactID=@ID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("ID", contactId);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;

            }
            finally
            {
                connection.Close();
            }
        }

        public bool Insert(string name, string family, int age, string mobile, string email, string address)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                string query = "Insert Into MyContact (Name,Family,Age,Mobile,Email,Address) Values (@Name,@Family,@Age,@Mobile,@Email,@Address)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Family", family);
                command.Parameters.AddWithValue("@Age", age);
                command.Parameters.AddWithValue("@Mobile", mobile);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Address", address);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {

                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public DataTable Search(string parameter)
        {
            string query = "Select * From MyContact Where Name Like @Parameter or Family Like @Parameter";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            adapter.SelectCommand.Parameters.AddWithValue("@parameter", "%" + parameter + "%");
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public DataTable SelectAll()
        {
            string query = "Select * From MyContact";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public DataTable SelectRow(int contactId)
        {
            string query = "Select * From MyContact Where ContactID=" + contactId;
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public bool Update(int contactId, string name, string family, int age, string mobile, string email, string address)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                string query = "Update MyContact Set Name=@Name,Family=@Family,Age=@Age,Mobile=@Mobile,Email=@Email,Address=@Address Where ContactID=@ID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", contactId);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Family", family);
                command.Parameters.AddWithValue("@Age", age);
                command.Parameters.AddWithValue("@Mobile", mobile);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Address", address);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {

                return false;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
