using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dll.Generic;
using Dll.BL;
using Dll.Utilities;
using System.Data.SqlClient;

namespace Dll.DL
{
    public class FeedBackCrud : IFeedBack
    {
        string conn = utility.getconnString();
        static FeedBackCrud instance ;
        private FeedBackCrud(string conn)
        {
            this.conn = conn;
        }
        public static FeedBackCrud getInstance(string conn)
        {
            if (instance == null)
            {
                instance = new FeedBackCrud(conn);
            }
            return instance;
        }
        public void addFeedBack(Feedback feedBack)
        {
           SqlConnection connection = new SqlConnection(conn);
            connection.Open();
            string query = String.Format("Insert into Feedback values('{0}')", feedBack.getFeedBackMsg());
            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public List<Feedback> getFeedBackList()
        {
            SqlConnection connection = new SqlConnection(conn);
            connection.Open();
            string query = "select * from Feedback";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            List<Feedback> feedbacks = new List<Feedback>();
            while (reader.Read())
            {
                Feedback f = new Feedback(reader["feedback"].ToString());
                feedbacks.Add(f);
            }
            connection.Close();
            return feedbacks;
        }
    }
}
