using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Leaderboard
{
    public class AuthorizationErrorView : MonoBehaviour
    {
        [SerializeField] private Button _confirmButton;

        private void Awake() => _confirmButton.onClick.AddListener(Hide);
        private void OnDestroy() => _confirmButton.onClick.RemoveListener(Hide);

        public void Show() => gameObject.SetActive(true);
        private void Hide() => gameObject.SetActive(false);
    }
}