using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryBeatManager : MonoBehaviour
{ 
    public int TotalNotes_Global;
    public int TotalNotes_Room;
    public int[] NoteInventory; //entrance = 0, bathhouse = 1, overhang = 2, warehouse = 3, library = 4, greenhouse = 5

    public GameObject RoomHandler;

    void Start()
    {
        NoteInventory = new int[5];

        //foreach (var x in NoteInventory) Debug.Log(x.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  




}
