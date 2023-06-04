using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Microsoft.Xna.Framework.Content;

namespace PongGame.PongGame
{
    class NPC
    {
        Vector2 position;
        Texture2D texture;
        float scale;
        Color color;
        Rectangle rectangle;

        public NPC()
        { 

        }

        public void Init()
        {
            scale = 1f;
            color = Color.DarkOrange;
        }

        public void LoadContent(ContentManager Content)
        {
            texture = Content.Load<Texture2D>("player");
            rectangle = new Rectangle(0, 0, texture.Width, texture.Height);
            position = new Vector2(GlobalParam.GetScreenWidth - rectangle.Width * 2, GlobalParam.GetScreenHeight / 2 - rectangle.Height / 2);
        }

        public void UnloadContent()
        {

        }

        public void Update(float posY)
        {
            //naehere Ball an
            if(posY - rectangle.Width / 2 -22f < position.Y)
            {
                position.Y -= 4f;
            }
            
            if (posY - rectangle.Width / 2 - 28f > position.Y)
            {
                position.Y += 4f;
            }

            //pruefe Bildschirmraender
            if (position.Y + rectangle.Height > GlobalParam.GetScreenHeight)
                position.Y = GlobalParam.GetScreenHeight - rectangle.Height;

            if (position.Y < 0)
                position.Y = 0f;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, rectangle, color, 0f, new Vector2(0, 0), scale, SpriteEffects.None, 0);
        }
    }
}
