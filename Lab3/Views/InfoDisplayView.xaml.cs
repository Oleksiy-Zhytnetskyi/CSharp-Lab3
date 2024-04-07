using KMA.CSharp2024.Lab3.ViewModels;
using System.Windows.Controls;

namespace KMA.CSharp2024.Lab3.Views
{
    /// <summary>
    /// Interaction logic for InfoDisplayView.xaml
    /// </summary>
    public partial class InfoDisplayView : UserControl
    {
        public InfoDisplayView(InfoDisplayViewModel viewModel)
        {
            InitializeComponent();

            DataContext = viewModel;
        }
    }
}
