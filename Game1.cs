using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Die_Class__MonoGame
{

    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        KeyboardState keyboardState, prevKeboardState;

        List<Texture2D> dieTextures;

        List<Die>dice;

        Die die1;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            dieTextures = new List<Texture2D>();

            dice = new List<Die>();
            for(int i = 0; i < 6; i++)
            {
                dice.Add(new Die (dieTextures, new Rectangle(100, i * 75 + 10, 75, 75)));
            }


            die1 = new Die(dieTextures, new Rectangle(10, 10, 75, 75));


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);


            for(int i = 1; i <= 6; i++)
            {
                dieTextures.Add(Content.Load<Texture2D>("Images/white_die_" + i));
            }


            // TODO: use this.Content to load your game content here


        }

        protected override void Update(GameTime gameTime)
        {
            prevKeboardState = keyboardState;
            keyboardState = Keyboard.GetState();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if(keyboardState.IsKeyDown(Keys.Space) && prevKeboardState.IsKeyUp(Keys.Space))
            {
                
                foreach(Die die in dice)
                {
                    die.RollDie();
                }
                
                die1.RollDie();

            }

 
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            die1.DrawRoll(_spriteBatch);

            foreach(Die die in dice)
            {
                die.DrawRoll(_spriteBatch);
            }


            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
