using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoList
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TaskDetailPage : ContentPage
    {
        public TaskDetailPage()
        {
            InitializeComponent();
        }

        public int counter=0;

        public TaskDetailPage(Resources.TaskModel task)
        {
            InitializeComponent();

            BindingContext = task;
        }

        private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Service.DatabaseConnection.AddTask(BindingContext as TaskModel);
            await Navigation.PopAsync();

        }
    }
}