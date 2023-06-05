using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedItemScript : MonoBehaviour
{
    public float TimeLeft = 20;


    public bool isCollided1 = false;
    public bool isCollided2 = false;

    public GameObject player1;
    public GameObject player2;

    public GameObject sphere;

    public PlayerControllerScript pC1WASD;
    public PlayerControllerScript pC2Arrows;
    public AllItemsScript items;

    Vector3 temp = new Vector3(0, -100, 0);


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
            pC1WASD.movementSpeed = 5f;
            StartCoroutine(Waiter());
            isCollided1 = false;

        }

        else if (isCollided2)
        {
            items.itemCounter += 1;
            pC2Arrows.movementSpeed = 5f;
            StartCoroutine(Waiter());
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
        Debug.Log("im trigger methode: "+ isCollided1);

    }

    private IEnumerator Waiter()
    {
        transform.position += temp;

        yield return new WaitForSecondsRealtime(20);
        pC1WASD.movementSpeed = 3f;
        isCollided1 = false;

        pC2Arrows.movementSpeed = 3f;
        isCollided2 = false;

        yield return new WaitForSecondsRealtime(20);
        sphere.SetActive(false);


    }
}
