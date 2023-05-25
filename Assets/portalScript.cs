using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalScript : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    bool collided = false;
    public Vector3 position;
    public Quaternion rotation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (collided)
        {
            player1.transform.position = position;
            player1.transform.rotation = rotation;
            Debug.Log("POSITION:"+player1.transform.position);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        collided = true;

    }

    private void OnTriggerExit(Collider collision)
    {
        collided = false;
    }

}
