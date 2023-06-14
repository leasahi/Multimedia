using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FriendCountScript : MonoBehaviour
{

    public int friends1;
    public int friends2;

    public int followingFriends1;
    public int followingFriends2;

    public Text friends2Text;
    public Text friends1Text;
    public bool p1HasBlob = false;
    public bool p2HasBlob = false;


    // Start is called before the first frame update
    void Start()
    {
        friends1 = 0;
        friends2 = 0;

        followingFriends1 = 0;
        followingFriends2 = 0;

    }

    // Update is called once per frame
    void Update()
    {
        friends2Text.text = friends2.ToString();
        friends1Text.text = friends1.ToString();
    }
}
