using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace MyApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        EditText imageCount;
        Button btnGallery, btnSlideshow;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            imageCount = FindViewById<EditText>(Resource.Id.imageCount);
            btnGallery = FindViewById<Button>(Resource.Id.btnGallery);
            btnSlideshow = FindViewById<Button>(Resource.Id.btnSlideshow);

            btnGallery.Click += BtnGallery_Click;
            btnSlideshow.Click += BtnSlideshow_Click;
        }

        private void BtnSlideshow_Click(object sender, System.EventArgs e)
        {
            int count = string.IsNullOrEmpty(imageCount.Text) ? 9 : int.Parse(imageCount.Text);
            Intent intent = new Intent(this, typeof(SlideshowActivity));
            intent.PutExtra("imageCount", count);
            StartActivity(intent);
        }

        private void BtnGallery_Click(object sender, System.EventArgs e)
        {
            int count = string.IsNullOrEmpty(imageCount.Text) ? 9 : int.Parse(imageCount.Text);
            Intent intent = new Intent(this, typeof(GalleryActivity));
            intent.PutExtra("imageCount", count);
            StartActivity(intent);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}