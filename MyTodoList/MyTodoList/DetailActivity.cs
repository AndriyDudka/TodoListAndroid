using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MyTodoList;

namespace TodoList
{
    [Activity(Label = "DetailActivity")]
    public class DetailActivity : Activity
    {

        public int id;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Detail);

            TextView textView = FindViewById<TextView>(Resource.Id.TextInformation);

            id = Convert.ToInt32(Intent.GetStringExtra(MainActivity.TEXT_KEY));
            textView.Text = MainActivity.myList[id].DetailInformation;

            var buttonCreate = FindViewById<Button>(Resource.Id.CreateNew);
            buttonCreate.Click += CreateButton;

            var buttonUpdate = FindViewById<Button>(Resource.Id.Update);
            buttonUpdate.Click += UpdateButton;

            var buttonDelete = FindViewById<Button>(Resource.Id.Delete);
            buttonDelete.Click += DeleteButton;

        }

        public void CreateButton(object sender, EventArgs args)
        {
            
        }

        public void UpdateButton(object sender, EventArgs args)
        {

        }

        public void DeleteButton(object sender, EventArgs args)
        {
            MainActivity.myList.RemoveAt(id);
            Intent intent = new Intent(this, typeof(MainActivity));       
            StartActivity(intent);
        }
    }
}