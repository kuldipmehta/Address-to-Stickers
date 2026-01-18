using Labely.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Labely
{
    public class UserViewmodel : INotifyPropertyChanged
    {
        Entities _Entities = new Entities();
        public delegate void OnLogin(string item);
        public event OnLogin OnLoginClick;
        public UserViewmodel()
        {
            FillData();
            LoginCommand = new RelayCommand(CanLogin, Login);

        }

        private string _loginGrid = "Visible";

        public string loginGrid
        {
            get { return _loginGrid; }
            set { _loginGrid = value; OnPropertyChanged("loginGrid"); }
        }

        private string _VisAll = "Hidden";

        public string VisAll
        {
            get { return _VisAll; }
            set { _VisAll = value; OnPropertyChanged("VisAll"); }
        }



        private string _UserName;
        public string UserName
        {
            get { return _UserName; }
            set
            {
                _UserName = value;
                OnPropertyChanged("UserName");
            }
        }

        private string _UserPassword;
        public string UserPassword
        {
            get { return _UserPassword; }
            set
            {
                _UserPassword = value;
                OnPropertyChanged("UserPassword");
            }
        }

        private string _Userlogin;
        public string Userlogin
        {
            get { return _Userlogin; }
            set
            {
                _Userlogin = value;
                OnPropertyChanged("Userlogin");
            }
        }

        public ICommand LoginCommand { get; set; }
        public bool CanLogin()
        {
            if (UserName == null)
            {

                return false;
            }
            else if (UserPassword == null)
            {

                return false;
            }
            else
                return true;
        }
        public bool CanLogin(object p)
        {
            return true;
        }
        public void Login(object pp)
        {
            try
            {
               // System.Windows.MessageBox.Show(_Entities.Database.Connection.ConnectionString);
                UserMaster _user = _Entities.UserMasters.Where(w => w.UserName == UserName && w.Password == UserPassword).SingleOrDefault();
                if (_user != null)
                {
                    loginGrid = "Hidden";
                    VisAll = "Visible";
                    Userlogin = _user.UserName;
                }
                else
                {
                    CustomDialogBox tempDB = new CustomDialogBox("UserName And Password Not Correct.", DialogType.Information);
                    tempDB.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
            }
        }


        private List<DemoClass> _DataList;
        public List<DemoClass> DataList
        {
            get { return _DataList; }
            set { _DataList = value; }
        }
        void FillData()
        {
            DataList = new List<DemoClass>();
            DataList.Add(new DemoClass { Name = "Group", icon = "Group", Url = "GroupView.xaml" });
            DataList.Add(new DemoClass { Name = "LabelDetail", icon = "AccountCardDetails", Url = "GroupDetailView.xaml" });

        }

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(String PropertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
public class DemoClass
{
    public string Name { get; set; }
    public string Url { get; set; }
    public string icon { get; set; }
}
