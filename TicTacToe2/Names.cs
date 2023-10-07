using Android.App;
using Android.Content;
using Android.Hardware.Camera2;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace TicTacToe2
{
    public static class Names
    {
        private static string xname = "X";
        private static string oname = "O";
        private static int xscore = 0;
        private static int oscore = 0;
        public static void SetX(string x)
        {
            xname = x;
        }
        public static void SetO(string x)
        {
            oname = x;
        }
        public static string GetX()
        {
            return xname;
        }
        public static string GetO()
        {
            return oname;
        }
        public static void incrementx()
        {
            xscore++;
        }
        public static void incremento()
        {
            oscore++;
        }
        public static int get_o_score()
        {
            return oscore;
        }
        public static int get_x_score()
        {
            return xscore;
        }
    }
}