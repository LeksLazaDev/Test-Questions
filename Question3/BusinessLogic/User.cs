using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLogic
{
    public class User
    {
        private int userID;
        private string username;
        private string firstName;
        private string lastName;
        private List<Shift> shifts;
        private Branch branch;
        private DataHandler dHandler;


        public User(int userIDParam,string usernameParam,string firstNameParam, string lastNameParam)
        {
            this.UserID = userIDParam;
            this.Username = usernameParam;
            this.FirstName = firstNameParam;
            this.LastName = lastNameParam;
        }

        public User(string usernameParam, string firstNameParam, string lastNameParam)
        {
            this.Username = usernameParam;
            this.FirstName = firstNameParam;
            this.LastName = lastNameParam;
        }

        public User()//default constructor
        {

        }

        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        } 

        public List<User> ViewAllUsers()
        {
            List<User> userList = new List<User>();
            dHandler = new DataHandler();
            branch = new Branch();
            branch.ViewAllBranches();
            DataSet rawData = dHandler.ViewUsers();
            foreach (DataRow item in rawData.Tables["Table"].Rows)
            {
                userList.Add(new User(int.Parse(item[0].ToString()), item[1].ToString(), item[2].ToString(),item[3].ToString()));
            }
            return userList;
        }

        public void UpdateUser(int userID,string username,string firstName,string lastName,int branchID)
        {
            dHandler = new DataHandler();
            dHandler.UpdateUser(userID, username, firstName, lastName, branchID);
        }

        public void InsertUser(string username,string firstName,string lastName,int branchID)
        {
            shifts = new List<Shift>();
            branch = new Branch();
            dHandler = new DataHandler();
            dHandler.InsertUser(username,firstName,lastName,branchID);
        }

        public void DeleteUser(int userID)
        {
            dHandler = new DataHandler();
            dHandler.DeleteUser(userID);
        }

        public override string ToString()
        {
            return string.Format("{0}\t{1} {2}",Username,FirstName,LastName);
        }
    }
}
