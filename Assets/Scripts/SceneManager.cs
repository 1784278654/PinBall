using UnityEngine;

public class SceneManager : MonoBehaviour
{
    private static SceneManager _instance;
    public static SceneManager Instance => _instance;

    private void Awake()
    {
        if (_instance != null && _instance != this) Destroy(this.gameObject);
        else
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }

        // Set target frame rate to 60 FPS
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape)) ReturnToMainMenu();
    }

    //SceneManager functions
    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void ReturnToMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void GoToGameOverMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }
}
