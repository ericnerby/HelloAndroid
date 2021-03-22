using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Android.Widget;
using System;
using System.Collections.Generic;

namespace HelloAndroid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        static readonly List<string> phoneNumbers = new List<string>();
        EditText phoneNumberText;
        TextView translatedPhoneword;
        Button translateButton;
        Button translationHistoryButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            phoneNumberText = FindViewById<EditText>(Resource.Id.PhoneNumberText);
            translatedPhoneword = FindViewById<TextView>(Resource.Id.TranslatedPhoneword);
            translateButton = FindViewById<Button>(Resource.Id.TranslateButton);

            translateButton.Click += OnTranslateButtonClick;
            translationHistoryButton = FindViewById<Button>(Resource.Id.TranslationHistoryButton);

            translationHistoryButton.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(TranslationHistoryActivity));
                intent.PutStringArrayListExtra("phone_numbers", phoneNumbers);
                StartActivity(intent);
            };
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
                phoneNumbers.Add(translatedNumber);
                translationHistoryButton.Enabled = true;
            }
        }
    }
}