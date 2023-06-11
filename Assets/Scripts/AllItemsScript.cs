using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllItemsScript : MonoBehaviour
{

   
    public Vector3[] positions;

    public List<GameObject> allItems;
    public GameObject item1;
    public GameObject item2;
    public GameObject item3;
    
   
    public LogicScript logic;
    public int itemCounter;
    public int oldItemCounter;


    // Start is called before the first frame update
    void Start()
    {

        int randomPosition = Random.Range(0, 3);
        item1.transform.position = positions[randomPosition];
        item1.SetActive(true);
        randomPosition = Random.Range(4, 8);
        item2.transform.position = positions[randomPosition];
        item2.SetActive(true);
        randomPosition = Random.Range(9, positions.Length - 1);
        item3.transform.position = positions[randomPosition];
        item3.SetActive(true);

        //Instantiate(allItems[randomItem], positions[randomPosition], q);
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
