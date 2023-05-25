using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    public float power = 3000;
    private Rigidbody rb;
    void Awake()
    {
        //transform.Rotate(Vector3.right, 0);
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.up * power);
    }
    void Update()
    {
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Stabable")
        {
            ContactPoint contact = collision.contacts[0];
            Vector3 pos = contact.point;
            transform.position = pos;
            transform.rotation = transform.rotation;
            this.transform.SetParent(collision.gameObject.transform.parent);
        }
    }
}
