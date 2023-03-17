using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bola_fogo : MonoBehaviour
{
    public GameObject som_cena;
    public AudioSource som;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        som_cena= GameObject.Find("flame");
        som = som_cena.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate( 0,-Time.deltaTime*10, 0, Space.World);
        time +=  Time.deltaTime;
        if(time>10){
             Destroy(gameObject);
        }
        
    }
    private void OnTriggerStay(Collider other) {
        if( other.gameObject.tag =="Hero"){
        Vector3 x = new Vector3(0,0,0);
        other.gameObject.GetComponent<Hero>().TakeDamage(10,x,false);
        som.Play();
            Destroy(gameObject);
            //print("dano!");
       }
    }
}
