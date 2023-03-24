using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation : MonoBehaviour
{
    public int num_perso;
    public bool customizavel;

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
    public bool  inimigo;

    [Header("APE BLUE\n")]
    public Sprite [] bracos_E;
    public Sprite [] bracos_D;
    public Sprite [] Perna_E;
    public Sprite [] Perna_D;
    public Sprite [] tox;
    public Sprite [] cabe;
    

    [Header("BLACK TEXUDO\n")]
    public Sprite [] Black_bracos_E;
    public Sprite [] Black_bracos_D;
    public Sprite [] Black_Perna_E;
    public Sprite [] Black_Perna_D;
    public Sprite [] Black_tox;
    public Sprite [] Black_cabe;

    [Header("EVIL MUTANTE\n")]
    public Sprite [] Evil_Mutant_bracos_E;
    public Sprite [] Evil_Mutant_bracos_D;
    public Sprite [] Evil_Mutant_Perna_E;
    public Sprite [] Evil_Mutant_Perna_D;
    public Sprite [] Evil_Mutant_tox;
    public Sprite [] Evil_Mutant_cabe;

    [Header("Bathrobe\n")]
    public Sprite [] Bathrobe_bracos_E;
    public Sprite [] Bathrobe_bracos_D;
    public Sprite [] Bathrobe_Perna_E;
    public Sprite [] Bathrobe_Perna_D;
    public Sprite [] Bathrobe_tox;
    public Sprite [] Bathrobe_cabe;

    [Header("Zombie\n")]
    public Sprite [] Zombie_bracos_E;
    public Sprite [] Zombie_bracos_D;
    public Sprite [] Zombie_Perna_E;
    public Sprite [] Zombie_Perna_D;
    public Sprite [] Zombie_tox;
    public Sprite [] Zombie_cabe;

    [Header("Blue_Zombie\n")]
    public Sprite [] Blue_Zombie_bracos_E;
    public Sprite [] Blue_Zombie_bracos_D;
    public Sprite [] Blue_Zombie_Perna_E;
    public Sprite [] Blue_Zombie_Perna_D;
    public Sprite [] Blue_Zombie_tox;
    public Sprite [] Blue_Zombie_cabe;


   
    [Header("CONTROLADORES\n")]
    public int part_cabeca,part_torax,part_bracos,part_pernas;
    public Robot bot;

    
   
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
       // num_perso = MainMenu.num_perso;
       // num_perso = 3;
        if(MainMenu.num_perso<4&&!inimigo){
            num_perso = MainMenu.num_perso;
        }
        else{
            float indiceinimigo = Random.Range(0,10);
            if(indiceinimigo>4){
                num_perso =4;
                bot.actorThumbnail = Zombie_cabe[0];
            }
            else{num_perso =5;bot.actorThumbnail = Blue_Zombie_cabe[0];}
        }
        num_perso =3;

    }

    // Update is called once per frame
    void Update()
    {
        if(customizavel){
            if(part_cabeca == 0){cabeca.sprite = cabe[num_cabeca];}
            if(part_cabeca == 1){cabeca.sprite = Evil_Mutant_cabe[num_cabeca];}
            if(part_cabeca == 2){cabeca.sprite = Black_cabe[num_cabeca];}
            if(part_cabeca == 3){cabeca.sprite = Zombie_cabe[num_cabeca];}
            if(part_cabeca == 4){cabeca.sprite = Zombie_cabe[num_cabeca];}

            if(part_torax == 0){torax.sprite = tox[num_torax];}
            if(part_torax == 1){torax.sprite = Evil_Mutant_tox[num_torax];}
            if(part_torax == 2){torax.sprite = Black_tox[num_torax];}
            if(part_torax == 3){torax.sprite = Zombie_tox[num_torax];}
            if(part_torax == 4){torax.sprite = Zombie_tox[num_torax];}

            if(part_bracos == 0){braco_esquerdo.sprite = bracos_E[num_braco_esquerdo];              braco_direito.sprite = bracos_D[num_braco_direito];}
            if(part_bracos == 1){braco_esquerdo.sprite = Evil_Mutant_bracos_E[num_braco_esquerdo];  braco_direito.sprite = Evil_Mutant_bracos_D[num_braco_direito];}
            if(part_bracos == 2){braco_esquerdo.sprite = Black_bracos_E[num_braco_esquerdo];        braco_direito.sprite = Black_bracos_D[num_braco_direito];}
            if(part_bracos == 3){braco_esquerdo.sprite = Zombie_bracos_E[num_braco_esquerdo];        braco_direito.sprite = Zombie_bracos_D[num_braco_direito];}
            if(part_bracos == 4){braco_esquerdo.sprite = Zombie_bracos_E[num_braco_esquerdo];        braco_direito.sprite = Zombie_bracos_D[num_braco_direito];}

            if(part_pernas == 0){perna_esquerda.sprite = Perna_E[num_perna_esquerda];              perna_direita.sprite = Perna_D[num_perna_direita];}
            if(part_pernas == 1){perna_esquerda.sprite = Evil_Mutant_Perna_E[num_perna_esquerda];  perna_direita.sprite = Evil_Mutant_Perna_D[num_perna_direita];}
            if(part_pernas == 2){perna_esquerda.sprite = Black_Perna_E[num_perna_esquerda];        perna_direita.sprite = Black_Perna_D[num_perna_direita];}
            if(part_pernas == 3){perna_esquerda.sprite = Zombie_Perna_E[num_perna_esquerda];        perna_direita.sprite = Zombie_Perna_D[num_perna_direita];}
            if(part_pernas == 4){perna_esquerda.sprite = Zombie_Perna_E[num_perna_esquerda];        perna_direita.sprite = Zombie_Perna_D[num_perna_direita];}
        }
        if(!customizavel){
            if(num_perso==0){
                braco_esquerdo.sprite = bracos_E[num_braco_esquerdo];
                braco_direito.sprite = bracos_D[num_braco_direito];

                perna_esquerda.sprite = Perna_E[num_perna_esquerda];
                perna_direita.sprite = Perna_D[num_perna_direita];

                torax.sprite = tox[num_torax];
                cabeca.sprite = cabe[num_cabeca];
            }


            if(num_perso==1){
                braco_esquerdo.sprite = Black_bracos_E[num_braco_esquerdo];
                braco_direito.sprite = Black_bracos_D[num_braco_direito];

                perna_esquerda.sprite = Black_Perna_E[num_perna_esquerda];
                perna_direita.sprite = Black_Perna_D[num_perna_direita];

                torax.sprite = Black_tox[num_torax];
                cabeca.sprite = Black_cabe[num_cabeca];
            }
            if(num_perso==2){
                braco_esquerdo.sprite = Evil_Mutant_bracos_E[num_braco_esquerdo];
                braco_direito.sprite = Evil_Mutant_bracos_D[num_braco_direito];

                perna_esquerda.sprite = Evil_Mutant_Perna_E[num_perna_esquerda];
                perna_direita.sprite = Evil_Mutant_Perna_D[num_perna_direita];

                torax.sprite = Evil_Mutant_tox[num_torax];
                cabeca.sprite = Evil_Mutant_cabe[num_cabeca];
            }
            if(num_perso==3){
                braco_esquerdo.sprite = Bathrobe_bracos_E[num_braco_esquerdo];
                braco_direito.sprite = Bathrobe_bracos_D[num_braco_direito];
                if(Bathrobe_Perna_E[num_perna_esquerda]==null){
                    perna_esquerda.sprite = Bathrobe_Perna_E[0];
                }
                else{
                    perna_esquerda.sprite = Bathrobe_Perna_E[num_perna_esquerda];
                }
                if(Bathrobe_Perna_D[num_perna_direita]==null){
                    perna_direita.sprite = Bathrobe_Perna_D[0];
                }
                else{
                    perna_direita.sprite = Bathrobe_Perna_D[num_perna_direita];
                }

                torax.sprite = Bathrobe_tox[num_torax];
                cabeca.sprite = Bathrobe_cabe[num_cabeca];
            }
            if(num_perso==4){
                braco_esquerdo.sprite = Zombie_bracos_E[num_braco_esquerdo];
                braco_direito.sprite = Zombie_bracos_D[num_braco_direito];
                if(Zombie_Perna_E[num_perna_esquerda]==null){
                    perna_esquerda.sprite = Zombie_Perna_E[0];
                }
                else{
                    perna_esquerda.sprite = Zombie_Perna_E[num_perna_esquerda];
                }
                if(Zombie_Perna_D[num_perna_direita]==null){
                    perna_direita.sprite = Zombie_Perna_D[0];
                }
                else{
                    perna_direita.sprite = Zombie_Perna_D[num_perna_direita];
                }

                torax.sprite = Zombie_tox[num_torax];
                cabeca.sprite = Zombie_cabe[num_cabeca];
            }
            if(num_perso==5){
                braco_esquerdo.sprite = Blue_Zombie_bracos_E[num_braco_esquerdo];
                braco_direito.sprite = Blue_Zombie_bracos_D[num_braco_direito];
                if(Blue_Zombie_Perna_E[num_perna_esquerda]==null){
                    perna_esquerda.sprite = Blue_Zombie_Perna_E[0];
                }
                else{
                    perna_esquerda.sprite = Blue_Zombie_Perna_E[num_perna_esquerda];
                }
                if(Blue_Zombie_Perna_D[num_perna_direita]==null){
                    perna_direita.sprite = Blue_Zombie_Perna_D[0];
                }
                else{
                    perna_direita.sprite = Blue_Zombie_Perna_D[num_perna_direita];
                }

                torax.sprite = Blue_Zombie_tox[num_torax];
                cabeca.sprite = Blue_Zombie_cabe[num_cabeca];
            }
            
        }
    }
    private void OnEnable() {
        if(customizavel){
         //   part_cabeca = bancodedados.carregarint("cabeca"+bancodedados.carregarint("selecionar"));
         //   part_torax = bancodedados.carregarint("torax"+bancodedados.carregarint("selecionar"));
         //   part_bracos = bancodedados.carregarint("bracos"+bancodedados.carregarint("selecionar"));
          //  part_pernas = bancodedados.carregarint("pernas"+bancodedados.carregarint("selecionar"));
        }
    }
}
