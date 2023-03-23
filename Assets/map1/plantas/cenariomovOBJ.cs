using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cenariomovOBJ : MonoBehaviour
{
    public float vel_x;
    public float vel_y;
    public Transform temp_obj;
    public float tempo;
    public bool inverter;
    public float time;
    public Vector3 escala;
    // Start is called before the first frame update
    void Start()
    {
        temp_obj = GetComponent<Transform>();
        escala = temp_obj.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time < tempo){transform.Translate(vel_x*Time.deltaTime,vel_y*Time.deltaTime,0);
        if(inverter){temp_obj.localScale= new Vector3(escala.x*-1,escala.y,1);}}
        if(time > tempo&&time < (tempo*2)){transform.Translate(-vel_x*Time.deltaTime,-vel_y*Time.deltaTime,0);
        if(inverter){temp_obj.localScale= new Vector3(escala.x,escala.y,1);}}
        if(time > (tempo*2)){time= 0;}
    }
}
