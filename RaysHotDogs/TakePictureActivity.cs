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
using Java.IO;
using Android.Provider;
using Android.Graphics;
using RaysHotDogs.Utility;

namespace RaysHotDogs
{
    [Activity(Label = "TakePictureActivity")]
    public class TakePictureActivity : Activity
    {
        private ImageView rayPictureImageView;
        private Button takePictureButton;
        private Button shareButton;
        private File imageDirectory;
        private File imageFile;
        private Bitmap imageBitmap;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.TakePictureView);
            FindViews();
            HandleEvents();
            imageDirectory = new File(Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDcim), "RaysHotDogs");
            string s = imageDirectory.ToString();
            if(!imageDirectory.Exists())
            {
                imageDirectory.Mkdirs();
            }
            // Create your application here
        }

        private void FindViews()
        {
            rayPictureImageView = FindViewById<ImageView>(Resource.Id.rayPictureImageview);
            takePictureButton = FindViewById<Button>(Resource.Id.takePictureButton);
            shareButton = FindViewById<Button>(Resource.Id.shareButton);

        }

        private void HandleEvents()
        {
            takePictureButton.Click += TakePictureButton_Click;
           
            shareButton.Click += ShareButton_Click; //delegate for share button
            
        }
        

        //share button
        private void ShareButton_Click(object sender, EventArgs e)
        {
            if (imageBitmap != null)
            {
                var imageUri = Android.Net.Uri.Parse($"file://{imageFile}");
                Intent sharingIntent = new Intent(Android.Content.Intent.ActionSend);
                sharingIntent.SetType("image/jpeg");
                //string shareBodyText = "Text to share.";
                sharingIntent.PutExtra(Android.Content.Intent.ExtraSubject, "Subject");
                sharingIntent.PutExtra(Android.Content.Intent.ExtraStream, imageUri);
                sharingIntent.AddFlags(ActivityFlags.GrantReadUriPermission);
                StartActivity(Intent.CreateChooser(sharingIntent, "sharing Options"));
                imageBitmap = null;    //freeing the variable imageBitmap after sharing
            }

            else
            {
                var dialog = new AlertDialog.Builder(this);
                dialog.SetTitle("Error!");
                dialog.SetMessage("Please taek a picture first!");
                dialog.Show();
            }

            //throw new NotImplementedException();
        }
        
        private void TakePictureButton_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            imageFile = new File(imageDirectory, String.Format("PhotoWithRay_{0}.jpg", Guid.NewGuid()));
            //string s = imageFile.ToString();
            intent.PutExtra(MediaStore.ExtraOutput, Android.Net.Uri.FromFile(imageFile));
            StartActivityForResult(intent, 0);
              
            //throw new NotImplementedException();
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            int height = rayPictureImageView.Height;
            int width = rayPictureImageView.Width;
            imageBitmap = ImageHelper.GetImageBitmapFromFilePath(imageFile.Path, width, height);
            if(imageBitmap!=null)
            {
                rayPictureImageView.SetImageBitmap(imageBitmap);
                //imageBitmap = null;
            }

            GC.Collect();
            //base.OnActivityResult(requestCode, resultCode, data);
        }
    }
}