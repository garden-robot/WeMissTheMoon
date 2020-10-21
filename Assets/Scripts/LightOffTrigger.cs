using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOffTrigger : MonoBehaviour
{
    public GameObject LightOff; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

  
   public void TurnLightOff()
    {
      gameObject.SetActive(false);
      LightOff.SetActive(true);
    }
}
