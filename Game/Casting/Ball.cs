using System;
using System.Collections.Generic;
using Unit06.Game.Casting;



namespace Unit06.Game.Casting
{
    /// <summary>
    /// 
    /// </summary>
    public class Ball : Actor
    {
        private static Random random = new Random();

        private Body body;
        private Image image;

        /// <summary>
        /// Constructs a new instance of Actor.
        /// </summary>
        public Ball(Body body, Image image, bool debug = false) : base(debug)
        {
            this.body = body;
            this.image = image;
        }

        /// <summary>
        /// Bounces the ball horizontally.
        /// </summary>
        public void BounceX()
        {
            // Point velocity = body.GetVelocity();
            // double rn = (random.NextDouble() * (1.2 - 0.8) + 0.8);
            // double vx = velocity.GetX() * -1;
            // double vy = velocity.GetY();
            // Point newVelocity = new Point((int)vx, (int)vy);
            // body.SetVelocity(newVelocity);
        }

        /// <summary>
        /// Bounces the ball vertically.
        /// </summary>
        public void BounceY()
        {
            // Point velocity = body.GetVelocity();
            // double rn = (random.NextDouble() * (1.2 - 0.8) + 0.8);
            // double vx = velocity.GetX();
            // double vy = velocity.GetY() * -1;
            // Point newVelocity = new Point((int)vx, (int)vy);
            // body.SetVelocity(newVelocity);
        }

        /// <summary>
        /// Shot fired.
        /// </summary>

        
        /// <summary>
        /// Gets the body.
        /// </summary>
        /// <returns>The body.</returns>
        public Body GetBody()
        {
            return body;
        }

        public void SetBody(Body body)
        {
            this.body = body;
        }

        /// <summary>
        /// Gets the image.
        /// </summary>
        /// <returns>The image.</returns>
        public Image GetImage()
        {
            return image;
        }
        public void Release(Cast cast)
        {
            Racket ship = (Racket)cast.GetFirstActor(Constants.RACKET_GROUP);
            Point velocity = new Point(0, -Constants.BALL_VELOCITY);
            Body body = ship.GetBody();
            Point position = body.GetPosition();
            this.body.SetPosition(position);
            this.body.SetVelocity(velocity);
        }
    }
}