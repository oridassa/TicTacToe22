using System;
using System.Net.WebSockets;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Principal;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace TicTacToe2
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private bool player1_turn;
        private Button[,] game_array;
        private string[,] game_array_txt;
        private TextView txt;
        private bool winflag;
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

            game_array_txt = new string[3, 3]; //game layout as the button's Text attribute
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
            if (b.Text == "Clear")
            {
                ClearDeck();
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


                if (CheckForWin() == "")
                {
                    return;
                }
                else
                {
                    txt.Text = "" + CheckForWin() + " won";
                    winflag = true;
                }
            }

            
        }
        private string CheckForWin()
        {

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++) 
                    game_array_txt[i, j] = game_array[i, j].Text;

            for (int i = 0; i < 3; i++) //check the columbs
            {
                if (game_array_txt[i, 0].Equals(game_array_txt[i, 1])
                    && game_array_txt[i, 0].Equals(game_array_txt[i, 2])
                    && !game_array_txt[i, 0].Equals(""))
                    return game_array_txt[i, 0];
            }
            for (int i = 0; i < 3; i++) //check the rows
            {
                if (game_array_txt[0, i].Equals(game_array_txt[1, i])
                    && game_array_txt[0, i].Equals(game_array_txt[2, i])
                    && !game_array_txt[0, i].Equals(""))
                    return game_array_txt[0, i];
            }
            if (game_array_txt[0, 0].Equals(game_array_txt[1, 1]) //check diagnal 1
                    && game_array_txt[0, 0].Equals(game_array_txt[2, 2])
                    && !game_array_txt[0, 0].Equals(""))
                return game_array_txt[0, 0];

            if (game_array_txt[0, 2].Equals(game_array_txt[1, 1]) //check diagnal 2
                    && game_array_txt[0, 2].Equals(game_array_txt[2, 0])
                    && !game_array_txt[0, 2].Equals(""))
                return game_array_txt[0, 2];

            return "";
        }
        private void ClearDeck()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    game_array[i, j].Text = "";
            this.winflag = false;
            this.txt.Text = "tic tac toe";
        }
    }
}