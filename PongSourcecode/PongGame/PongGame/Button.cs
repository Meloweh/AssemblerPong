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
    class Button
    {
        Texture2D texButton;
        Rectangle rect;
        Vector2 position;

        MouseState mouse;

        int frameW,
            frameH,
            frame;

        SpriteFont font;

        String str_buttonText = "test";

        //bestimme Knopftext, Knopfgroesse, Knopfanimationsindex und Position
        public Button(String text, int width, int height, int frame, Vector2 pos)
        {
            this.frameW = width;
            this.frameH = height;
            this.frame = frame;
            this.position = pos;
            rect = new Rectangle(0, 0, frameW, frameH);
            this.str_buttonText = text;
        }

        public void LoadContent(ContentManager Content)
        {
            texButton = Content.Load<Texture2D>("button");
            font = Content.Load<SpriteFont>("spritefont");
        }

        public bool isPressed()
        {
            mouse = Mouse.GetState();

            //Wenn eben die Mausklickframe da war und die Maus nicht mehr klickt, dann erkenne als Knopfdruck
            if (frame == 2 && mouse.LeftButton != ButtonState.Pressed)
            {
                frame = 0;
                return true;
            }

            // pruefe ob sich der Mauszeiger innerhalb der Knopfposition befindet
            if (mouse.X > position.X &&
               mouse.X < position.X + frameW &&
               mouse.Y > position.Y &&
               mouse.Y < position.Y + frameH)
            {
                //setze naechste Textur
                frame = 1;

                //setze naechste Textur bei Knopfdruck
                if (mouse.LeftButton == ButtonState.Pressed)
                {
                    frame = 2;
                }
            }
            else
            {
                //setze Standardtextur
                frame = 0;
            }

            //alle Knopftexturen sind in der selben Datei. Deshalb bilden wir ein Rechteck um den Texturberech, welchen wir anzeigen lassen wollen
            rect = new Rectangle(frame * frameW, 0, frameW, frameH);

            return false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texButton, position, rect, Color.White, 0, new Vector2(0, 0), 1f, SpriteEffects.None, 1);
            spriteBatch.DrawString(font, str_buttonText, new Vector2(position.X + 20, position.Y - 4), Color.White, 0, new Vector2(0, 0), 2, SpriteEffects.None, 0);
        }
    }
}
