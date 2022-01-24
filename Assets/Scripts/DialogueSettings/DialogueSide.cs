using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueSide : MonoBehaviour
{
    [SerializeField] 
    GameObject dialogueBox;
    
    [SerializeField] 
    GameObject speakerPortrait;
    
    [SerializeField] 
    GameObject speakerText;
    
    [SerializeField] 
    GameObject nextDialogueIndicator;

    public void SetDialogueBox(Sprite dialogueBoxSprite)
    {
        dialogueBox.GetComponent<Image>().sprite = dialogueBoxSprite;
    }

    public void SetSpeakerPortrait(Sprite speakerPortraitSprite)
    {
        speakerPortrait.GetComponent<Image>().sprite = speakerPortraitSprite;
    }

    public void SetSpeakerText(string speakerTextString)
    {
        speakerText.GetComponent<TMP_Text>().SetText(speakerTextString);
    }

    public void HasMoreDialogue(bool moreDialogue)
    {
        nextDialogueIndicator.SetActive(moreDialogue);
    }
}