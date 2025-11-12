using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Die_Class
{
    public class Die
    {
        private Random _generator;
        private int _roll;
        private List<Texture2D> _faces;
        private Rectangle _location;

        public Die(List<Texture2D> faces, Rectangle location)
        {
           _generator = new Random();
            _roll = _generator.Next(1, 7);

            _faces = faces;
            _location = location;
            
        }

        public int Roll 
        {
            get { return _roll; }
            //set { _roll = value; }
        }
     
        public void RollDie()
        { 
            _roll = _generator.Next(1, 7);
        }

        public Die (int roll)
        {
            _generator = new Random();
            if (roll < 1)
            {
                _roll = 1;
            }
            else if (roll > 6)
            {
                _roll = 6;
            }
            else 
            { 
                  _roll = roll;
            }
        }

        public void DrawRoll(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_faces[_roll - 1], _location, Color.White);
        }




    }
}
