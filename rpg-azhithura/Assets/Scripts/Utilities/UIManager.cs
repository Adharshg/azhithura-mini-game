using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    [Header("In-GameUI")]
    public GameObject InteractionMenuPanel;
    public GameObject ToDoListPanel;
    public Button TaskButton;
    public Button ToDoListButton;

    [Header("Inventory Assets")]
    public GameObject InventoryPanel;
    public GameObject TaskRow;
    public Button CloseButton;

    [Header("Day-Night System Assets")]
    public GameObject NighttimeFadePanel;
    public Slider DayNightIndicator;
    public Button NextDayButton;


    void Awake()
    {
        Instance = this;
    }

    // ---------------------------------------------------------------

    public void ShowMainMenu()
    {
        GetComponent<GameManager>().Player.SwitchStateTo(PlayerState.Stopped);
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

    public void ShowGame()
    {
        MainMenuPanel.SetActive(false);
        NextDayPanel.SetActive(false);
        InteractionMenuPanel.SetActive(false);

        NighttimeFadePanel.SetActive(true);
    }

    public void ShowNextDayPanel()
    {
        NextDayPanel.SetActive(true);
    }

    public void HideNextDayPanel()
    {
        NextDayPanel.SetActive(false);
    }

    public void OpenInteractionMenu(TaskType[] types)
    {
        InteractionMenuPanel.SetActive(true);
        foreach (TaskType type in types)
        {
            if (type == TaskType.Talk || type == TaskType.Remind)
            {
                // Need to open dialogue panel
            }
            else if (type == TaskType.Steal)
            {
                // Need to open 
            }

            Button btn = Instantiate(TaskButton, InteractionMenuPanel.transform.GetChild(0).transform);
            btn.onClick.AddListener(() => SceneLoader(type));
            btn.transform.GetChild(0).GetComponent<TMP_Text>().text = type.ToString();
        }
        float height = 120 + (types.Length * 90);
        InteractionMenuPanel.GetComponent<RectTransform>().sizeDelta = new Vector2(160, height);
    }

    public void HideInteractionMwnu()
    {
        //InteractionMenuPanel.SetActive(false);
        foreach(Transform child in InteractionMenuPanel.transform.GetChild(0).transform)
        {
            Destroy(child);
        }
        InteractionMenuPanel.GetComponent<RectTransform>().sizeDelta = new Vector2(160, 0);
    }

    public void SceneLoader(TaskType type)
    {
        SceneManager.LoadScene(StatsHandler.Singleton.gm.TaskTypesOrder.FindIndex(0, x => x == type));
    }

}
