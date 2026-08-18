using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class StatsHandler : MonoBehaviour
{
    public static StatsHandler Singleton;

    public List<GameObject> SpawnedNpcsList;
    public List<Task> TasksList;

    public GameManager gm;

    void Start()
    {

        if (Singleton != null)
            Destroy(this.gameObject);
        else
        {
            Singleton = this;
            DontDestroyOnLoad(gameObject);

            if (gm == null) gm = UIManager.Instance.GetComponent<GameManager>();

            // Initial setup of the game.
            UIManager.Instance.ShowMainMenu();
        }
    }

    // ---------------------------------------------------------------

    void Update()
    {
        if (gm == null) gm = UIManager.Instance.GetComponent<GameManager>();
    }

    public void StoreNPCs()
    {

    }
}
