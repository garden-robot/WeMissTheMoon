using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStarttoInactive : MonoBehaviour
{
    public GameObject startScreen;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        startScreen.SetActive(false);
        Player.GetComponent<CharacterController>().enabled = true;
        Player.GetComponent<FirstPersonDrifter>().enabled = true;
        Player.GetComponent<MouseLook>().enabled = true;

    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
