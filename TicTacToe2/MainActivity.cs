using System;
using System.Net.WebSockets;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Principal;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Telephony;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using Java.Lang;

namespace TicTacToe2
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private bool player1_turn;
        private Button[,] game_array;
        private TextView txt;
        private bool winflag;
        private Button reset;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            player1_turn = true;
            game_array = new Button[3, 3];

            txt = FindViewById<TextView>(Resource.Id.txt);

            winflag = false;

            game_array[0, 0] = FindViewById<Button>(Resource.Id.button00);
            game_array[0, 1] = FindViewById<Button>(Resource.Id.button01);
            game_array[0, 2] = FindViewById<Button>(Resource.Id.button02);
            game_array[1, 0] = FindViewById<Button>(Resource.Id.button10);
            game_array[1, 1] = FindViewById<Button>(Resource.Id.button11);
            game_array[1, 2] = FindViewById<Button>(Resource.Id.button12);
            game_array[2, 0] = FindViewById<Button>(Resource.Id.button20);
            game_array[2, 1] = FindViewById<Button>(Resource.Id.button21);
            game_array[2, 2] = FindViewById<Button>(Resource.Id.button22);

            reset = FindViewById<Button>(Resource.Id.reset);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        [Java.Interop.Export("Onclick")]
        public void Onclick(View v)
        {
            Button b = (Button)v;
            if (b.Text == "NAMES")
            {
                Intent intent = new Intent(this, typeof(PlayerNameInputActivity));
                base.StartActivity(intent);
            }
            if (b.Text == "Clear")
            {
                TicTacToeGameplay.ClearDeck(game_array, winflag, txt);
                winflag = false;
                player1_turn = true;
                reset.Visibility = ViewStates.Invisible;
            }
            if (!winflag)
            {
                if (b.Text != "")
                    return;
                if (this.player1_turn)
                {
                    b.Text = "X";
                    this.player1_turn = false;
                }
                else
                {
                    b.Text = "O";
                    this.player1_turn = true;
                }

                switch (TicTacToeGameplay.CheckForWin(game_array))
                {
                    case "":
                        return;
                    case "X":
                        txt.Text = Names.GetX() + " won";
                        winflag = true;
                        reset.Visibility = ViewStates.Visible;
                        break;
                    case "O":
                        txt.Text = Names.GetO() + " won";
                        winflag = true;
                        reset.Visibility = ViewStates.Visible;
                        break;
                    case "finish_game":
                        txt.Text = "Draw";
                        reset.Visibility = ViewStates.Visible;
                        break;
                }
            } 
 
            
        }
       
    }
}

