using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class NetMan : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab;
    Spinner lavaBlade;

    // Start is called before the first frame update
    void Start()
    {
        lavaBlade = GameObject.Find("LavaBlade").GetComponent<Spinner>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Runs once on each laptop in the game.
    public override void OnJoinedRoom() {
        lavaBlade.transform.eulerAngles = 
            (float) PhotonNetwork.Time * lavaBlade.spin;

        //create my player on all laptops in the room
        PhotonNetwork.Instantiate(playerPrefab.name,
            new Vector3(Random.Range(-8, 8), Random.Range(-4, 4), 0),
            Quaternion.identity);

    }    
}