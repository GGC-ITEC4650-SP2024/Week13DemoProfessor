using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class BallController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision) {
        if(PhotonNetwork.IsMasterClient) {
            GameObject g = collision.gameObject;
            if(g.tag == "Player") {
                //PlayerController pc = g.GetComponent<PlayerController>();
                //pc.score += 10;
                PhotonView pv = g.GetComponent<PhotonView>();
                pv.RPC("increaseScore", RpcTarget.AllBuffered, 10);
            }
        }
    }


}
