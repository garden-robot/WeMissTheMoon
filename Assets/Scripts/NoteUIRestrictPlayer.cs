using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteUIRestrictPlayer : MonoBehaviour
{
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Player.GetComponent<CharacterController>().enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void ExitNoteUI()
    {
        gameObject.SetActive(false);
        Player.GetComponent<CharacterController>().enabled = true;
    }
}
