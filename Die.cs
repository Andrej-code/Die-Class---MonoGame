using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Die_Class;

public class Die
{
    private int _roll, _randomFace, _frame;
    private Random _generator;
    private List<Texture2D>_faces;
    private Rectangle _location;

    // For for animation
    float _rotation;

    public Die(List<Texture2D> faces, Rectangle location)
    {
        _generator = new Random();
        _roll = _generator.Next(1, 7);
        _faces = faces;
        _location = location;  
        _frame = 0;
        _rotation = 0f;
    }

    // Allows the user to create a Die and specify its starting value
    public Die(List<Texture2D> faces, Rectangle location, int roll)
    {
        _generator = new Random();
        if (roll < 1 || roll > 6)
            roll = 6;
        else
            _roll = roll;
        _faces = faces;
        _location = location;
        _frame = 0;
        _rotation = 0f;
    }

    public int Roll
    {
        get { return _roll; }
    }

    public override string ToString()
    {
        return _roll + "";
    }

    public Rectangle Rect
    {
        // Fixes offset error made from rotation
        //get { return new Rectangle(_location.X - _location.Width / 2, _location.Y - _location.Height / 2, _location.Width, _location.Height); }
        //set { _location = new Rectangle }
        get { return _location; }
        set { _location = value; }               
    }

    public int RollDie()
    {
        _roll = _generator.Next(1, 7);
        _frame = 1;
        return _roll;
    }

    public void DrawRoll(SpriteBatch spriteBatch)
    {
        if (_frame > 0) // When _frame is > 0, we are animating a roll
        {
            _frame++;
            _rotation += 0.1f;
            if (_frame % 10 == 0)   // Every 10 frames display a random die face.
            {
                _randomFace = _generator.Next(_faces.Count);
                if (_frame == 60)   // After 60 frames, stop animating a roll
                {
                    _frame = 0; // Animation is done
                    _rotation = 0f;
                }
            }
            // Spins and iterates through dies faces to animate roll, this translates the rotated texture to be on the rectangle for drawing
            spriteBatch.Draw(_faces[_randomFace], new Rectangle(_location.X + _location.Width/2, _location.Y + _location.Height/2, _location.Width, _location.Height), null, Color.White, _rotation, new Vector2(_faces[0].Width/2, _faces[0].Height/2), SpriteEffects.None, 1);
        }
        else
        {
            // Draws final roll
            spriteBatch.Draw(_faces[_roll - 1], _location, Color.White);

        }

    }
}
