using KMA.CSharp2024.Lab3.ViewModels;
using System.Windows.Controls;

namespace KMA.CSharp2024.Lab3.Views
{
    /// <summary>
    /// Interaction logic for LandingView.xaml
    /// </summary>
    public partial class LandingView : UserControl
    {
        public LandingView(LandingViewModel viewModel)
        {
            InitializeComponent();

            DataContext = viewModel;
        }

        private void DpOnSelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataContext is LandingViewModel viewModel)
            {
                viewModel.BirthDate = (sender as DatePicker)?.SelectedDate ?? default;
            }
        }
    }
}
