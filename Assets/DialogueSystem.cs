using Ink.Runtime;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public TextAsset text;
    private Story story;
    public List<Sprite> CharacterSprites, BGs;
    public TextMeshProUGUI dialogueBox;
    public Button buttonPrefab;
    public Image bg, characterSprite;

    // Start is called before the first frame update
    void Start()
    {
        story = new Story(text.text);
        story.variablesState["Name"] = NameManager.save_Names.userName; ;
        LoadStory();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            LoadStory();
        }
    }
    void LoadStory()
    {
        if (story.canContinue)
        {
            EraseButtons();
            dialogueBox.text = story.Continue();
            switch (story.variablesState.GetVariableWithName("ActiveCharacter").ToString())
            {
                case "Kathrin":
                    characterSprite.gameObject.SetActive(true);
                    characterSprite.sprite = CharacterSprites[0];
                    break;
                case "Highmourn":
                    characterSprite.gameObject.SetActive(true);
                    characterSprite.sprite = CharacterSprites[1];
                    break;
                case "Aurum":
                    characterSprite.gameObject.SetActive(true);
                    characterSprite.sprite = CharacterSprites[2];
                    break;
                case "Balberos":
                    characterSprite.gameObject.SetActive(true);
                    characterSprite.sprite = CharacterSprites[3];
                    break;
                case "Tarkar":
                    characterSprite.gameObject.SetActive(true);
                    characterSprite.sprite = CharacterSprites[4];
                    break;
                case "Idrid":
                    characterSprite.gameObject.SetActive(true);
                    characterSprite.sprite = CharacterSprites[5];
                    break;
                case "Valthris":
                    characterSprite.gameObject.SetActive(true);
                    characterSprite.sprite = CharacterSprites[6];
                    break;
                case "Mairead":
                    characterSprite.gameObject.SetActive(true);
                    characterSprite.sprite = CharacterSprites[7];
                    break;
                case "Ghostmourn":
                    characterSprite.gameObject.SetActive(true);
                    characterSprite.sprite = CharacterSprites[8];
                    break;
                default:
                    characterSprite.gameObject.SetActive(false);
                    break;
            }
            switch (story.variablesState.GetVariableWithName("ActiveLocation").ToString())
            {
                case "Outside":
                    bg.sprite = BGs[0];
                    break;
                case "Ballroom":
                    bg.sprite = BGs[1];
                    break;
                case "Sanctum":
                    bg.sprite = BGs[2];
                    break;
                case "EndOfDay":
                    bg.sprite = BGs[3];
                    break;
                default:
                    break;
            }
            foreach (Choice choice in story.currentChoices)
            {
                Button choiceButton = Instantiate(buttonPrefab) as Button;
                choiceButton.transform.SetParent(this.transform, false);
                Debug.Log(choice.text);
                TextMeshProUGUI choiceText = choiceButton.GetComponentInChildren<TextMeshProUGUI>();
                choiceText.text = choice.text;

                choiceButton.onClick.AddListener(delegate { choiceTime(choice); LoadStory(); LoadStory(); });
            }
        }
    }

    void EraseButtons()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            Destroy(this.transform.GetChild(i).gameObject);
        }
    }
    void choiceTime(Choice choice)
    {
        story.ChooseChoiceIndex(choice.index);
    }
}
