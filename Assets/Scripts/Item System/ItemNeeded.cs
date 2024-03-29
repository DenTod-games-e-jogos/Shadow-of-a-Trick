using UnityEngine;

public class ItemNeeded : MonoBehaviour
{
    [SerializeField]
    Item _itemNeeded;

    [SerializeField]
    GameObject[] gameObjectsToDistroy;

    Dialogue _dialogueHasItem;
    
    Dialogue _dialogueDontHasItem;
    
    Dialogue _dialogue;

    GameObject _sceneManager;
    
    InventoryManager _inventoryManager;

    GameObject _dialogueSystem;
    
    DialogueManager _dialogueManager;

    void Awake()
    {
        _dialogueManager = _dialogueSystem.GetComponent<DialogueManager>();
        
        _inventoryManager = _sceneManager.GetComponent<InventoryManager>();
    }

    void Start()
    {
        _sceneManager = GameObject.FindWithTag("Scene Manager");
    
        _dialogueHasItem = _itemNeeded.GetDialogueHasItem();
        
        _dialogueDontHasItem = _itemNeeded.GetDialogueDontHasItem();

        _dialogueSystem = GameObject.FindWithTag("Dialogue System");
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _dialogue = _inventoryManager.HasItemInInventory(_itemNeeded) ? _dialogueHasItem : _dialogueDontHasItem;

            if (_dialogue != null)
            {
                _dialogueManager.SetDitalogue(_dialogue);

                _dialogueManager.StartDialogue();
            }

            if (_inventoryManager.HasItemInInventory(_itemNeeded))
            {
                _inventoryManager.RemoveItemFromInventory(_itemNeeded);

                for (int i = 0; i < gameObjectsToDistroy.Length; i++)
                {
                    Destroy(gameObjectsToDistroy[i]);
                }

                Destroy(gameObject);
            }
        }
    }
}