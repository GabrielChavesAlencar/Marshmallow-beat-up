using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


public class PlayerControler : MonoBehaviour
{
    public float playerSpeed = 5;
    public Rigidbody2D rig;
    public PhotonView photonView;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        photonView = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if(photonView.IsMine){
            PlayerMove();
            PlayerTurn();
        }
    }
    public void PlayerMove () {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");

        rig.velocity = new Vector2(x,y);
    }
    public void PlayerTurn () {
        Vector3 mouseposition = Input.mousePosition;

        mouseposition = Camera.main.ScreenToViewportPoint(mouseposition);
        Vector2 direction = new Vector2(mouseposition.x-transform.position.x,mouseposition.y-transform.position.y);
        transform.up = direction;
    }
}
