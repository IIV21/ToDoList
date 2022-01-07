using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ToDoList.Resources
{
    public class TaskModel
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime Date { get; set; } 

        public double Days { get; set; }

        public bool Check { get; set; }

        public string Details { get; set; }
    }
}
