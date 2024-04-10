using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickStart : MonoBehaviour
{
    public Vector3 kick;
    Rigidbody myBod;

    // Start is called before the first frame update
    void Start()
    {
        myBod = GetComponent<Rigidbody>();
        myBod.velocity = kick;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
