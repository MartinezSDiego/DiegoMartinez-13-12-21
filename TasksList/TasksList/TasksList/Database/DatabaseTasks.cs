using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using TasksList.Models;

namespace TasksList.Database
{
    public class DatabaseTasks
    {
        private static SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<DatabaseTasks> Instance = new AsyncLazy<DatabaseTasks>(async () =>
        {
            Database = new SQLiteAsyncConnection(DatabaseConfiguration.DatabasePath, DatabaseConfiguration.Flags);
            _ = await Database.CreateTableAsync<TaskItem>();
            DatabaseTasks instance = new DatabaseTasks();
            return instance;
        });

        private DatabaseTasks() { }

        public Task<List<TaskItem>> GetTaskItemsAsync()
        {
            return Database.Table<TaskItem>().ToListAsync();
        }

        public Task<int> SaveItemAsync(TaskItem taskItem)
        {
            return taskItem.Id != 0 ? Database.UpdateAsync(taskItem) : Database.InsertAsync(taskItem);
        }

        public Task<int> DeleteItemAsync(TaskItem item)
        {
            return Database.DeleteAsync(item);
        }
    }
}
