using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class powerUp : MonoBehaviour
{
    public Hero heroi;
    public static bool moreMoney;

    public GameObject [] powerUps;
    public static float tempo;
    public Text tempo1;

    // Start is called before the first frame update
    void Start()
    {
        heroi = GameObject.Find(jogo.nome_jogador).GetComponent<Hero>();
        if(bancodedados.carregarint("PowerUp")==1&&tempo<=0){
            tempo = 99;
            heroi.walkSpeed = 5;
            heroi.runSpeed = 10;
        }
        if(bancodedados.carregarint("PowerUp")==0){
            powerUps[0].SetActive(false);
            powerUps[1].SetActive(false);
            powerUps[2].SetActive(false);
            fim_powerup();
            tempo1.enabled = false;
            heroi.walkSpeed = 2;
            heroi.runSpeed = 5;
        }
        ataque_atualizado();

    }

    // Update is called once per frame
    void Update()
    {
  
         if(bancodedados.carregarint("PowerUp")==1){
            tempo-=Time.deltaTime;
            tempo1.text =(int)tempo+"";
            if(tempo<=0){
                bancodedados.salvarint("PowerUp",0);
                tempo =0;
            }
            if(tempo>0){
                powerUps[0].SetActive(true);
                powerUps[1].SetActive(true);
                powerUps[2].SetActive(true);
                powerup1();
                powerup2();
                powerup3();
                tempo1.enabled = true;
            }
            else{
                powerUps[0].SetActive(false);
                powerUps[1].SetActive(false);
                powerUps[2].SetActive(false);
                fim_powerup();
                tempo1.enabled = false;
            }

        }
        
       
        
    }
    public void powerup1 () {
        heroi.normalAttack.attackDamage = 20+(10*bancodedados.carregarint("level_atack"));
        heroi.normalAttack2.attackDamage = 20+(10*bancodedados.carregarint("level_atack"));
        heroi.normalAttack3.attackDamage = 40+(10*bancodedados.carregarint("level_atack"));
        heroi.walkSpeed = 5;
        heroi.runSpeed = 10;
    }
    public void ataque_atualizado () {
        heroi.normalAttack.attackDamage = 10+(10*bancodedados.carregarint("level_atack"));
        heroi.normalAttack2.attackDamage = 10+(10*bancodedados.carregarint("level_atack"));
        heroi.normalAttack3.attackDamage = 20+(10*bancodedados.carregarint("level_atack"));
    }
    public void powerup2 () {
        moreMoney = true;
    }
    public void powerup3 () {
         jogo.more_artefatis = true;
        
    }
    public void fim_powerup () {
        heroi.normalAttack.attackDamage = 10;
        heroi.normalAttack2.attackDamage = 10;
        heroi.normalAttack3.attackDamage = 20;
        heroi.walkSpeed = 2;
        heroi.runSpeed = 5;
        moreMoney = false;
        jogo.more_artefatis = false;
    }

}
