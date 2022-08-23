using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    private GameObject _player;
    private PlayerMovement _playerMovement;
    private DialogueManager _dialogueManager;
    private bool _canTalk;
    private bool _playerContact;
    private Animator _dialogueAnim;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerMovement = _player.GetComponent<PlayerMovement>();
        _dialogueManager = GameObject.FindObjectOfType<LevelManager>().GetComponent<DialogueManager>();

        _dialogueAnim = GameObject.FindGameObjectWithTag("New Level Manager").GetComponent<DialogueManager>().anim;
    }

    void Update()
    {
        if (Input.GetKeyDown(_playerMovement.dialogueButton) && 
            _playerContact && 
            _playerMovement.dialogueEnabled)
        {
            HandleDialogue();
        }
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        // Probably a good idea to add a UI notification here telling the player that
        // they can talk to this character....

        if (col.gameObject == _player && _playerMovement.dialogueEnabled)
        {
            Debug.Log("Dialogue Available");
            _canTalk = true;
        }
    }

    private void OnTriggerStay2D(Collider2D col)    
    {
        if (col.gameObject == _player)
        {
            _playerContact = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        // Also probably a good idea to remove that UI notification from earlier here...

        _playerContact = false;
        _canTalk = false;
        _dialogueAnim.SetBool("isOpen", false);
    }

    void HandleDialogue()
    {
        if (_canTalk && 
            _playerContact)
            
        {
            _canTalk = false;
            TriggerDialogue();
        }

        else if (!_canTalk &&
                _playerContact)
        {
            _dialogueManager.DisplayNextSentence();
        }
    }
}
