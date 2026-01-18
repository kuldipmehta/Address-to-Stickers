using Labely.Model;
using Microsoft.Win32;
using ShowPopup;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.OleDb;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace Labely.ViewModel
{
    public class GroupDetailViewModel : INotifyPropertyChanged
    {
        Entities _Entities = new Entities();

        public GroupDetailViewModel()
        {
            FillCombo();
            FillGroup();
            FillAddGroup();
            AddFromCommand = new RelayCommand(CanAddFrom, AddFrom);
            SaveCommand = new RelayCommand(CanSave, save);
            EditCommand = new RelayCommand(CanEdit, Edit);
            DeleteCommand = new RelayCommand(CanDelete, Delete);
            ClearCommand = new RelayCommand(CanClear, Clear);
            ImportCommand = new RelayCommand(CanImport, Import);
            AddGroupCommand = new RelayCommand(CanAddGroup, AddGroup);
            PrintCommand = new RelayCommand(CanPrint, Print);
            FillGridSC();
            PrintGCCommand = new RelayCommand(CanPrintGC, PrintGC);

        }

        private string _FrmVis = "Hidden";
        public string FrmVis
        {
            get { return _FrmVis; }
            set { _FrmVis = value; OnPropertyChanged("FrmVis"); }
        }

        private string _FrmVis2 = "Hidden";
        public string FrmVis2
        {
            get { return _FrmVis2; }
            set { _FrmVis2 = value; OnPropertyChanged("FrmVis2"); }
        }

        private string _FrmLabNo = "Hidden";
        public string FrmLabNo
        {
            get { return _FrmLabNo; }
            set { _FrmLabNo = value; OnPropertyChanged("FrmLabNo"); }
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
            else if (Id == "2")
            {
                FrmVis2 = "Visible";
                FillAddGroup();
            }
            else if (Id == "3")
            {
                FrmVis2 = "Hidden";
                FillAddGroup();

            }
            else if (Id == "4")
            {
                foreach (GroupDetail item in ListOfGroupD)
                {
                    item.IsCheck = true;
                }
                CollectionViewSource.GetDefaultView(ListOfGroupD).Refresh();
            }
            else if (Id == "5")
            {
                //ListOfGroupD.All(a => a.IsSelect = false);
                foreach (GroupDetail item in ListOfGroupD)
                {
                    item.IsCheck = false;
                }
                CollectionViewSource.GetDefaultView(ListOfGroupD).Refresh();
            }
            else if (Id == "6")
            {
                PrintSFrmVis = "Visible";
                NoLangthVis = "Visible";
                NoOfLable = "";

            }
            else if (Id == "7")
            {
                FrmLabNo = "Hidden";
            }
            else
            {
                FrmVis = "Hidden";
                Clear(null);
            }
        }

        private string _NoLangthVis = "Hidden";

        public string NoLangthVis
        {
            get { return _NoLangthVis; }
            set { _NoLangthVis = value; OnPropertyChanged("NoLangthVis"); }
        }

        private string _NoOfLable;

        public string NoOfLable
        {
            get { return _NoOfLable; }
            set { _NoOfLable = value; OnPropertyChanged("NoOfLable"); }
        }


        private ObservableCollection<GroupDetail> _ListOfGroupD;

        public ObservableCollection<GroupDetail> ListOfGroupD
        {
            get { return _ListOfGroupD; }
            set
            {
                _ListOfGroupD = value;
                OnPropertyChanged("ListOfGroupD");
            }
        }


        private GroupMaster _Search;

        public GroupMaster Search
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
                if (Search != null)
                {
                    ListOfGroupD = new ObservableCollection<GroupDetail>(_Entities.GroupDetails.Where(w => w.GMId == Search.GroupId && w.IsDelete != true).OrderBy(o => o.GDId).ToList());
                }
                else
                    ListOfGroupD = new ObservableCollection<GroupDetail>(_Entities.GroupDetails.Where(w => w.IsDelete != true).OrderBy(o => o.GDId).ToList());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private ObservableCollection<GroupMaster> _ListOfGroup;

        public ObservableCollection<GroupMaster> ListOfGroup
        {
            get { return _ListOfGroup; }
            set { _ListOfGroup = value; NotifyPropertyChanged(); }
        }

        private GroupMaster _SelectGroup;

        public GroupMaster SelectGroup
        {
            get { return _SelectGroup; }
            set { _SelectGroup = value; OnPropertyChanged("SelectGroup"); }
        }

        void FillCombo()
        {
            ListOfGroup = new ObservableCollection<GroupMaster>(_Entities.GroupMasters.Where(w => w.IsDelete != true).ToList());
        }

        private String _Lable1;

        public String Lable1
        {
            get { return _Lable1; }
            set { _Lable1 = value; OnPropertyChanged("Lable1"); }
        }

        private String _Lable2;

        public String Lable2
        {
            get { return _Lable2; }
            set { _Lable2 = value; OnPropertyChanged("Lable2"); }
        }

        private String _Lable3;

        public String Lable3
        {
            get { return _Lable3; }
            set { _Lable3 = value; OnPropertyChanged("Lable3"); }
        }

        private String _Lable4;

        public String Lable4
        {
            get { return _Lable4; }
            set { _Lable4 = value; OnPropertyChanged("Lable4"); }
        }

        private String _Lable5;

        public String Lable5
        {
            get { return _Lable5; }
            set { _Lable5 = value; OnPropertyChanged("Lable5"); }
        }
        private String _Lable6;

        public String Lable6
        {
            get { return _Lable6; }
            set { _Lable6 = value; OnPropertyChanged("Lable6"); }
        }
        private String _Lable7;

        public String Lable7
        {
            get { return _Lable7; }
            set { _Lable7 = value; OnPropertyChanged("Lable7"); }
        }

        private String _Lable8;
        public String Lable8
        {
            get { return _Lable8; }
            set { _Lable8 = value; OnPropertyChanged("Lable8"); }
        }

        private String _Lable9;
        public String Lable9
        {
            get { return _Lable9; }
            set { _Lable9 = value; OnPropertyChanged("Lable9"); }
        }

        private String _Lable10;
        public String Lable10
        {
            get { return _Lable10; }
            set { _Lable8 = value; OnPropertyChanged("Lable10"); }
        }


        private GroupDetail _GroupDetail;

        public GroupDetail GroupDetail
        {
            get { return _GroupDetail; }
            set { _GroupDetail = value; OnPropertyChanged("GroupDetail"); }
        }

        bool Cansave()
        {
            if (string.IsNullOrEmpty(Lable1))
            {
                CustomDialogBox tempDB = new CustomDialogBox("Enter Name.", DialogType.Information);
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
                if (GroupDetail == null)
                {
                    GroupDetail = new GroupDetail();
                    GroupDetail.GroupMaster = SelectGroup;
                    GroupDetail.Lable1 = Lable1;
                    GroupDetail.Lable2 = Lable2;
                    GroupDetail.Lable3 = Lable3;
                    GroupDetail.Lable4 = Lable4;
                    GroupDetail.Lable5 = Lable5;
                    GroupDetail.Lable6 = Lable6;
                    GroupDetail.Lable7 = Lable7;
                    GroupDetail.Lable8 = Lable8;
                    GroupDetail.Lable9 = Lable9;
                    GroupDetail.Lable10 = Lable10;
                    GroupDetail.AddDate = DateTime.Now;
                    GroupDetail.IsDelete = false;
                    _Entities.GroupDetails.Add(GroupDetail);
                    _Entities.SaveChanges();
                    ListOfGroupD.Insert(0, GroupDetail);
                }
                else
                {
                    GroupDetail.GroupMaster = SelectGroup;
                    GroupDetail.Lable1 = Lable1;
                    GroupDetail.Lable2 = Lable2;
                    GroupDetail.Lable3 = Lable3;
                    GroupDetail.Lable4 = Lable4;
                    GroupDetail.Lable5 = Lable5;
                    GroupDetail.Lable6 = Lable6;
                    GroupDetail.Lable7 = Lable7;
                    GroupDetail.Lable8 = Lable8;
                    GroupDetail.Lable9 = Lable9;
                    GroupDetail.Lable10 = Lable10;
                    GroupDetail.EditDate = DateTime.Now;
                    _Entities.Entry(GroupDetail).State = EntityState.Modified;
                    _Entities.SaveChanges();
                    CollectionViewSource.GetDefaultView(ListOfGroupD).Refresh();
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
            GroupDetail _DD = pp as GroupDetail;
            if (_DD != null)
            {
                GroupDetail = _DD;
                SelectGroup = _DD.GroupMaster;
                Lable1 = _DD.Lable1;
                Lable2 = _DD.Lable2;
                Lable3 = _DD.Lable3;
                Lable4 = _DD.Lable4;
                Lable5 = _DD.Lable5;
                Lable6 = _DD.Lable6;
                Lable7 = _DD.Lable7;
                Lable8 = _DD.Lable8;
                Lable9 = _DD.Lable9;
                Lable10 = _DD.Lable10;
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
            if (pp as string == "1")
            {
                if (ListOfGroupD.Where(a => a.IsCheck == true).Count() > 0)
                {
                    ObservableCollection<GroupDetail> _GD = new ObservableCollection<GroupDetail>(ListOfGroupD.Where(w => w.IsCheck == true).ToList());
                    foreach (GroupDetail item in _GD)
                    {
                        item.IsDelete = true;
                        item.DeleteDate = DateTime.Now;
                        _Entities.Entry(item).State = EntityState.Modified;
                        _Entities.SaveChanges();
                        _ListOfGroupD.Remove(item);

                    }
                    CustomDialogBox tempDB = new CustomDialogBox("Successfully Delete.", DialogType.Information);
                    tempDB.ShowDialog();
                }
                else
                {
                    CustomDialogBox tempDB = new CustomDialogBox("No Date Found.", DialogType.Information);
                    tempDB.ShowDialog();
                }
            }
            else
            {
                GroupDetail _DD = pp as GroupDetail;
                if (_DD != null)
                {

                    CustomDialogBox tempDB = new CustomDialogBox("Are you sure ?", DialogType.Question);
                    bool? result = tempDB.ShowDialog();
                    if (result == true)
                    {
                        _DD.IsDelete = true;
                        _DD.DeleteDate = DateTime.Now;
                        _Entities.Entry(_DD).State = EntityState.Modified;
                        _Entities.SaveChanges();
                        _ListOfGroupD.Remove(_DD);
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
            GroupDetail = null;
            Lable1 = null;
            Lable2 = null;
            Lable3 = null;
            Lable4 = null;
            Lable5 = null;
            Lable6 = null;
            Lable7 = null;
            Lable8 = null;
            SelectGroup = null;
        }
        public ICommand ImportCommand { get; set; }
        public bool CanImport(object p)
        {
            return true;
        }
        public void Import(object pp)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.ShowDialog();
            try
            {

                string strFileType;
                strFileType = System.IO.Path.GetExtension(openFileDialog1.FileName).ToLower();
                if (strFileType != "")
                {
                    CustomDialogBox tempDB = new CustomDialogBox("Are you sure you want to ImportDate ?", DialogType.Question);
                    bool? result = tempDB.ShowDialog();
                    if (result == true)
                    {
                        if (strFileType != ".xlsx")
                        {
                            tempDB = new CustomDialogBox("ArePlease Select only Excel File with .xlsx Extension", DialogType.Information);
                            tempDB.ShowDialog();
                            openFileDialog1.ShowDialog();
                            strFileType = System.IO.Path.GetExtension(openFileDialog1.FileName).ToLower();
                        }
                        else
                        {
                            string path = openFileDialog1.FileName;

                            System.Data.DataTable dtExcel = new System.Data.DataTable();
                            dtExcel.TableName = "ImportPI";

                            string SourceConstr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\"";

                            // string SourceConstr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source='C:\Users\agite\Documents\Sheet1.xlsx';Extended Properties= 'Excel 8.0;HDR=Yes;IMEX=1'";
                            OleDbConnection con = new OleDbConnection(SourceConstr);
                            string query = " select Lable1,Lable2,Lable3,Lable4,Lable5,Lable6,Lable7,Lable8,Lable9,Lable10 from [Sheet1$]";
                            OleDbDataAdapter data = new OleDbDataAdapter(query, con);
                            data.Fill(dtExcel);
                            int res = 0;
                            List<GroupDetail> _GroupDetail = new List<GroupDetail>();
                            if (dtExcel.Rows.Count > 0)
                            {
                                foreach (DataRow row in dtExcel.Rows)
                                {
                                    GroupDetail GroupDetail = new GroupDetail();
                                    GroupDetail.GMId = SelectGm.GroupId;
                                    GroupDetail.Lable1 = row["Lable1"].ToString();
                                    GroupDetail.Lable2 = row["Lable2"].ToString();
                                    GroupDetail.Lable3 = row["Lable3"].ToString();
                                    GroupDetail.Lable4 = row["Lable4"].ToString();
                                    GroupDetail.Lable5 = row["Lable5"].ToString();
                                    GroupDetail.Lable6 = row["Lable6"].ToString();
                                    GroupDetail.Lable7 = row["Lable7"].ToString();
                                    GroupDetail.Lable8 = row["Lable8"].ToString();
                                    GroupDetail.Lable9 = row["Lable9"].ToString();
                                    GroupDetail.Lable10 = row["Lable10"].ToString();
                                    GroupDetail.AddDate = DateTime.Now;
                                    GroupDetail.IsDelete = false;
                                    _Entities.GroupDetails.Add(GroupDetail);
                                    _GroupDetail.Add(GroupDetail);
                                }
                                _Entities.SaveChanges();
                                CustomDialogBox tempDB1 = new CustomDialogBox("Imported Successfully.", DialogType.Information);
                                tempDB1.ShowDialog();
                                FillGroup();
                                FrmVis2 = "Hidden";

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private ObservableCollection<GroupDetail> _ListOfAddGroup;

        public ObservableCollection<GroupDetail> ListOfAddGroup
        {
            get { return _ListOfAddGroup; }
            set { _ListOfAddGroup = value; NotifyPropertyChanged(); }
        }

        void FillAddGroup()
        {
            try
            {
                ListOfAddGroup = new ObservableCollection<GroupDetail>(_Entities.GroupDetails.Where(w => w.IsDelete != true && w.GMId == null).OrderByDescending(o => o.GDId).ToList());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private GroupMaster _SelectGm;

        public GroupMaster SelectGm
        {
            get { return _SelectGm; }
            set
            {
                _SelectGm = value;
                NotifyPropertyChanged();
            }
        }


        public ICommand AddGroupCommand { get; set; }
        public bool CanAddGroup(object p)
        {
            return true;
        }
        public void AddGroup(object pp)
        {
            string Id = pp as string;
            if (Id == "0")
            {
                if (SelectGm == null)
                {
                    CustomDialogBox tempDB = new CustomDialogBox("Select Group", DialogType.Information);
                    tempDB.ShowDialog();
                }
                else
                {

                    Import(null);
                    //if (ListOfAddGroup.Count == 0)
                    //{
                    //    CustomDialogBox tempDB = new CustomDialogBox("No Data found.", DialogType.Information);
                    //    tempDB.ShowDialog();
                    //}
                    //else
                    //{
                    //    foreach (GroupDetail item in ListOfAddGroup)
                    //    {
                    //        if (item.IsSelect == true)
                    //        {
                    //            item.GroupMaster = SelectGm;
                    //            item.GName = SelectGm.GroupName;
                    //            item.IsSelect = false;
                    //        }
                    //    }
                    //    FillAddGroup();
                    SelectGm = null;
                    CollectionViewSource.GetDefaultView(ListOfAddGroup).Refresh();
                    //}
                }
            }
            else if (Id == "1")
            {


                if (ListOfAddGroup.Count == 0)
                {
                    CustomDialogBox tempDB = new CustomDialogBox("No Data found.", DialogType.Information);
                    tempDB.ShowDialog();
                }
                else
                {
                    foreach (GroupDetail item in ListOfAddGroup)
                    {
                        _Entities.Entry(item).State = EntityState.Modified;
                    }
                    _Entities.SaveChanges();
                    CollectionViewSource.GetDefaultView(ListOfGroupD).Refresh();
                    CustomDialogBox tempDB = new CustomDialogBox("Saved Successfully", DialogType.Information);
                    tempDB.ShowDialog();
                    SelectGm = null;
                    FillAddGroup();
                    FrmVis2 = "Hidden";
                }

            }

        }


        public ICommand PrintCommand { get; set; }
        public bool CanPrint(object p)
        {
            return true;
        }
        private GroupDetail _PrintGD;

        public GroupDetail PrintGD
        {
            get { return _PrintGD; }
            set { _PrintGD = value; OnPropertyChanged("PrintGD"); }
        }


        private string _TextAlign = "Left";

        public string TextAlign
        {
            get { return _TextAlign; }
            set { _TextAlign = value; OnPropertyChanged("TextAlign"); }
        }

        private string _FontStyle = "Normal";

        public string FontStyle
        {
            get { return _FontStyle; }
            set { _FontStyle = value; OnPropertyChanged("FontStyle"); }
        }

        private string _FontWeight = "Normal";

        public string FontWeight
        {
            get { return _FontWeight; }
            set { _FontWeight = value; OnPropertyChanged("FontWeight"); }
        }

        private string _Font = "Cambria";

        public string Font
        {
            get { return _Font; }
            set { _Font = value; OnPropertyChanged("Font"); }
        }


        public void Print(object pp)
        {
            string type = "";
            if (LableType == "Lable16")
            {
                type = "L16";
            }
            else if (LableType == "Lable24")
            {
                type = "L24";
            }
            else if (LableType == "Lable18")
            {
                type = "L18";
            }
            //PrintWindow _print = new PrintWindow(new ObservableCollection<object>(ListOfGroupD));
            //_print.ShowDialog();
            if (NoLangthVis == "Visible")
            {

                if (string.IsNullOrEmpty(LableType))
                {
                    CustomDialogBox tempDB = new CustomDialogBox("Enter Lable.", DialogType.Information);
                    tempDB.ShowDialog();
                }
                else if (string.IsNullOrEmpty(NoOfLable))
                {
                    CustomDialogBox tempDB = new CustomDialogBox("Enter LabelNo.", DialogType.Information);
                    tempDB.ShowDialog();
                }
                else if (string.IsNullOrEmpty(TextAlign))
                {
                    CustomDialogBox tempDB = new CustomDialogBox("Select TextAlign.", DialogType.Information);
                    tempDB.ShowDialog();
                }
                else
                {
                    GroupDetail _GRoupDetail = new GroupDetail();
                    ReportWindow _ReportWindow = new ReportWindow(PrintGD, ListOfGridSC, NoOfLable, type, TextAlign, FontStyle, FontWeight, Font);
                    _ReportWindow.ShowDialog();
                }
            }
            else
            {
                if (ListOfGroupD.Where(a => a.IsCheck == true).Count() > 0)
                {
                    if (string.IsNullOrEmpty(LableType))
                    {
                        CustomDialogBox tempDB = new CustomDialogBox("Enter Lable.", DialogType.Information);
                        tempDB.ShowDialog();
                    }
                    else if (string.IsNullOrEmpty(TextAlign))
                    {
                        CustomDialogBox tempDB = new CustomDialogBox("Select TextAlign.", DialogType.Information);
                        tempDB.ShowDialog();
                    }
                    else
                    {
                        ObservableCollection<GroupDetail> _GD = new ObservableCollection<GroupDetail>(ListOfGroupD.Where(w => w.IsCheck == true).ToList());
                        foreach (GroupDetail item in _GD)
                        {
                            item.Lable5 = item.Lable5;
                        }
                        ReportWindow _ReportWindow = new ReportWindow(ListOfGridSC, _GD, type, TextAlign, FontStyle, FontWeight, Font);
                        _ReportWindow.ShowDialog();
                    }
                }
                else
                {
                    CustomDialogBox tempDB = new CustomDialogBox("No Date Found.", DialogType.Information);
                    tempDB.ShowDialog();
                }
            }



        }



        #region SelectColumn For Print

        private string _PrintSFrmVis = "Hidden";
        public string PrintSFrmVis
        {
            get { return _PrintSFrmVis; }
            set { _PrintSFrmVis = value; OnPropertyChanged("PrintSFrmVis"); }
        }

        private bool _Lable16 = true;

        public bool Lable16
        {
            get { return _Lable16; }
            set { _Lable16 = value; OnPropertyChanged("Lable16"); }
        }

        private bool _Lable24 = false;

        public bool Lable24
        {
            get { return _Lable24; }
            set { _Lable24 = value; OnPropertyChanged("Lable24"); }
        }


        private string _LableType = "Lable16";

        public string LableType
        {
            get { return _LableType; }
            set { _LableType = value; OnPropertyChanged("LableType"); }
        }


        private ObservableCollection<GridSC> _ListOfGridSC;

        public ObservableCollection<GridSC> ListOfGridSC
        {
            get { return _ListOfGridSC; }
            set
            {
                _ListOfGridSC = value;
                OnPropertyChanged("ListOfGridSC");
            }
        }


        void FillGridSC()
        {
            ListOfGridSC = new ObservableCollection<GridSC>();
            ListOfGridSC.Add(new GridSC { ColumnName = "Name", No = 1, Column = "Lable1", IsDisplay = true });
            ListOfGridSC.Add(new GridSC { ColumnName = "Address1", No = 2, Column = "Lable2", IsDisplay = true });
            ListOfGridSC.Add(new GridSC { ColumnName = "Address2", No = 3, Column = "Lable3", IsDisplay = true });
            ListOfGridSC.Add(new GridSC { ColumnName = "Address3", No = 4, Column = "Lable4", IsDisplay = true });
            ListOfGridSC.Add(new GridSC { ColumnName = "City Pin.", No = 5, Column = "Lable5", IsDisplay = true });
            ListOfGridSC.Add(new GridSC { ColumnName = "Mobile No.", No = 6, Column = "Lable6", IsDisplay = true });
            ListOfGridSC.Add(new GridSC { ColumnName = "Email", No = 7, Column = "Lable7", IsDisplay = true });
            ListOfGridSC.Add(new GridSC { ColumnName = "Remarks1", No = 8, Column = "Lable8", IsDisplay = true });
            ListOfGridSC.Add(new GridSC { ColumnName = "Remarks2", No = 9, Column = "Lable9", IsDisplay = true });
            ListOfGridSC.Add(new GridSC { ColumnName = "Remarks3", No = 10, Column = "Lable10", IsDisplay = true });
        }

        public ICommand PrintGCCommand { get; set; }
        public bool CanPrintGC(object p)
        {
            return true;
        }
        public void PrintGC(object pp)
        {
            if (NoLangthVis == "Visible")
            {
                string Id = pp as string;
                if (Id == "2")
                {
                    PrintSFrmVis = "Hidden";
                    NoLangthVis = "Hidden";
                    NoOfLable = "";
                }
            }
            else
            {
                if (ListOfGroupD.Where(a => a.IsCheck == true).Count() > 0)
                {
                    string Id = pp as string;
                    if (Id == "1")
                    {
                        PrintSFrmVis = "Visible";
                        NoLangthVis = "Hidden";
                    }
                    else if (Id == "2")
                    {
                        PrintSFrmVis = "Hidden";
                        NoLangthVis = "Hidden";
                    }
                    else if (Id == "3")
                    {

                    }
                }
                else
                {
                    CustomDialogBox tempDB = new CustomDialogBox("No Date Found.", DialogType.Information);
                    tempDB.ShowDialog();
                }
            }

        }
        #endregion

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
public class GridSC
{
    public int No { get; set; }
    public String ColumnName { get; set; }
    public String Column { get; set; }
    public bool IsDisplay { get; set; }
}