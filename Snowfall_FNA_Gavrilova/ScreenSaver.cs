using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Snowfall_FNA_Gavrilova
{
    public class ScreenSaver : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private Texture2D snowflakeTexture;
        private Texture2D backgroundTexture;
        private List<SnowflakeParameters> snowflakes;

        private Random rnd = new Random();
        private const int HeightWindows = 720;
        private const int WidthWindows = 1280;

        /// <summary>
        /// Конструктор класса ScreenSaver.
        /// </summary>
        public ScreenSaver()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferHeight = HeightWindows;
            graphics.PreferredBackBufferWidth = WidthWindows;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();
        }

        /// <summary>
        /// Загружает содержимое папки "Content".
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            snowflakeTexture = TextureLoader.Load("snowflake", Content);
            backgroundTexture = TextureLoader.Load("background", Content);
            snowflakes = new List<SnowflakeParameters>();

            for (var i = 0; i < 250; i++)
            {
                var size = (float)rnd.Next(10, 35) / 100;
                var speed = (float)rnd.NextDouble() * 50f + 20f;
                var startPosition = new Vector2(rnd.Next(0, WidthWindows), rnd.Next(0, HeightWindows));

                speed *= size * 10;

                snowflakes.Add(new SnowflakeParameters(snowflakeTexture, startPosition, speed, size));
            }
        }

        /// <summary>
        /// Обновляет состояние скринсейвера.
        /// </summary>
        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            foreach (var snowflake in snowflakes)
            {
                snowflake.SnowfallPosition(gameTime);

                if (snowflake.PositionSnowflake.Y > HeightWindows)
                {
                    snowflake.ResetSnowfallPosition(new Vector2(rnd.Next(0, WidthWindows), -50));
                }
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// Отображает графическое содержимое.
        /// </summary>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            spriteBatch.Draw(backgroundTexture, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);

            foreach (var snowflake in snowflakes)
            {
                snowflake.SnowfallDraw(spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

