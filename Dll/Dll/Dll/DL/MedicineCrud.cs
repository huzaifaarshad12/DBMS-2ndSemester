using Dll.BL;
using Dll.Generic;
using Dll.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace Dll.DL
{
    public class MedicineCrud : IMedicine
    {
        public string connectionString = utility.getconnString();
        static MedicineCrud instance;

        private MedicineCrud(string connection)
        {
            this.connectionString = connection;
        }
        public static MedicineCrud getInstance(string connection)
        {
            if (instance == null)
            {
                instance =new  MedicineCrud(connection);
            }
            return instance;
        }
        public static bool validateMedicine(Medicine medicine, string connectionString)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = String.Format("SELECT * FROM medicine WHERE medicineName = '{0}'", medicine.getMedicineName());
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                connection.Close();
                return true;
            }
            connection.Close();
            return false;
        }
        public bool addMedicine(Medicine medicine)
        {
            if (!validateMedicine(medicine, connectionString))
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                string query = String.Format("INSERT INTO medicine(medicineName, company, ExpDate, Price, Quantity, Distributor) VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')", medicine.getMedicineName(), medicine.getCompany(), medicine.getExpiryDate(), medicine.getPrice(), medicine.getQuantity(), medicine.getDistributor());
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            return false;
        }
        public void delMedicine(Medicine medicine)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = String.Format("DELETE FROM medicine WHERE medicineName = '{0}'", medicine.getMedicineName());
            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void updateMedicine(Medicine medicine)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = String.Format("UPDATE medicine SET company = '{0}', ExpDate = '{1}', Price = '{2}', Quantity = '{3}', Distributor = '{4}' WHERE medicineName = '{5}'", medicine.getCompany(), medicine.getExpiryDate(), medicine.getPrice(), medicine.getQuantity(), medicine.getDistributor(), medicine.getMedicineName());
            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public Medicine searchMedicine(string name)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = String.Format("SELECT * FROM medicine WHERE medicineName = '{0}'", name);
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                Medicine medicine = new Medicine(reader["medicineName"].ToString(), reader["company"].ToString(), reader["ExpDate"].ToString(), Convert.ToInt32(reader["Price"]), Convert.ToInt32(reader["Quantity"]), reader["Distributor"].ToString());
                connection.Close();
                return medicine;
            }
            connection.Close();
            return null;
        }
        
        public  List<Medicine> getMedicineList()
        {
           List<Medicine> medicines = new List<Medicine>();
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from medicine", con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Medicine med= new Medicine(reader["medicineName"].ToString(), reader["company"].ToString(), reader["ExpDate"].ToString(), Convert.ToInt32(reader["Price"]), Convert.ToInt32(reader["Quantity"]), reader["Distributor"].ToString());
                medicines.Add(med);
            }
            con.Close();
            return medicines;
        }
        public List<Medicine> getExpireMedicine()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from medicine where STR_TO_DATE(ExpDate,'%Y-%m-%d') < CURDATE();", con);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Medicine> medicines = new List<Medicine>();
            while (reader.Read())
            {
                Medicine med = new Medicine(reader["medicineName"].ToString(), reader["company"].ToString(), reader["ExpDate"].ToString(), Convert.ToInt32(reader["Price"]), Convert.ToInt32(reader["Quantity"]), reader["Distributor"].ToString());
                medicines.Add(med);
            }
            con.Close();
            return medicines;
        }
        public void returnMedicine(Medicine medicine)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string query = String.Format("DELETE FROM medicine WHERE medicineName = '{0}'", medicine.getMedicineName());
            string query1 = String.Format("INSERT INTO returnedMedicines(medicineName, company, ExpDate, Price, Quantity, Distributor) VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')", medicine.getMedicineName(), medicine.getCompany(), medicine.getExpiryDate(), medicine.getPrice(), medicine.getQuantity(), medicine.getDistributor());
            SqlCommand command = new SqlCommand(query, conn);
            SqlCommand command1 = new SqlCommand(query1, conn);

            command.ExecuteNonQuery();
            command1.ExecuteNonQuery();

            conn.Close();
        }
    }
}
