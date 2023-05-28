using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllBlobsScript : MonoBehaviour
{

    public GameObject[] allBlobs;
    public Vector3[] positions;
    private List<Vector3> usedPositions = new List<Vector3>();
    private List<GameObject> usedBlobs = new List<GameObject>();
    //private bool newBlob = true;
    public LogicScript logic;
    private int oldFriendCounter = 0;


    // Start is called before the first frame update
    void Start()
    {
        oldFriendCounter = logic.friendCounter;

        int randomBlob = Random.Range(0, allBlobs.Length);
        int randomPosition = Random.Range(0, positions.Length);

        usedPositions.Add(positions[randomPosition]);
        usedBlobs.Add(allBlobs[randomBlob]);
        Debug.Log("Null dings position: " + positions[randomPosition]);

        allBlobs[randomBlob].transform.position = positions[randomPosition];
        allBlobs[randomBlob].SetActive(true);
        Debug.Log("Blob position: " + allBlobs[randomBlob].transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (logic.friendCounter > oldFriendCounter)
        {

            int randomBlob = Random.Range(0, allBlobs.Length);
            int randomPosition = Random.Range(0, positions.Length);

            if (!usedPositions.Contains(positions[randomPosition]) && !usedBlobs.Contains(allBlobs[randomBlob]))
            {
                allBlobs[randomBlob].transform.position = positions[randomPosition];
                allBlobs[randomBlob].SetActive(true);
                usedPositions.Add(positions[randomPosition]);
                usedBlobs.Add(allBlobs[randomBlob]);

                Debug.Log("Blob position: " + allBlobs[randomBlob].transform.position);
                oldFriendCounter = logic.friendCounter;
            }
        }
    }
}
