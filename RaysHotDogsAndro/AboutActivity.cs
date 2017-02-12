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

namespace RaysHotDogsAndro
{

    [Activity(Label = "About Rays Hot Dog")]
    public class AboutActivity : Activity
    {
        private TextView phoneNumberTV;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.AboutView);
            // Create your application here
            FindViews();
            HandleEvents();
        }

        private void FindViews()
        {
            phoneNumberTV = FindViewById<TextView>(Resource.Id.phoneNumberTV);

        }

        private void HandleEvents()
        {
            phoneNumberTV.Click += PhoneNumberTV_Click;
        }

        private void PhoneNumberTV_Click(object sender, EventArgs e)
        {
            var intent = new Intent(Intent.ActionCall);
            intent.SetData(Android.Net.Uri.Parse("tel:" + phoneNumberTV.Text));
            StartActivity(intent);  
            //throw new NotImplementedException();
        }
    }
}