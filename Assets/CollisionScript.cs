using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    public bool isCollided1 = false;
    public bool isCollided2 = false;

    public GameObject player1;
    public GameObject player2;
    Vector3 temp = new Vector3(7.0f, 0, 0);
    float distance = 0.75f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isCollided1)
        {
            //player.transform.SetParent(this.transform);
            this.transform.SetParent(player1.transform);
            this.transform.position = player1.transform.position;
            this.transform.position -= player1.transform.forward * distance;

        }
        else if (isCollided2)
        {
            this.transform.SetParent(player2.transform);
            //Vector3 bar = player2.transform.position;
            this.transform.position = player2.transform.position;
            this.transform.position -= player2.transform.forward * distance;


        }

        else
        {
            this.transform.SetParent(null);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player1"))
        {
            isCollided1 = true;
        }

        if (other.gameObject.CompareTag("Player2"))
        {
            isCollided2 = true;
        }

    }
}
