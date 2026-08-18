using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerController Player;
    public NPCSpawner NpcSpawner;
    public TasksAssignerSystem TasksAssigner;
    float dayCount;

    UIManager uim;
    DaynightSystem dnSystem;

    [Space]
    public List<TaskType> TaskTypesOrder;

    void Awake()
    {
        dayCount = 0;

        uim = gameObject.GetComponent<UIManager>();
        dnSystem = GetComponent<DaynightSystem>();

        uim.StartGameButton.onClick.AddListener(StartGame);
        uim.NextDayButton.onClick.AddListener(startDay);
    }

    // ---------------------------------------------------------------

    void StartGame()
    {
        uim.dayText.text = dayCount.ToString();
        NpcSpawner.SpawnNPCs();
        uim.HideMainMenu();
        startDay();
    }


    public void completeDay()
    {
        Player.SwitchStateTo(PlayerState.Stopped);

        dnSystem.isDaynightWorking = false;
        dayCount++;
        uim.dayText.text = dayCount.ToString();

        uim.ShowNextDayPanel();
    }

    public void startDay() // call only at GAME-START & after complete DAY-TIME
    {
        Player.SwitchStateTo(Player.GetPreviousState());

        uim.HideNextDayPanel();
        dnSystem.isDaynightWorking = true;
    }

    public void pauseTimeOnly()
    {
        dnSystem.isDaynightWorking = false;
    }


}
