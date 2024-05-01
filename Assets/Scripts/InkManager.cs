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
    public bool canContinueToNextLine = false;
    public static InkManager self;
    public Story story;
    public TextMeshProUGUI textBox;
    public TextAsset InkStory;
    public GameObject[] choices;
    public TextMeshProUGUI[] choicesText;

    Mouse mouse = Mouse.current;
    Keyboard kb = Keyboard.current;

    private Coroutine displayLineCoroutine;

    private void Awake()
    {
        canContinueToNextLine = true;
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

        if (story.currentChoices.Count == 0 && canContinueToNextLine && mouse.leftButton.wasPressedThisFrame)
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

    private void HideChoices()
    {
        foreach (GameObject choiceButton in choices)
        {
            choiceButton.gameObject.SetActive(false);
        }
    }

    private IEnumerator SelectFirstChoice()
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }

    public void MakeChoice(int choiceIndex)
    {
        if (canContinueToNextLine)
        {
            story.ChooseChoiceIndex(choiceIndex);
            ContinueStory();
        }
    }

    private IEnumerator DisplayLine(string line)
    {
        
        bool isAddingRichTextTag = false;
        HideChoices();
        canContinueToNextLine = false;
        textBox.text = "";
        foreach (char letter in line.ToCharArray())
        {
            if (letter == '<' || isAddingRichTextTag)
            {
                isAddingRichTextTag = true;
                textBox.text += letter;
                if (letter == '>')
                {
                    isAddingRichTextTag = false;
                }
            }
            else
            {
                textBox.text += letter;
                yield return new WaitForSeconds(typingSpeed);
            }

            
        }
        
        canContinueToNextLine = true;
        DisplayChoices();
    }
}
