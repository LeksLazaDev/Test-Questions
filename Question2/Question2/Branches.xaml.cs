using System;
using System.Collections.Generic;
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
    /// Interaction logic for Branches.xaml
    /// </summary>
    public partial class Branches : Window
    {
        private Branch branch = new Branch();
        public Branches()
        {
            InitializeComponent();
            
            dtBranches.ItemsSource = branch.ViewAllBranches();
            dtBranches.IsReadOnly = true;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void BtnInsert_Click(object sender, RoutedEventArgs e)
        {
            string branchName = txtBranchName.Text.ToString();
            int branchCode = int.Parse(txtBranchCode.Text.ToString());
            string address1 = txtAddress1.Text.ToString();
            string address2 = txtAddress2.Text.ToString();
            string suburb = txtSubrub.Text.ToString();
            branch.InsertBranch(branchName, branchCode, address1, address2, suburb);
            MessageBox.Show("Branch has been inserted!", "Insert Successful", MessageBoxButton.OK);
            dtBranches.ItemsSource = branch.ViewAllBranches();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Branch row = (Branch)dtBranches.SelectedItems[0];
            int branchID = row.BranchID;
            string branchName = txtBranchName.Text.ToString();
            int branchCode = int.Parse(txtBranchCode.Text.ToString());
            string address1 = txtAddress1.Text.ToString();
            string address2 = txtAddress2.Text.ToString();
            string suburb = txtSubrub.Text.ToString();
            var result = MessageBox.Show("Are you sure would like to edit Branch?", "Edit", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                branch.UpdateBranch(branchID, branchName, branchCode, address1, address2, suburb);
                MessageBox.Show("Branch has been updated!", "Update Successful", MessageBoxButton.OK);
                dtBranches.ItemsSource = branch.ViewAllBranches();
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            Branch row = (Branch)dtBranches.SelectedItems[0];
            int branchID = row.BranchID;
            var result = MessageBox.Show("Are you sure would like to Delete Branch?", "Edit", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                branch.DeleteBranch(branchID);
                MessageBox.Show("Branch has been deleted!", "Delete Successful", MessageBoxButton.OK);
                dtBranches.ItemsSource = branch.ViewAllBranches();
            }
        }
    }
}
