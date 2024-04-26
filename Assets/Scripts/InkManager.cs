using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class InkManager : MonoBehaviour
{
    public float typingSpeed = 0.05f;
    public GameObject dialoguePanel;
    public bool isDialoguePlaying;
    public bool canContinueStory;
    public static InkManager self;
    public Story story;
    public TextMeshProUGUI textBox;
    public TextAsset InkStory;
    public GameObject[] choices;
    public TextMeshProUGUI[] choicesText;

    private bool canContinueLine = false;

    private Coroutine displayLineCoroutine;

    private void Awake()
    {
     
        if (self != null)
        {
            Debug.LogError("There's more than one InkManager in the scene. " +gameObject.name);
        }
        self = this;
    }
    
    void Start()
    {
        isDialoguePlaying = false;
        dialoguePanel.SetActive(false);

        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }

    void Update()
    {
        if(!isDialoguePlaying)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ContinueStory();
        }
    }

   public void ExitInkConvo()
   {
        isDialoguePlaying = false;
        dialoguePanel.SetActive(false);
        textBox.text = "";
   }

    public void StartInkConvo(TextAsset InkFileName)
    {
        Debug.Log("Manager Is starting inkfile");
        story = new Story(InkFileName.text);
        isDialoguePlaying = true;
        dialoguePanel.SetActive(true);
        DisplayChoices();
    }

    private void ContinueStory()
    {
        if (story.canContinue)
        {
            if (displayLineCoroutine != null)
            {
                StopCoroutine(displayLineCoroutine);
            }
            canContinueStory = true;
            StartCoroutine(DisplayLine(story.Continue()));
            DisplayChoices();
        }
        else
        {
            ExitInkConvo();
        }
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = story.currentChoices;

        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("Too many choices for the UI to support. Number of choices: " + currentChoices.Count);
        }

        int index = 0;
        foreach (Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }
        for (int i = index; i < choices.Length; i++) 
        {
            choices[i].gameObject.SetActive(false);
        }

        StartCoroutine(SelectFirstChoice());
    }

    private IEnumerator SelectFirstChoice()
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }

    public void MakeChoice(int choiceIndex)
    {
        if (canContinueStory == true)
        {
            story.ChooseChoiceIndex(choiceIndex);
            ContinueStory();

        }
    }

    private IEnumerator DisplayLine(string line)
    {
        textBox.text = "";

        foreach (char letter in line.ToCharArray())
        {
            textBox.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
