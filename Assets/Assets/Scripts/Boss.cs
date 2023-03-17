using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy {

    public bool morreu;
	// Use this for initialization
	protected override void Start () 
    {

        base.Start();
        canFlinch = false;
        morteboss = true;
        if(jogo.dificuldade>0){
            maxLife = maxLife+(jogo.dificuldade*50);
            currentLife = maxLife;
            lifeBar.SetProgress(currentLife);
        }
	}

    public override void TakeDamage(float value, Vector3 hitVector, bool knockdown = false)
    {
        base.TakeDamage(value, hitVector, false);
    }
    public override  void Update() {
        base.Update();
        if(currentLife<=0){
            jogo.escuro = true;
            if(!morreu){
                if(jogo.dificuldade>0){jogo.Score+=10+(jogo.dificuldade*10);}
                else{jogo.Score+=10;}
                jogo.dificuldade++;
                morreu=true;
            }
        }
    }

}
