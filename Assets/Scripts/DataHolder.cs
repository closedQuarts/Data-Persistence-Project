using UnityEngine;

public class DataHolder : MonoBehaviour
{
  public static DataHolder Instance {get; private set;}
  public string playerName;
  public int bestScore;
  public string bestPlayer;
    public int POINTS;
  private const string BestScoreKey = "BestScore";
  private const string BestPlayerKey = "BestPlayer";

  public int GetBestScore() => bestScore;
  public string GetBestPlayer() => bestPlayer;

    public void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        Load();
    }

    public void SetPoint(int points)
    {
        Debug.Log($"SetPoint called: points={points}, currentBest={bestScore}, playerName='{playerName}'");
        POINTS = points;
        if(points > bestScore)
        {
            bestScore = points;
            bestPlayer = playerName;
            Save();
            Debug.Log($"New best saved: {bestPlayer} : {bestScore}");
        }
        else
        {
            Debug.Log($"Not a new best (best={bestScore}).");
        }
    }

    public void Save()
    {
        PlayerPrefs.SetInt(BestScoreKey, bestScore);
        PlayerPrefs.SetString(BestPlayerKey, bestPlayer);
        PlayerPrefs.Save();
    }

    public void Load()
    {
        bestScore = PlayerPrefs.GetInt(BestScoreKey, 0);
        bestPlayer = PlayerPrefs.GetString(BestPlayerKey, "");
    }
    
    public void SetPlayerName(string name)
    {
        playerName = name;
    }
    
    public string GetPlayerName()
    {
        return playerName;
    }
}
