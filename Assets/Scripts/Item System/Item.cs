using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Shadow of a Trick/Item System", order = 1)]
public class Item : ScriptableObject
{
    [Tooltip("Nome do item.")]
    [SerializeField]
    string _itemName;

    [Tooltip("Descrição do item (campo opciona).")]
    [TextArea]
    [SerializeField]
    string _itemDescription;

    [Tooltip("Possível diálogo quando obtem o item.")]
    [SerializeField]
    Dialogue _dialogueGetItem;

    [Tooltip("Possível diálogo quando não tem o item.")]
    [SerializeField]
    Dialogue _dialogueDontHasItem;

    [Tooltip("Possível diálogo quando usa o item.")]
    [SerializeField]
    Dialogue _dialogueHasItem;

    public string GetItemName()
    {
        return _itemName;
    }

    public string GetItemDescription()
    {
        return _itemDescription;
    }

    public Dialogue GetDialogue()
    {
        return _dialogueGetItem;
    }

    public Dialogue GetDialogueDontHasItem()
    {
        return _dialogueDontHasItem;
    }

    public Dialogue GetDialogueHasItem()
    {
        return _dialogueHasItem;
    }
}