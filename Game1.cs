using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Topic_3___animation
{
    public class Game1 : Game
    {

        Rectangle greyTribbleRect;//for the size and start position
        Vector2 tribbleGreySpeed;//for the speed 

        Rectangle creamTribbleRect;
        Vector2 tribbleCreamSpeed;

        Rectangle orangeTribbleRect;
        Vector2 tribbleOrangeSpeed;

        Rectangle brownTribbleRect;
        Vector2 tribbleBrownSpeed;

        Color bgColor;

        List<Rectangle> tribbleRects = new List<Rectangle>();

        List<Vector2> tribbleSpeed = new List<Vector2>();

        List<Texture2D> tribbleTexture = new List<Texture2D>();

        Texture2D tribbleGreyTexture;
        Texture2D tribbleCreamTexture;
        Texture2D tribbleOrangeTexture;
        Texture2D tribbleBrownTexture;

        Random generator = new Random();

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 600;
            _graphics.ApplyChanges();

            bgColor = Color.Goldenrod;

            base.Initialize();



            tribbleRects.Add(new Rectangle(150, 10, 100, 100));//size and start position
            tribbleSpeed.Add(new Vector2(5, 0));//first is speed horizontally, second is speed vertically
            tribbleTexture.Add(tribbleGreyTexture);

            tribbleRects.Add(new Rectangle(300, 10, 100, 100));
            tribbleSpeed.Add(new Vector2(0, 5));
            tribbleTexture.Add(tribbleCreamTexture);

            tribbleRects.Add(new Rectangle(450, 10, 100, 100));
            tribbleSpeed.Add(new Vector2(7, 6));
            tribbleTexture.Add(tribbleOrangeTexture);

            tribbleRects.Add(new Rectangle(600, 10, 100, 100));
            tribbleSpeed.Add(new Vector2(5,5));
            tribbleTexture.Add(tribbleBrownTexture);

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            tribbleGreyTexture = Content.Load<Texture2D>("tribbleGrey");
            tribbleCreamTexture = Content.Load<Texture2D>("tribbleCream");
            tribbleOrangeTexture = Content.Load<Texture2D>("tribbleOrange");
            tribbleBrownTexture = Content.Load<Texture2D>("tribbleBrown");

       

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            for (int i = 0; i < tribbleRects.Count; i++)
            {
                Rectangle temp = tribbleRects[i];
                temp.X += (int)tribbleSpeed[i].X;
                temp.Y += (int)tribbleSpeed[i].Y;
                tribbleRects[i] = temp;


                if (tribbleRects[i].Right > _graphics.PreferredBackBufferWidth || tribbleRects[i].Left < 0)
                {
                    Vector2 tempSpeed = tribbleSpeed[i];
                    tempSpeed.X *= -1;
                    tribbleSpeed[i] = tempSpeed;
                    if (i == tribbleRects.Count - 1)
                        bgColor = GetRandomColor();
                }
                if (tribbleRects[i].Bottom > _graphics.PreferredBackBufferHeight || tribbleRects[i].Top < 0)
                {
                    Vector2 tempSpeed = tribbleSpeed[i];
                    tempSpeed.Y *= -1;
                    tribbleSpeed[i] = tempSpeed;
                    if (i == tribbleRects.Count - 1)
                        bgColor = GetRandomColor();
                }
            }

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        private Color GetRandomColor()
        {
            return new Color(generator.Next(256), generator.Next(256), generator.Next(256));
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(bgColor);

            _spriteBatch.Begin();

            for (int i = 0; i < tribbleTexture.Count; i++)
            {
                _spriteBatch.Draw(tribbleTexture[i], tribbleRects[i], Color.White);
            }

            _spriteBatch.End();


            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}