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



    Vector3 offset1 = new Vector3(0.9f, 0.2f, 0.0f);
    public Vector3 offset2 = new Vector3(-0.9f, 0.2f, 0.0f);
    public int currentBlobs = 0;

    float distance = 0.75f;

    public FriendCountScript friend1;
    public FriendCountScript friend2;

    public AllBlobsScript allBlobsScript;

    public bool counted = false;
    public int collectedBlobs = 0;

    public bool first = true;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(" alle parents: " + this.transform.parent);
        Debug.Log(this.transform.parent == player1.transform);

        if (isCollided1 && bS.invited1)
        {
            Debug.Log(" in if 1");
            if (bS.invited2)
            {
                Debug.Log(" in if 1.2");

                bS.invited2 = false;
            }

            //this.transform.position = player1.transform.position;
            //not yet correct, trying to figure out the maths
            //this.transform.position -= player1.transform.forward * (distance * friend1.friends1);

            Vector3 targetPosition = player1.transform.position;
            this.transform.position = targetPosition + offset1;
            this.transform.LookAt(p1);
        }
        if (isCollided2 && bS.invited2)
        {
            Debug.Log(" in if 1");

            if (bS.invited1)
            {
                Debug.Log(" in if 1.2");

                bS.invited1 = false;
            }


            /*if (this.transform.parent == player1.transform)
            {
                Debug.Log("in parent drin von 2");
                this.transform.SetParent(null);
                this.transform.SetParent(player2.transform);
            }
            else
            {
                this.transform.SetParent(player2.transform);
            }
            */

            Vector3 targetPosition = player2.transform.position;
            this.transform.position = targetPosition + offset1;
            this.transform.LookAt(p2);
            //Vector3 bar = player2.transform.position;
            /*this.transform.position = player2.transform.position;
            this.transform.position -= player2.transform.forward * (distance * friend2.friends2);
            this.transform.LookAt(p2);*/

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
            friend1.friends1 += 1;
            collectedBlobs += 1;
            //wenn zu hause, ein blob weniger dabei
            friend1.followingFriends1 -= 1;
        }

        if (isCollided2 && collision == home2.GetComponent<Collider>())
        {
            isCollided2 = false;
            currentBlob.SetActive(false);
            isHome2 = true;
            friend2.friends2 += 1;
            collectedBlobs += 1;
        }

    }
}
