using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class NPCSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> npcsMasterList;
    List<GameObject> npcsTempList;

    [SerializeField] int spawnVolume;
    [SerializeField] GameObject SpawnedNpcs;

    [Space]
    [SerializeField] GameObject Locations;


    // ---------------------------------------------------------------


    public void SpawnNPCs()
    {
        if (StatsHandler.Singleton.SpawnedNpcsList.Count == 0)
            npcsTempList = GetRandomSubset<GameObject>(npcsMasterList, spawnVolume);

        Debug.Log("Temp list count: " + npcsTempList.Count);
        // Spawning characters into scene
        foreach (GameObject npc in npcsTempList)
        {
            GameObject NewNpc = Instantiate(npc, Locations.transform.Find(npc.GetComponent<NPCdata>().HomeLocation).transform.position, Quaternion.identity, SpawnedNpcs.transform);
            if (npc.GetComponent<NPCdata>().CharacterName != "")
            {
                npc.name = npc.GetComponent<NPCdata>().CharacterName;
                NewNpc.name = npc.GetComponent<NPCdata>().CharacterName;
            }

            StatsHandler.Singleton.SpawnedNpcsList.Add(NewNpc);
        }
        Debug.Log(StatsHandler.Singleton.TasksList.Count);

        // Setting up or updating tasks for all characters
        if (StatsHandler.Singleton.TasksList.Count == 0)
            StatsHandler.Singleton.gm.TasksAssigner.CreateTasks();

        //NewNpc.GetComponent<NPCdata>().;
        

    }

    public List<T> GetRandomSubset<T>(List<T> originalList, int subsetSize)
    {
        int count = Mathf.Min(subsetSize, originalList.Count);

        List<T> copyList = new List<T>(originalList);
        List<T> subset = new List<T>();

        for (int i = 0; i < count; i++)
        {
            int randomIndex = Random.Range(i, copyList.Count);

            T temp = copyList[i];
            copyList[i] = copyList[randomIndex];
            copyList[randomIndex] = temp;

            subset.Add(copyList[i]);
        }

        return subset;

    }

}
