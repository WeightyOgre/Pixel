using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Pixel
{
    public class Bullet
    {

        public Vector2 position;

        int bulletMoveSpeed =2;

        int screenWidth = 1920;

        int bulletWidth = 1;

        public bool active { get; set; }

        public Bullet(Vector2 position)
        {
            this.position = position;
            
            active = true;
        }

        public void UpdateBullet()
        {
            position.X += bulletMoveSpeed;
            if (position.X + bulletWidth > screenWidth)
            {
                active = false;
            }

        }

    }
}
