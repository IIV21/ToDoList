using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Resources;
using Xamarin.Forms;

namespace ToDoList
{


    public partial class MainPage : ContentPage
    {
        public List<TaskModel> taskModels { get; set; } = new List<TaskModel>
        {
            new TaskModel
            { 
                Name = "asd",
                Date = "29.01.2019",
                Days = 23,
                Check = true
            },
             new TaskModel
            {
                Name = "asd",
                Date = "29.01.2019",
                Days = 23,
                Check = true
            },
              new TaskModel
            {
                Name = "asd",
                Date = "29.01.2019",
                Days = 23,
                Check = true
            },
               new TaskModel
            {
                Name = "asd",
                Date = "29.01.2019",
                Days = 23,
                Check = true
            }
        };
        public string Name { get; set; }
        public MainPage()
        {

            InitializeComponent();
            BindingContext = this;
        }

        private void ToDoList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var task = e.CurrentSelection.FirstOrDefault() as TaskModel;
            Navigation.PushAsync(new TaskDetailPage(task));
        }
    }
}
