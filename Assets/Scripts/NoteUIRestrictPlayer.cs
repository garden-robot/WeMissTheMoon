using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteUIRestrictPlayer : MonoBehaviour
{
    public GameObject Player;
    public GameObject Camera;
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
        Player.GetComponent<MouseLook>().enabled = false;
        Camera.GetComponent<MouseLook>().enabled = false;
    }

    public void ExitNoteUI()
    {
        gameObject.SetActive(false);
        Player.GetComponent<CharacterController>().enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Player.GetComponent<MouseLook>().enabled = true;
        Camera.GetComponent<MouseLook>().enabled = true;
    }
}
