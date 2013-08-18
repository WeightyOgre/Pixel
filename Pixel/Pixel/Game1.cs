using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Pixel
{

    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D testTexture;

        ABlock aBlock;

        MouseState mouseState;

        public List<Bullet> bullets;

        public List<ABlock> blocks;

        Color aColor;
        Color anotherColor;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            
        }

        protected override void Initialize()
        {
            this.aBlock = new ABlock(new Vector2(800, 200));
            
            // TODO: Add your initialization logic here
            bullets = new List<Bullet>();
            blocks = new List<ABlock>();
            //set up the viewport to match screen resolution and set to full screen
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
            graphics.IsFullScreen = true;
            graphics.ApplyChanges();

            this.IsMouseVisible = true;

            aColor = Color.Black;

            anotherColor = Color.White;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            testTexture = Content.Load<Texture2D>("1x1");
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape) == true)
            {
                this.Exit();
            }

            mouseState = Mouse.GetState();

            //left mouse button click
            if (mouseState.LeftButton == ButtonState.Pressed && mouseState.RightButton == ButtonState.Released)
            {
                //add a bullet
                Bullet abullet = new Bullet(new Vector2(mouseState.X,mouseState.Y));
                bullets.Add(abullet);
            }
            //right mouse button click
            if (mouseState.LeftButton == ButtonState.Released && mouseState.RightButton == ButtonState.Pressed)
            {
                //add a block
                ABlock anBlock = new ABlock(new Vector2(mouseState.X, mouseState.Y));
                blocks.Add(anBlock);
            }

            for (int i = bullets.Count - 1; i >= 0; i--)
            {
                bullets[i].UpdateBullet();
                if (bullets[i].active == false)
                {
                    
                    bullets.RemoveAt(i);
                }
                
            }

            for (int i = bullets.Count - 1; i >= 0; i--)
            {
                for (int j = blocks.Count - 1; j >= 0; j--)
                {
                    Rectangle theBlock = new Rectangle(Convert.ToInt32(blocks[j].aPosition.X), Convert.ToInt32(blocks[j].aPosition.Y), blocks[j].blockWidth, blocks[j].blockHeight);

                    Rectangle theBullet = new Rectangle(Convert.ToInt32(bullets[i].position.X), Convert.ToInt32(bullets[i].position.Y), 1, 1);

                    if (theBlock.Intersects(theBullet))
                    {
                        
                        //if the distance is less than 2pixels, check collision between the bullet and the pixel, checking for distance between them
                        for (int k = 0; k <= blocks[j].blockWidth; k++)
                        {
                            for (int l = 0; l <= blocks[j].blockHeight; l++)
                            {
                                if (blocks[j].aBlock[k, l].active == true)
                                {
                                    if (Vector2.Distance(blocks[j].aBlock[k, l].pixelPosition, bullets[i].position) < 15.0f)
                                    {
                                        bullets[i].active = false;
                                        blocks[j].aBlock[k, l].active = false;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            UpdateBlocks();

            base.Update(gameTime);
        }

        public void UpdateBlocks()
        {
            for (int i = blocks.Count - 1; i >= 0; i--)
            {

                if (blocks[i].DeleteBlock())
                {
                    blocks.RemoveAt(i);
                }
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(aColor);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            spriteBatch.Draw(testTexture, new Rectangle(GraphicsDevice.Viewport.Width/2,GraphicsDevice.Viewport.Height/2,100,1), Color.White);
            aBlock.DrawBlock(spriteBatch, testTexture, anotherColor);
            for (int i = bullets.Count - 1; i >= 0; i--)
            {
                if (bullets[i].active)
                {
                    spriteBatch.Draw(testTexture, bullets[i].position, Color.White);
                }
            }
            for (int i = blocks.Count - 1; i >= 0; i--)
            {
                blocks[i].DrawBlock(spriteBatch, testTexture, anotherColor);
            }

            spriteBatch.End();

            

            base.Draw(gameTime);
        }
    }
}
