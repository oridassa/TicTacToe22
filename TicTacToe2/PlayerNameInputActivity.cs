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

namespace TicTacToe2
{
    [Activity(Label = "PlayerNameInputActivity")]
    public class PlayerNameInputActivity : Activity
    {
        private Button button;
        private EditText xname;
        private EditText oname;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.PlayerNameInput);

            button = FindViewById<Button>(Resource.Id.button);
            xname = FindViewById<EditText>(Resource.Id.Xname);
            oname = FindViewById<EditText>(Resource.Id.Oname);
        }
        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
        }
        [Java.Interop.Export("Onclick")]
        public void Onclick(View v)
        {
            Names.SetX(xname.Text);
            Names.SetO(oname.Text);
            Intent intent = new Intent(this, typeof(MainActivity));
            base.StartActivity(intent);
        }
    }
}