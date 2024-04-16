using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviourPunCallbacks
{
    Rigidbody myBod;
    float moveForce = 500;
    Text namePlate;

    // Start is called before the first frame update
    void Start()
    {
        myBod = GetComponent<Rigidbody>();
        namePlate = GetComponentInChildren<Text>();
        namePlate.text = photonView.Owner.NickName;
    }

    // Update is called once per frame
    void Update()
    {
        if(photonView.IsMine) {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            Vector3 f = new Vector3(h, v, 0);
            myBod.AddForce(f * moveForce * Time.deltaTime);
        }
    }
}
