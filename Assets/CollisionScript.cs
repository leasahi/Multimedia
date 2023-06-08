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
    public bool invited1 = false;
    public bool invited2 = false;
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
    public int collectedBlobs = 0;
     Vector3 offset1 = new Vector3(0.8199f, 0.119f, 0);
     Vector3 offset2 = new Vector3(0.93f, 0.33f, 0.0f);


    // Start is called before the first frame update
    void Start()
    {
    }
    //https://docs.unity.cn/ScriptReference/Bounds.Contains.html for bounds 
    //think we would need an invisible plane below the house to check four collision or something
    // Update is called once per frame
    void Update()
    {
        //invited1 = bS.invited1;
        //invited2 = bS.invited2;

        if (!invited1 && isCollided1 && Input.GetKey(KeyCode.X))
        {
            invited1 = true;
        }
        else if (!invited2 && isCollided2 && Input.GetKey(KeyCode.L))
        {
            invited2 = true;

        }

        Debug.Log("Blob: "+ currentBlob + ", & Collision parent: " + this.transform.parent);
        if (isCollided1 && invited1)
        {
            Debug.Log("im P1 IF also isCollided1 true");
         


            if (this.transform.parent == player2.transform)
            {
                Debug.Log("im P1 klauen");
                invited2 = false;
                isCollided2 = false;

                this.transform.SetParent(null);
                this.transform.SetParent(player1.transform);
                this.transform.position = player1.transform.position + offset1;
                this.transform.LookAt(p1);

            }
            else
            {
                this.transform.SetParent(player1.transform);
                this.transform.position = player1.transform.position + offset1;
                this.transform.LookAt(p1);
            }

        }
        if (isCollided2 && invited2)
        {
            Debug.Log("im P1 IF also isCollided2 true");
            
            if (this.transform.parent == player1.transform)
            {
                Debug.Log("im P2 klauen");
                invited1 = false;
                isCollided1 = false;

                this.transform.SetParent(null);
                this.transform.SetParent(player2.transform);
                this.transform.position = player2.transform.position + offset2;
                this.transform.LookAt(p2);

            }
            else
            {
                this.transform.SetParent(player2.transform);
                this.transform.position = player2.transform.position + offset2;
                this.transform.LookAt(p2);
            }
        }
       
    }
    /*private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player1"))
        {
            isCollided1 = true;
        }
        if (other.gameObject.CompareTag("Player2"))
        {
            isCollided2 = true;
        }

    }*/
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


        if (isCollided1 && invited2 && collision == home1.GetComponent<Collider>())
        {
            isCollided1 = false;
            invited1 = false;
            currentBlob.SetActive(false);
            isHome1 = true;
            friend1.friends1 += 1;

            collectedBlobs += 1;
        }

        if (isCollided2 && invited2 && collision == home2.GetComponent<Collider>())
        {
            isCollided2 = false;
            invited2 = false;
            currentBlob.SetActive(false);
            isHome2 = true;
            friend2.friends2 += 1;
            collectedBlobs += 1;
        }

    }
}