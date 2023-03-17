using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempoPulo : MonoBehaviour
{
    public EnemyAI ia;
    public float tempo;
    public BoxCollider box;
    // Start is called before the first frame update
    void Start()
    {
        box = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(tempo<3){tempo+=Time.deltaTime;}
        if(tempo>=2){
            box.material = null;
            ia.enabled= true;
            transform.position = new Vector3(transform.position.x,0,transform.position.z);
            enabled = false;

        }
    }
}
