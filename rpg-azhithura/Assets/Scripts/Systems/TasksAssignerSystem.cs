using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class TasksAssignerSystem : MonoBehaviour
{
    [SerializeField] int tasksPerDay;

    List<GameObject> AvbleChars;


    void Start()
    {

    }

    public void CreateTasks()
    {
        if (AvbleChars == null)
            if (StatsHandler.Singleton.SpawnedNpcsList != null) AvbleChars = StatsHandler.Singleton.SpawnedNpcsList;

        List<GameObject> tempChars = StatsHandler.Singleton.gm.NpcSpawner.GetRandomSubset<GameObject>(AvbleChars, tasksPerDay);

        foreach (GameObject npc in tempChars)
        {
            Task newTask = Task.Create(npc.GetComponent<NPCdata>());
            StatsHandler.Singleton.TasksList.Add(newTask);
            npc.GetComponent<NPCdata>().DailyTasks.Add(newTask);

            Debug.Log("adding task: " + StatsHandler.Singleton.TasksList[StatsHandler.Singleton.TasksList.Count - 1].Type + " to " + npc.name);
        }

        UIManager.Instance.SetUpToDoList();
    }

    public void TaskDone(NPCdata NPC)
    {
        if (StatsHandler.Singleton.TasksList.Exists(npc => npc.npcdata.CharacterName == NPC.CharacterName))
        {
            StatsHandler.Singleton.TasksList.Find(npc => npc.npcdata.CharacterName == NPC.CharacterName).OnTaskDone();
        }
        else
        {
            Debug.Log("No tasks with " + NPC.CharacterName);
        }
        // Update Task-list UI
    }
}
