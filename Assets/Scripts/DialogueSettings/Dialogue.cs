using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "Shadow of a Trick/Dialogue System", order = 1)]
public class Dialogue : ScriptableObject
{
    [Tooltip("Sprite o perssonagem que está falando.")]
    
    [SerializeField] 
    Sprite _speakerPortrait;

    [Tooltip("Sprite que representa a caixa de diálogo.")]
    
    [SerializeField] 
    Sprite _dialogueBox;

    [Tooltip("Texto do diálogo.")]

    [TextArea]
    [SerializeField] 
    string _speakText;
    
    [Tooltip("O pr�xio di�logo.")]
    
    [SerializeField] 
    Dialogue _nextDialogue;
    
    public enum Side 
    {
        [InspectorName("Lado Esquerdo")] Left, 
        [InspectorName("Lado Direito")] Right 
    }
    
    [Tooltip("Qual o lado que o sprite do personagem ir� aparecer.")]
    
    [SerializeField] 
    Side _protraitSide;

    public Sprite GetSpeakerPortrait()
    {
        return _speakerPortrait;
    }

    public Sprite GetDialogueBox()
    {
        return _dialogueBox;
    }

    public string GetSpeakText()
    {
        return _speakText;
    }

    public Dialogue GetNextDialogue()
    {
        return _nextDialogue;
    }

    public Side GetSpeakerSide()
    {
        return _protraitSide;
    }
}