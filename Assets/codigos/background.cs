using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour
{
    public GameObject jogador;
    public float originalX;
    // Start is called before the first frame update
    void Start()
    {
        jogador = GameObject.Find("MyGameManager");
        originalX = transform.position.x;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(originalX+(jogador.transform.position.x/2),transform.position.y,transform.position.z);
    }
}
