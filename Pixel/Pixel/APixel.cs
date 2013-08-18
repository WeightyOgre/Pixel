using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Pixel
{
    public class APixel
    {

        public Texture2D pixelTexture;

        public Texture2D PixelTexture
        {
            get { return pixelTexture; }
            set { pixelTexture = value; }
        }

        public bool active { get; set; }

        public Vector2 pixelPosition;

        public Vector2 PixelPosition
        {
            get { return pixelPosition; }
            set { pixelPosition = value; }
        }
    }
}
