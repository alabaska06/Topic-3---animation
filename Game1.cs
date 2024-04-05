using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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

        List<Rectangle> tribbleRects = new List<Rectangle>();

        List<Vector2> tribbleSpeed = new List<Vector2>();

        List<Texture2D> tribbleTexture = new List<Texture2D>();

        Texture2D tribbleGreyTexture;
        Texture2D tribbleCreamTexture;
        Texture2D tribbleOrangeTexture;
        Texture2D tribbleBrownTexture;

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

            tribbleRects.Add(new Rectangle(150, 10, 100, 100));//size and start position
            tribbleSpeed.Add(new Vector2(5, 5));//first is speed horizontally, second is speed vertically
            tribbleTexture.Add(tribbleGreyTexture);

            tribbleRects.Add(new Rectangle(300, 10, 100, 100));
            tribbleSpeed.Add(new Vector2(5, 5));
            tribbleTexture.Add(tribbleCreamTexture);

            tribbleRects.Add(new Rectangle(300, 10, 100, 100));
            tribbleSpeed.Add(new Vector2(5, 5));
            tribbleTexture.Add(tribbleOrangeTexture);

            tribbleRects.Add(new Rectangle(300, 10, 100, 100));
            tribbleSpeed.Add(new Vector2(5, 5));
            tribbleTexture.Add(tribbleBrownTexture);

            base.Initialize();
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


            greyTribbleRect.X += (int)tribbleGreySpeed.X;//makes x move
            greyTribbleRect.Y += (int)tribbleGreySpeed.Y;//makes y move
            if (greyTribbleRect.Right > _graphics.PreferredBackBufferWidth || greyTribbleRect.Left < 0)//makes it hit the wall 
                tribbleGreySpeed.X *= -1;
            if (greyTribbleRect.Bottom > _graphics.PreferredBackBufferHeight || greyTribbleRect.Top < 0)//makes it hit the top and bottom
                tribbleGreySpeed.Y *= -1;

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Sienna);

            _spriteBatch.Begin();
            _spriteBatch.Draw(tribbleGreyTexture, greyTribbleRect, Color.White);//draws the tribble
            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}