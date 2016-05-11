using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Realms;

namespace RealmExample
{
	public class Task : INotifyPropertyChanged
	{
		public string Guid { set; get; } = System.Guid.NewGuid ().ToString ("N");
		public string Title { set; get; }
		public bool Done { set; get; } = false;
		public DateTime CreatedDate { set; get; } = DateTime.Now;
		public string Description => $"{CreatedDate}";
		public string Display => $"{!Done ? "▢" : "☑"} {Title}";
		 
		public event PropertyChangedEventHandler PropertyChanged;

		public void Update ()
		{
			if (PropertyChanged == null) return;
			PropertyChanged (this, new PropertyChangedEventArgs ("Display"));
		}
	}

	public class TaskViewModel
	{
		public ObservableCollection<Task> Tasks { set; get; } = new ObservableCollection<Task> ();
		public string Intro => "Intro";
		public string Summary => "Summary";

		public void AddTasks (Task task)
		{
			Tasks.Add (task);
		}
	}
}

