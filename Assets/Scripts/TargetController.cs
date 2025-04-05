using UnityEngine;

public class TargetController : MonoBehaviour
{
    [SerializeField] private int scoreValue = 500;

    private UIManager uiManager;
    private GameManager gameManager;

    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            //play SFX
            if(this.gameObject.CompareTag("Migu")) gameManager.MikuSFX();
            else gameManager.ScoreSFX();

            uiManager?.AddScore(scoreValue);
        }
    }
}