using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NoteObject : MonoBehaviour
{
    public string RoomName;
    public int RoomNameID;

    public string CharacterName;
    public string Message;
    public int AddOne = 1;
    public bool isLamp = false;
    public bool isOpeningLamp = false;

    //Inspector GameObjects
    public GameObject OpeningCutscene;

    //components
    private SpriteRenderer note_sprite;
    public BoxCollider note_collider;


    //UI
    public Image note_ImageUI;
    public GameObject NoteDisplay; //Attach in Inspector
    public TMP_Text MessageUI_text;

    //Scripts
    public StoryBeatManager storyBeatManager;
    public LightOffTrigger lightOffTrigger;

    void Start()
    {
        note_sprite = gameObject.GetComponent<SpriteRenderer>();
        note_collider = gameObject.GetComponent<BoxCollider>();
        note_ImageUI = gameObject.GetComponent<Image>();


        MessageUI_text = NoteDisplay.GetComponentInChildren<TMP_Text>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //Trigger Collider
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("PRESS E");

        //If E is pressed
    }

    void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            Debug.Log("E key was released.");

            //Pass Note to UI
            MessageUI_text.text = Message;
            NoteDisplay.GetComponent<Image>().sprite = note_ImageUI.sprite;
            NoteDisplay.SetActive(true);

            Destroy(note_sprite);
            Destroy(note_collider);

            if (isLamp == false)
            {
                storyBeatManager.NoteInventory[RoomNameID] += AddOne;
            }
            else
            {
                lightOffTrigger.TurnLightOff();
                if(isOpeningLamp == true)
                {
                    OpeningCutscene.GetComponent<Collider>().enabled = true;
                }
            }
         

        }

        //Player movement restrict
    }

        private void OnTriggerExit(Collider other)
    {
        Debug.Log(" ");
    }
}
