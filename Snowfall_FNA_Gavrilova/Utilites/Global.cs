using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Snowfall_FNA_Gavrilova;

namespace FNAClassCode
{
    static class Snowfall_FNA_Gavrilova
    {
        public static ScreenSaver game;
        public static Random random = new Random();
        public static string levelName;

        public static void Initialize(ScreenSaver inputGame)
        {
            game = inputGame;
        }
    }
}
