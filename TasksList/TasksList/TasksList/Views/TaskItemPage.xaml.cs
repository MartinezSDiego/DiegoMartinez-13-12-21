using TasksList.Database;
using TasksList.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TasksList.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TaskItemPage : ContentPage
    {
        public TaskItemPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (BindingContext is TaskItem item && item.Id == 0)
            {
                ButtonDelete.IsEnabled = false;
            }
        }

        private async void SaveClicked(object sender, System.EventArgs e)
        {
            if (BindingContext is TaskItem item)
            {
                if (string.IsNullOrEmpty(item.Description) || string.IsNullOrWhiteSpace(item.Description))
                {
                    _ = DisplayAlert("Description", "Please fill the description", "Ok");
                    return;
                }
                DatabaseTasks database = await DatabaseTasks.Instance;
                await database.SaveItemAsync(item);
                await Navigation.PopAsync();
            }
        }

        private async void Deletelicked(object sender, System.EventArgs e)
        {
            if (BindingContext is TaskItem item)
            {
                DatabaseTasks database = await DatabaseTasks.Instance;
                await database.DeleteItemAsync(item);
                await Navigation.PopAsync();
            }
        }
    }
}