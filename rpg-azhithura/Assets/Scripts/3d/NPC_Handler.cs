using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Handler : MonoBehaviour
{

    [SerializeField] List<NPC_Data> Npcs;
    [SerializeField] GameObject NPCPrefab;
    [Space]
    [SerializeField] int NumberOfNpcs;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (NumberOfNpcs > Npcs.Count) NumberOfNpcs = Npcs.Count;
        else if (NumberOfNpcs <= 0) NumberOfNpcs = 1;
        else SpawnNPCs();
    }


    void SpawnNPCs()
    {
        int npcCount = NumberOfNpcs;
        while (npcCount > 0)
        {
            int randomIndex = Random.Range(0, npcCount);
            GameObject character = Instantiate(NPCPrefab, new Vector3(Npcs[randomIndex].SpawnPoint.x, 0, Npcs[randomIndex].SpawnPoint.y), Quaternion.identity);
            character.GetComponent<NPCBehaviour>().NPC_data = Npcs[randomIndex];
            character.GetComponent<NPC>().NPC_data = Npcs[randomIndex];
            character.transform.parent = transform;

            Npcs.RemoveAt(randomIndex);
            npcCount--;
        }
    }
}
