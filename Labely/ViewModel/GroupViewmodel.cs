using Labely.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace Labely
{
    public class GroupViewmodel : INotifyPropertyChanged
    {
        Entities _Entities = new Entities();

        public GroupViewmodel()
        {
            FillGroup();
            AddFromCommand = new RelayCommand(CanAddFrom, AddFrom);
            SaveCommand = new RelayCommand(CanSave, save);
            EditCommand = new RelayCommand(CanEdit, Edit);
            DeleteCommand = new RelayCommand(CanDelete, Delete);
            ClearCommand = new RelayCommand(CanClear, Clear);
        }

        private string _FrmVis = "Hidden";

        public string FrmVis
        {
            get { return _FrmVis; }
            set { _FrmVis = value; OnPropertyChanged("FrmVis"); }
        }


        public ICommand AddFromCommand { get; set; }

        public bool CanAddFrom(object p)
        {
            return true;
        }
        public void AddFrom(object pp)
        {
            string Id = pp as string;
            if (Id == "0")
            {
                FrmVis = "Visible";
                Clear(null);
            }
            else
            {
                FrmVis = "Hidden";
                Clear(null);
            }
        }


        private ObservableCollection<GroupMaster> _CollectionOfGroupMaster;

        public ObservableCollection<GroupMaster> CollectionOfGroupMaster
        {
            get
            {
                return _CollectionOfGroupMaster;
            }
            set
            {
                _CollectionOfGroupMaster = value;
                NotifyPropertyChanged();
            }
        }

        private GroupMaster _GroupMaster;

        public GroupMaster GroupMaster
        {
            get { return _GroupMaster; }
            set
            {
                _GroupMaster = value;
                OnPropertyChanged("GroupMaster");
            }
        }


        private string _GroupName;

        public string GroupName
        {
            get { return _GroupName; }
            set { _GroupName = value; OnPropertyChanged("GroupName"); }
        }

        private string _Search = "";

        public string Search
        {
            get { return _Search; }
            set
            {
                _Search = value;
                FillGroup();
                OnPropertyChanged("Search");
            }
        }


        void FillGroup()
        {
            try
            {
                if (!string.IsNullOrEmpty(Search))
                {
                    CollectionOfGroupMaster = new ObservableCollection<GroupMaster>(_Entities.GroupMasters.Where(w => w.GroupName.Contains(Search) && w.IsDelete != true).OrderByDescending(o => o.GroupId).ToList());
                }
                else
                    CollectionOfGroupMaster = new ObservableCollection<GroupMaster>(_Entities.GroupMasters.Where(w => w.IsDelete != true).OrderByDescending(o => o.GroupId).ToList());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        bool Cansave()
        {
            if (string.IsNullOrEmpty(GroupName))
            {
                CustomDialogBox tempDB = new CustomDialogBox("Enter GroupName.", DialogType.Information);
                tempDB.ShowDialog();
                return false;
            }
            else
                return true;
        }

        public ICommand SaveCommand { get; set; }

        public bool CanSave(object p)
        {
            return true;
        }
        public void save(object pp)
        {
            if (Cansave())
            {
                if (GroupMaster == null)
                {
                    GroupMaster = new GroupMaster();
                    GroupMaster.GroupName = GroupName;
                    GroupMaster.AddDate = DateTime.Now;
                    GroupMaster.IsDelete = false;
                    _Entities.GroupMasters.Add(GroupMaster);
                    _Entities.SaveChanges();
                    _CollectionOfGroupMaster.Insert(0,GroupMaster);
                }
                else
                {
                    GroupMaster.GroupName = GroupName;
                    GroupMaster.EditDate = DateTime.Now;
                    _Entities.Entry(GroupMaster).State = EntityState.Modified;
                    _Entities.SaveChanges();
                    CollectionViewSource.GetDefaultView(_CollectionOfGroupMaster).Refresh();
                    FrmVis = "Hidden";
                }
                Clear(null);
            }
        }

        public ICommand EditCommand { get; set; }
        public bool CanEdit(object p)
        {
            return true;
        }
        public void Edit(object pp)
        {
            GroupMaster _DM = pp as GroupMaster;
            if (_DM != null)
            {
                GroupMaster = _DM;
                GroupName = _DM.GroupName;
                FrmVis = "Visible";
            }

        }

        public ICommand DeleteCommand { get; set; }
        public bool CanDelete(object p)
        {
            return true;
        }
        public void Delete(object pp)
        {
            GroupMaster _DM = pp as GroupMaster;
            if (_DM != null)
            {
                if (_DM.GroupDetails.Where(w => w.IsDelete != true).Count() > 0)
                {
                    CustomDialogBox tempDB = new CustomDialogBox("Already used by Details.", DialogType.Information);
                    tempDB.ShowDialog();
                }
                else
                {
                    CustomDialogBox tempDB = new CustomDialogBox("Are you sure ?", DialogType.Question);
                    bool? result = tempDB.ShowDialog();
                    if (result == true)
                    {
                        _DM.IsDelete = true;
                        _DM.Deletedate = DateTime.Now;
                        _Entities.Entry(_DM).State = EntityState.Modified;
                        _Entities.SaveChanges();
                        _CollectionOfGroupMaster.Remove(_DM);
                    }
                }
            }

        }

        public ICommand ClearCommand { get; set; }
        public bool CanClear(object p)
        {
            return true;
        }
        public void Clear(object pp)
        {
            GroupMaster = null;
            GroupName = null;
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
