using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PressEtoStart : MonoBehaviour
{
    public PlayableDirector playableDirector;
    // Start is called before the first frame update
    void Start()
    {
         playableDirector = GameObject.FindGameObjectWithTag("StartCam").GetComponent<PlayableDirector>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            playableDirector.Play();
            gameObject.SetActive(false);
           
        }
    }
}
