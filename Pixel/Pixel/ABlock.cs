using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pixel
{
    public class ABlock
    {
        public Vector2 aPosition;

        public int blockWidth;
        public int blockHeight;

        public APixel[,] aBlock;

        int startingPosition;

        public ABlock(Vector2 aPosition)
        {
            
            aBlock = new APixel[40,40];
            
            blockWidth = aBlock.GetUpperBound(0);
            blockHeight = aBlock.GetUpperBound(1);

            this.aPosition = aPosition;
            startingPosition = Convert.ToInt32(this.aPosition.X);

            for (int i = 0; i <= blockWidth; i++)
            {
                for (int j = 0; j <= blockHeight; j++)
                {
                    aBlock[i, j] = new APixel();
                    aBlock[i, j].active = true;
                    aBlock[i, j].PixelPosition = aPosition;

                    if (aPosition.X >= startingPosition + blockWidth)
                    {
                        aPosition.X = startingPosition -1;
                        aPosition.Y++;
                    }
                    
                    aPosition.X++;
                    
                }
                
            }
        }

        public bool DeleteBlock()
        {
            int counter = 0;
            for (int i = 0; i <= blockWidth; i++)
            {
                for (int j = 0; j <= blockHeight; j++)
                {
                    if (aBlock[i, j].active == true)
                    {
                        counter++;
                    }
                }
            }
            if (counter > 0)
            {
                //return false, do not delete
                return false;
            }
            else
            {
                //return true delete
                return true;
            }
        }

        public void DrawBlock(SpriteBatch spritebatch, Texture2D aTexture, Color aColor)
        {
            for (int i = 0; i <= blockWidth; i++)
            {
                for (int j = 0; j <= blockHeight; j++)
                {
                    if (aBlock[i, j].active == true)
                    {
                        spritebatch.Draw(aTexture, aBlock[i, j].pixelPosition, aColor);
                    }
                }
            }
        }
        

    }
}
