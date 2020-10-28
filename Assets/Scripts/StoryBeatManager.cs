using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryBeatManager : MonoBehaviour
{
    public int TotalNotes_Global;
    public int TotalNotes_Room;

    public int[] NoteInventory; //entrance = 0, bathhouse = 1, overhang = 2, warehouse = 3, library = 4, greenhouse = 5
    public float playMusicInterpolate = 9.9f;
    public float nextMusicPlay = 0.0f;
    public GameObject RoomHandler;

    public RoomHandler roomHandler;

    public AudioSource Shed;
    public AudioSource BathHouse;
    public AudioSource Overhang;
    public AudioSource Library;
    public AudioSource Factory;
    public AudioSource DarkRoom;

    public GameObject endingCutsceneCam;//attahced to player
    public GameObject oilRigTeleport;

    public int Win = 24;

   
  
    void Start()
    {
        NoteInventory = new int[10];



        // roomHandler = RoomHandler.GetComponent<RoomHandler>();
        //foreach (var x in NoteInventory) Debug.Log(x.ToString());
    }

    // Update is called once per frame
    void Update()
    {
      
        BathHouse.timeSamples = Shed.timeSamples;
        Factory.timeSamples = Shed.timeSamples;
        Library.timeSamples = Shed.timeSamples;
        Overhang.timeSamples = Shed.timeSamples;
        DarkRoom.timeSamples = Shed.timeSamples;

        if (roomHandler != null)
        {

            if (roomHandler.RoomDone == true)
            {



                if (roomHandler.RoomNameID == 0)
                {
                    Shed.enabled = true;

                }

                if (roomHandler.RoomNameID == 1)
                {
                    BathHouse.enabled = true;
                    BathHouse.timeSamples = Shed.timeSamples;
                }
                if (roomHandler.RoomNameID == 2)
                {
                    Overhang.enabled = true;
                    Overhang.timeSamples = Shed.timeSamples;
                }
                if (roomHandler.RoomNameID == 3)
                {
                    Factory.enabled = true;
                    Factory.timeSamples = Shed.timeSamples;
                }
                if (roomHandler.RoomNameID == 4)
                {
                    Library.enabled = true;
                    Library.timeSamples = Shed.timeSamples;
                }
                if (roomHandler.RoomNameID == 5)
                {
                    DarkRoom.enabled = true;
                   DarkRoom.timeSamples = Shed.timeSamples;
                }


            }
        }

        if(TotalNotes_Global == 23)
        {
            endingCutsceneCam.SetActive(true);
            oilRigTeleport.SetActive(true);

        }


       
    }
}





