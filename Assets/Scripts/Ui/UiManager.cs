using UnityEngine;
using UnityEngine.UI;

public class UiManager : Singleton<UiManager>
{
    [Header("====== UI Panel ======")]
    public GameObject mainMenuUI;
    public GameUI gameUI;

    [Header("====== Buttons ======")]
    public Button playBtn;

    void Start()
    {
        ShowMenuUI();
        playBtn.onClick.AddListener(OnPlayClick);

        GameManager.instance.OnGameStart += ShowGameUI;
        GameManager.instance.OnGameOver += ShowMenuUI;
    }

    private void OnPlayClick()
    {
        GameManager.instance.StartGame();
    }

    public void ShowMenuUI()
    {
        mainMenuUI.SetActive(true);
        gameUI.gameObject.SetActive(false);      
    }

    public void ShowGameUI()
    {
        mainMenuUI.SetActive(false);
        gameUI.gameObject.SetActive(true);
    }

}
