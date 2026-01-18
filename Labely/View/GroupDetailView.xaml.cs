using Labely.Model;
using Labely.ViewModel;
using ShowPopup;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Labely.View
{
    /// <summary>
    /// Interaction logic for GroupView.xaml
    /// </summary>
    public partial class GroupDetailView : Page
    {
        GroupDetailViewModel _GroupDetailViewModel = new GroupDetailViewModel();
        public GroupDetailView()
        {
            InitializeComponent();
            this.DataContext = _GroupDetailViewModel;
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            GroupDetail _Dm = dgUsers.SelectedItem as GroupDetail;
            _GroupDetailViewModel.EditCommand.Execute(_Dm);
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            GroupDetail _Dm = dgUsers.SelectedItem as GroupDetail;
            _GroupDetailViewModel.DeleteCommand.Execute(_Dm);
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (ChkAll.IsChecked == true)
            {
                _GroupDetailViewModel.AddFromCommand.Execute("4");
            }
            else
            {
                _GroupDetailViewModel.AddFromCommand.Execute("5");

            }
        }

        private void btnNoPrint_Click(object sender, RoutedEventArgs e)
        {
            GroupDetail _Dm = dgUsers.SelectedItem as GroupDetail;
            string Type = Check16.IsChecked == true ? "L16" : "L24";
            if (string.IsNullOrEmpty(txtLabelNo.Text.Trim()))
            {
                CustomDialogBox tempDB = new CustomDialogBox("Enter LabelNo.", DialogType.Information);
                tempDB.ShowDialog();
                txtLabelNo.Focus();
            }
            else
            {
                //ReportWindow _ReportWindow = new ReportWindow(_Dm, txtLabelNo.Text, Type);
                //_ReportWindow.Show();
                //_ReportWindow.Closed += _ReportWindow_Closed;
            }
        }

        private void _ReportWindow_Closed(object sender, EventArgs e)
        {

            _GroupDetailViewModel.AddFromCommand.Execute("7");
            txtLabelNo.Text = "";
        }

        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
            _GroupDetailViewModel.AddFromCommand.Execute("6");
            _GroupDetailViewModel.PrintGD= dgUsers.SelectedItem as GroupDetail;
            Check16.IsChecked = true;
        }

        private void ButtonFechar_Click(object sender, RoutedEventArgs e)
        {
            _GroupDetailViewModel.AddFromCommand.Execute("7");
            txtLabelNo.Text = "";

        }
    }
}
