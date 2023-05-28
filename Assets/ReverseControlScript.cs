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

    public PlayerControllerScript pC1WASD;
    public PlayerControllerScript pC2Arrows;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (isCollided1)
        {
            pC1WASD.reversedWASD = true;
            StartCoroutine(Waiter());

        }

        else if (isCollided2)
        {
            pC2Arrows.reversedArrows = true;
            StartCoroutine(Waiter());
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
        yield return new WaitForSecondsRealtime(20);
        pC1WASD.reversedWASD = false;
        isCollided1 = false;

        pC2Arrows.reversedArrows = false;
        isCollided2 = false;

    }
}
