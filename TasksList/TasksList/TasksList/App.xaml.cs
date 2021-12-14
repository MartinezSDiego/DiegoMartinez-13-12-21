using TasksList.Database;
using Xamarin.Forms;

namespace TasksList
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }
    }
}
