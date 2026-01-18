using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.IO;
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

namespace Labely
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        UserViewmodel _U;
        public MainWindow()
        {
            InitializeComponent();
            DataBaseConnectionString();
            _U = new UserViewmodel();
            this.DataContext = _U;
            this.txtUser.Focus();
            //txtUser.Text = "admin";
            //txtPass.Password = "123";
        }

        private void DemoItemsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DemoClass _DemoClass = DemoItemsListBox.SelectedItem as DemoClass;
            if (!string.IsNullOrEmpty(_DemoClass.Url))
            {
                Uri pageFunctionUri = new Uri("View/" + _DemoClass.Url, UriKind.Relative);
                this.MainFrame.Navigate(pageFunctionUri);
            }
        }

        private void UIElement_OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MenuToggleButton.IsChecked = false;

        }

        private void btnMinimized_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
        void DataBaseConnectionString()
        {
            string Path = Environment.CurrentDirectory + "\\LabelyDB";
            if (!Directory.Exists(Path))
            {
                Directory.CreateDirectory(Path);
            }
            string FilePath = Path + "\\LabelyDB.sdf";
            if (!File.Exists(FilePath))
            {
                File.Copy(Environment.CurrentDirectory + "\\LabelyDB.sdf", FilePath);
            }
            EntityConnectionStringBuilder entityString = new EntityConnectionStringBuilder()
            {
                Provider = "System.Data.SqlServerCe.4.0",
                Metadata = "res://*/Model.LabelyDB.csdl|res://*/Model.LabelyDB.ssdl|res://*/Model.LabelyDB.msl",
                ProviderConnectionString = @"data source=" + FilePath + ";Max Database Size=4091;"// sqlString.ToString()

                //    metadata = res://*/Model.LabelyDB.csdl|res://*/Model.LabelyDB.ssdl|res://*/Model.LabelyDB.msl;provider=System.Data.SqlServerCe.4.0;provider connection 
                //string='Data Source=&quot;C:\TRDS Work\Work\Labely\Labely\LabelyDB.sdf&quot;;Max Database Size=4091'" providerName="System.Data.EntityClient" />
            };
            Program.ConnectionString = entityString.ToString();
            //System.Windows.MessageBox.Show(entityString.ToString());

        }
        private void btnlogin_Click(object sender, RoutedEventArgs e)
        {
            _U.UserName = txtUser.Text;
            _U.UserPassword = txtPass.Password;
            _U.LoginCommand.Execute(null);
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnlogin_Click(sender, e);  
            }
        }
    }
}
