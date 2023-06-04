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
    class Ball
    {
        Vector2 position;
        Rectangle rectangle;
        Texture2D texture;
        float scale;

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public Ball() 
        { }

        public void Init() 
        {
            scale = 1f;
            position = new Vector2(GlobalParam.GetScreenWidth / 2 - 25f, GlobalParam.GetScreenHeight / 2 - 25f);
        }

        public void LoadContent(ContentManager Content)
        {
            texture = Content.Load<Texture2D>("ball");
            rectangle = new Rectangle(0, 0, texture.Width, texture.Height);
            position = new Vector2(GlobalParam.GetScreenWidth / 2 - rectangle.Width / 2, GlobalParam.GetScreenHeight / 2 - rectangle.Height / 2);
        }

        public void UnloadContent() { }

        public void Update()
        {
            //Ballbewegung um das Debuggen zu erleichtern
            position.X -= 3f;
            position.Y -= 2f;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, rectangle, Color.Black, 0f, new Vector2(0, 0), scale, SpriteEffects.None, 0);
        }

        public float getCenterPosY()
        {
            if (rectangle == null)
                return -1f;

            return position.Y - rectangle.Height;
        }
    }
}
