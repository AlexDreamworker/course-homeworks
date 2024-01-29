using UnityEngine;
using UnityEngine.UI;

namespace Homework2.Task4
{
    public class HUDPanel : MonoBehaviour
    {
        [SerializeField] private Button _restart;

        [Space]
        [SerializeField] private Text _health;
        [SerializeField] private Text _maxHealth;
        [SerializeField] private Text _level;
        [SerializeField] private Text _levelScore;
        [SerializeField] private Text _levelScoreLimit;

        private HUDMediator _hudMediator;

        public void Initialize(HUDMediator mediator) 
        {
            _hudMediator = mediator;
        }

        private void OnEnable()
        {
            _restart.onClick.AddListener(OnRestartClick);
        }

        private void OnDisable()
        {
            _restart.onClick.RemoveListener(OnRestartClick);
        }

        public void ShowRestartButton() => _restart.gameObject.SetActive(true);
        public void HideRestartButton() => _restart.gameObject.SetActive(false);

        public void UpdateHealth(int health, int maxHealth) 
        {
            _health.text = health.ToString();
            _maxHealth.text = maxHealth.ToString();
        }

        public void UpdateLevel(int level, int levelScore, int levelScoreLimit) 
        {
            _level.text = level.ToString();
            _levelScore.text = levelScore.ToString();
            _levelScoreLimit.text = levelScoreLimit.ToString();
        }

        private void OnRestartClick() => _hudMediator.Restart();
    }
}