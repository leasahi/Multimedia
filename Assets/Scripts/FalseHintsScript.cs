using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalseHintsScript : MonoBehaviour
{
    public GameObject[] allFalseHints;
    public Vector3[] positions;
    private List<Vector3> usedPositions = new List<Vector3>();
    public LogicScript logic;
    public FriendCountScript friend1;
    public FriendCountScript friend2;
    private int oldFriendCounter = 0;
    private bool init = true;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void initHints()
    {
        oldFriendCounter = friend1.friends1 + friend2.friends2;

        int randomHint = Random.Range(0, allFalseHints.Length);
        int randomPosition = Random.Range(0, positions.Length);

        usedPositions.Add(positions[randomPosition]);
        //    Debug.Log("Null dings position: " + positions[randomPosition]);

        Debug.Log("Hint position before: " + allFalseHints[randomHint].transform.position);
        allFalseHints[randomHint].transform.position = positions[randomPosition];
        allFalseHints[randomHint].SetActive(true);
        Debug.Log("Hint position after: " + allFalseHints[randomHint].transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (logic.started && init) {
            Debug.Log("START INIT HINTS");
            this.initHints();
            init = false;
        }

        if (logic.started && !init)
        {
            if (friend1.friends1 + friend2.friends2 > oldFriendCounter)
            {
                StartCoroutine(Waiter());
            }
        }
    }

    private IEnumerator Waiter()
    {
        oldFriendCounter = friend1.friends1 + friend2.friends2;
        yield return new WaitForSecondsRealtime(10);
        int randomHints = Random.Range(0, allFalseHints.Length);
        int randomPosition = Random.Range(0, positions.Length);

        if (!usedPositions.Contains(positions[randomPosition]))
        {
            allFalseHints[randomHints].transform.position = positions[randomPosition];
            allFalseHints[randomHints].SetActive(true);
            usedPositions.Add(positions[randomPosition]);
            Debug.Log("Hint position: " + allFalseHints[randomHints].transform.position);
            oldFriendCounter = friend1.friends1 + friend2.friends2;
        }

    }
}