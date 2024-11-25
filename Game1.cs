using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace monogame;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

//skärmbredd 800p skärmhöjd 400p
    Texture2D pixel;
    Ball ball;
    Paddle paddleright;
    Paddle paddleleft;








    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        pixel = new Texture2D(GraphicsDevice,1,1);
        pixel.SetData(new Color[]{Color.White});
        ball = new Ball(pixel);
        paddleright = new Paddle(pixel,780,200,Keys.Up,Keys.Down);
        paddleleft = new Paddle(pixel,0,200,Keys.W,Keys.S);
        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();


        // TODO: Add your update logic here


        paddleright.Update();
        paddleleft.Update(); 
        ball.Update();

        if(ball.Rectangle.Intersects(paddleleft.Rectangle) || ball.Rectangle.Intersects(paddleright.Rectangle)){
            ball.PaddleBounce();
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();
        
        ball.Draw(_spriteBatch);
        paddleright.Draw(_spriteBatch);
        paddleleft.Draw(_spriteBatch);
        _spriteBatch.End();
        base.Draw(gameTime);
    }
}
