using System.Windows;
using Mm.Client.Infrastructure;

namespace Mm.Client
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Loaded += (sender, args) => (DataContext as IInitializable)?.Initialize();
        }
    }
}
