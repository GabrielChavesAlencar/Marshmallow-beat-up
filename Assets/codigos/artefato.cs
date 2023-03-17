using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class artefato : MonoBehaviour
{
    public bool ativado;
    public Hero heroi;
    public GameObject som_cena;
    public AudioSource som;
    public SpriteRenderer render;
    public Sprite [] imagens;
    // Start is called before the first frame update
    void Start()
    {
        
        render = GetComponent<SpriteRenderer>();
        som_cena= GameObject.Find("life_sound");
        som = som_cena.GetComponent<AudioSource>();

        int num_arma = Random.Range(0,imagens.Length);
        render.sprite = imagens[num_arma];

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)){
            if(ativado){
                heroi.baseAnim.SetBool("PickupPowerup",true);
                som.Play();
                jogo.Score+=10;
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
                transform.Translate( Time.deltaTime*Random.Range(-0.1f,0.1f), Time.deltaTime*Random.Range(-0.1f,0.1f),0, Space.World);
            }
        }
    }
     private void OnTriggerExit(Collider other) {
        if(other.gameObject.tag =="Hero"){
            ativado= false;
        }
     }
}
