using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
                Name = "asasdasdasdasdsad",
                Check = true
            },
             new TaskModel
            {
                Name = "asd",
                Check = true
            },
              new TaskModel
            {
                Name = "asd",
                Check = true
            },
               new TaskModel
            {
                Name = "asd",
                Check = true
            }
        };
        public ObservableCollection<TaskModel> taskList { get; set; }
        public static int NumberOfTasks { get; set; }
        public MainPage()
        {

            InitializeComponent();

            Task.Run(async () =>
            {
                taskList = new ObservableCollection<TaskModel>(await Service.DatabaseConnection.GetTasks());
            }).Wait();

            BindingContext = this;
        }




        protected async override void OnAppearing()
        {
            base.OnAppearing();
            taskList = new ObservableCollection<TaskModel>(await Service.DatabaseConnection.GetTasks());
            ToDoList.ItemsSource = taskList;
        }

        private async void ToDoList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var task = e.CurrentSelection.FirstOrDefault() as TaskModel;

            if (task == null)
                return;

            await Navigation.PushAsync(new TaskDetailPage { BindingContext = task });

            ((CollectionView)sender).SelectedItem = null;
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TaskDetailPage(new TaskModel()));
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Service.DatabaseConnection.DeleteAllTask(BindingContext as TaskModel);
            taskList = new ObservableCollection<TaskModel>(await Service.DatabaseConnection.GetTasks());
            ToDoList.ItemsSource = taskList;
        }

        private async void myRefreshView_Refreshing(object sender, EventArgs e)
        {
            await Task.Delay(500);
            myRefreshView.IsRefreshing = false;
            OnAppearing();
        }
    }
}
