using System;
using System.Collections.Generic;

namespace Unit06.Game.Casting
{
    /// <summary>
    /// A thing that participates in the game.
    /// </summary>
    public class Brick : Actor
    {
        private Body body;
        private Animation animation;
        private int points;
        private static Random random = new Random();

        /// <summary>
        /// Constructs a new instance of Actor.
        /// </summary>
        public Brick(Body body, Animation animation, int points, bool debug) : base(debug)
        {
            this.body = body;
            this.animation = animation;
            this.points = points;
        }

        /// <summary>
        /// Gets the animation.
        /// </summary>
        /// <returns>The animation.</returns>
        public Animation GetAnimation()
        {
            return animation;
        }

        /// <summary>
        /// Gets the body.
        /// </summary>
        /// <returns>The body.</returns>
        public Body GetBody()
        {
            return body;
        }

        /// <summary>
        /// Gets the points.
        /// </summary>
        /// <returns>The points.</returns>
        public int GetPoints()
        {
            return points;
        }
        
        public void BounceX()
        {
            Point velocity = body.GetVelocity();
            double rn = (random.Next() * (1.2 - 0.8) + 0.8);
            double vx = velocity.GetX() * -1;
            double vy = velocity.GetY() * -1;
            Point newVelocity = new Point((int)vx, (int)vy);
            body.SetVelocity(newVelocity);
        }

        /// <summary>
        /// Bounces the ball vertically.
        /// </summary>
        public void BounceY()
        {
            Point velocity = body.GetVelocity();
            double rn = (random.Next() * (1.2 - 0.8) + 0.8);
            double vx = velocity.GetX() * -1;
            double vy = velocity.GetY() * -1;
            Point newVelocity = new Point((int)vx, (int)vy);
            body.SetVelocity(newVelocity);
        }

         public void Release()
        {
            Point velocity = body.GetVelocity();
            List<int> velocities = new List<int> {Constants.BRICK_VELOCITY, Constants.BRICK_VELOCITY};
            int index = random.Next(velocities.Count);
            double vx = velocities[index];
            double vy = Constants.BRICK_VELOCITY;
            Point newVelocity = new Point((int)vx, (int)vy);
            body.SetVelocity(velocity);
        }
    }
}