using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Ink.Runtime;



public class InkConvo : MonoBehaviour
{
    public TextAsset InkStory;
    public TextMeshProUGUI textBox;
    public Story story;
    private TextMeshPro textPrefab;

    public void Awake()
    {
        InkManager.self.StartInkConvo(InkStory);
        story = new Story(InkStory.text);
    }
    public void RunInk()
    {     
        
        while (story.canContinue)
        {
            string text = story.Continue();
            text.Trim();
            ContentView(text);
        }

    }

    void ContentView(string text)
    {
        TextMeshPro storyText = Instantiate(textPrefab);
        storyText.text = text;
    }
}
