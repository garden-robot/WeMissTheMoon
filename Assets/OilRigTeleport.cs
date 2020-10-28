using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilRigTeleport : MonoBehaviour
{
    public GameObject player;


    public GameObject ShedHandler;
    public GameObject FactoryHandler;
    public GameObject OverHangHandler;
    public GameObject DarkRoomHandler;
    public GameObject BathHouseHandler;
    public GameObject LibraryHandler;


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ENTERED TRIGGER");
        GameObject player = other.gameObject;

        ShedHandler.GetComponent<AudioSource>().enabled = false;
        FactoryHandler.GetComponent<AudioSource>().enabled = false;
        OverHangHandler.GetComponent<AudioSource>().enabled = false;
        DarkRoomHandler.GetComponent<AudioSource>().enabled = false;
        BathHouseHandler.GetComponent<AudioSource>().enabled = false;
        LibraryHandler.GetComponent<AudioSource>().enabled = false;
        var cc = player.GetComponent<CharacterController>();
        cc.enabled = false;
        player.transform.position = new Vector3(-3, 57, 21);
        cc.enabled = true;
    }

}
