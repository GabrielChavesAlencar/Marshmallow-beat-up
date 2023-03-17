using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bonequinho : MonoBehaviour
{
    public Sprite [] bracos;
    public Sprite [] pernas;
    public Sprite [] torax;
    public Sprite [] cabeca;

    public SpriteRenderer braco_esquerdo;

    public SpriteRenderer braco_direito;

    public SpriteRenderer perna_esquerda;

    public SpriteRenderer perna_direita;

    public SpriteRenderer chest;
    public SpriteRenderer head;
    public int indice;
    public bool inimigo;
    public Robot r;
    public Hero h;
    // Start is called before the first frame update
    void Start()
    {
        if(!inimigo){
            indice =MainMenu.num_perso;
            h.actorThumbnail =cabeca[indice];
            h.icone.sprite = cabeca[indice];
        }
        else{
            indice = Random.Range(0,2);
            r.actorThumbnail =cabeca[indice];

        }
        
        braco_esquerdo.sprite =bracos[indice];
        braco_direito.sprite =bracos[indice];
        perna_esquerda.sprite =pernas[indice];
        perna_direita.sprite =pernas[indice];
        chest.sprite =torax[indice];
        head.sprite =cabeca[indice];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
