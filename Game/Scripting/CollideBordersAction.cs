using Unit06.Game.Casting;
using Unit06.Game.Services;
using System.Collections.Generic;


namespace Unit06.Game.Scripting
{
    public class CollideBordersAction : Action
    {
        private AudioService audioService;
        private PhysicsService physicsService;

        public CollideBordersAction(PhysicsService physicsService, AudioService audioService)
        {
            this.physicsService = physicsService;
            this.audioService = audioService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            // Bricks

            List<Actor> bricks = cast.GetActors(Constants.BRICK_GROUP);

            foreach (Brick brick in bricks)
            {

                Body BODY = brick.GetBody();
                Point position1 = BODY.GetPosition();
                int dx = position1.GetX();
                int dy = position1.GetY();
              

                if (dx < Constants.FIELD_LEFT)
                {
                    brick.BounceX();
                    
                }
                else if (dx >= Constants.FIELD_RIGHT - Constants.BALL_WIDTH)
                {
                    brick.BounceX();
                
                }

                if (dy < Constants.FIELD_TOP)
                {
                    brick.BounceY();
                  
                }

                if (dy > 860)
                {
                    brick.BounceY();
                }
    
            }



            // ball 
                Ball ball = (Ball)cast.GetFirstActor(Constants.BALL_GROUP);
                Body body = ball.GetBody();
                Point position = body.GetPosition();
                int x = position.GetX();
                int y = position.GetY();
                Sound bounceSound = new Sound(Constants.BOUNCE_SOUND);
                Sound overSound = new Sound(Constants.OVER_SOUND);

                if (x < Constants.FIELD_LEFT)
                {
                    ball.BounceX();
                    audioService.PlaySound(bounceSound);
                }
                else if (x >= Constants.FIELD_RIGHT - Constants.BALL_WIDTH)
                {
                    ball.BounceX();
                    audioService.PlaySound(bounceSound);
                }

                if (y < Constants.FIELD_TOP)
                {
                    ball.BounceY();
                    audioService.PlaySound(bounceSound);
                }
                else if (y >= Constants.FIELD_BOTTOM - Constants.BALL_WIDTH)
                {
                    Stats stats = (Stats)cast.GetFirstActor(Constants.STATS_GROUP);
                    stats.RemoveLife();

                    if (stats.GetLives() > 0)
                    {
                        callback.OnNext(Constants.TRY_AGAIN);
                    }
                    else
                    {
                        callback.OnNext(Constants.GAME_OVER);
                        audioService.PlaySound(overSound);
                    }
                }


            }
        }
    }
