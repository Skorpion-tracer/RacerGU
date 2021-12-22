using Controllers;
using Profile;
using Tools;
using UnityEngine;

namespace Game.InputLogic
{
    internal class FloatJoysticController : BaseController
    {
        public FloatJoysticController(SubscriptionProperty<float> leftMove,
                SubscriptionProperty<float> rightMove, Car car)
        {
            _view = LoadView();
            _view.Init(leftMove, rightMove, car.Speed);
        }

        private readonly ResourcePath _viewPath = new ResourcePath
        {
            PathResource = "Prefabs/FloatInputJoystick"
        };
        private FloatInputJoystick _view;

        private FloatInputJoystick LoadView()
        {
            GameObject objView = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath));
            AddGameObjects(objView);
            return objView.GetComponent<FloatInputJoystick>();
        }
    }
}
