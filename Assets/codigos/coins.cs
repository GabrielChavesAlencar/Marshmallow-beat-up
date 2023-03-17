using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coins : MonoBehaviour
{
    public bool ativado;
    public GameObject som_cena;
    public AudioSource som;

    public GameObject obj_pai;
    
    // Start is called before the first frame update
    void Start()
    {
        som_cena= GameObject.Find("coinsplash");
        som = som_cena.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        obj_pai.transform.position = transform.position;
        if(obj_pai.GetComponent<HeroDetector>().heroIsNearby){
            if(obj_pai.GetComponent<HeroDetector>().player.transform.position.x>transform.position.x){
                transform.Translate(Time.deltaTime/20,0,0);
            }
            else{
                transform.Translate(-Time.deltaTime/20,0,0);
            }

            if(obj_pai.GetComponent<HeroDetector>().player.transform.position.y>transform.position.y){
                transform.Translate(0,Time.deltaTime/20,0);
            }
            else{
                transform.Translate(0,-Time.deltaTime/20,0);
            }
            if(obj_pai.GetComponent<HeroDetector>().player.transform.position.z>transform.position.z){
                transform.Translate(0,0,Time.deltaTime/20);
            }
            else{
                transform.Translate(0,0,-Time.deltaTime/20);
            }
        }
        else{
            GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(!ativado){
            if(other.gameObject.tag =="Hero"){
                if(powerUp.moreMoney){
                    //jogo.coins+=1.15f;
                    bancodedados.salvarfloat("coins",bancodedados.carregarfloat("coins")+1.15f);
                }
                else{
                    //jogo.coins++;
                    bancodedados.salvarfloat("coins",bancodedados.carregarfloat("coins")+1);
                }
                som.Play();
                
                Destroy(obj_pai);
                Destroy(gameObject);
                ativado= true;
            }
            
        }
        
    }
    void OnTriggerStay(Collider hitCollider)
    {
        if(!ativado){
            if(hitCollider.gameObject.tag =="Hero"){
                som.Play();
                if(powerUp.moreMoney){
                    //sjogo.coins+=1.15f;
                    bancodedados.salvarfloat("coins",bancodedados.carregarfloat("coins")+1.15f);
                }
                else{
                   // jogo.coins++;
                    bancodedados.salvarfloat("coins",bancodedados.carregarfloat("coins")+1);
                }
                Destroy(gameObject);
                ativado= true;
                
            }
            if(hitCollider.gameObject.tag !="Hero"){
               // transform.Translate(Time.deltaTime*Random.Range(-0.9f,0.9f), Time.deltaTime*Random.Range(-0.9f,0.9f),0, Space.World);
            }
        }
    }
}
