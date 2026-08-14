using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    private DialogueData currentDialogue;
    private int currentNode;

    public bool IsDialogueOpen { get; private set; }

    void Awake()
    {
        Instance = this;
    }

    public void StartDialogue(DialogueData dialogue)
    {
        IsDialogueOpen = true;

        PlayerBehaviour.Instance.CanMove = false;
        PlayerBehaviour.Instance.CanInteract = false;

        currentDialogue = dialogue;
        currentNode = 0;

        ShowCurrentNode();
    }

    public void EndDialogue()
    {
        IsDialogueOpen = false;

        currentDialogue = null;

        UIManager.Instance.ClearDialogue();

        PlayerBehaviour.Instance.CanMove = true;
        PlayerBehaviour.Instance.CanInteract = true;

        if (PlayerBehaviour.Instance.CurrentNPC != null) PlayerBehaviour.Instance.CurrentNPC.RefreshCue();
    }

    void ShowCurrentNode()
    {
        Debug.Log($"Current Node: {currentNode}");
        Debug.Log($"Node Count: {currentDialogue.nodes.Count}");

        DialogueNode node = null;

        for (int i = currentNode; i < currentDialogue.nodes.Count; i++)
        {
            bool valid = true;

            foreach (var condition in currentDialogue.nodes[i].conditions)
            {
                if (!condition.IsMet())
                {
                    valid = false;
                    break;
                }
            }

            if (valid)
            {
                currentNode = i;
                node = currentDialogue.nodes[i];
                break;
            }
        }

        if (node == null)
        {
            EndDialogue();
            return;
        }

        UIManager.Instance.ShowDialogue(node.text);

        if (node.choices.Count <= 0)
        {
            UIManager.Instance.ShowOkayBtn();
            return;
        }

        UIManager.Instance.ClearChoices();

        for (int i = 0; i < node.choices.Count; i++)
            UIManager.Instance.ShowChoiceBtn(node.choices[i].choiceText, i);
    }

    public void SelectChoice(int index)
    {
        DialogueChoice choice = currentDialogue.nodes[currentNode].choices[index];

        foreach (var action in choice.actions) action.Execute();

        currentNode = choice.nextNode;
        ShowCurrentNode();
    }
}