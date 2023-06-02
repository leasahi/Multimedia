using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalScript : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    bool collided1 = false;
    bool collided2 = false;

    public Vector3 position;
    public Quaternion rotation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (collided1)
        {
            player1.transform.position = position;
            player1.transform.rotation = rotation;
            Debug.Log("POSITION:"+player1.transform.position);
        }
        if (collided2)
        {
            player2.transform.position = position;
            player2.transform.rotation = rotation;
            Debug.Log("POSITION:" + player2.transform.position);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision == player1.GetComponent<Collider>())
        {
            collided1 = true;

        }

        if (collision == player2.GetComponent<Collider>())
        {
            collided2 = true;

        }

    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision == player1.GetComponent<Collider>())
        {
            collided1 = false;

        }
        if (collision == player2.GetComponent<Collider>())
        {
            collided2 = false;

        }
    }

}
