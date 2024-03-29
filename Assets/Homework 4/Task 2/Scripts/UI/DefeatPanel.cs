using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Homework4.Task2
{
    public class DefeatPanel : MonoBehaviour
    {
        [SerializeField] private Button _restart;

        private GameplayMediator _mediator; 

        [Inject]
        private void Construct(GameplayMediator mediator) 
        {
            _mediator = mediator;
        }

        private void OnEnable()
        {
            _restart.onClick.AddListener(OnRestartClick);
        }

        private void OnDisable()
        {
            _restart.onClick.RemoveListener(OnRestartClick);
        }

        public void Show() => gameObject.SetActive(true);

        public void Hide() => gameObject.SetActive(false);

        private void OnRestartClick() => _mediator.RestartLevel();
    }
}