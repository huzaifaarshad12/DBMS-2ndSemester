using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dll.BL;
using Dll.Generic;
using Dll.Utilities;

namespace Dll.DL
{
    public class AnnoucementCrud
    {
        string con = utility.getconnString();
        static AnnoucementCrud instance;
        private AnnoucementCrud(string con)
        {
            this.con = con;
        }
        public static AnnoucementCrud getInstance(string con)
        {
            if(instance==null)
            {
                instance = new AnnoucementCrud(con);
                
            }
            return instance;
        }
        public void AdminAnnouncement(Announcement A)
        {
            SqlConnection connection = new SqlConnection(con);
            connection.Open();
            string query = String.Format("INSERT INTO Announcement(Announcements,AnnouncDate) VALUES('{0}','{1}')", A.getMessage(), A.getDate());
            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public List<Announcement> GetNotifications()
        {
            SqlConnection connection = new SqlConnection(con);
            connection.Open();
            string query = String.Format("select * from Announcement");
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            List<Announcement> announcements = new List<Announcement>();
            while (reader.Read())
            {
                Announcement a = new Announcement(reader["Announcements"].ToString(), reader["AnnouncDate"].ToString());
                announcements.Add(a);
            }
            connection.Close();
            return announcements; 
        }
    }
}
