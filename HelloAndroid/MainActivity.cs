using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Android.Widget;
using System;

namespace HelloAndroid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        EditText phoneNumberText;
        TextView translatedPhoneword;
        Button translateButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            phoneNumberText = FindViewById<EditText>(Resource.Id.PhoneNumberText);
            translatedPhoneword = FindViewById<TextView>(Resource.Id.TranslatedPhoneword);
            translateButton = FindViewById<Button>(Resource.Id.TranslateButton);

            translateButton.Click += OnTranslateButtonClick;
        }

        private void OnTranslateButtonClick(object sender, EventArgs e)
        {
            string translatedNumber = Core.PhonewordTranslator.ToNumber(phoneNumberText.Text);
            if (string.IsNullOrWhiteSpace(translatedNumber))
            {
                translatedPhoneword.Text = string.Empty;
            }
            else
            {
                translatedPhoneword.Text = translatedNumber;
            }
        }
    }
}