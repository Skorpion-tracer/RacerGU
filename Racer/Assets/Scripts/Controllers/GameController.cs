using Game.InputLogic;
using Profile;
using Tools;

namespace Controllers
{
    internal class GameController : BaseController
    {
        public GameController(ProfilePlayer profilePlayer)
        {
            var leftMoveDiff = new SubscriptionProperty<float>();
            var rightMoveDiff = new SubscriptionProperty<float>();

            var tapeBackgroundController = new TapeBackgroundController(leftMoveDiff, rightMoveDiff);
            AddController(tapeBackgroundController);

            var inputGameController = new InputGameController(leftMoveDiff, rightMoveDiff, profilePlayer.CurrentCar);
            AddController(inputGameController);

            var floatinputController = new FloatJoysticController(leftMoveDiff, rightMoveDiff, profilePlayer);
            AddController(floatinputController);

            var carController = new CarController();
            AddController(carController);
        }
    }
}

