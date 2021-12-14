using System.Collections.ObjectModel;
using TasksList.Models;

namespace TasksList.ViewModels
{
    public class TasksViewModel : BaseViewModel
    {
        private ObservableCollection<TaskItem> taskList = new ObservableCollection<TaskItem>();
        public ObservableCollection<TaskItem> TaskList
        {
            get => taskList;
            set { taskList = value; NotifyPropertyChanged(); }
        }

        public TasksViewModel() { }
    }
}
