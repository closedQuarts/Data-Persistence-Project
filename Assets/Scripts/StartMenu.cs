using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class StartMenu : MonoBehaviour
{
    public TMP_InputField nameInput;

    // Best score display: support either TextMeshPro or legacy UI Text
    public TMP_Text bestScoreTextTMP;
    public Text bestScoreTextLegacy;

    private void Start()
    {
        if (DataHolder.Instance != null)
        {
            nameInput.text = DataHolder.Instance.GetPlayerName();
        }

        UpdateBestScoreUI();
    }

    private void OnEnable()
    {
        UpdateBestScoreUI();
    }

    private void UpdateBestScoreUI()
    {
        string bestPlayer;
        int bestScore;

        if (DataHolder.Instance != null)
        {
            bestPlayer = DataHolder.Instance.GetBestPlayer();
            bestScore = DataHolder.Instance.GetBestScore();
        }
        else
        {
            bestPlayer = PlayerPrefs.GetString("BestPlayer", "None");
            bestScore = PlayerPrefs.GetInt("BestScore", 0);
        }

        string text = $"Best Score: {bestPlayer} : {bestScore}";

        if (bestScoreTextTMP != null)
            bestScoreTextTMP.text = text;

        if (bestScoreTextLegacy != null)
            bestScoreTextLegacy.text = text;
    }

    public void StartGame()
    {
        string playerName = nameInput.text;
        if (string.IsNullOrEmpty(playerName))
        {
            playerName = "Player";
        }
        if (DataHolder.Instance != null)
        {
            DataHolder.Instance.SetPlayerName(playerName);
        }
        else
        {
            Debug.LogWarning("DataHolder instance is not found");
        }

        SceneManager.LoadScene(1);
    }
}
















