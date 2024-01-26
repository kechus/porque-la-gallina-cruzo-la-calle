using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Player") != null)
        {
            this.transform.position = new Vector3 (GameObject.FindGameObjectWithTag("Player").transform.position.x, this.transform.position.y, -10);
        }
    }
}
