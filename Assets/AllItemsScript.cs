using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllItemsScript : MonoBehaviour
{

   
    public Vector3[] positions;

    public List<GameObject> allItems;
   
    public LogicScript logic;
    public int itemCounter;
    public int oldItemCounter;


    // Start is called before the first frame update
    void Start()
    {
        
        int randomPosition = Random.Range(0, positions.Length - 1);
        int randomItem = Random.Range(0, allItems.Count - 1);

        Debug.Log("Item Listenlänge: " + allItems.Count);
        allItems[randomItem].transform.position = positions[randomPosition];
        allItems[randomItem].SetActive(true);
        Debug.Log("aktuelles Item: " + allItems[randomItem]);
        //allItems.Remove(allItems[randomItem]);
       
     
    }

    // Update is called once per frame
    void Update()
    {
        if (itemCounter>oldItemCounter)
        {
            int randomPosition = Random.Range(0, positions.Length - 1);
            int randomItem = Random.Range(0, allItems.Count - 1);

            Debug.Log("Item Listenlänge: " + allItems.Count);
            allItems[randomItem].transform.position = positions[randomPosition];
            allItems[randomItem].SetActive(true);
            Debug.Log("aktuelles Item: " + allItems[randomItem]);
            //allItems.Remove(allItems[randomItem]);
            oldItemCounter = itemCounter;
        }
    }
}
