using Labely.Model;
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
    public partial class GroupView : Page
    {
        GroupViewmodel _GroupViewmodel = new GroupViewmodel();
        public GroupView()
        {
            InitializeComponent();
            this.DataContext = _GroupViewmodel;
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            GroupMaster _Dm = dgUsers.SelectedItem as GroupMaster;
            _GroupViewmodel.EditCommand.Execute(_Dm);
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            GroupMaster _Dm = dgUsers.SelectedItem as GroupMaster;
            _GroupViewmodel.DeleteCommand.Execute(_Dm);
        }
    }
}
