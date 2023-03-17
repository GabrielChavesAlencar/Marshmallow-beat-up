using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SHOP : MonoBehaviour
{
    public GameObject [] textos;
    // Start is called before the first frame update
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
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
}
