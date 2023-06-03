using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobScript : MonoBehaviour
{
    public LogicScript logic;
    public bool collided = false;
    public bool invited = false;


    public bool isCollided1 = false;
    public bool isCollided2 = false;


    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!invited && isCollided1 && Input.GetKey(KeyCode.X))
        {
            invited = true;
           // logic.addScore();
        } else if (!invited && isCollided2 && Input.GetKey(KeyCode.L))
        {
            invited = true;

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

    public int getScore()
    {
        return logic.getScore();
    }

}
