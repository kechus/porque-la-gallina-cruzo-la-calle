using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField] GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        createPlayer();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void createPlayer()
    {
        Instantiate(player, this.transform.position, this.transform.rotation);
    }
}
