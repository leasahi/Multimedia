using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobScript : MonoBehaviour
{
    public LogicScript logic;
    bool collided = false;
    bool invited = false;


    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!invited && collided && Input.GetKey(KeyCode.X))
        {
            invited = true;
            logic.addScore();
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
