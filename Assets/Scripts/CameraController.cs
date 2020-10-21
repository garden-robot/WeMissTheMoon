using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    public Transform[] views;
    public float transitionSpeed;
    Transform currentView;

    public GameObject playerCam;
    public GameObject Player;


    public Transform LampsOn;
    public GameObject[] LampsOff;

    public double originalCutsceneCamPosZ;


    public CutsceneTrigger cutsceneTrigger;

    // Use this for initialization
    void Start()
    {
        

        
        LampsOff = GameObject.FindGameObjectsWithTag("LampsOff");

        currentView = views[0];
        originalCutsceneCamPosZ = 0.0;

    }

    void Update()
    {

        if (cutsceneTrigger.cutsceneOn == true)
        {
            Player.GetComponent<CharacterController>().enabled = false;
            playerCam.SetActive(false);
            gameObject.GetComponent<Camera>().enabled = true;
            Player.GetComponent<MouseLook>().enabled = false;
            currentView = views[1];

            StartCoroutine("WaitCutscene");




        }
        else
        {
            if (gameObject.GetComponent<Camera>().enabled == true)
            {
             
                if (transform.rotation.eulerAngles.z <1)
                {
                            
                    gameObject.GetComponent<Camera>().enabled = false;
                    playerCam.SetActive(true);
                    Player.GetComponent<MouseLook>().enabled = true;
                    Player.GetComponent<CharacterController>().enabled = true;
                    Destroy(cutsceneTrigger.cutscenecollider);
                }
            }
            


        }
        /*
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentView = views[1];
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentView = views[2];
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            currentView = views[3];
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            currentView = views[4];
        }
        */

    }


    void LateUpdate()
    {

        //Lerp position
        transform.position = Vector3.Lerp(transform.position, currentView.position, Time.deltaTime * transitionSpeed);
     

        Vector3 currentAngle = new Vector3(
         Mathf.LerpAngle(transform.rotation.eulerAngles.x, currentView.transform.rotation.eulerAngles.x, Time.deltaTime * transitionSpeed),
         Mathf.LerpAngle(transform.rotation.eulerAngles.y, currentView.transform.rotation.eulerAngles.y, Time.deltaTime * transitionSpeed),
         Mathf.LerpAngle(transform.rotation.eulerAngles.z, currentView.transform.rotation.eulerAngles.z, Time.deltaTime * transitionSpeed));

        transform.eulerAngles = currentAngle;


       
    }


    IEnumerator WaitCutscene()
    {
        if (cutsceneTrigger.cutsceneOn == true)
        {
            yield return new WaitForSeconds(3);
            for (int i = 0; i < LampsOff.Length; i++)
            {
                LampsOff[i].SetActive(false);
                LampsOn.GetChild(i).gameObject.SetActive(true);
                // Debug.Log(i);
                if (i == LampsOff.Length)
                {
                    LampsOn.GetChild(i+1).gameObject.SetActive(true);
                }
                yield return new WaitForSeconds(1);
                
            }


            yield return new WaitForSeconds(3);
            currentView = views[0];

            
            cutsceneTrigger.cutsceneOn = false;
            
        }
        
        
      
      
       
      

    }
}