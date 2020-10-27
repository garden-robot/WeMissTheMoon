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
    [TextArea (40,10)]
    public string Message;
    public int AddOne = 1;
    public bool isLamp = false;
    public bool isOpeningLamp = false;

    public bool isEnd = false;

    //Inspector GameObjects
    public GameObject OpeningCutscene;

    //components
    private SpriteRenderer note_sprite;
    public BoxCollider note_collider;


    //UI
    public Image note_ImageUI;
    public GameObject NoteDisplay; //Attach in Inspector
    public TMP_Text MessageUI_text;
    public GameObject PressE_text;

    //Scripts
    public StoryBeatManager storyBeatManager;
    public LightOffTrigger lightOffTrigger;


    public GameObject End;
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
        //Debug.Log("PRESS E");
        PressE_text.SetActive(true);
        storyBeatManager.RoomHandler = gameObject;


    }

    void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            PressE_text.SetActive(false);
            //Debug.Log("E key was released.");

            //Pass Note to UI
            MessageUI_text.text = Message;
            NoteDisplay.GetComponent<Image>().sprite = note_ImageUI.sprite;
            NoteDisplay.SetActive(true);

            Destroy(note_sprite);
            Destroy(note_collider);

            if (isLamp == false)
            {
                storyBeatManager.NoteInventory[RoomNameID] += AddOne;
                storyBeatManager.TotalNotes_Global += AddOne;
            }
            else
            {
                storyBeatManager.TotalNotes_Global += AddOne;
                lightOffTrigger.TurnLightOff();
                if(isOpeningLamp == true)
                {
                    storyBeatManager.TotalNotes_Global += AddOne;
                    OpeningCutscene.GetComponent<Collider>().enabled = true;
                    storyBeatManager.TotalNotes_Global += AddOne;
                }
              
            }
         
            if(isEnd == true)
            {
                End.SetActive(true);
            }
        }

        //Player movement restrict
    }

        private void OnTriggerExit(Collider other)
    {
        PressE_text.SetActive(false);
    }
}
