using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLogic
{
    public class Branch
    {

        private int branchID;
        private string branchName;
        private int branchCode;
        private string addressLine1;
        private string addressLine2;
        private string suburb;
        DataHandler dHandler;

        public Branch(int branchIDParam,string branchNameParam,int branchCodeParam,string address1Param,string address2Param,string subParam)
        {
            this.BranchID = branchIDParam;
            this.BranchName = branchNameParam;
            this.BranchCode = branchCodeParam;
            this.AddressLine1 = address1Param;
            this.AddressLine2 = address2Param;
            this.Suburb = subParam;
            ;
        }

        public Branch(string branchNameParam, int branchCodeParam, string address1Param, string address2Param, string subParam)
        {
            this.BranchName = branchNameParam;
            this.BranchCode = branchCodeParam;
            this.AddressLine1 = address1Param;
            this.AddressLine2 = address2Param;
            this.Suburb = subParam;
        }

        public Branch()//default constructor
        {

        }

        public int BranchID
        {
            get { return branchID; }
            set { branchID = value; }
        }
        public string BranchName
        {
            get { return branchName; }
            set { branchName = value; }
        }
        public int BranchCode
        {
            get { return branchCode; }
            set { branchCode = value; }
        }
        public string AddressLine1
        {
            get { return addressLine1; }
            set { addressLine1 = value; }
        }
        public string AddressLine2
        {
            get { return addressLine2; }
            set { addressLine2 = value; }
        }
        public string Suburb
        {
            get { return suburb; }
            set { suburb = value; }
        }

        public List<Branch> ViewAllBranches()
        {
            List<Branch> branchList = new List<Branch>();
            dHandler = new DataHandler();
            DataSet rawData = dHandler.ViewBranches();
            foreach (DataRow item in rawData.Tables["Table"].Rows)
            {
                branchList.Add(new Branch(int.Parse(item[0].ToString()), item[1].ToString(), int.Parse(item[2].ToString()), item[3].ToString(), item[4].ToString(), item[5].ToString()));
            }
            return branchList;
        }

        public void InsertBranch(string branchName, int branchCode, string address1, string address2, string sub)
        {
            dHandler = new DataHandler();
            dHandler.InsertBranch(branchName, branchCode, address1, address2, sub);
        }

        public void UpdateBranch(int branchID, string branchName, int branchCode, string address1, string address2, string sub)
        {
            dHandler = new DataHandler();
            dHandler.UpdateBranch(branchID, branchName, branchCode, address1, address2, sub);
        }

        public void DeleteBranch(int branchID)
        {
            dHandler = new DataHandler();
            dHandler.DeleteBranch(branchID);
        }

        public override string ToString()
        {
            return string.Format("{0}{1}{2}\t{3}",BranchName,BranchCode,Suburb,BranchName);
        }
    }
}
