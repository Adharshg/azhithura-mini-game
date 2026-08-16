using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class NPCSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> npcsMasterList;

    [SerializeField] int spawnVolume;
    [SerializeField] GameObject SpawnedNpcs;

    [Space]
    [SerializeField] GameObject Locations;


    // ---------------------------------------------------------------


    public void SpawnNPCs()
    {
        if (StatsHandler.singleton.SpawnedNpcsList.Count == 0)
            StatsHandler.singleton.SpawnedNpcsList = GetRandomSubset<GameObject>(npcsMasterList, spawnVolume);

        foreach (GameObject npc in StatsHandler.singleton.SpawnedNpcsList)
        {
            GameObject NewNpc = Instantiate(npc, Locations.transform.Find(npc.GetComponent<NPCdata>().HomeLocation).transform.position, Quaternion.identity, SpawnedNpcs.transform);
            if (npc.GetComponent<NPCdata>().CharacterName != "") NewNpc.name = npc.GetComponent<NPCdata>().CharacterName;
        }
    }

    public List<T> GetRandomSubset<T>(List<T> originalList, int subsetSize)
    {
        // Clamp the subset size so it doesn't exceed the list bounds
        int count = Mathf.Min(subsetSize, originalList.Count);

        // Create a copy so we don't modify the original list
        List<T> copyList = new List<T>(originalList);
        List<T> subset = new List<T>();

        for (int i = 0; i < count; i++)
        {
            // Pick a random remaining index
            int randomIndex = Random.Range(i, copyList.Count);

            // Swap the element into the current position
            T temp = copyList[i];
            copyList[i] = copyList[randomIndex];
            copyList[randomIndex] = temp;

            // Add the swapped element to our subset
            subset.Add(copyList[i]);
        }

        return subset;

    }

}
