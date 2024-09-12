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
    [Activity(Label = "GalleryActivity")]
    public class GalleryActivity : Activity
    {
        Button btnBack;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_gallery);

            btnBack = FindViewById<Button>(Resource.Id.btnBack);
            btnBack.Click += BtnBack_Click;

            int imageCount = Intent.GetIntExtra("imageCount", 0);
            LinearLayout galleryLayout = FindViewById<LinearLayout>(Resource.Id.galleryLayout);

            // קביעת מספר התמונות בכל שורה
            int imagesPerRow = 3;
            int totalRows = (int)Java.Lang.Math.Ceil(imageCount / (float)imagesPerRow);

            for (int row = 0; row < totalRows; row++)
            {
                // יצירת LinearLayout אופקי עבור השורה הנוכחית
                LinearLayout rowLayout = new LinearLayout(this)
                {
                    Orientation = Orientation.Horizontal
                };
                rowLayout.LayoutParameters = new LinearLayout.LayoutParams(
                    LinearLayout.LayoutParams.MatchParent,
                    LinearLayout.LayoutParams.WrapContent);

                // הוספת התמונות לשורה
                for (int col = 0; col < imagesPerRow; col++)
                {
                    int imageIndex = row * imagesPerRow + col;
                    if (imageIndex >= imageCount) break;

                    ImageView imageView = new ImageView(this);
                    int resourceId = Resources.GetIdentifier($"image{row * imagesPerRow + col + 1}", "drawable", PackageName);
                    imageView.SetImageResource(resourceId);

                    // חישוב גודל התמונה כך שתתאים לרוחב המסך
                    int screenWidth = Resources.DisplayMetrics.WidthPixels;
                    int imageSize = screenWidth / imagesPerRow - 16; // הפרדה בין תמונות

                    LinearLayout.LayoutParams layoutParams = new LinearLayout.LayoutParams(imageSize, imageSize);
                    layoutParams.SetMargins(8, 8, 8, 8);
                    imageView.LayoutParameters = layoutParams;

                    // הוספת ImageView לשורה
                    rowLayout.AddView(imageView);
                }

                // הוספת השורה לגלריה
                galleryLayout.AddView(rowLayout);
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            Finish();
        }
    }
}