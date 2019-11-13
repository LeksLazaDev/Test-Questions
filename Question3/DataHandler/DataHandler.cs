using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DataHandler
    {

        private SqlCommand command;
        private SqlConnection connection;
        private SqlDataAdapter adapter;
        private DataSet dataSet;

        SqlConnectionStringBuilder ConnectionString = new SqlConnectionStringBuilder();

             
        public DataHandler()
        {
            ConnectionString.DataSource = @"DESKTOP-VK8O823\SQLEXPRESS";

            ConnectionString.InitialCatalog = "dbUserBranch";

            ConnectionString.IntegratedSecurity = true;

            connection = new SqlConnection(ConnectionString.ToString());
        }

        #region Queries
        public DataSet ViewUsers()
        {
            dataSet = new DataSet();
            try
            {
                CheckDBConnection();

                command = new SqlCommand("prViewUsers", connection);
                command.CommandType = CommandType.StoredProcedure;
                adapter = new SqlDataAdapter(command);
                adapter.Fill(dataSet);
                return dataSet;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                CheckDBConnection();
            }
        }
            
        public void UpdateUser(int userID,string username,string firstName,string lastName, int branchID)
        {
            try
            {
                CheckDBConnection();

                command = new SqlCommand("prEditUser", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserID", userID);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Firstname", firstName);
                command.Parameters.AddWithValue("@Lastname", lastName);
                command.Parameters.AddWithValue("@BranchID", branchID);
                command.ExecuteNonQuery();
            }catch(Exception e)
            {
                throw e;
            }
            finally
            {
                CheckDBConnection();
            }
        }

        public void InsertUser(string username, string firstName, string lastName, int branchID)
        {
            try
            {
                CheckDBConnection();

                command = new SqlCommand("prInsertUser", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Firstname", firstName);
                command.Parameters.AddWithValue("@Lastname", lastName);
                command.Parameters.AddWithValue("@BranchID", branchID);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                CheckDBConnection();
            }
        }

        public void DeleteUser(int userID)
        {
            try
            {
                CheckDBConnection();
                command = new SqlCommand("prDeleteUser", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserID", userID);
                command.ExecuteNonQuery();
            }catch(Exception e)
            {
                throw e;
            }
            finally
            {
                CheckDBConnection();
            }
        }

        public DataSet ViewBranches()
        {
            dataSet = new DataSet();
            try
            {
                CheckDBConnection();

                command = new SqlCommand("prViewBranches", connection);
                command.CommandType = CommandType.StoredProcedure;
                adapter = new SqlDataAdapter(command);
                adapter.Fill(dataSet);
                return dataSet;
            }catch(Exception e)
            {
                throw e;
            }
            finally
            {
                CheckDBConnection();
            }
        }

        public void UpdateBranch(int branchID,string branchName,int branchCode, string addressLine1,string addressLine2,string suburb)
        {
            try
            {
                CheckDBConnection();

                command = new SqlCommand("prEditBranch", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@BranchID", branchID);
                command.Parameters.AddWithValue("@BranchName", branchName);
                command.Parameters.AddWithValue("@AddressLine1", addressLine1);
                command.Parameters.AddWithValue("@AddressLine2", addressLine2);
                command.Parameters.AddWithValue("@Suburb", suburb);
                command.Parameters.AddWithValue("@BranchCode", branchCode);
                command.ExecuteNonQuery();
            }catch(Exception e)
            {
                throw e;
            }
            finally
            {
                CheckDBConnection();
            }
        }

        public void InsertBranch(string branchName, int branchCode, string addressLine1, string addressLine2, string suburb)
        {
            try
            {
                CheckDBConnection();

                command = new SqlCommand("prInsertBranch", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@BranchName", branchName);
                command.Parameters.AddWithValue("@AddressLine1", addressLine1);
                command.Parameters.AddWithValue("@AddressLine2", addressLine2);
                command.Parameters.AddWithValue("@Suburb", suburb);
                command.Parameters.AddWithValue("@BranchCode", branchCode);
                command.ExecuteNonQuery();

            }
            catch(Exception e)
            {
                throw e;
            }
            finally
            {
                CheckDBConnection();
            }
        }

        public void DeleteBranch (int branchID)
        {
            try
            {
                CheckDBConnection();

                command = new SqlCommand("prDeleteBranch", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@BranchID", branchID);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                throw e;
            }finally
            {
                CheckDBConnection();
            }
        }

        public DataSet ViewShifts()
        {
            dataSet = new DataSet();
            try
            {
                CheckDBConnection();

                command = new SqlCommand("prViewShift", connection);
                command.CommandType = CommandType.StoredProcedure;
                adapter = new SqlDataAdapter(command);
                adapter.Fill(dataSet);
                return dataSet;
            }
            catch (Exception e)
            {

                throw e;
            }finally
            {
                CheckDBConnection();
            }
        }

        public void InsertShift(string date, string time)
        {
            
            try
            {
                CheckDBConnection();

                command = new SqlCommand("prInsertShift", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ShiftDay", date);
                command.Parameters.AddWithValue("@ShiftTIme", time);
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                CheckDBConnection();
            }
        }

        public void UpdateShift(int shiftID,string date,string time)
        {
            try
            {
                CheckDBConnection();

                command = new SqlCommand("prEditShift", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ShiftID", shiftID);
                command.Parameters.AddWithValue("@ShiftDay", date);
                command.Parameters.AddWithValue("@ShiftTime", time);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                CheckDBConnection();
            }
        }

        public void DeleteShift(int shiftID)
        {
            try
            {
                CheckDBConnection();
                command = new SqlCommand("prDeleteShift", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ShiftID", shiftID);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                CheckDBConnection();
            }
        }
        #endregion

        #region DBHelper
        private void CheckDBConnection()
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();
            else if (connection.State != ConnectionState.Closed)
            {
                connection.Dispose();
                connection.Close();
            }
        }
        #endregion
    }
}
