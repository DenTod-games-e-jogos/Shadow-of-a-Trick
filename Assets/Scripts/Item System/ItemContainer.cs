using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemContainer : MonoBehaviour
{
    [SerializeField]
    Item _item;
    Dialogue _dialogue;

    GameObject _sceneManager;
    InventoryManager _inventoryManager;

    GameObject _dialogueSystem;
    DialogueManager _dialogueManager;

    void Start()
    {
        _sceneManager = GameObject.FindWithTag("Scene Manager");
        _inventoryManager = _sceneManager.GetComponent<InventoryManager>();

        _dialogue = _item.GetDialogue();

        _dialogueSystem = GameObject.FindWithTag("Dialogue System");
        if (_dialogueSystem != null)
            _dialogueManager = _dialogueSystem.GetComponent<DialogueManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (_dialogue != null)
            {
                _dialogueManager.SetDitalogue(_dialogue);
                _dialogueManager.StartDialogue();
            }

            _inventoryManager.AddItemToInventory(_item);

            Destroy(gameObject);
        }
    }
}
