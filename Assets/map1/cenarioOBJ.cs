using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cenarioOBJ : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 original;
    public Transform temp_obj;

    public float tamanho_x;
    public float tamanho_y;
    //0.002
    public float tempo;

    public float time;
    void Start()
    {
      // original = GetComponent<Transform>();
        temp_obj = GetComponent<Transform>();
        original = temp_obj.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        /*
        if(time > tempo){temp_obj.localScale = new Vector3(temp_obj.localScale.x+tamanho_x,temp_obj.localScale.y+tamanho_y,1);}
        if(time > (tempo*2)){temp_obj.localScale = new Vector3(temp_obj.localScale.x-(tamanho_x*2),temp_obj.localScale.y-(tamanho_y*2),1);}
        if(time > (tempo*3)){time=0;temp_obj.localScale = original;}
        */


        if(time < tempo){temp_obj.localScale = new Vector3(temp_obj.localScale.x+tamanho_x,temp_obj.localScale.y+tamanho_y,1);}
        if(time > tempo&&time < (tempo*2)){temp_obj.localScale = new Vector3(temp_obj.localScale.x-tamanho_x,temp_obj.localScale.y-tamanho_y,1);}
        if(time > (tempo*2)){time=0;
        //temp_obj.localScale = original;
        }
        
    }
}
