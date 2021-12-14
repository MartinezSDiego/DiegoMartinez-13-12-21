using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TasksList.Database;
using TasksList.Models;
using TasksList.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TasksList.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TasksPage : ContentPage
    {
        public TasksPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (BindingContext is TasksViewModel viewModel)
            {
                DatabaseTasks database = await DatabaseTasks.Instance;
                viewModel.TaskList = new ObservableCollection<TaskItem>(await database.GetTaskItemsAsync());
            }
        }

        private async void PlusIconClicked(object sender, System.EventArgs e)
        {
            await OpenTaskItemPage(new TaskItem());
        }

        private async void TaskItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item is TaskItem item)
            {
                await OpenTaskItemPage(item);
            }
        }

        private async Task OpenTaskItemPage(TaskItem item)
        {
            ListTasks.SelectedItem = null;
            await Navigation.PushAsync(new TaskItemPage
            {
                BindingContext = item
            });
        }
    }
}