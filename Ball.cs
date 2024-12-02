using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.WIC;


namespace monogame
{
    public class Ball
    {
        private Rectangle rectangle = new Rectangle(390,230,20,20);
        private Texture2D texture;
        private int xVelocity = 5;
        private int yVelocity = 1;

        public Rectangle Rectangle{
            get{return rectangle;}
        }

        public Ball(Texture2D t){
            texture = t;
        }

        public void PaddleBounce(){







            if(xVelocity < 0){
                xVelocity =  5 + Convert.ToInt32(Math.Abs(Paddle.Speedbounce/2));
            }else{
                xVelocity =  -1*(5 + Convert.ToInt32(Math.Abs(Paddle.Speedbounce/2)));

            }


        }

        public void Update(){
            rectangle.X += xVelocity;
            rectangle.Y += yVelocity;

            if(rectangle.Y < 0 || rectangle.Y > 460){
                yVelocity *= -1;
            }

            if(rectangle.X < 0 || rectangle.X > 780){
                rectangle.X = 390;
                rectangle.Y = 230;
            }
        }

        public void  Draw(SpriteBatch spritebatch){
            spritebatch.Draw(texture,rectangle,Color.White);
        }
    }
}