using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AddScoreTest : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private TMP_Text _score;

    private void Awake()
    {
        _button.onClick.AddListener(OnClick);
        Agava.YandexGames.PlayerAccount.AuthorizedInBackground += OnAuthorized;
        UpdateScoreView();
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveListener(OnClick);
        Agava.YandexGames.PlayerAccount.AuthorizedInBackground -= OnAuthorized;
    }

    private void UpdateScoreView() =>
        _score.text = Agava.YandexGames.Utility.PlayerPrefs.GetInt(Constants.SCORE_PREFS_KEY, 0).ToString();

    private void OnClick()
    {
        int score = Agava.YandexGames.Utility.PlayerPrefs.GetInt(Constants.SCORE_PREFS_KEY, 0) + 1;
        _score.text = score.ToString();
        Agava.YandexGames.Utility.PlayerPrefs.SetInt(Constants.SCORE_PREFS_KEY, score);
        Agava.YandexGames.Utility.PlayerPrefs.Save();

        Agava.YandexGames.Leaderboard.SetScore(Constants.LEADERBOARD_NAME, score);
    }

    private void OnAuthorized() => UpdateScoreView();
}
