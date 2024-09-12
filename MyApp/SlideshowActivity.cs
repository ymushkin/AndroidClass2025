using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyApp
{
    [Activity(Label = "SlideshowActivity")]
    public class SlideshowActivity : Activity
    {
        int currentIndex = 1;
        ImageView imageView;
        Button btnPrevious, btnNext, btnBack;
        int imageCount = 0;
        TextView txtImageNumber;

        Android.Graphics.Color enabledColor = Android.Graphics.Color.LightBlue;
        Android.Graphics.Color disabledColor = Android.Graphics.Color.LightGray;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_slideshow);

            imageView = FindViewById<ImageView>(Resource.Id.imageView);
            btnPrevious = FindViewById<Button>(Resource.Id.btnPrevious);
            txtImageNumber = FindViewById<TextView>(Resource.Id.txtImageNumber);
            btnNext = FindViewById<Button>(Resource.Id.btnNext);
            btnBack = FindViewById<Button>(Resource.Id.btnBack);
            btnBack.Click += BtnBack_Click;
            
            imageCount = Intent.GetIntExtra("imageCount", 0);
            UpdateImage();

            btnPrevious.Click += BtnPrevious_Click;
            btnNext.Click += BtnNext_Click;

        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            currentIndex++;
            UpdateImage();
        }

        private void BtnPrevious_Click(object sender, EventArgs e)
        {
            currentIndex--;
            UpdateImage();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            Finish();
        }

        void UpdateImage()
        {
            int resourceId = Resources.GetIdentifier($"image{currentIndex}", "drawable", PackageName);
            imageView.SetImageResource(resourceId);

            btnPrevious.Enabled = currentIndex > 1;
            btnNext.Enabled = currentIndex < imageCount;

            if (btnPrevious.Enabled)
                btnPrevious.SetBackgroundColor(enabledColor);
            else
                btnPrevious.SetBackgroundColor(disabledColor);

            if (btnNext.Enabled)
                btnNext.SetBackgroundColor(enabledColor);
            else
                btnNext.SetBackgroundColor(disabledColor);

            txtImageNumber.Text = $"Image {currentIndex}/{imageCount}";
        }
    }
}