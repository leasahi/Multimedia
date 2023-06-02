using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    public bool isCollided1 = false;
    public bool isCollided2 = false;

    public bool isHome1 = true;
    public bool isHome2 = true;
    Vector3 home1coordinates = new Vector3(7.0f, 0, 0);
    Vector3 home2coordinates = new Vector3(7.0f, 0, 0);

    public BlobScript bS;

    public GameObject player1;
    public GameObject player2;

    public GameObject currentBlob;

    public GameObject home1;
    public GameObject home2;

    public LogicScript logic;

    public Transform p1;
    public Transform p2;



    Vector3 temp = new Vector3(7.0f, 0, 0);
    float distance = 0.75f;

    public FriendCountScript friend1;
    public FriendCountScript friend2;

    public bool counted = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    //https://docs.unity.cn/ScriptReference/Bounds.Contains.html for bounds 
    //think we would need an invisible plane below the house to check four collision or something
    // Update is called once per frame
    void Update()
    {

        if (isCollided1 && bS.invited)
        {
            //player.transform.SetParent(this.transform);
            if (!counted)
            {
                friend1.friends1 += 1;
                counted = true;
            }
            this.transform.SetParent(player1.transform);
            this.transform.position = player1.transform.position;
            //not yet correct, trying to figure out the maths
            this.transform.position -= player1.transform.forward * (distance * friend1.friends1);
            this.transform.LookAt(p1);


        }
        else if (isCollided2 && bS.invited)
        {
            if (!counted)
            {
                friend2.friends2 += 1;
                counted = true;
            }
            this.transform.SetParent(player2.transform);
            //Vector3 bar = player2.transform.position;
            this.transform.position = player2.transform.position;
            this.transform.position -= player2.transform.forward * (distance * friend2.friends2);
            this.transform.LookAt(p2);


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

    private void OnTriggerEnter(Collider collision)
    {
        if (isCollided1 && collision == home1.GetComponent<Collider>())
        {
            isCollided1 = false;

            currentBlob.SetActive(false);
            isHome1 = true;
            logic.addScore();
        }

        if (isCollided2 && collision == home2.GetComponent<Collider>())
        {
            isCollided2 = false;
            currentBlob.SetActive(false);
            isHome2 = true;
        }

    }
}
