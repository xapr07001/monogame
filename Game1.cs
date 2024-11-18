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
    Rectangle leftpaddle = new Rectangle(x:10,y:200,width:20,height:100);

    Rectangle rightpaddle = new Rectangle(x:770,y:200,width:20,height:100);

    Rectangle ball = new Rectangle(390,230,20,20);

    int ballXVelocity = 5;
    int ballYVelocity = 1;




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

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        KeyboardState kState = Keyboard.GetState();
        if(kState.IsKeyDown(Keys.W) && leftpaddle.Y > 0){
            leftpaddle.Y -= 4;
        }
        if(kState.IsKeyDown(Keys.S) && leftpaddle.Y < 400){
            leftpaddle.Y += 4;
        }
        if(kState.IsKeyDown(Keys.Up) && rightpaddle.Y > 0){
            rightpaddle.Y -= 4;
        }
        if(kState.IsKeyDown(Keys.Down) && rightpaddle.Y < 400){
            rightpaddle.Y += 4;
        }
        
        ball.X += ballXVelocity;
        ball.Y += ballYVelocity;
        if(rightpaddle.Intersects(ball) || leftpaddle.Intersects(ball)){
            ballXVelocity *= -1;
        }
        if(ball.Y < 0 || ball.Y > 460){
            ballYVelocity *= -1;
        }

        if(ball.X < 0 || ball.X > 780){
            ball.X = 390;
            ball.Y = 230;
        }
        
   

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();
        _spriteBatch.Draw(pixel,leftpaddle,Color.White);
        _spriteBatch.Draw(pixel,rightpaddle,Color.White);
        _spriteBatch.Draw(pixel,ball,Color.White);
        _spriteBatch.End();
        base.Draw(gameTime);
    }
}
