using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projetil : MonoBehaviour
{
    public Actor actor;
    public Collider triggerCollider;
    public Rigidbody rig;
    public float virar;
    public int invert;
    public float time;

    public bool rotacao;
    public int dano;
    public bool arremecar;
    public SpriteRenderer render;
    public Sprite [] imagens;
    public bool armas;
    public int num_arma;
    public GameObject power_up;


    void OnTriggerEnter(Collider hitCollider)
    {
        
        if(hitCollider.gameObject.tag =="Dog"){
            Vector3 temp = new Vector3(0,0,0);
            
            if(arremecar){
                
                hitCollider.GetComponent<Actor>().TakeDamage(dano,temp,true);
                if(transform.localScale.x>0)hitCollider.GetComponent<Rigidbody>().AddForce(-300,270,0);
                else{hitCollider.GetComponent<Rigidbody>().AddForce(300,270,0);}
                 
                
            }
            else{
                hitCollider.GetComponent<Actor>().TakeDamage(dano,temp,false);
                if(power_up!=null){
                GameObject obj = Instantiate(power_up);
                obj.transform.position = transform.position;}
            }
            
            
            Destroy(gameObject);
        }
    }
    private void Start() {
        render = GetComponent<SpriteRenderer>();
        rig = GetComponent<Rigidbody>();
        if(armas){
            //render.sprite = imagens[Random.Range(0,imagens.Length)];
        }
        if(transform.localScale.x>0){
            if(!arremecar)rig.AddForce(Vector3.right*600);
            if(rotacao)transform.rotation = Quaternion.Euler(new Vector3(0,0,-40));
            invert = -1;
        }else{
            if(!arremecar)rig.AddForce(Vector3.left*600);
            if(rotacao)transform.rotation = Quaternion.Euler(new Vector3(0,0,40));
            invert = 1;
        }
        
    }
    private void Update() {
        if(armas){
          //  render.sprite = imagens[num_arma];
        }
        if(rotacao)virar +=Time.deltaTime*(900*invert);
        transform.rotation = Quaternion.Euler(new Vector3(0,0,virar));

        time +=  Time.deltaTime;
        if(!arremecar){
            if(time>1){
                Destroy(gameObject);
            }
        }else{
            if(time>0.5f){
                Destroy(gameObject);
            }
        }
    }
}
