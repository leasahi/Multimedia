using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllBlobsScript : MonoBehaviour
{

    public GameObject[] allBlobs;
    public Vector3[] positions;

    public List<GameObject> allBlobsNew;
    public List<Vector3> positionsNew;

    private List<Vector3> usedPositions = new List<Vector3>();
    private List<GameObject> usedBlobs = new List<GameObject>();
    //private bool newBlob = true;
    public LogicScript logic;
    public FriendCountScript friend1;
    public FriendCountScript friend2;
    public bool multipleBlobs1 = false;
    public bool multipleBlobs2 = false;
    public Vector3 offset1 = new Vector3(-0.9f, 0.2f, 0.0f);
    public Vector3 offset2 = new Vector3(0.9f, 0.2f, 0.0f);
    public Vector3 currentOffset;
    public int oldFriendCounter = 0;


    // Start is called before the first frame update
    void Start()
    {
        //BlobScript blob = allBlobs[0].GetComponent<BlobScript>();
        oldFriendCounter = friend1.friends1 + friend2.friends2;

        //int randomBlob = Random.Range(0, allBlobs.Length);
        int randomPosition = Random.Range(0, 9);
        int randomBlobNew = Random.Range(0, allBlobsNew.Count-1);
        int randomPosition2 = Random.Range(10, 20);
        int randomBlobNew2 = Random.Range(0, allBlobsNew.Count - 1);
        int randomPosition3 = Random.Range(20, positions.Length - 1);
        int randomBlobNew3 = Random.Range(0, allBlobsNew.Count - 1);

        NewBlob(randomBlobNew, positions[randomPosition]);
        NewBlob(randomBlobNew2, positions[randomPosition2]);
        NewBlob(randomBlobNew3, positions[randomPosition3]);

        /*allBlobsNew[randomBlobNew].transform.position = positions[randomPosition];
        allBlobsNew[randomBlobNew].SetActive(true);
        allBlobsNew.Remove(allBlobsNew[randomBlobNew]);*/

        //usedPositions.Add(positions[randomPosition]);
        //usedBlobs.Add(allBlobs[randomBlob]);
        //Debug.Log("Null dings position: " + positions[randomPosition]);

       // allBlobs[randomBlob].transform.position = positions[randomPosition];
       // allBlobs[randomBlob].SetActive(true);
       // Debug.Log("Blob position: " + allBlobs[randomBlob].transform.position);


    }

    // Update is called once per frame
    void Update()
    {
        if (friend1.friends1 + friend2.friends2 > oldFriendCounter)
        {
            if (allBlobsNew.Count > 0)
            {
                int randomPosition = Random.Range(0, positions.Length - 1);
            int randomBlobNew = Random.Range(0, allBlobsNew.Count - 1);
             
            NewBlob(randomBlobNew, positions[randomPosition]);
            }

        }
        if(friend1.followingFriends1 == 2)
        {
            multipleBlobs1 = true;
            currentOffset = offset1;
        }
        else
        {
            multipleBlobs1 = false;
            currentOffset = offset2;
        }

        if (friend2.followingFriends2 == 2)
        {
            multipleBlobs2 = true;
        }
        else
        {
            multipleBlobs2 = false;
        }
    }

    public void NewBlob(int randomBlob, Vector3 position)
    {
        allBlobsNew[randomBlob].transform.position = position;
        Debug.Log("Listenlänge: " + allBlobsNew.Count);
            
            allBlobsNew[randomBlob].SetActive(true);
            Debug.Log("aktueller Blob: " + allBlobsNew[randomBlob]);
            allBlobsNew.Remove(allBlobsNew[randomBlob]);
            
            Debug.Log("Liste nach löschen: " + allBlobsNew.Count);

            oldFriendCounter = friend1.friends1 + friend2.friends2;
    }
}
