using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobScript : MonoBehaviour
{
    public LogicScript logic;
    public bool collided = false;
    public bool invited1 = false;
    public bool invited2 = false;
    public bool isCollided1 = false;
    public bool isCollided2 = false;
    public FriendCountScript friend1;
    public FriendCountScript friend2;


    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!invited1 && isCollided1 && Input.GetKey(KeyCode.X) && !friend1.p1HasBlob)
        {
            invited1 = true;
        } else if (!invited2 && isCollided2 && Input.GetKey(KeyCode.L) && !friend2.p2HasBlob)
        {
            invited2 = true;

        }

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player1"))
        {
            isCollided1 = true;
        }

        if (collision.gameObject.CompareTag("Player2"))
        {
            isCollided2 = true;
        }

    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player1"))
        {
            isCollided1 = false;
        }

        if (collision.gameObject.CompareTag("Player2"))
        {
            isCollided2 = false;
        }
    }

    /*public int getScore()
    {
        return logic.getScore();
    }*/

}
