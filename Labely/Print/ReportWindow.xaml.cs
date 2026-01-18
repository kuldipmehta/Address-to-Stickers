using Labely.Model;
using MahApps.Metro.Controls;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Reflection;
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

namespace ShowPopup
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ReportWindow : MetroWindow
    {
        ObservableCollection<GroupDetail> _ListOfGD;
        string TA = "";
        string FS = "";
        string FW = "";
        string font = "";
        public ReportWindow(ObservableCollection<GroupDetail> _listOfGD, string Type)
        {
            InitializeComponent();
            try
            {
                _ListOfGD = _listOfGD;
                if (Type == "L16")
                {
                    FillLable16();
                }
                else if (Type == "L24")
                {
                    FillLable24();
                }
                else if (Type == "L18")
                {
                    FillLable18();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
        GroupDetail _GroupDetail;
        string NoOfLabel;
        public ReportWindow(GroupDetail _GD, ObservableCollection<GridSC> _ListOfGridSC, string No, string Type, string TextAlign, string FontStyle, string FontWeight, string Font)
        {
            InitializeComponent();
            try
            {

                ListOfGridSC = _ListOfGridSC;
                _GroupDetail = _GD;
                NoOfLabel = No;
                TA = TextAlign;
                FS = FontStyle;
                FW = FontWeight;
                font = Font;

                if (Type == "L16")
                {
                    FillLable16One();
                }
                else if (Type == "L24")
                {
                    FillLable24One();
                }
                else if (Type == "L18")
                {
                    FillLable18One();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
        ObservableCollection<GridSC> ListOfGridSC;
        public ReportWindow(ObservableCollection<GridSC> _ListOfGridSC, ObservableCollection<GroupDetail> _listOfGD, string Type, string TextAlign, string FontStyle, string FontWeight, string Font)
        {
            InitializeComponent();
            _ListOfGD = _listOfGD;
            ListOfGridSC = _ListOfGridSC;
            TA = TextAlign;
            FS = FontStyle;
            FW = FontWeight;
            font = Font;

            if (Type == "L16")
            {
                FillLable16();
            }
            else if (Type == "L24")
            {
                FillLable24();
            }
            else if (Type == "L18")
            {
                FillLable18();
            }
        }

        public static bool IsOdd(int value)
        {
            return value % 2 != 0;
        }
        #region Lable16
        void FillLable16()
        {
            string ReportPath = null;
            DataTable dt = new DataTable();
            dt.Columns.Add("Lable1");
            dt.Columns.Add("Lable2");
            dt.Columns.Add("Lable3");
            dt.Columns.Add("Lable4");
            dt.Columns.Add("Lable5");
            dt.Columns.Add("Lable6");
            dt.Columns.Add("Lable11");
            dt.Columns.Add("Lable21");
            dt.Columns.Add("Lable31");
            dt.Columns.Add("Lable41");
            dt.Columns.Add("Lable51");
            dt.Columns.Add("Lable61");
            this.reportViewer.LocalReport.DataSources.Clear();
            DataTable _DataSet = new DataTable();
            ReportDataSource RDS;
            ReportPath = "Labely.Print.RDLC.16Label.rdlc";

            int Id = _ListOfGD.Count();
            DataTable GDdt = ToDataTable<GroupDetail>(_ListOfGD);
            LablePrint[] arr = new LablePrint[Id];
            int cou = 0;
            foreach (DataRow item in GDdt.Rows)
            {
                for (int i = 0; i < 1; i++)
                {
                    string L1 = ListOfGridSC.Where(w => w.No == 1 && w.IsDisplay == true).Select(s => s.Column).FirstOrDefault();
                    string L2 = ListOfGridSC.Where(w => w.No == 2 && w.IsDisplay == true).Select(s => s.Column).FirstOrDefault();
                    string L3 = ListOfGridSC.Where(w => w.No == 3 && w.IsDisplay == true).Select(s => s.Column).FirstOrDefault();
                    string L4 = ListOfGridSC.Where(w => w.No == 4 && w.IsDisplay == true).Select(s => s.Column).FirstOrDefault();
                    string L5 = ListOfGridSC.Where(w => w.No == 5 && w.IsDisplay == true).Select(s => s.Column).FirstOrDefault();
                    string L6 = ListOfGridSC.Where(w => w.No == 6 && w.IsDisplay == true).Select(s => s.Column).FirstOrDefault();
                    string L7 = ListOfGridSC.Where(w => w.No == 7 && w.IsDisplay == true).Select(s => s.Column).FirstOrDefault();
                    arr[cou] = new LablePrint(string.IsNullOrEmpty(L1) ? "" : item[L1].ToString(), string.IsNullOrEmpty(L2) ? "" : item[L2].ToString(), string.IsNullOrEmpty(L3) ? "" : item[L3].ToString(), string.IsNullOrEmpty(L4) ? "" : item[L4].ToString(), string.IsNullOrEmpty(L5) ? "" : item[L5].ToString(), string.IsNullOrEmpty(L6) ? "" : item[L6].ToString(), string.IsNullOrEmpty(L7) ? "" : item[L7].ToString(), "", "");
                    cou++;
                }
            }
            for (int i = 0; i < arr.Length; i = i + 2)
            {
                DataRow dr = dt.NewRow();
                dr["Lable1"] = arr[i].Lable1;
                dr["Lable2"] = arr[i].Lable2;
                dr["Lable3"] = arr[i].Lable3;
                dr["Lable4"] = arr[i].Lable4;
                dr["Lable5"] = arr[i].Lable5;
                dr["Lable6"] = arr[i].Lable6;
                if ((i + 1) < arr.Length)
                {
                    dr["Lable11"] = arr[i + 1].Lable1;
                    dr["Lable21"] = arr[i + 1].Lable2;
                    dr["Lable31"] = arr[i + 1].Lable3;
                    dr["Lable41"] = arr[i + 1].Lable4;
                    dr["Lable51"] = arr[i + 1].Lable5;
                    dr["Lable61"] = arr[i + 1].Lable6;
                }
                dt.Rows.Add(dr);
            }
            ReportParameter[] parms = new ReportParameter[4];

            parms[0] = new ReportParameter("TextAlign", TA);
            parms[1] = new ReportParameter("FontStyle", FS);
            parms[2] = new ReportParameter("FontWeight", FW);
            parms[3] = new ReportParameter("Font", font);
            RDS = new ReportDataSource("Lable16DataSet", dt);
            this.reportViewer.LocalReport.ReportEmbeddedResource = ReportPath;
            reportViewer.LocalReport.SetParameters(parms);
            this.reportViewer.ProcessingMode = ProcessingMode.Local;
            this.reportViewer.LocalReport.DataSources.Add(RDS);
            this.reportViewer.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            this.reportViewer.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;
            this.reportViewer.ZoomPercent = 100;
            this.reportViewer.RefreshReport();
        }

        void FillLable16One()
        {
            string ReportPath = null;
            DataTable dt = new DataTable();
            dt.Columns.Add("Lable1");
            dt.Columns.Add("Lable2");
            dt.Columns.Add("Lable3");
            dt.Columns.Add("Lable4");
            dt.Columns.Add("Lable5");
            dt.Columns.Add("Lable6");
            dt.Columns.Add("Lable11");
            dt.Columns.Add("Lable21");
            dt.Columns.Add("Lable31");
            dt.Columns.Add("Lable41");
            dt.Columns.Add("Lable51");
            dt.Columns.Add("Lable61");
            this.reportViewer.LocalReport.DataSources.Clear();
            DataTable _DataSet = new DataTable();
            ReportDataSource RDS;
            ReportPath = "Labely.Print.RDLC.16Label.rdlc";


            ObservableCollection<GroupDetail> _listOfGd = new ObservableCollection<GroupDetail>();
            for (int i = 1; i <= Convert.ToInt32(NoOfLabel); i++)
            {
                _listOfGd.Add(_GroupDetail);
            }

            int Id = _listOfGd.Count();
            DataTable GDdt = ToDataTable<GroupDetail>(_listOfGd);
            LablePrint[] arr = new LablePrint[Id];
            int cou = 0;
            foreach (DataRow item in GDdt.Rows)
            {
                for (int i = 0; i < 1; i++)
                {
                    string L1 = ListOfGridSC.Where(w => w.No == 1 && w.IsDisplay == true).Select(s => s.Column).FirstOrDefault();
                    string L2 = ListOfGridSC.Where(w => w.No == 2 && w.IsDisplay == true).Select(s => s.Column).FirstOrDefault();
                    string L3 = ListOfGridSC.Where(w => w.No == 3 && w.IsDisplay == true).Select(s => s.Column).FirstOrDefault();
                    string L4 = ListOfGridSC.Where(w => w.No == 4 && w.IsDisplay == true).Select(s => s.Column).FirstOrDefault();
                    string L5 = ListOfGridSC.Where(w => w.No == 5 && w.IsDisplay == true).Select(s => s.Column).FirstOrDefault();
                    string L6 = ListOfGridSC.Where(w => w.No == 6 && w.IsDisplay == true).Select(s => s.Column).FirstOrDefault();
                    string L7 = ListOfGridSC.Where(w => w.No == 7 && w.IsDisplay == true).Select(s => s.Column).FirstOrDefault();
                    arr[cou] = new LablePrint(string.IsNullOrEmpty(L1) ? "" : item[L1].ToString(), string.IsNullOrEmpty(L2) ? "" : item[L2].ToString(), string.IsNullOrEmpty(L3) ? "" : item[L3].ToString(), string.IsNullOrEmpty(L4) ? "" : item[L4].ToString(), string.IsNullOrEmpty(L5) ? "" : item[L5].ToString(), string.IsNullOrEmpty(L6) ? "" : item[L6].ToString(), string.IsNullOrEmpty(L7) ? "" : item[L7].ToString(), "", "");
                    cou++;
                }
            }
            //int Id = _listOfGd.Count();
            //LablePrint[] arr = new LablePrint[Id];
            //int cou = 0;
            //foreach (var item in _listOfGd)
            //{
            //    for (int i = 0; i < 1; i++)
            //    {
            //        arr[cou] = new LablePrint(item.Lable1, item.Lable2, item.Lable3, item.Lable4, "", "");
            //        cou++;
            //    }
            //}
            for (int i = 0; i < arr.Length; i = i + 2)
            {
                DataRow dr = dt.NewRow();
                dr["Lable1"] = arr[i].Lable1;
                dr["Lable2"] = arr[i].Lable2;
                dr["Lable3"] = arr[i].Lable3;
                dr["Lable4"] = arr[i].Lable4;
                dr["Lable5"] = arr[i].Lable5;
                dr["Lable6"] = arr[i].Lable6;
                if ((i + 1) < arr.Length)
                {
                    dr["Lable11"] = arr[i + 1].Lable1;
                    dr["Lable21"] = arr[i + 1].Lable2;
                    dr["Lable31"] = arr[i + 1].Lable3;
                    dr["Lable41"] = arr[i + 1].Lable4;
                    dr["Lable51"] = arr[i + 1].Lable5;
                    dr["Lable61"] = arr[i + 1].Lable6;
                }
                dt.Rows.Add(dr);
            }
            ReportParameter[] parms = new ReportParameter[4];

            parms[0] = new ReportParameter("TextAlign", TA);
            parms[1] = new ReportParameter("FontStyle", FS);
            parms[2] = new ReportParameter("FontWeight", FW);
            parms[3] = new ReportParameter("Font", font);
            RDS = new ReportDataSource("Lable16DataSet", dt);

            this.reportViewer.LocalReport.ReportEmbeddedResource = ReportPath;
            reportViewer.LocalReport.SetParameters(parms);
            this.reportViewer.ProcessingMode = ProcessingMode.Local;
            this.reportViewer.LocalReport.DataSources.Add(RDS);
            this.reportViewer.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            this.reportViewer.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;
            this.reportViewer.ZoomPercent = 100;
            this.reportViewer.RefreshReport();
        }

        #endregion

        #region Lable24
        void FillLable24()
        {
            string ReportPath = null;
            DataTable dt = new DataTable();
            dt.Columns.Add("Lable1");
            dt.Columns.Add("Lable2");
            dt.Columns.Add("Lable3");
            dt.Columns.Add("Lable4");
            dt.Columns.Add("Lable5");
            dt.Columns.Add("Lable6");
            dt.Columns.Add("Lable7");
            dt.Columns.Add("Lable11");
            dt.Columns.Add("Lable21");
            dt.Columns.Add("Lable31");
            dt.Columns.Add("Lable41");
            dt.Columns.Add("Lable51");
            dt.Columns.Add("Lable61");
            dt.Columns.Add("Lable71");
            dt.Columns.Add("Lable12");
            dt.Columns.Add("Lable22");
            dt.Columns.Add("Lable32");
            dt.Columns.Add("Lable42");
            dt.Columns.Add("Lable52");
            dt.Columns.Add("Lable62");
            dt.Columns.Add("Lable72");
            this.reportViewer.LocalReport.DataSources.Clear();
            DataTable _DataSet = new DataTable();
            ReportDataSource RDS;
            ReportPath = "Labely.Print.RDLC.24Lable.rdlc";

            int Id = _ListOfGD.Count();
            DataTable GDdt = ToDataTable<GroupDetail>(_ListOfGD);

            LablePrint[] arr = new LablePrint[Id];
            int cou = 0;
            foreach (DataRow item in GDdt.Rows)
            {
                for (int i = 0; i < 1; i++)
                {

                    string L1 = ListOfGridSC.Where(w => w.No == 1 && w.IsDisplay == true).Select(s => s.Column).FirstOrDefault();
                    string L2 = ListOfGridSC.Where(w => w.No == 2 && w.IsDisplay == true).Select(s => s.Column).FirstOrDefault();
                    string L3 = ListOfGridSC.Where(w => w.No == 3 && w.IsDisplay == true).Select(s => s.Column).FirstOrDefault();
                    string L4 = ListOfGridSC.Where(w => w.No == 4 && w.IsDisplay == true).Select(s => s.Column).FirstOrDefault();
                    string L5 = ListOfGridSC.Where(w => w.No == 5 && w.IsDisplay == true).Select(s => s.Column).FirstOrDefault();
                    string L6 = ListOfGridSC.Where(w => w.No == 6 && w.IsDisplay == true).Select(s => s.Column).FirstOrDefault();
                    string L7 = ListOfGridSC.Where(w => w.No == 7 && w.IsDisplay == true).Select(s => s.Column).FirstOrDefault();
                    arr[cou] = new LablePrint(string.IsNullOrEmpty(L1) ? "" : item[L1].ToString(), string.IsNullOrEmpty(L2) ? "" : item[L2].ToString(), string.IsNullOrEmpty(L3) ? "" : item[L3].ToString(), string.IsNullOrEmpty(L4) ? "" : item[L4].ToString(), string.IsNullOrEmpty(L5) ? "" : item[L5].ToString(), string.IsNullOrEmpty(L6) ? "" : item[L6].ToString(), string.IsNullOrEmpty(L7) ? "" : item[L7].ToString(), "", "");
                    //arr[cou] = new LablePrint(item.Lable1, item.Lable2, item.Lable3, item.Lable4, item.Lable5, item.Lable6);
                    cou++;
                }
            }
            for (int i = 0; i < arr.Length; i = i + 3)
            {
                DataRow dr = dt.NewRow();
                dr["Lable1"] = arr[i].Lable1;
                dr["Lable2"] = arr[i].Lable2;
                dr["Lable3"] = arr[i].Lable3;
                dr["Lable4"] = arr[i].Lable4;
                dr["Lable5"] = arr[i].Lable5;
                dr["Lable6"] = arr[i].Lable6;
                dr["Lable7"] = arr[i].Lable7;
                if ((i + 1) < arr.Length)
                {
                    dr["Lable11"] = arr[i + 1].Lable1;
                    dr["Lable21"] = arr[i + 1].Lable2;
                    dr["Lable31"] = arr[i + 1].Lable3;
                    dr["Lable41"] = arr[i + 1].Lable4;
                    dr["Lable51"] = arr[i + 1].Lable5;
                    dr["Lable61"] = arr[i + 1].Lable6;
                    dr["Lable71"] = arr[i + 1].Lable7;
                }
                if ((i + 2) < arr.Length)
                {
                    dr["Lable12"] = arr[i + 2].Lable1;
                    dr["Lable22"] = arr[i + 2].Lable2;
                    dr["Lable32"] = arr[i + 2].Lable3;
                    dr["Lable42"] = arr[i + 2].Lable4;
                    dr["Lable52"] = arr[i + 2].Lable5;
                    dr["Lable62"] = arr[i + 2].Lable6;
                    dr["Lable72"] = arr[i + 2].Lable7;
                }
                dt.Rows.Add(dr);
            }
            ReportParameter[] parms = new ReportParameter[4];

            parms[0] = new ReportParameter("TextAlign", TA);
            parms[1] = new ReportParameter("FontStyle", FS);
            parms[2] = new ReportParameter("FontWeight", FW);
            parms[3] = new ReportParameter("Font", font);
            RDS = new ReportDataSource("Lable24Dataset", dt);
            this.reportViewer.LocalReport.ReportEmbeddedResource = ReportPath;
            reportViewer.LocalReport.SetParameters(parms);
            this.reportViewer.ProcessingMode = ProcessingMode.Local;
            this.reportViewer.LocalReport.DataSources.Add(RDS);
            this.reportViewer.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            this.reportViewer.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;
            this.reportViewer.ZoomPercent = 100;
            this.reportViewer.RefreshReport();
        }
        void FillLable24One()
        {
            string ReportPath = null;
            DataTable dt = new DataTable();
            dt.Columns.Add("Lable1");
            dt.Columns.Add("Lable2");
            dt.Columns.Add("Lable3");
            dt.Columns.Add("Lable4");
            dt.Columns.Add("Lable5");
            dt.Columns.Add("Lable6");
            dt.Columns.Add("Lable7");
            dt.Columns.Add("Lable11");
            dt.Columns.Add("Lable21");
            dt.Columns.Add("Lable31");
            dt.Columns.Add("Lable41");
            dt.Columns.Add("Lable51");
            dt.Columns.Add("Lable61");
            dt.Columns.Add("Lable71");
            dt.Columns.Add("Lable12");
            dt.Columns.Add("Lable22");
            dt.Columns.Add("Lable32");
            dt.Columns.Add("Lable42");
            dt.Columns.Add("Lable52");
            dt.Columns.Add("Lable62");
            dt.Columns.Add("Lable72");
            this.reportViewer.LocalReport.DataSources.Clear();
            DataTable _DataSet = new DataTable();
            ReportDataSource RDS;
            ReportPath = "Labely.Print.RDLC.24Lable.rdlc";

            ObservableCollection<GroupDetail> _listOfGd = new ObservableCollection<GroupDetail>();
            for (int i = 1; i <= Convert.ToInt32(NoOfLabel); i++)
            {
                _listOfGd.Add(_GroupDetail);
            }

            int Id = _listOfGd.Count();
            DataTable GDdt = ToDataTable<GroupDetail>(_listOfGd);

            LablePrint[] arr = new LablePrint[Id];
            int cou = 0;
            foreach (DataRow item in GDdt.Rows)
            {
                for (int i = 0; i < 1; i++)
                {
                    string L1 = ListOfGridSC.Where(w => w.No == 1 && w.IsDisplay == true).Select(s => s.Column).FirstOrDefault();
                    string L2 = ListOfGridSC.Where(w => w.No == 2 && w.IsDisplay == true).Select(s => s.Column).FirstOrDefault();
                    string L3 = ListOfGridSC.Where(w => w.No == 3 && w.IsDisplay == true).Select(s => s.Column).FirstOrDefault();
                    string L4 = ListOfGridSC.Where(w => w.No == 4 && w.IsDisplay == true).Select(s => s.Column).FirstOrDefault();
                    string L5 = ListOfGridSC.Where(w => w.No == 5 && w.IsDisplay == true).Select(s => s.Column).FirstOrDefault();
                    string L6 = ListOfGridSC.Where(w => w.No == 6 && w.IsDisplay == true).Select(s => s.Column).FirstOrDefault();
                    string L7 = ListOfGridSC.Where(w => w.No == 7 && w.IsDisplay == true).Select(s => s.Column).FirstOrDefault();
                    arr[cou] = new LablePrint(string.IsNullOrEmpty(L1) ? "" : item[L1].ToString(), string.IsNullOrEmpty(L2) ? "" : item[L2].ToString(), string.IsNullOrEmpty(L3) ? "" : item[L3].ToString(), string.IsNullOrEmpty(L4) ? "" : item[L4].ToString(), string.IsNullOrEmpty(L5) ? "" : item[L5].ToString(), string.IsNullOrEmpty(L6) ? "" : item[L6].ToString(), string.IsNullOrEmpty(L7) ? "" : item[L7].ToString(), "", "");
                    //arr[cou] = new LablePrint(item.Lable1, item.Lable2, item.Lable3, item.Lable4, item.Lable5, item.Lable6);
                    cou++;
                }
            }
            for (int i = 0; i < arr.Length; i = i + 3)
            {
                DataRow dr = dt.NewRow();
                dr["Lable1"] = arr[i].Lable1;
                dr["Lable2"] = arr[i].Lable2;
                dr["Lable3"] = arr[i].Lable3;
                dr["Lable4"] = arr[i].Lable4;
                dr["Lable5"] = arr[i].Lable5;
                dr["Lable6"] = arr[i].Lable6;
                dr["Lable7"] = arr[i].Lable7;
                if ((i + 1) < arr.Length)
                {
                    dr["Lable11"] = arr[i + 1].Lable1;
                    dr["Lable21"] = arr[i + 1].Lable2;
                    dr["Lable31"] = arr[i + 1].Lable3;
                    dr["Lable41"] = arr[i + 1].Lable4;
                    dr["Lable51"] = arr[i + 1].Lable5;
                    dr["Lable61"] = arr[i + 1].Lable6;
                    dr["Lable71"] = arr[i + 1].Lable7;
                }
                if ((i + 2) < arr.Length)
                {
                    dr["Lable12"] = arr[i + 1].Lable1;
                    dr["Lable22"] = arr[i + 1].Lable2;
                    dr["Lable32"] = arr[i + 1].Lable3;
                    dr["Lable42"] = arr[i + 1].Lable4;
                    dr["Lable52"] = arr[i + 1].Lable5;
                    dr["Lable62"] = arr[i + 1].Lable6;
                    dr["Lable72"] = arr[i + 1].Lable7;
                }
                dt.Rows.Add(dr);
            }
            ReportParameter[] parms = new ReportParameter[4];

            parms[0] = new ReportParameter("TextAlign", TA);
            parms[1] = new ReportParameter("FontStyle", FS);
            parms[2] = new ReportParameter("FontWeight", FW);
            parms[3] = new ReportParameter("Font", font);
            RDS = new ReportDataSource("Lable24Dataset", dt);
            this.reportViewer.LocalReport.ReportEmbeddedResource = ReportPath;
            reportViewer.LocalReport.SetParameters(parms);
            this.reportViewer.ProcessingMode = ProcessingMode.Local;
            this.reportViewer.LocalReport.DataSources.Add(RDS);
            this.reportViewer.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            this.reportViewer.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;
            this.reportViewer.ZoomPercent = 100;
            this.reportViewer.RefreshReport();
        }
        #endregion

        #region Lable18
        void FillLable18()
        {
            string ReportPath = null;
            DataTable dt = new DataTable();
            dt.Columns.Add("Lable1");
            dt.Columns.Add("Lable2");
            dt.Columns.Add("Lable3");
            dt.Columns.Add("Lable4");
            dt.Columns.Add("Lable5");
            dt.Columns.Add("Lable6");
            dt.Columns.Add("Lable7");
            dt.Columns.Add("Lable8");
            dt.Columns.Add("Lable9");
            dt.Columns.Add("Lable11");
            dt.Columns.Add("Lable21");
            dt.Columns.Add("Lable31");
            dt.Columns.Add("Lable41");
            dt.Columns.Add("Lable51");
            dt.Columns.Add("Lable61");
            dt.Columns.Add("Lable71");
            dt.Columns.Add("Lable81");
            dt.Columns.Add("Lable91");
            dt.Columns.Add("Lable12");
            dt.Columns.Add("Lable22");
            dt.Columns.Add("Lable32");
            dt.Columns.Add("Lable42");
            dt.Columns.Add("Lable52");
            dt.Columns.Add("Lable62");
            dt.Columns.Add("Lable72");
            dt.Columns.Add("Lable82");
            dt.Columns.Add("Lable92");
            this.reportViewer.LocalReport.DataSources.Clear();
            DataTable _DataSet = new DataTable();
            ReportDataSource RDS;
            ReportPath = "Labely.Print.RDLC.18Lable.rdlc";

            int Id = _ListOfGD.Count();
            DataTable GDdt = ToDataTable<GroupDetail>(_ListOfGD);

            LablePrint[] arr = new LablePrint[Id];
            int cou = 0;
            foreach (DataRow item in GDdt.Rows)
            {
                for (int i = 0; i < 1; i++)
                {

                    string L1 = ListOfGridSC.Where(w => w.No == 1 && w.IsDisplay == true).Select(s => s.Column).FirstOrDefault();
                    string L2 = ListOfGridSC.Where(w => w.No == 2 && w.IsDisplay == true).Select(s => s.Column).FirstOrDefault();
                    string L3 = ListOfGridSC.Where(w => w.No == 3 && w.IsDisplay == true).Select(s => s.Column).FirstOrDefault();
                    string L4 = ListOfGridSC.Where(w => w.No == 4 && w.IsDisplay == true).Select(s => s.Column).FirstOrDefault();
                    string L5 = ListOfGridSC.Where(w => w.No == 5 && w.IsDisplay == true).Select(s => s.Column).FirstOrDefault();
                    string L6 = ListOfGridSC.Where(w => w.No == 6 && w.IsDisplay == true).Select(s => s.Column).FirstOrDefault();
                    string L7 = ListOfGridSC.Where(w => w.No == 7 && w.IsDisplay == true).Select(s => s.Column).FirstOrDefault();
                    string L8 = ListOfGridSC.Where(w => w.No == 8 && w.IsDisplay == true).Select(s => s.Column).FirstOrDefault();
                    string L9 = ListOfGridSC.Where(w => w.No == 9 && w.IsDisplay == true).Select(s => s.Column).FirstOrDefault();
                    arr[cou] = new LablePrint(string.IsNullOrEmpty(L1) ? "" : item[L1].ToString(), string.IsNullOrEmpty(L2) ? "" : item[L2].ToString(), string.IsNullOrEmpty(L3) ? "" : item[L3].ToString(), string.IsNullOrEmpty(L4) ? "" : item[L4].ToString(), string.IsNullOrEmpty(L5) ? "" : item[L5].ToString(), string.IsNullOrEmpty(L6) ? "" : item[L6].ToString(), string.IsNullOrEmpty(L7) ? "" : item[L7].ToString(), string.IsNullOrEmpty(L8) ? "" : item[L8].ToString(), string.IsNullOrEmpty(L9) ? "" : item[L9].ToString());
                    //arr[cou] = new LablePrint(item.Lable1, item.Lable2, item.Lable3, item.Lable4, item.Lable5, item.Lable6);
                    cou++;
                }
            }
            for (int i = 0; i < arr.Length; i = i + 3)
            {
                DataRow dr = dt.NewRow();
                dr["Lable1"] = arr[i].Lable1;
                dr["Lable2"] = arr[i].Lable2;
                dr["Lable3"] = arr[i].Lable3;
                dr["Lable4"] = arr[i].Lable4;
                dr["Lable5"] = arr[i].Lable5;
                dr["Lable6"] = arr[i].Lable6;
                dr["Lable7"] = arr[i].Lable7;
                dr["Lable8"] = arr[i].Lable8;
                dr["Lable9"] = arr[i].Lable9;
                if ((i + 1) < arr.Length)
                {
                    dr["Lable11"] = arr[i + 1].Lable1;
                    dr["Lable21"] = arr[i + 1].Lable2;
                    dr["Lable31"] = arr[i + 1].Lable3;
                    dr["Lable41"] = arr[i + 1].Lable4;
                    dr["Lable51"] = arr[i + 1].Lable5;
                    dr["Lable61"] = arr[i + 1].Lable6;
                    dr["Lable71"] = arr[i + 1].Lable7;
                    dr["Lable81"] = arr[i + 1].Lable8;
                    dr["Lable91"] = arr[i + 1].Lable9;
                }
                if ((i + 2) < arr.Length)
                {
                    dr["Lable12"] = arr[i + 2].Lable1;
                    dr["Lable22"] = arr[i + 2].Lable2;
                    dr["Lable32"] = arr[i + 2].Lable3;
                    dr["Lable42"] = arr[i + 2].Lable4;
                    dr["Lable52"] = arr[i + 2].Lable5;
                    dr["Lable62"] = arr[i + 2].Lable6;
                    dr["Lable72"] = arr[i + 2].Lable7;
                    dr["Lable82"] = arr[i + 2].Lable8;
                    dr["Lable92"] = arr[i + 2].Lable9;
                }
                dt.Rows.Add(dr);
            }
            ReportParameter[] parms = new ReportParameter[4];

            parms[0] = new ReportParameter("TextAlign", TA);
            parms[1] = new ReportParameter("FontStyle", FS);
            parms[2] = new ReportParameter("FontWeight", FW);
            parms[3] = new ReportParameter("Font", font);
            RDS = new ReportDataSource("Lable18Dataset", dt);
            this.reportViewer.LocalReport.ReportEmbeddedResource = ReportPath;
            reportViewer.LocalReport.SetParameters(parms);
            this.reportViewer.ProcessingMode = ProcessingMode.Local;
            this.reportViewer.LocalReport.DataSources.Add(RDS);
            this.reportViewer.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            this.reportViewer.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;
            this.reportViewer.ZoomPercent = 100;
            this.reportViewer.RefreshReport();
        }
        void FillLable18One()
        {
            string ReportPath = null;
            DataTable dt = new DataTable();
            dt.Columns.Add("Lable1");
            dt.Columns.Add("Lable2");
            dt.Columns.Add("Lable3");
            dt.Columns.Add("Lable4");
            dt.Columns.Add("Lable5");
            dt.Columns.Add("Lable6");
            dt.Columns.Add("Lable7");
            dt.Columns.Add("Lable8");
            dt.Columns.Add("Lable9");
            dt.Columns.Add("Lable11");
            dt.Columns.Add("Lable21");
            dt.Columns.Add("Lable31");
            dt.Columns.Add("Lable41");
            dt.Columns.Add("Lable51");
            dt.Columns.Add("Lable61");
            dt.Columns.Add("Lable71");
            dt.Columns.Add("Lable81");
            dt.Columns.Add("Lable91");
            dt.Columns.Add("Lable12");
            dt.Columns.Add("Lable22");
            dt.Columns.Add("Lable32");
            dt.Columns.Add("Lable42");
            dt.Columns.Add("Lable52");
            dt.Columns.Add("Lable62");
            dt.Columns.Add("Lable72");
            dt.Columns.Add("Lable82");
            dt.Columns.Add("Lable92");
            this.reportViewer.LocalReport.DataSources.Clear();
            DataTable _DataSet = new DataTable();
            ReportDataSource RDS;
            ReportPath = "Labely.Print.RDLC.18Lable.rdlc";

            ObservableCollection<GroupDetail> _listOfGd = new ObservableCollection<GroupDetail>();
            for (int i = 1; i <= Convert.ToInt32(NoOfLabel); i++)
            {
                _listOfGd.Add(_GroupDetail);
            }

            int Id = _listOfGd.Count();
            DataTable GDdt = ToDataTable<GroupDetail>(_listOfGd);

            LablePrint[] arr = new LablePrint[Id];
            int cou = 0;
            foreach (DataRow item in GDdt.Rows)
            {
                for (int i = 0; i < 1; i++)
                {
                    string L1 = ListOfGridSC.Where(w => w.No == 1 && w.IsDisplay == true).Select(s => s.Column).FirstOrDefault();
                    string L2 = ListOfGridSC.Where(w => w.No == 2 && w.IsDisplay == true).Select(s => s.Column).FirstOrDefault();
                    string L3 = ListOfGridSC.Where(w => w.No == 3 && w.IsDisplay == true).Select(s => s.Column).FirstOrDefault();
                    string L4 = ListOfGridSC.Where(w => w.No == 4 && w.IsDisplay == true).Select(s => s.Column).FirstOrDefault();
                    string L5 = ListOfGridSC.Where(w => w.No == 5 && w.IsDisplay == true).Select(s => s.Column).FirstOrDefault();
                    string L6 = ListOfGridSC.Where(w => w.No == 6 && w.IsDisplay == true).Select(s => s.Column).FirstOrDefault();
                    string L7 = ListOfGridSC.Where(w => w.No == 7 && w.IsDisplay == true).Select(s => s.Column).FirstOrDefault();
                    string L8 = ListOfGridSC.Where(w => w.No == 8 && w.IsDisplay == true).Select(s => s.Column).FirstOrDefault();
                    string L9 = ListOfGridSC.Where(w => w.No == 9 && w.IsDisplay == true).Select(s => s.Column).FirstOrDefault();
                    arr[cou] = new LablePrint(string.IsNullOrEmpty(L1) ? "" : item[L1].ToString(), string.IsNullOrEmpty(L2) ? "" : item[L2].ToString(), string.IsNullOrEmpty(L3) ? "" : item[L3].ToString(), string.IsNullOrEmpty(L4) ? "" : item[L4].ToString(), string.IsNullOrEmpty(L5) ? "" : item[L5].ToString(), string.IsNullOrEmpty(L6) ? "" : item[L6].ToString(), string.IsNullOrEmpty(L7) ? "" : item[L7].ToString(), string.IsNullOrEmpty(L8) ? "" : item[L8].ToString(), string.IsNullOrEmpty(L9) ? "" : item[L9].ToString());
                    //arr[cou] = new LablePrint(item.Lable1, item.Lable2, item.Lable3, item.Lable4, item.Lable5, item.Lable6);
                    cou++;
                }
            }
            for (int i = 0; i < arr.Length; i = i + 3)
            {
                DataRow dr = dt.NewRow();
                dr["Lable1"] = arr[i].Lable1;
                dr["Lable2"] = arr[i].Lable2;
                dr["Lable3"] = arr[i].Lable3;
                dr["Lable4"] = arr[i].Lable4;
                dr["Lable5"] = arr[i].Lable5;
                dr["Lable6"] = arr[i].Lable6;
                dr["Lable7"] = arr[i].Lable7;
                dr["Lable8"] = arr[i].Lable8;
                dr["Lable9"] = arr[i].Lable9;
                if ((i + 1) < arr.Length)
                {
                    dr["Lable11"] = arr[i + 1].Lable1;
                    dr["Lable21"] = arr[i + 1].Lable2;
                    dr["Lable31"] = arr[i + 1].Lable3;
                    dr["Lable41"] = arr[i + 1].Lable4;
                    dr["Lable51"] = arr[i + 1].Lable5;
                    dr["Lable61"] = arr[i + 1].Lable6;
                    dr["Lable71"] = arr[i + 1].Lable7;
                    dr["Lable81"] = arr[i + 1].Lable8;
                    dr["Lable91"] = arr[i + 1].Lable9;
                }
                if ((i + 2) < arr.Length)
                {
                    dr["Lable12"] = arr[i + 2].Lable1;
                    dr["Lable22"] = arr[i + 2].Lable2;
                    dr["Lable32"] = arr[i + 2].Lable3;
                    dr["Lable42"] = arr[i + 2].Lable4;
                    dr["Lable52"] = arr[i + 2].Lable5;
                    dr["Lable62"] = arr[i + 2].Lable6;
                    dr["Lable72"] = arr[i + 2].Lable7;
                    dr["Lable82"] = arr[i + 2].Lable8;
                    dr["Lable92"] = arr[i + 2].Lable9;
                }
                dt.Rows.Add(dr);
            }
            ReportParameter[] parms = new ReportParameter[4];

            parms[0] = new ReportParameter("TextAlign", TA);
            parms[1] = new ReportParameter("FontStyle", FS);
            parms[2] = new ReportParameter("FontWeight", FW);
            parms[3] = new ReportParameter("Font", font);
            RDS = new ReportDataSource("Lable18Dataset", dt);
            this.reportViewer.LocalReport.ReportEmbeddedResource = ReportPath;
            reportViewer.LocalReport.SetParameters(parms);
            this.reportViewer.ProcessingMode = ProcessingMode.Local;
            this.reportViewer.LocalReport.DataSources.Add(RDS);
            this.reportViewer.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            this.reportViewer.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;
            this.reportViewer.ZoomPercent = 100;
            this.reportViewer.RefreshReport();
        }
        #endregion


        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DemoItemsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        public static DataTable ToDataTable<T>(ObservableCollection<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }
    }
}

public class LablePrint
{

    public LablePrint(string l1, string l2, string l3, string l4, string l5, string l6, string l7, string l8, string l9)
    {
        Lable1 = l1;
        Lable2 = l2;
        Lable3 = l3;
        Lable4 = l4;
        Lable5 = l5;
        Lable6 = l6;
        Lable7 = l7;
        Lable8 = l8;
        Lable9 = l9;
    }
    public string Lable1 { get; set; }
    public string Lable2 { get; set; }
    public string Lable3 { get; set; }
    public string Lable4 { get; set; }
    public string Lable5 { get; set; }
    public string Lable6 { get; set; }
    public string Lable7 { get; set; }
    public string Lable8 { get; set; }
    public string Lable9 { get; set; }
}