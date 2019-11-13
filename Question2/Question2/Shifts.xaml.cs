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
    /// Interaction logic for Shifts.xaml
    /// </summary>
    public partial class Shifts : Window
    {
        private Shift shift = new Shift();
        public Shifts()
        {
            InitializeComponent();
            
            dtShifts.ItemsSource = shift.ViewAllShifts();
            dtShifts.IsReadOnly = true;
            if (dtShifts.SelectedItems.Count > 0)
            {
                Shift row = (Shift)dtShifts.SelectedItems[0];
                txtShiftDay.Text = row.ShiftDay.ToString();
                txtShiftTime.Text = row.ShiftTime.ToString();
            }
            
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void BtnInsert_Click(object sender, RoutedEventArgs e)
        {
            string day = txtShiftDay.Text.ToString();
            string time = txtShiftTime.Text.ToString();
            shift.InsertShift(day, time);
            MessageBox.Show("Shift has been inserted!", "Insert Successful", MessageBoxButton.OK);
            dtShifts.ItemsSource = shift.ViewAllShifts();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Shift row = (Shift)dtShifts.SelectedItems[0];
            int shiftID = row.ShiftID;
            string day = txtShiftDay.Text.ToString();
            string time = txtShiftTime.Text.ToString();
            var result = MessageBox.Show("Are you sure would like to edit Shift?", "Edit", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                shift.UpdateShift(shiftID, day, time);
                MessageBox.Show("Shift has been updated!", "Update Successful", MessageBoxButton.OK);
                dtShifts.ItemsSource = shift.ViewAllShifts();
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            Shift row = (Shift)dtShifts.SelectedItems[0];
            int shiftID = row.ShiftID;
            var result = MessageBox.Show("Are you sure would like to Delete Shift?", "Edit", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                shift.DeleteShift(shiftID);
                MessageBox.Show("Shift has been deleted!", "Delete Successful", MessageBoxButton.OK);
                dtShifts.ItemsSource = shift.ViewAllShifts();
            }
        }
    }
}
