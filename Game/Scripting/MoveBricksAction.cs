using Unit06.Game.Casting;
using System.Collections.Generic;

namespace Unit06.Game.Scripting
{
    public class MoveBricksAction : Action
    {
        public MoveBricksAction()
        {
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            List <Actor> bricks = cast.GetActors(Constants.BRICK_GROUP);
           
            foreach(Brick brick in bricks ){
            // Brick brick = (Brick)cast.GetFirstActor(Constants.BRICK_GROUP);
            Body body = brick.GetBody();
            Point position = body.GetPosition();
            Point velocity = body.GetVelocity();
            position = position.Add(velocity);
            body.SetPosition(position);
            }
        }
        
        }
    }
