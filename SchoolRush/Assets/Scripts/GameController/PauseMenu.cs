using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    private bool isPaused = false;

    private AudioManager am;

    void Start()
    {
        if (pauseMenuUI != null)
            pauseMenuUI.SetActive(false);

        am = AudioManager.Instance;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            am.PlayOneShot(am.pauseAudio);

            if (isPaused) Resume();
            else Pause();
        }
    }

    public void Pause()
    {
        if (pauseMenuUI != null)
            pauseMenuUI.SetActive(true);

        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Resume()
    {
        if (pauseMenuUI != null)
            pauseMenuUI.SetActive(false);

        Time.timeScale = 1f;
        isPaused = false;
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;  
        SceneManager.LoadScene("MainScene");
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        Scene current = SceneManager.GetActiveScene();
        SceneManager.LoadScene(current.name);
    }
}