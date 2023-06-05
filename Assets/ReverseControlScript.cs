using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseControlScript : MonoBehaviour
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
            pC1WASD.reversedWASD = true;
            StartCoroutine(Waiter());
            sphere.SetActive(false);
            isCollided1 = false;

        }

        else if (isCollided2)
        {
            items.itemCounter += 1;
            pC2Arrows.reversedArrows = true;
            StartCoroutine(Waiter());
            isCollided2 = false;
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

    private IEnumerator Waiter()
    {
        transform.position += temp;
        yield return new WaitForSecondsRealtime(20);
        pC1WASD.reversedWASD = false;
        isCollided1 = false;

        pC2Arrows.reversedArrows = false;
        isCollided2 = false;
        yield return new WaitForSecondsRealtime(20);
        sphere.SetActive(false);


    }
}
