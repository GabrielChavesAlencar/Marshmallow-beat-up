using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carroVoador : MonoBehaviour
{
    public float x;
    public float velocidade;
    public bool frente;
    // Start is called before the first frame update
    void Start()
    {
        x = transform.localScale.x;
        //velocidade = 1;
        frente=true;
    }

    // Update is called once per frame
    void Update()
    {
        if(frente){
            andar_frente();
            if(transform.position.x>70){
                frente = false;
            }
        }
        else{
            andar_tras();
             if(transform.position.x<2){
                frente = true;
            }
        }

    }
    public void andar_frente(){
        transform.Translate(Vector3.right*Time.deltaTime*velocidade);
        transform.localScale = new Vector3(x,transform.localScale.y,transform.localScale.z);
    }
    public void andar_tras(){
        transform.Translate(Vector3.right*Time.deltaTime*-velocidade);
        transform.localScale = new Vector3(-x,transform.localScale.y,transform.localScale.z);
    }
}
