using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using TMPro;

public class InkManager : MonoBehaviour
{
    private InkConvo convo;
    public GameObject dialoguePanel;
    public bool isDialoguePlaying;
    public static InkManager self;
    public Story story;
    public TextMeshProUGUI textBox;
    public TextAsset InkStory;

    private void Awake()
    {
        self = this; 
        if (self != null)
        {
            Debug.LogError("There's more than one InkManager in the scene.");
        }
    }

    

    void Start()
    {
        isDialoguePlaying = false;
        dialoguePanel.SetActive(false);
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

        ContinueStory();
    }

    private void ContinueStory()
    {
        if (story.canContinue)
        {
            textBox.text = story.Continue();
        }
        else
        {
            ExitInkConvo();
        }
    }
}
