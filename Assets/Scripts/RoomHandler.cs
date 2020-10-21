﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoomHandler : MonoBehaviour
{
    public int RoomNameID;
    public int NoteTotal;

    public BoxCollider RoomCollider;

    //Attach these in inspector
    public GameObject NoteCounter;
    public GameObject NoteCounterTotal;
    public GameObject NoteSlash;

    public GameObject NoteLampAppear;

    public StoryBeatManager storyBeatManager;

    public TMP_Text NoteCounterTotal_text;
    public TMP_Text NoteCounter_text;
    // Start is called before the first frame update
    void Start()
    {
     

        RoomCollider = gameObject.GetComponent<BoxCollider>();

        NoteCounterTotal_text = NoteCounterTotal.GetComponent<TMP_Text>();
        NoteCounter_text = NoteCounter.GetComponent<TMP_Text>();


    }

    /*
    void Update()
    {

    }
    */
  
    private void OnTriggerEnter(Collider other)
    {
        //NoteCounter value in StoryBeatManager
        storyBeatManager.TotalNotes_Room = NoteTotal;

        storyBeatManager.RoomHandler = gameObject;

        NoteCounterTotal_text.text = NoteTotal.ToString();

        NoteCounter_text.text = storyBeatManager.NoteInventory[RoomNameID].ToString();

        NoteCounter.SetActive(true);
        NoteSlash.SetActive(true);
        NoteCounterTotal.SetActive(true);

       

    }


    
    void OnTriggerStay(Collider other)
    {
        NoteCounterTotal_text.text = NoteTotal.ToString();

        NoteCounter_text.text = storyBeatManager.NoteInventory[RoomNameID].ToString();

        //NoteTotal vs. NoteInventory[RoomNameID]
        if (storyBeatManager.NoteInventory[RoomNameID] == NoteTotal)
        {
            //Note Appear Trigger
            NoteLampAppear.SetActive(true);

            //Effect Trigger
            
        }

    }

    private void OnTriggerExit(Collider other)
    {
        NoteCounter.SetActive(false);
        NoteCounterTotal.SetActive(false);
        NoteSlash.SetActive(false);
    }
}