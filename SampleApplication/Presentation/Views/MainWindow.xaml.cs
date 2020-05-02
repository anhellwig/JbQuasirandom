using SampleApplication.Applications.Views;
using System.ComponentModel.Composition;
using System.Windows;

namespace SampleApplication.Presentation.Views
{
    [Export(typeof(IMainView))]
    public partial class MainWindow : Window, IMainView
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
