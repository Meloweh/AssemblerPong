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
    class MainHandler
    {
        //Textdarstellung für Punktestand
        SpriteFont font;

        //Punktestand von Spieler und vom Bot
        int playerScore1;
        int playerScore2;

        
        Player player;
        NPC bot;
        Ball ball;

        //Startknopf
        Button btnStart;

        bool gameStarted;
        bool resetToggled;

        public MainHandler()
        { 
            //instanziiere Objekte
            btnStart = new Button("Start", 150, 50, 0, new Vector2(GlobalParam.GetScreenWidth / 2 - 75f, GlobalParam.GetScreenHeight / 2 - 25f));
            player = new Player();
            bot = new NPC();
            ball = new Ball();
        }

        public void Init()
        {
            //initialisiere Startwerte der Objekte
            gameStarted = false;
            resetToggled = false;

            playerScore1 = 0;
            playerScore2 = 0;

            player.Init();

            bot.Init();

            ball.Init();
        }

        public void LoadContent(ContentManager Content)
        {
            //lade Texturen
            font = Content.Load<SpriteFont>("spritefont");

            btnStart.LoadContent(Content);

            player.LoadContent(Content);
            bot.LoadContent(Content);
            ball.LoadContent(Content);
        }

        public void UnloadContent()
        {
            //loese Speicher von externen Resourcen
            player.UnloadContent();
            bot.UnloadContent();
            ball.UnloadContent();
        }

        public void Update(GameTime gameTime)
        {
            // initialisiere erneut die Startwerte mit der "R" Taste fuer einen Reset
            if (Keyboard.GetState().IsKeyDown(Keys.R))
                resetToggled = true;
            else if (resetToggled)
                Init();

            if (!gameStarted)
            {
                if (btnStart.isPressed())
                {
                    Init();
                    gameStarted = true;
                }

                //lasse Funktion hier enden wenn keine Runde am Laufen ist
                return;
            }

            // Spielerposition Y bekommt die Mausposition Y
            player.Update();

            // wenn der Ball keine konstante Position hat, koennen wir sie besser debuggen
            ball.Update();

            // richte Botposition in Richtung des Balles
            bot.Update(ball.getCenterPosY());

            // pruefe Feldgrenze fuer ein Tor, wird aber durch den Assemblercode ueberschrieben
            if (ball.Position.X <= 0)
            {
                playerScore2++;
                ball.Init();
            }

            if (ball.Position.X >= GlobalParam.GetScreenWidth - 25f)
            {
                ball.Init();
                playerScore1++;
            }

            //pruefe ob ein Spieler gewonnen hat
            if(playerScore1 == 10 || playerScore2 == 10)
            {
                gameStarted = false;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //zeichne Knopf und Autornamen, wenn die Runde noch nicht gestartet ist
            if (!gameStarted)
            {
                btnStart.Draw(spriteBatch);
                spriteBatch.DrawString(font, "Von Steven Kovacs", new Vector2(GlobalParam.GetScreenWidth / 2 - 80f, GlobalParam.GetScreenHeight - 50f), Color.Black, 0f, new Vector2(0, 0), 0.8f, SpriteEffects.None, 0f);
            }
            else
            {
                // zeichne Objekte
                ball.Draw(spriteBatch);
                player.Draw(spriteBatch);
                bot.Draw(spriteBatch);
            }
           
            //Zeichne Punktestand oder Sieg
            if(playerScore1 < 10)
                spriteBatch.DrawString(font, "Spieler 1 Punkte: " + playerScore1, new Vector2(50, 0), Color.Black, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 0f);
            else
                spriteBatch.DrawString(font, "Spieler 1 hat gewonnen!", new Vector2(50, 0), Color.Black, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 0f);

            if(playerScore2 < 10)
                spriteBatch.DrawString(font, "Spieler 2 Punkte: " + playerScore2, new Vector2(GlobalParam.GetScreenWidth - 250f, 0), Color.Black, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 0f);
            else
                spriteBatch.DrawString(font, "Spieler 2 hat gewonnen!", new Vector2(GlobalParam.GetScreenWidth - 250f, 0f), Color.Black, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 0f);
        }
    }
}
