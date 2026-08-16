using UnityEngine;
using UnityEngine.SceneManagement;

public class StatsHandler : MonoBehaviour
{
    public static StatsHandler singleton;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (singleton != null)
            Destroy(this.gameObject);
        else
            singleton = this;

    }

    // Update is called once per frame
    void Update()
    {

    }

}
