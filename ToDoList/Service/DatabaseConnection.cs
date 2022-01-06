using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Resources;
using Xamarin.Essentials;

namespace ToDoList.Service
{
    public static class DatabaseConnection
    {
        static SQLiteAsyncConnection db;
        static async Task Init()
        {
            if (db != null)
            {
                return;
            }

            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "TasksData.db");
            db = new SQLiteAsyncConnection(databasePath);

            await db.CreateTableAsync<Resources.TaskModel>();
        }

        public static async Task AddTask(TaskModel t)
        {
            await Init();
            await db.InsertAsync(t);
        }

        public static async Task UpdateTask(TaskModel t)
        {
            await Init();
            await db.UpdateAsync(t);
        }

        public static async Task DeleteTask(TaskModel t)
        {
            await Init();
            await db.DeleteAsync(t);
        }
        public static async Task DeleteAllTask(TaskModel t)
        {
            await Init();
            await db.DeleteAllAsync<TaskModel>();
        }

        public static async Task<List<TaskModel>> GetTasks()
        {
            await Init();
            return await db.Table<TaskModel>().ToListAsync();
        }
    }
}
