using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviourPunCallbacks, IPunObservable
{
    Rigidbody myBod;
    float moveForce = 500;
    Text namePlate;
    Text scorePlate;
    public int health;
    Transform greenHealth;
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        myBod = GetComponent<Rigidbody>();
        namePlate = transform.Find("Canvas/NamePlate").GetComponent<Text>();
        namePlate.text = photonView.Owner.NickName;
        greenHealth = transform.Find("Canvas/GreenHealth");
        scorePlate = transform.Find("Canvas/ScorePlate").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //this code runs on every cube
        scorePlate.text = "" + score;


        if(health > 0) {
            greenHealth.localScale = new Vector3(health/100f, 1, 1);
        }
        else {
            //die
            transform.position = new Vector3(
                transform.position.x,
                transform.position.y,
                5);
            myBod.constraints = RigidbodyConstraints.FreezeAll;
            namePlate.color = Color.gray;    
        }

        //this code runs only on the cube I own
        if(photonView.IsMine) {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            Vector3 f = new Vector3(h, v, 0);
            myBod.AddForce(f * moveForce * Time.deltaTime);
        }
    }

    void OnTriggerStay(Collider other) {
        if(photonView.IsMine) {
            //only owner can correclty calc physics
            health -= 1;
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if(photonView.IsMine) {
            stream.SendNext(health);
        } 
        else {
            health = (int) stream.ReceiveNext();
        }
    }

    [PunRPC]
    public void increaseScore(int n) {
        score += n;
    }
}
