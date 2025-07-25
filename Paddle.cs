using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace monogame
{
    public class Paddle
    {
        private Rectangle rectangle;
        private Texture2D texture;
        


        private Keys up;
        private Keys down;

        private double speed;

        public static double Speedbounce;


        public Rectangle Rectangle{
            get{return rectangle;}
        }


        public Paddle(Texture2D t, int x, int y, Keys u,Keys d){
            texture = t;
            rectangle = new Rectangle(x,y,20,100);
            up = u;
            down = d;
        }

        public void Update(){
            KeyboardState kState = Keyboard.GetState();

            if(kState.IsKeyDown(up) && speed < 5){
                speed += 0.25;
            }else if(speed >= 0 || kState.IsKeyDown(Keys.None)){
                speed -= 0.1;
            }
            
            if(kState.IsKeyDown(down) && speed > -5){
                speed -= 0.25;
            }else if(speed <= 0 || kState.IsKeyDown(Keys.None)){
                speed += 0.1;
            }
            rectangle.Y -= Convert.ToInt16(speed);
            Speedbounce = speed;




        }

        public void  Draw(SpriteBatch spritebatch){
            spritebatch.Draw(texture,rectangle,Color.White);
        }
    }
}