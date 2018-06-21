using System;
using OpenTK;

namespace PongGame
{
    class AIPaddle : Paddle
    {
        
        public AIPaddle(int x, int y) : base(x, y)
        {  
        }

        public override void Update(float dt)
        {
            position += velocity;
        }

        public void Move(Vector2 ballPosition)
        {
            if(SceneManager.diff=="easy")
            velocity.Y += (ballPosition.Y - position.Y) * 0.0002f;
            else
            velocity.Y += (ballPosition.Y - position.Y) * 0.02f;
        }
    }
}
