using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace RealmExample
{
	public partial class TasksPage : ContentPage
	{
		public TaskViewModel Vm { get; private set;} = new TaskViewModel ();

		public TasksPage ()
		{
			InitializeComponent ();
			Title = "List View Example";

			taskListView.ItemTapped += (s, e) => {
				var task = taskListView.SelectedItem as Task;
				task.Done = !task.Done;
				task.Update ();
			};

			addTaskButton.Clicked += (sender, e) => {
				var title = titleTextBox.Text;
				if (string.IsNullOrEmpty (title)) return;
				Vm.AddTasks (new Task { Title = title });
				titleTextBox.Text = string.Empty;
			};

			clearTaskButton.Clicked += (sender, e) => {
				taskListView.SelectedItem = null;
				var done = Vm.Tasks.Where (x => x.Done);
				for (int i = 0; i < done.Count() ; i++) {
					Vm.Tasks.Remove (done.ElementAt(i));
				}
			};

			BindingContext = Vm;
		}
	}
}

