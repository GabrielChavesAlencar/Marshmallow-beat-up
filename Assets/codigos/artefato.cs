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
         int num_arma = 0;
        //int num_arma = Random.Range(0,imagens.Length);
        if(GameManager.CurrentLevel == 0){
            num_arma = Random.Range(0,3);
        }
        else if(GameManager.CurrentLevel == 1){
            num_arma = Random.Range(3,6);
        }
        else if(GameManager.CurrentLevel == 2){
            num_arma = Random.Range(6,9);
        }
        else if(GameManager.CurrentLevel == 3){
            num_arma = Random.Range(9,12);
        }
        else if(GameManager.CurrentLevel == 4){
            num_arma = Random.Range(12,15);
        }
        else if(GameManager.CurrentLevel == 5){
            num_arma = Random.Range(15,18);
        }
        else if(GameManager.CurrentLevel == 6){
            num_arma = Random.Range(18,21);
        }
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
