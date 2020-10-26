using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEffect : MonoBehaviour
{
    public GameObject flowers;
    public GameObject plants;

    // Start is called before the first frame update
  
    void Update()
    {

        gameObject.SetActive(true);

        flowers.SetActive(true);
        plants.SetActive(true);
    }

}