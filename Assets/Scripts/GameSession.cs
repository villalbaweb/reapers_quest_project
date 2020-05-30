using UnityEngine;

public class GameSession : MonoBehaviour
{
    // Config Params
    [Header("Player Status")]
    [SerializeField] int playerLives = 3;
    [SerializeField] int coins = 0;
    [SerializeField] int stars = 0;

    [Header("Config")]
    [SerializeField] int lifeUpCoins = 100;
    [SerializeField] int powerupStars = 5;


    // Cache
    LevelLoader _levelLoader;
    Player _player;

    private void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;

        if(numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _levelLoader = FindObjectOfType<LevelLoader>();
        _player = FindObjectOfType<Player>();
    }

    #region Lifes

    public int NumberOfLifes()
    {
        return playerLives;
    }

    public void ProcessPlayerDeath()
    {
        if (playerLives > 1)
        {
            TakeLife();
        }
        else
        {
            ResetGameSession();
        }
    }

    private void TakeLife()
    {
        playerLives--;
        _levelLoader.LoadCurrentScene();
    }

    #endregion

    #region Coins

    public int NumberOfCoins()
    {
        return coins;
    }

    public void CollectCoin(int numberOfCoins)
    {
        coins += numberOfCoins;

        if(coins == lifeUpCoins)
        {
            playerLives++;
            coins = 0;
            _player.LifeUp();
        }
    }

    #endregion

    #region Stars

    public int NumberOfStars()
    {
        return stars;
    }

    public void CollectStar(int numberOfStars)
    {
        stars += numberOfStars;

        if(stars == powerupStars)
        {
            _player.PowerUp();
        }
    }

    #endregion

    #region TimeScale

    public void SetTimeScaleStop()
    {
        Time.timeScale = 0;
    }

    public void SetTimeScaleNormal()
    {
        Time.timeScale = 1;
    }

    #endregion

    private void ResetGameSession()
    {
        _levelLoader.LoadMainMenuScene();
        Destroy(gameObject);
    }
}
