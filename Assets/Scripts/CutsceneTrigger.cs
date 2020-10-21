using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneTrigger : MonoBehaviour
{
    public GameObject View;
    public bool cutsceneOn = false;

    public Collider cutscenecollider;
    // Start is called before the first frame update
    void Start()
    {
        cutscenecollider = gameObject.GetComponent<Collider>();
    }


    private void OnTriggerEnter(Collider other)
    {
        View.SetActive(true);
        cutsceneOn = true;
    }
}
