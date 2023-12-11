using UnityEngine;
using System.Collections;
using TMPro;
using System;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timeTxt;
    [SerializeField] TextMeshProUGUI healthTxt;
    [SerializeField] Health planetHealth;
    [SerializeField] GameObject pauseScreen;
    [SerializeField] GameObject gameOverScreen;

    [Header("Buttons")]
    [SerializeField] Button pauseBtn;
    [SerializeField] Button resumeBtn;
    [SerializeField] Button giveUpBtn;
    [SerializeField] Button resumeGameOverBtn;

    private void Start()
    {
        planetHealth.OnHealthChanges += UpdateHealth;
        UpdateHealth();
        pauseBtn.onClick.AddListener(OnPausePressed);
        resumeBtn.onClick.AddListener(OnResumePressed);
        giveUpBtn.onClick.AddListener(OnGiveUpPressed);
        resumeGameOverBtn.onClick.AddListener(OnGiveUpPressed);
    }

    private void OnEnable()
    {
        timeTxt.text = "00:00";
        StartCoroutine(nameof(TimerUpdate));
    }

    private void OnDisable()
    {
        StopCoroutine(nameof(TimerUpdate));
    }

    private void UpdateHealth()
    {
        healthTxt.text = ((int)planetHealth.CurrentHealth).ToString() + "/" + ((int)planetHealth.MaxHealth).ToString();
    }

    public void OpenGameOverPage()
    {
        pauseScreen.SetActive(false);
        gameOverScreen.SetActive(true);
        Time.timeScale = 0;
    }

    private void OnPausePressed()
    {
        pauseScreen.SetActive(true);
        Time.timeScale = 0;
    }

    private void OnResumePressed()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1;
    }

    private void OnGiveUpPressed()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        GameManager.instance.GameOver();
    }

    IEnumerator TimerUpdate()
    {
        int seconds = 0;
        while (true)
        {
            seconds++;

            TimeSpan result = TimeSpan.FromSeconds(seconds);
            timeTxt.text = result.ToString("mm':'ss");

            yield return new WaitForSeconds(1);
        }
    }

}
