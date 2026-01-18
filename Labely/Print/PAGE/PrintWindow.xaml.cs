using PageRepeate;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    public partial class PrintWindow : Window
    {
        //public A4PageUC reportpage = new A4PageUC();
        int PageHalf = 0;
        public PrintWindow(ObservableCollection<Object> _ListOfData)
        {
            InitializeComponent();
            ItemsSource = _ListOfData;
            GeneratePages();
            CreatePrintReport();
        }
        private void GeneratePages()
        {
            if (ItemsSource != null)
            {
                if (ItemsSource.Count != 0)
                {
                    PageCount = (int)Math.Ceiling(ItemsSource.Count / (double)ItemsPerPage);
                    PageHalf = PageCount / 2;
                    Pages = new ObservableCollection<ObservableCollection<Object>>();
                    for (int i = 0; i < PageCount; i++)
                    {
                        ObservableCollection<Object> page = new ObservableCollection<Object>();
                        for (int j = 0; j < ItemsPerPage; j++)
                        {
                            if (i * ItemsPerPage + j > ItemsSource.Count - 1) break;
                            page.Add(ItemsSource[i * ItemsPerPage + j]);
                        }
                        Pages.Add(page);
                    }
                    //CurrentPage = Pages[0];
                    //CurrentPageNumber = 1;
                }
            }
        }

        private int PageCount;
        private int _CurrentPageNumber;
        private ObservableCollection<ObservableCollection<Object>> Pages;
        private ObservableCollection<Object> _ItemsSource;
        private ObservableCollection<Object> _CurrentPage;
        public ObservableCollection<Object> CurrentPage
        {
            get { return _CurrentPage; }
            set
            {
                _CurrentPage = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("CurrentPage"));
            }
        }
        public ObservableCollection<Object> ItemsSource
        {
            get { return _ItemsSource; }
            set
            {
                _ItemsSource = value;
                GeneratePages();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public int ItemsPerPage
        {
            get { return (int)GetValue(ItemsPerPageProperty); }
            set { SetValue(ItemsPerPageProperty, value); }
        }
        public static readonly DependencyProperty ItemsPerPageProperty =
            DependencyProperty.Register("ItemsPerPage", typeof(int), typeof(MainWindow), new UIPropertyMetadata(24));

        public void CreatePrintReport()
        {
            FixedDocument fixedDoc = new FixedDocument();
            for (int i = 0; i < Pages.Count; i++)
            {
                Size size;
                PageContent pageContent = new PageContent();
                FixedPage fixedPage = new FixedPage();
                size = new Size(8.27 * 96.0, 11.69 * 96.0);
                fixedPage.Width = 8.27 * 96.0;
                fixedPage.Height = 11.69 * 96.0;
                fixedPage.Measure(size);
                //A4PageUC reportpage = new A4PageUC();
                Lable24 reportpage = new Lable24();
                reportpage.self.ItemsSource = Pages[i];
                reportpage.txtPageNo.Text = "Page : " + (i + 1).ToString();
                fixedPage.Children.Add(reportpage);
                ((System.Windows.Markup.IAddChild)pageContent).AddChild(fixedPage);
                fixedDoc.Pages.Add(pageContent);
            }
            documentViewer1.Document = fixedDoc;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
