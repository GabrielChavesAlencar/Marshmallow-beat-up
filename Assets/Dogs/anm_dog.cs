using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anm_dog : MonoBehaviour
{
    public int indice_personagem;
    public bool customizavel;
    public bool dog_cpu;

    public SpriteRenderer pata_dianteira_frente;
    public int num_dianteira_frente;

    public SpriteRenderer pata_dianteira_tras;
    public int num_dianteira_tras;

    public SpriteRenderer pata_trazeira_frente;
    public int num_trazeira_frente;

    public SpriteRenderer pata_trazeira_tras;
    public int num_trazeira_tras;

    public SpriteRenderer corpo;
    public int num_corpo;

    public SpriteRenderer rabo;
    public int num_rabo;

    public SpriteRenderer cabeca;
    public int num_cabeca;

    public SpriteRenderer boca;
    public int num_boca;
    public int num_boca_mutavel;
    public int num_eye;
    public int num_camiseta;

    [Header("Mutant\n")]
    public Sprite [] pata_d_f;
    public Sprite [] pata_d_t;
    public Sprite [] pata_t_f;
    public Sprite [] pata_t_t;
    public Sprite [] cor;
    public Sprite [] rab;
    public Sprite [] cabe;
    public Sprite [] boc_aberta;
    public Sprite [] boc_fechada;


    public int num_camiseta_cpu;
    public int num_eye_cpu;
    public int num_corpo_cpu;
    public int num_boca_mutavel_cpu;
    // Start is called before the first frame update
    void Start()
    {
        num_camiseta_cpu = Random.Range(0,7);
        num_eye_cpu = Random.Range(0,85);
        num_corpo_cpu = Random.Range(0,39);
        num_boca_mutavel_cpu = Random.Range(0,56);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
           // Debug.Log(Input.mousePosition);
           /*
           num_boca_mutavel++;
           if(num_boca_mutavel>55){num_boca_mutavel=0;}
           */
           
        }
        /*
        if (Input.GetKeyDown(KeyCode.O)){
           num_corpo++;
      }
      */
        //patas
        
       

        
      //  rabo.sprite = rab[num_rabo];


       // cabeca.sprite = cabe[num_cabeca];
        
        if(num_boca==0){boca.sprite = boc_aberta[num_boca_mutavel];}
        if(num_boca==1){boca.sprite = boc_fechada[num_boca_mutavel];}
        
        if(dog_cpu){
            if(num_boca==0){boca.sprite = boc_aberta[num_boca_mutavel_cpu];}
            if(num_boca==1){boca.sprite = boc_fechada[num_boca_mutavel_cpu];}

            pata_dianteira_frente.sprite = pata_d_f[num_corpo_cpu];
            pata_dianteira_tras.sprite = pata_d_t[num_corpo_cpu];
            pata_trazeira_frente.sprite = pata_t_f[num_corpo_cpu];
            pata_trazeira_tras.sprite = pata_t_t[num_corpo_cpu];
            corpo.sprite = cor[num_corpo_cpu];
            cabeca.sprite = cabe[num_corpo_cpu];
            rabo.sprite = rab[num_corpo_cpu];

        }
        else{
            if(customizavel){
                pata_dianteira_frente.sprite = pata_d_f[num_corpo];
                pata_dianteira_tras.sprite = pata_d_t[num_corpo];
                pata_trazeira_frente.sprite = pata_t_f[num_corpo];
                pata_trazeira_tras.sprite = pata_t_t[num_corpo];
                corpo.sprite = cor[num_corpo];
                cabeca.sprite = cabe[num_corpo];
                rabo.sprite = rab[num_corpo];

            }
            else{
                pata_dianteira_frente.sprite = pata_d_f[0];
                pata_dianteira_tras.sprite = pata_d_t[0];
                pata_trazeira_frente.sprite = pata_t_f[0];
                pata_trazeira_tras.sprite = pata_t_t[0];
                cabeca.sprite = cabe[0];
                rabo.sprite = rab[0];
                corpo.sprite = cor[0];

            }
        }
        
    }
    private void OnEnable() {
        if(customizavel){
        //    num_eye = bancodedados.carregarint("Eyes_dog"+bancodedados.carregarint("selecionar"));
         //   num_boca_mutavel = bancodedados.carregarint("Boca_dog"+bancodedados.carregarint("selecionar"));
         //   num_corpo = bancodedados.carregarint("Body_dog"+bancodedados.carregarint("selecionar"));
          //  num_camiseta = bancodedados.carregarint("roupas_dog"+bancodedados.carregarint("selecionar"));
        }
    }
}
