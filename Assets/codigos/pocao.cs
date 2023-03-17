using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pocao : MonoBehaviour
{
    public bool ativado;
    public Hero heroi;
    public GameObject som_cena;
    public AudioSource som;
    // Start is called before the first frame update
    void Start()
    {
        som_cena= GameObject.Find("life_sound");
        som = som_cena.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)){
            if(ativado){
                heroi.baseAnim.SetBool("PickupPowerup",true);
                som.Play();
                heroi.currentLife +=20;
                heroi.lifeBar.EnableLifeBar(true);
                heroi.lifeBar.SetProgress(heroi.currentLife / heroi.maxLife);
                
                if(heroi.currentLife>heroi.maxLife){
                    heroi.currentLife = heroi.maxLife;
                }
                 Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter(Collider other) {
        if(!ativado){
            if(other.gameObject.tag =="Hero"){
                heroi =  other.GetComponent<Hero>();
                ativado= true;
            }
            
        }
        
    }
    void OnTriggerStay(Collider hitCollider)
    {
        if(!ativado){
            if(hitCollider.gameObject.tag =="Hero"){
                heroi =  hitCollider.GetComponent<Hero>();
                ativado= true;

                
            }
            if(hitCollider.gameObject.tag !="Hero"){
                transform.Translate( Time.deltaTime*Random.Range(-0.8f,0.8f), Time.deltaTime*Random.Range(-0.6f,0.6f),0, Space.World);
            }
        }
    }
     private void OnTriggerExit(Collider other) {
        if(other.gameObject.tag =="Hero"){
            ativado= false;
        }
     }
}
