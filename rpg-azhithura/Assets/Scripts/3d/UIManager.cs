using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("Dialogues")]
    [SerializeField] GameObject dialogueBox;
    [SerializeField] TMP_Text dialogueText;
    [Header("Options")]
    [SerializeField] GameObject optionsArea;
    [SerializeField] GameObject optionsPrefab;

    private void Start()
    {
        Instance = this;
        ClearDialogue();
    }

    public void ShowDialogue(string dlg)
    {
        ClearChoices();
        dialogueBox.SetActive(true);
        dialogueText.text = dlg;

        //Invoke("ClearDialogue",Mathf.Ceil(countWords(dlg) * 0.5f));
    }

    public void ShowChoiceBtn(string optionName, int ind)
    {
        GameObject choicebtn = Instantiate(optionsPrefab, optionsArea.transform);
        choicebtn.transform.GetChild(0).GetComponent<TMP_Text>().text = optionName;

        choicebtn.GetComponent<Button>().onClick.AddListener(() => DialogueManager.Instance.SelectChoice(ind));
    }

    public void ShowOkayBtn()
    {
        GameObject choicebtn = Instantiate(optionsPrefab);
        choicebtn.transform.SetParent(optionsArea.transform, false);
        choicebtn.transform.GetChild(0).GetComponent<TMP_Text>().text = "Ok";
        choicebtn.GetComponent<Button>().onClick.AddListener(DialogueManager.Instance.EndDialogue);
    }

    public void ClearDialogue()
    {
        foreach (Transform child in optionsArea.transform) Destroy(child.gameObject);

        dialogueText.text = "";
        dialogueBox.SetActive(false);
    }

    public void ClearChoices()
    {
        foreach (Transform child in optionsArea.transform)
            Destroy(child.gameObject);
    }

    int countWords(string dlg)
    {
        int cnt = 0;
        foreach (char s in dialogueText.text)
        {
            if (s == ' ')
            {
                cnt++;
            }
        }
        return cnt + 1;
    }

}
