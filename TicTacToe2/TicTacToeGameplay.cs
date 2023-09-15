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
using AndroidX.AppCompat.App;

namespace TicTacToe2
{
    public class TicTacToeGameplay : AppCompatActivity
    {
        public TicTacToeGameplay()
        {
        }
        public string CheckForWin(Button[,] game_array)
        {
            string[,] game_array_txt = new string[3, 3];
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
        public void ClearDeck(Button[,] game_array, bool winflag, TextView txt)
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    game_array[i, j].Text = "";
            winflag = false;
            txt.Text = "tic tac toe";
        }
    }
}