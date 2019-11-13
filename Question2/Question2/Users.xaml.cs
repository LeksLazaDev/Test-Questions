using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BusinessLogic;

namespace Question2
{
    /// <summary>
    /// Interaction logic for Users.xaml
    /// </summary>
    public partial class Users : Window
    {
        private User user = new User();
        private Branch branch = new Branch();
        public Users()
        {
            InitializeComponent();

            dtUsers.ItemsSource = user.ViewAllUsers();
            dtUsers.IsReadOnly = true;
            dtBranch.ItemsSource = branch.ViewAllBranches();
            dtBranch.IsReadOnly = true;
        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Branch branchRow = (Branch)dtBranch.SelectedItems[0];
            
            string username = txtUsername.Text.ToString();
            string fullName = txtFullname.Text.ToString();
            int branchID = branchRow.BranchID;

            string[] Names = fullName.Split();
            string firstName = Names[0].ToString();
            string lastName = Names[1].ToString();
            user.InsertUser(username, firstName, lastName,branchID);
            MessageBox.Show("User has been Inserted!", "Insert Successful", MessageBoxButton.OK);
            dtUsers.ItemsSource = user.ViewAllUsers();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            User row = (User)dtUsers.SelectedItems[0];
            int userID = row.UserID;
            var result = MessageBox.Show("Are you sure would like to delete User?", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                user.DeleteUser(userID);
                MessageBox.Show("User has been deleted!", "Delete Successful", MessageBoxButton.OK);
                dtUsers.ItemsSource = user.ViewAllUsers();
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            User row = (User)dtUsers.SelectedItems[0];
            Branch branchRow = (Branch)dtBranch.SelectedItems[0];
            int userID = row.UserID;
            int branchID = branchRow.BranchID;
            string username = txtUsername.Text.ToString();
            string fullName = txtFullname.Text.ToString();

            string[] Names = fullName.Split();
            string firstName = Names[0].ToString();
            string lastName = Names[1].ToString();
            var result = MessageBox.Show("Are you sure would like to edit User?", "Edit", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                user.UpdateUser(userID, username, firstName, lastName, branchID);
                MessageBox.Show("User has been updated!", "Update Successful", MessageBoxButton.OK);
                dtUsers.ItemsSource = user.ViewAllUsers();
            }
        }

        private void DtUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;
            DataRowView rowSelected = dg.SelectedItem as DataRowView;
            if(rowSelected!= null)
            {

                txtUsername.Text = rowSelected[1].ToString();
            }
        }
    }

    
}
