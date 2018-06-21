using System;

namespace PongGame
{
    class PlayerPaddle : Paddle
    {
        public PlayerPaddle(int x, int y) : base(x, y)
        { 
        }

        public override void Update(float dt)
        {
        }

        public void Move(int dy)
        {
            position.Y += dy;
            if (position.Y < 0) position.Y = 0;
            else if (position.Y > SceneManager.WindowHeight) position.Y = SceneManager.WindowHeight;
        }
    }
}
