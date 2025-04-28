using Dll.BL;
using Dll.Generic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dll.DL
{
    public class MUserFileStore 
    {

        public List<MUser> usersList = new List<MUser>();
        string dataFile = "data.txt";
        static MUserFileStore instance;  
        private MUserFileStore(string dataFilePath)   
 
        {
            this.dataFile = dataFilePath;
            readDataFromFile(this.dataFile);

        }
        
        public static MUserFileStore getInstance(string dataFilePath)
        {
            if (instance == null)
            {
                instance = new MUserFileStore(dataFilePath);

            }
            return instance;
        }
        public MUser SignIn(MUser user)
        {
            foreach (MUser storedUser in usersList)
            {
                if (storedUser.getUserName() == user.getUserName() && storedUser.getUserPassword() == user.getUserPassword())
                {
                    return storedUser;
                }
            }
            return null;

        }

        public bool SignUp(MUser user)
        {
            StreamWriter file = new StreamWriter(dataFile, true);
            file.WriteLine(user.getUserName() + "," + user.getUserPassword() + "," + user.getUserRole());
            file.Flush();
            file.Close();
            return true;
        }
        public bool addEmployee(EmployeeUser user)
        {
            StreamWriter file = new StreamWriter(dataFile, true);
            file.WriteLine(user.getUserName() + "," + user.getUserPassword() + "," + user.getUserRole() + "," + user.getName() + "," + user.getDob() + "," + user.getSalary() + "," + user.getEmail() + "," + user.getMobileNo());
            file.Flush();
            file.Close();
            return true;
        }
        public List<MUser> getAllUsers()
        {
            return usersList;
        }



        private string parseData(string record, int field)
        {
            int comma = 1;
            string item = "";
            for (int x = 0; x < record.Length; x++)
            {
                if (record[x] == ',')
                {
                    comma++;
                }
                else if (comma == field)
                {
                    item = item + record[x];
                }
            }
            return item;
        }
        private void readDataFromFile(string path)
        {
            if (File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                    string userName = parseData(record, 1);
                    string userPassword = parseData(record, 2);
                    string userRole = parseData(record, 3);
                    MUser user = new MUser(userName, userPassword, userRole);
                    usersList.Add(user);

                }
                fileVariable.Close();
            }
            else
            {
                Console.WriteLine("Not Exists");
            }
        }
    }
}
