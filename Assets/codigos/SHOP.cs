using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SHOP : MonoBehaviour
{
    public GameObject [] textos;
    public Text money_text;
    public GameObject shop_nft;
    public GameObject shop_comun;

    public Text level_atack;
    public Text price_atack;
    public Text level_life;
    public Text price_life;
    // Start is called before the first frame update
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        price_atack.text = ((bancodedados.carregarint("level_atack")*bancodedados.carregarint("level_atack"))+1)*100+"$";
      
        level_atack.text = "LEVEL "+(bancodedados.carregarint("level_atack")+1);

        price_life.text = ((bancodedados.carregarint("level_life")*bancodedados.carregarint("level_life"))+1)*100+"$";
        level_life.text = "LEVEL "+(bancodedados.carregarint("level_life")+1);

        money_text.text = ""+bancodedados.carregarfloat("coins");
        if(bancodedados.carregarint("PowerUp")==0){textos[0].SetActive(false);}
        else{textos[0].SetActive(true);}

        if(bancodedados.carregarint("PowerUp")==0){textos[1].SetActive(false);}
        else{textos[1].SetActive(true);}

        if(bancodedados.carregarint("PowerUp")==0){textos[2].SetActive(false);}
        else{textos[2].SetActive(true);}
    }
    public void comprar_PowerUp () {
        bancodedados.salvarint("PowerUp",1);
    }
    public void comprar_atack () {
        float valor = ((bancodedados.carregarint("level_atack")*bancodedados.carregarint("level_atack"))+1)*100;
        if(bancodedados.carregarfloat("coins")>valor){
            bancodedados.salvarint("level_atack",bancodedados.carregarint("level_atack")+1);
            bancodedados.salvarfloat("coins",bancodedados.carregarfloat("coins")-valor);
            //bancodedados.carregarfloat("coins")
        }
    }
    public void comprar_life () {
        float valor = ((bancodedados.carregarint("level_life")*bancodedados.carregarint("level_life"))+1)*100;
        if(bancodedados.carregarfloat("coins")>valor){
            bancodedados.salvarint("level_life",bancodedados.carregarint("level_life")+1);
            bancodedados.salvarfloat("coins",bancodedados.carregarfloat("coins")-valor);
        }
        
    }
}
