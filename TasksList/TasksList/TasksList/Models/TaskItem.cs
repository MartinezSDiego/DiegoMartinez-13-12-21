using SQLite;
using TasksList.ViewModels;

namespace TasksList.Models
{
    public class TaskItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Description { get; set; }
        public bool Done { get; set; }
    }
}
