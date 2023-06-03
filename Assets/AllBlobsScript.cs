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
    public int oldFriendCounter = 0;


    // Start is called before the first frame update
    void Start()
    {
        oldFriendCounter = friend1.friends1 + friend2.friends2;

        //int randomBlob = Random.Range(0, allBlobs.Length);
        int randomPosition = Random.Range(0, positions.Length-1);

        int randomBlobNew = Random.Range(0, allBlobsNew.Count-1);

        Debug.Log("Listenlänge: " + allBlobsNew.Count);
        allBlobsNew[randomBlobNew].transform.position = positions[randomPosition];
        allBlobsNew[randomBlobNew].SetActive(true);
        allBlobsNew.Remove(allBlobsNew[randomBlobNew]);
        Debug.Log("Liste nach löschen: " + allBlobsNew.Count);

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

            int randomBlobNew = Random.Range(0, allBlobsNew.Count - 1);
            int randomPosition = Random.Range(0, positions.Length-1);

            Debug.Log("Listenlänge: " + allBlobsNew.Count);
            allBlobsNew[randomBlobNew].transform.position = positions[randomPosition];
            allBlobsNew[randomBlobNew].SetActive(true);
            allBlobsNew.Remove(allBlobsNew[randomBlobNew]);
            Debug.Log("Liste nach löschen: " + allBlobsNew.Count);

                oldFriendCounter = friend1.friends1 + friend2.friends2;
            
        }
    }
}
