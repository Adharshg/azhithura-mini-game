using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("Main Menu Assets")]
    public GameObject MainMenuPanel;
    public Button StartGameButton;

    [Header("Next Day Menu Assets")]
    public GameObject NextDayPanel;

    [Space]
    public TMP_Text dayText;

    [Header("Day-Night System Assets")]
    public GameObject NighttimeFadePanel;
    public Slider DayNightIndicator;
    public Button NextDayButton;

    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        ShowMainMenu();
    }

    void Update()
    {
        
    }

    public void ShowMainMenu()
    {
        GetComponent<GameManager>().player.FreezePlayer();
        NighttimeFadePanel.SetActive(false);
        NextDayPanel.SetActive(false);
        MainMenuPanel.SetActive(true);
    }

    public void HideMainMenu()
    {
        NighttimeFadePanel.SetActive(true);
        NextDayPanel.SetActive(false);
        MainMenuPanel.SetActive(false);
    }

    public void ShowNextDayPanel()
    {
        NextDayPanel.SetActive(true);
    }

    public void HideNextDayPanel()
    {
        NextDayPanel.SetActive(false);
    }
}
