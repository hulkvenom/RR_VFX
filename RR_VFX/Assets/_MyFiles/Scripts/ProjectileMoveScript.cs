using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMoveScript : MonoBehaviour
{

    int delay = 2;
    private DissolvingController dissolvingControllerScript;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            dissolvingControllerScript.StartDissolveCo();
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        dissolvingControllerScript = GameObject.Find("VampireHolder").GetComponent<DissolvingController>();
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, delay);
    }

   
}
