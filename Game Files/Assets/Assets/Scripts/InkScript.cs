using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InkScript : MonoBehaviour
{
    public TextAsset inkJSON;
    private Story story;
    public TextMeshProUGUI textPrefab;
    public Button buttonPrefab;
    public Canvas mainStory;
    public Canvas names;


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
        if (Input.anyKeyDown && story.canContinue)
        {
            refreshUI();
            //Debug.Log("anykey");
        }
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

        string text = loadStoryChunk();

        List<string> tags = story.currentTags;

        //if (tags.Count > 0)
        //{
        //    loadNames();
        //}

        foreach (string nametags in story.currentTags)
        {
            //Inster nametags here to be shown
            if (nametags == "Barny" || nametags == "marnie" || nametags == "Keth")
            {
                loadNames();
            }
        }

        storyText.text = text;
        storyText.transform.SetParent(mainStory.transform, false);

        //Debug.Log(loadStoryChunk());

        foreach (Choice choice in story.currentChoices)
        {
            Button choiceButton = Instantiate(buttonPrefab) as Button;
            TextMeshProUGUI choiceText = choiceButton.GetComponentInChildren<TextMeshProUGUI>();
            choiceText.text = choice.text;
            choiceButton.transform.SetParent(mainStory.transform, false);
            choiceButton.onClick.AddListener(delegate {
                chooseStoryChoice(choice);
            });
        }

        void loadNames()
        {
            TextMeshProUGUI nameText = Instantiate(textPrefab) as TextMeshProUGUI;
            nameText.text = "<b>" + tags[0] + "</b>";
            nameText.transform.SetParent(names.transform, false);
        }
    }

    void eraseUI()
    {
        for(int i = 0; i < mainStory.transform.childCount; i++)
        {
            Destroy(mainStory.transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < names.transform.childCount; i++)
        {
            Destroy(names.transform.GetChild(i).gameObject);
        }
    }

    string loadStoryChunk()
    {
        string text = "";

        if (story.canContinue)
        {
            text = story.Continue();
        }

        return text;
    }
}
