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
    public Button TaskButton;

    [Header("To Do List Assets")]
    public GameObject ToDoListPanel;
    public Button ToDoListButton;
    public GameObject TaskRow;
    public Button ToDoCloseButton;

    [Header("Inventory Assets")]
    public GameObject InventoryPanel;

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

        HideToDoList();

        NighttimeFadePanel.SetActive(false);
        NextDayPanel.SetActive(false);

        MainMenuPanel.SetActive(true);
    }

    public void HideMainMenu()
    {
        NighttimeFadePanel.SetActive(true);

        HideToDoList();

        NextDayPanel.SetActive(false);
        MainMenuPanel.SetActive(false);
    }

    public void ShowGame()
    {
        MainMenuPanel.SetActive(false);
        NextDayPanel.SetActive(false);

        HideInteractionMenu();
        HideToDoList();

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

    public void HideInteractionMenu()
    {
        InteractionMenuPanel.SetActive(false);
        foreach(Transform child in InteractionMenuPanel.transform.GetChild(0).transform)
        {
            Destroy(child.gameObject);
        }
        InteractionMenuPanel.GetComponent<RectTransform>().sizeDelta = new Vector2(160, 120);
    }


    #region To-do list

    public void SetUpToDoList()
    {
        Debug.Log("Set up list");
        if (ToDoListPanel.transform.GetChild(0).childCount == 0)
        {
            if (StatsHandler.Singleton.TasksList.Count > 0)
            {
                foreach (Task t in StatsHandler.Singleton.TasksList)
                {
                    t.CreateTaskOnList();
                }
            }
        }
    }


    public void ClearToDoList()
    {
        Debug.Log("Clear list");

        foreach (Transform T in ToDoListPanel.transform.GetChild(0).transform)
        {
            Destroy(T.gameObject);
        }
    }

    public void ShowToDoList()
    {
        ToDoListPanel.SetActive(true);
        ToDoListButton.gameObject.SetActive(false);
    }

    public void HideToDoList()
    {
        ToDoListButton.gameObject.SetActive(true);
        ToDoListPanel.SetActive(false);
    }

    public Toggle AddTaskToList(string ToDoName)
    {
        Debug.Log("Add item to list");
        GameObject ToDoItem = Instantiate(TaskRow, ToDoListPanel.transform.GetChild(0).transform);
        ToDoItem.transform.GetChild(0).GetChild(1).GetComponent<TMP_Text>().text = ToDoName;
        return ToDoItem.transform.GetChild(0).GetComponent<Toggle>();
    }

    public void CrossTaskOnList(int index)
    {

    }

    #endregion



    public void SceneLoader(TaskType type)
    {
        SceneManager.LoadScene(StatsHandler.Singleton.gm.TaskTypesOrder.FindIndex(0, x => x == type));
    }

}
