using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snowfall_FNA_Gavrilova
{
    internal class SnowflakeParameters
    {
        public Vector2 PositionSnowflake { get; private set; }
        private readonly float snowfallRate;
        private readonly float snowflakeSize
;
        private readonly Texture2D texture;
        private Random rnd = new Random();

        /// <summary>
        /// Инициализирует новый экземпляр SnowflakeParameters.
        /// </summary>
        public SnowflakeParameters(Texture2D texture, Vector2 startPosition, float snowfallRate, float snowflakeSize)
        {
            this.texture = texture;
            PositionSnowflake = startPosition;
            this.snowfallRate = snowfallRate;
            this.snowflakeSize = snowflakeSize;

            PositionSnowflake += new Vector2((float)rnd.Next(-5, 6), (float)rnd.Next(-5, 6));
        }

        /// <summary>
        /// Обновляет позицию снежинки в соответствии со временем игры.
        /// </summary>
        public void SnowfallPosition(GameTime gameTime)
        {
            float fallSpeed = snowfallRate * (snowflakeSize / 2);
            PositionSnowflake = new Vector2(PositionSnowflake.X, PositionSnowflake.Y + fallSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds);
        }

        /// <summary>
        /// Сбрасывает позицию снежинки до заданной новой позиции.
        /// </summary>
        public void ResetSnowfallPosition(Vector2 newPosition)
        {
            PositionSnowflake = newPosition + new Vector2((float)rnd.Next(-5, 6), (float)rnd.Next(-5, 6));
        }

        /// <summary>
        /// Рисует снежинку на экране с использованием SpriteBatch.
        /// </summary>
        public void SnowfallDraw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, PositionSnowflake, null, Color.White, 0f, Vector2.Zero, snowflakeSize, SpriteEffects.None, 0f);
        }
    }
}
