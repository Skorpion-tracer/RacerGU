using JoostenProductions;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Ui
{
    internal class MainMenuView : MonoBehaviour
    {
        [SerializeField] private Button _buttonStart;
        [SerializeField] private GameObject _trail;

        public void Init(UnityAction startGame)
        {
            _buttonStart.onClick.AddListener(startGame);
            UpdateManager.SubscribeToUpdate(Move);
        }

        protected void OnDestroy()
        {
            _buttonStart.onClick.RemoveAllListeners();
            UpdateManager.UnsubscribeFromUpdate(Move);
        }

        private void Move()
        {
            Touch touch = Input.GetTouch(0);
            _trail.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));
        }
    }
}
