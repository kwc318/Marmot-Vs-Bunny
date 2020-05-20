using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InkScript : MonoBehaviour
{
    public TextAsset inkJSON;
    private Story story;
    public TextMeshProUGUI textPrefab;
    public Button buttonPrefab;

    // Start is called before the first frame update
    void Start()
    {
        story = new Story(inkJSON.text);
        eraseUI();
        refreshUI();
    }

    // Update is called once per frame
    void Update()
    {
        //refreshUI();
    }

    void chooseStoryChoice(Choice choice)
    {
        story.ChooseChoiceIndex(choice.index);
        refreshUI();
    }

    void refreshUI()
    {
        eraseUI();

        TextMeshProUGUI storyText = Instantiate(textPrefab) as TextMeshProUGUI;
        storyText.text = loadStoryChunk();
        storyText.transform.SetParent(this.transform, false);

        Debug.Log(loadStoryChunk());

        foreach (Choice choice in story.currentChoices)
        {
            Button choiceButton = Instantiate(buttonPrefab) as Button;
            TextMeshProUGUI choiceText = choiceButton.GetComponentInChildren<TextMeshProUGUI>();
            choiceText.text = choice.text;
            choiceButton.transform.SetParent(this.transform, false);
            choiceButton.onClick.AddListener(delegate {
                chooseStoryChoice(choice);
            });
        }
    }

    void eraseUI()
    {
        for(int i = 0; i < this.transform.childCount; i++)
        {
            Destroy(this.transform.GetChild(i).gameObject);
        }
    }

    string loadStoryChunk()
    {
        string text = "";

        if (story.canContinue)
        {
            text = story.ContinueMaximally();
        }

        return text;
    }
}
