using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TasksList.Views.Templates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TaskTemplate : ContentView
    {
        public TaskTemplate()
        {
            InitializeComponent();
        }
    }
}