using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class StatsHandler : MonoBehaviour
{
    public static StatsHandler singleton;

    public List<GameObject> SpawnedNpcsList;

    GameManager gm;

    void Start()
    {

        if (singleton != null)
            Destroy(this.gameObject);
        else
        {
            singleton = this;
            DontDestroyOnLoad(gameObject);

            if (gm == null) GameObject.FindGameObjectWithTag("GameManager");

            // Initial setup of the game.
            UIManager.Instance.ShowMainMenu();
        }
    }

    // ---------------------------------------------------------------

    void Update()
    {
        if (gm == null) GameObject.FindGameObjectWithTag("GameManager");
    }

    public void StoreNPCs()
    {

    }
}
