using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerController player;
    float dayCount;

    UIManager uim;
    DaynightSystem dnSystem;

    void Awake()
    {
        dayCount = 0;

        uim = gameObject.GetComponent<UIManager>();
        dnSystem = GetComponent<DaynightSystem>();

        uim.StartGameButton.onClick.AddListener(StartGame);
        uim.NextDayButton.onClick.AddListener(startDay);
    }

    void StartGame()
    {
        uim.dayText.text = dayCount.ToString();
        uim.HideMainMenu();
        startDay();
    }

    void Update()
    {
        
    }

    public void completeDay()
    {
        player.FreezePlayer();

        dnSystem.isDaynightWorking = false;
        dayCount++;
        uim.dayText.text = dayCount.ToString();

        uim.ShowNextDayPanel();
    }

    public void startDay() // call only at GAME-START & after complete DAY-TIME
    {
        player.UnfreezePlayer();

        uim.HideNextDayPanel();
        dnSystem.isDaynightWorking = true;
    }

    public void pauseTimeOnly()
    {
        dnSystem.isDaynightWorking = false;
    }


}
