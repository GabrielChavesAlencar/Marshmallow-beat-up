using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour
{
    public bool dano;
    public GameObject dir;
    public Actor actor;
    public Collider triggerCollider;

    public GameObject som_cena;
    public AudioSource som;

    public int x;

    public float time;
    // Start is called before the first frame update
    void Start()
    {
        som_cena= GameObject.Find("somlaser");
        som = som_cena.GetComponent<AudioSource>();
        if(dir.transform.localScale.x>0){
             x =5;
        }
        else{
             x = -5;
        }
    }

    // Update is called once per frame
    void Update()
    {
        time +=  Time.deltaTime;
        if(time>10){
             Destroy(gameObject);
        }
        /*
        if(dir.transform.localScale.x>0){
             
        }
        else{
             transform.Translate( Time.deltaTime*-3,0, 0, Space.World);
        }
        */
        transform.Translate( Time.deltaTime*x,0, 0, Space.World);
       
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
/*

    void OnTriggerEnter(Collider hitCollider)
    {
        
        Vector3 direction = new Vector3(hitCollider.transform.position.x -
                                        actor.transform.position.x, 0, 0);
        direction.Normalize();
        

        BoxCollider collider = triggerCollider as BoxCollider;
        Vector3 centerPoint = this.transform.position;
        if (collider)
        {
            centerPoint = transform.TransformPoint(collider.center);
        }

        Vector3 startPoint = hitCollider.ClosestPointOnBounds(centerPoint);
       actor.DidHitObject(hitCollider, startPoint, direction);
       
       if( hitCollider.gameObject.tag =="Hero"){
        Vector3 x = new Vector3(0,0,0);
        hitCollider.gameObject.GetComponent<Hero>().TakeDamage(10,x,false);
            Destroy(gameObject);
            print("dano!");
       }
      
       
    }
    */
}
