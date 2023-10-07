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
        private EditText xname, oname;
        private TextView xscore, oscore;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.PlayerNameInput);

            button = FindViewById<Button>(Resource.Id.button);
            xname = FindViewById<EditText>(Resource.Id.Xname);
            oname = FindViewById<EditText>(Resource.Id.Oname);
            xscore = FindViewById<TextView>(Resource.Id.xscore);
            oscore = FindViewById<TextView>(Resource.Id.oscore);
            xscore.Text = $"{Names.GetX()} score is: {Names.get_x_score()}";
            oscore.Text = $"{Names.GetO()} score is: {Names.get_o_score()}";
        }
        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            xscore.Text = $"{Names.GetX()} score is: {Names.get_x_score()}";
            oscore.Text = $"{Names.GetO()} score is: {Names.get_o_score()}";
        }
        [Java.Interop.Export("Onclick")]
        public void Onclick(View v)
        {
            if (xname.Text != "")
                Names.SetX(xname.Text);
            
            if (oname.Text != "")
                Names.SetO(oname.Text);
            Intent intent = new Intent(this, typeof(MainActivity));
            base.StartActivity(intent);
        }
    }
}