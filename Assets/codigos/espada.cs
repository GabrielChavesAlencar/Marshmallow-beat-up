using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class espada : MonoBehaviour
{
    public bool ativado;

    public GameObject temp;
     public SpriteRenderer render;
    public Sprite [] imagens;
    public bool armas;
    public int num_arma;
    public bool cano;

    // Start is called before the first frame update
    void Start()
    {
     //   render = GetComponent<SpriteRenderer>();
        
        if(armas){
           // render.sprite = imagens[Random.Range(0,imagens.Length)];
        }
    }
    private void OnEnable() {
        
        if(armas){

            //num_arma = Random.Range(0,imagens.Length);
           // if(cano){num_arma = 7;}
            if(GameManager.CurrentLevel == 0){
                num_arma = Random.Range(0,2);
            }
            else if(GameManager.CurrentLevel == 1){
                num_arma = Random.Range(2,4);
            }
            else if(GameManager.CurrentLevel == 2){
                num_arma = Random.Range(4,6);
            }
            else if(GameManager.CurrentLevel == 3){
                num_arma = Random.Range(6,8);
            }
            else if(GameManager.CurrentLevel == 4){
                num_arma = Random.Range(8,10);
            }
            else if(GameManager.CurrentLevel == 5){
                num_arma = Random.Range(10,12);
            }
            else if(GameManager.CurrentLevel == 6){
                num_arma = Random.Range(12,14);
            }
            render.sprite = imagens[num_arma];
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)){
            if(ativado){
                temp.GetComponent<Hero>().baseAnim.SetBool("PickupPowerup",true);
                Destroy(gameObject);
                temp.GetComponent<Hero>().ativar_espada();
                 temp.GetComponent<Hero>().num_arma = num_arma;
                temp.GetComponent<Hero>().sprite_arma.sprite = temp.GetComponent<Hero>().imagens_armas[num_arma];
                Hero.espada_sprite = temp.GetComponent<Hero>().imagens_armas[num_arma];
                temp.GetComponent<Hero>().baseAnim.SetBool("espada",true);
            }
        }
    }
    void OnTriggerStay(Collider hitCollider)
    {
         if(hitCollider.gameObject.tag =="Hero"){
            ativado = true;
            temp = hitCollider.gameObject;
        }
    }
    private void OnTriggerExit(Collider other) {

        if(other.gameObject.tag =="Hero"){
            ativado = false;
            temp = other.gameObject;
        }
        
    }
}
