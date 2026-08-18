using UnityEngine;

public class NPCController : MonoBehaviour
{


    public void checkTask()
    {
        if (GetComponent<NPCdata>().DailyTasks.Count != 0)
        {
            TaskType[] typeList = new TaskType[GetComponent<NPCdata>().DailyTasks.Count];
            int i = 0;
            foreach(Task task in GetComponent<NPCdata>().DailyTasks)
            {
                if (!task.TaskDone)
                {
                    typeList[i] = task.Type;
                    i++;
                }
            }

            UIManager.Instance.OpenInteractionMenu(typeList);
        }
    }
}
