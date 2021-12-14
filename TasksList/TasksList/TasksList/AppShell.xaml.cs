using TasksList.Views;
using Xamarin.Forms;

namespace TasksList
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(TaskItemPage), typeof(TaskItemPage));
        }
    }
}
