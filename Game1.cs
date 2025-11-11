using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Die_Class;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    KeyboardState keyboardState, prevKeyboardState;
    MouseState mouseState, prevMouseState;

    List<Texture2D> dieTextures;

    Die die1;

    List<Die> dice;

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

        die1 = new Die(dieTextures, new Rectangle(10, 10, 75, 75));

        for(int i = 0; i < 6; i++)
        {
            dice.Add(new Die(dieTextures, new Rectangle(100, i * 75, 75, 75)));
        }
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here

        for (int i = 1; i <= 6; i++)
        {
            dieTextures.Add(Content.Load<Texture2D>("white_die_" + i));
        }
    }

    protected override void Update(GameTime gameTime)
    {
        prevMouseState = mouseState;
        mouseState = Mouse.GetState();

        prevKeyboardState = keyboardState;
        keyboardState = Keyboard.GetState();

        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();


        if(keyboardState.IsKeyDown(Keys.Space) && prevKeyboardState.IsKeyUp(Keys.Space))
        {
            foreach(Die die in dice)
            {
                die.RollDie();
            }
            die1.RollDie();
        }

        if(mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released)
        {
            foreach(Die die in dice)
            {
                if (die.Rect.Contains(mouseState.Position))
                {
                    die.RollDie();
                }
            }
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
