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
using RaysHotDog.Core.Model;
using RaysHotDog.Core.Service;
using RaysHotDogsAndro.Utility;

namespace RaysHotDogsAndro
{
    [Activity(Label = "Hot Dog Detail", MainLauncher =true)]
    public class HotDogDetailActivity : Activity
    {
        private ImageView hotDogIV;
        private TextView hotDogNameTV;
        private TextView shortDescTV;
        private TextView descTV;
        private TextView priceTV;
        private EditText amountET;
        private Button cancelBut;
        private Button orderBut;

        private HotDog selectedHotDog;
        private HotDogDataService dataService;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.HotDogDetailView);

            HotDogDataService dataService = new HotDogDataService();
            selectedHotDog = dataService.GetHotDogByID(1);

            FindViews();
            BindData();
            HandleEvents();
            // Create your application here
        }

        private void FindViews()
        {
            hotDogIV = FindViewById<ImageView>(Resource.Id.HotDogImageview);
            hotDogNameTV = FindViewById<TextView>(Resource.Id.HotDogNameTV);
            shortDescTV = FindViewById<TextView>(Resource.Id.ShortDescTV);
            descTV = FindViewById<TextView>(Resource.Id.DescTV);
            priceTV = FindViewById<TextView>(Resource.Id.PriceTV);
            amountET = FindViewById<EditText>(Resource.Id.amountET);
            cancelBut = FindViewById<Button>(Resource.Id.cancelButton);
            orderBut = FindViewById<Button>(Resource.Id.orderButton);

        }


        private void BindData()
        {
            hotDogNameTV.Text = selectedHotDog.Name;
            shortDescTV.Text = selectedHotDog.ShortDescription;
            descTV.Text = selectedHotDog.Description;
            priceTV.Text = "Price: " + selectedHotDog.Price;

            var imageBitmap = ImageHelper.GetImageBitmapFromUrl("http://gillcleerenpluralsight.blob.core.windows.net/files/" + selectedHotDog.ImagePath + ".jpg");
            hotDogIV.SetImageBitmap(imageBitmap);
        }

        private void HandleEvents()
        {
            orderBut.Click += OrderButton_Click;
            cancelBut.Click += CancelButton_Click;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OrderButton_Click(object sender, EventArgs e)
        {
            var amount = Int32.Parse(amountET.Text);

            var dialog = new AlertDialog.Builder(this);
            dialog.SetTitle("Confirmation");
            dialog.SetMessage("Your Hotdog added to cart!");
            dialog.Show();
        }

        
    }
}