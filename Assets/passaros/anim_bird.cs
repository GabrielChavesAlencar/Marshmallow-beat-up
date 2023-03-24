using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anim_bird : MonoBehaviour
{
    public int indice_personagem;

    public SpriteRenderer braco_esquerdo;
    public int num_braco_esquerdo;

    public SpriteRenderer braco_direito;
    public int num_braco_direito;

    public SpriteRenderer perna_esquerda;
    public int num_perna_esquerda;

    public SpriteRenderer perna_direita;
    public int num_perna_direita;

    public SpriteRenderer torax;
    public int num_torax;

    public SpriteRenderer cabeca;
    public int num_cabeca;

    [Header("RED BIRD\n")]
    public Sprite [] bracos_E;
    public Sprite [] bracos_D;
    public Sprite [] Perna_E;
    public Sprite [] Perna_D;
    public Sprite [] tox;
    public Sprite [] cabe;


    [Header("HIPPIE OWL\n")]
    public Sprite [] hippie_bracos_E;
    public Sprite [] hippie_bracos_D;
    public Sprite [] hippie_Perna_E;
    public Sprite [] hippie_Perna_D;
    public Sprite [] hippie_tox;
    public Sprite [] hippie_cabe;

    [Header("SKULL BIRD\n")]
    public Sprite [] skull_bracos_E;
    public Sprite [] skull_bracos_D;
    public Sprite [] skull_Perna_E;
    public Sprite [] skull_Perna_D;
    public Sprite [] skull_tox;
    public Sprite [] skull_cabe;

    
    // Start is called before the first frame update
    void Start()
    {
        if(MainMenu.num_perso>3){
            indice_personagem = MainMenu.num_perso-4;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(indice_personagem == 0){
            braco_esquerdo.sprite = bracos_E[num_braco_esquerdo];
            braco_direito.sprite = bracos_D[num_braco_direito];

            perna_esquerda.sprite = Perna_E[num_perna_esquerda];
            perna_direita.sprite = Perna_D[num_perna_direita];

            torax.sprite = tox[num_torax];
            cabeca.sprite = cabe[num_cabeca];
        }

        if(indice_personagem == 1){
            braco_esquerdo.sprite = hippie_bracos_E[num_braco_esquerdo];
            braco_direito.sprite = hippie_bracos_D[num_braco_direito];

            perna_esquerda.sprite = hippie_Perna_E[num_perna_esquerda];
            perna_direita.sprite = hippie_Perna_D[num_perna_direita];

            torax.sprite = hippie_tox[num_torax];
            cabeca.sprite = hippie_cabe[num_cabeca];
        }

        if(indice_personagem == 2){
            braco_esquerdo.sprite = skull_bracos_E[num_braco_esquerdo];
            braco_direito.sprite = skull_bracos_D[num_braco_direito];

            perna_esquerda.sprite = skull_Perna_E[num_perna_esquerda];
            perna_direita.sprite = skull_Perna_D[num_perna_direita];

            torax.sprite = skull_tox[num_torax];
            cabeca.sprite = skull_cabe[num_cabeca];
        }
        
    }
}
