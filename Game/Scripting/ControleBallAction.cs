using Unit06.Game.Casting;
using Unit06.Game.Services;


namespace Unit06.Game.Scripting
{
    public class ControlBallAction : Action
    {
        private KeyboardService keyboardService;

        public ControlBallAction(KeyboardService keyboardService)
        {
            this.keyboardService = keyboardService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Ball ball = (Ball)cast.GetFirstActor(Constants.BALL_GROUP);
            if (keyboardService.IsKeyDown(Constants.SPACE))
            {   
                ball.Release(cast);     
            }

        }    
    }
}