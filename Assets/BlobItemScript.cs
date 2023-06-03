using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobItemScript : MonoBehaviour
{

    public float TimeLeft = 20;

    public Vector3 blobPosition;

    public bool isCollided1 = false;
    public bool isCollided2 = false;

    public GameObject player1;
    public GameObject player2;

    public GameObject sphere;
    public AllBlobsScript blobs;
    public AllItemsScript items;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isCollided1)
        {
            items.itemCounter += 1;
            if (blobs.allBlobsNew.Count > 0)
            {
                blobs.NewBlob(0, blobPosition);
                sphere.SetActive(false);
            }
            sphere.SetActive(false);
            isCollided1 = false;

        }

        else if (isCollided2)
        {
            items.itemCounter += 1;
            if (blobs.allBlobsNew.Count > 0)
            {
                blobs.NewBlob(0, blobPosition);
                sphere.SetActive(false);
            }
            sphere.SetActive(false);
            isCollided2 = false;
        }

    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("im trigger methode");
        if (collision == player1.GetComponent<Collider>())
        {
            isCollided1 = true;

        }

        if (collision == player2.GetComponent<Collider>())
        {
            isCollided2 = true;

        }
        Debug.Log("im trigger methode: " + isCollided1);

    }
}
