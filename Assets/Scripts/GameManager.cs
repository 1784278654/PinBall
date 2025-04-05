using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private Transform ballSpawnPoint;
    [SerializeField] private int maxBalls = 3;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip pointSFX;
    [SerializeField] private AudioClip HitSFX;
    [SerializeField] private AudioClip deathSFX;
    [SerializeField] private AudioClip mikuSFX;

    private GameObject ball;
    public int remainingBalls;
    private UIManager uIManager;

    private void Start()
    {
        uIManager = FindObjectOfType<UIManager>();
        audioSource = GetComponent<AudioSource>();
        remainingBalls = maxBalls;
        SpawnBall();

        //make sure fps is desired 60
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        //r to reset everything
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetGame();
        }

        //if no ball spawn ball
        if(ball == null)SpawnBall();
    }

    private void SpawnBall()
    {
        if (remainingBalls > 0)
        {
            // Clear any existing ball reference first
            if (ball != null)
            {
                Destroy(ball);
            }

            ball = Instantiate(ballPrefab, ballSpawnPoint.position, Quaternion.identity);
            remainingBalls--;
        }
        else
        {
            //no more balls, GG
            SceneManager.Instance.GoToGameOverMenu();
        }
    }

    public void BallLost()
    {
        DeathSFX();
        Destroy(ball);
        uIManager.UpdateLivesDisplay();
    }

    private void ResetGame()
    {
        // Destroy all balls
        Destroy(ball);

        //Reset score and lives
        var UIManager = FindObjectOfType<UIManager>();
        if (UIManager != null)
        {
            UIManager.ResetScoreDisplay();
            remainingBalls = 3;
            UIManager.ResetLivesDisplay();
        }
    }


    //audio
    public void BumpFX()
    {
        audioSource.PlayOneShot(HitSFX);
    }

    public void ScoreSFX()
    {
        audioSource.PlayOneShot(pointSFX);
    }
    public void DeathSFX()
    {
        audioSource.PlayOneShot(deathSFX);
    }
    public void MikuSFX()
    {
        audioSource.PlayOneShot(mikuSFX);
    }
}