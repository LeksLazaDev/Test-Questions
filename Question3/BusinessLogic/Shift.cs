using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLogic
{
    public class Shift
    {

        private int shiftID;
        private string shiftDay;
        private string shiftTime;
        private DataHandler dHandler;

        public Shift(int shiftIDParam,string shiftDayParam,string shiftTimeParam)
        {
            this.ShiftID = shiftIDParam;
            this.ShiftDay = shiftDayParam;
            this.ShiftTime = shiftTimeParam;
        }
        public Shift(string shiftDayParam, string shiftTimeParam)
        {
            this.ShiftDay = shiftDayParam;
            this.ShiftTime = shiftTimeParam;
        }

        public Shift()//default constructor
        {

        }
        public int ShiftID
        {
            get { return shiftID; }
            set { shiftID = value; }
        }
       
        public string ShiftDay
        {
            get { return shiftDay; }
            set { shiftDay = value; }
        }
        public string ShiftTime
        {
            get { return shiftTime; }
            set { shiftTime = value; }
        }


        public List<Shift> ViewAllShifts()
        {
            List<Shift> shiftList = new List<Shift>();
            dHandler = new DataHandler();
            DataSet rawData = dHandler.ViewShifts();
            foreach (DataRow item in rawData.Tables["Table"].Rows)
            {
                shiftList.Add(new Shift(int.Parse(item[0].ToString()), item[1].ToString(), item[2].ToString()));
            }
            return shiftList;
        }

        public void InsertShift(string shiftDate,string shiftTime)
        {
            dHandler = new DataHandler();
            dHandler.InsertShift(shiftDate, shiftTime);
        }

        public void UpdateShift(int shiftID, string shiftDate,string shiftTime)
        {
            dHandler = new DataHandler();
            dHandler.UpdateShift(shiftID, shiftDate, shiftTime);
        }

        public void DeleteShift(int shiftID)
        {
            dHandler = new DataHandler();
            dHandler.DeleteShift(shiftID);
        }

        public override string ToString()
        {
            return null;
        }

    }
}
