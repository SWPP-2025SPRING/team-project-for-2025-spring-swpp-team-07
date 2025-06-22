using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndGameController : MonoBehaviour
{
    public GameObject endGameUI;
    public GameObject finalPanel;
    public TextMeshProUGUI finalTimeText;

    [SerializeField]
    private BGMController bgmController;
    private HUDController hud;
    private bool hasEnded = false;

    void Start()
    {
        if (endGameUI != null)
            endGameUI.SetActive(false);

        hud = FindObjectOfType<HUDController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (!hasEnded && other.CompareTag("Player"))
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        bgmController.PlayGameClearBGM();

        hasEnded = true;
        Time.timeScale = 0f;

        if (endGameUI != null)
            endGameUI.SetActive(true);
            finalPanel.SetActive(true);

        if (finalTimeText != null && hud != null)
            finalTimeText.text = hud.timeText.text;

        KartController kartController = FindObjectOfType<KartController>();
        PlayerData playerData = kartController.GetPlayerData();
        playerData.Save((int)(hud.GetElapsedTime() * 1000));
    }
}
