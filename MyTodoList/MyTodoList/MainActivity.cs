using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using TodoList;
using TodoList.Resources;

namespace MyTodoList
{
    [Activity(Label = "MyTodoList", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : ListActivity
    {

        public static ObservableCollection<Person> myList = new ObservableCollection<Person>
            {
                new Person { Name = "Item1", DetailInformation = "SomeInformation1"},
                new Person { Name = "Item2", DetailInformation = "SomeInformation2"},
                new Person { Name = "Item3", DetailInformation = "SomeInformation3"},
            };

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            for (int i = 0; i < myList.Count; i++)
            {
                myList[i].Id = i;
            }


            ListAdapter = new MyAdapter(this, myList);
        }

        public const string TEXT_KEY = "TEXT_KEY";

        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            Intent intent = new Intent(this, typeof(DetailActivity));

            intent.PutExtra(TEXT_KEY, myList[position].Id.ToString());
            StartActivity(intent);
        }
    }
}

