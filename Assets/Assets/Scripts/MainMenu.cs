using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class MainMenu : MonoBehaviour {

    private Coroutine loadingRoutine;
    public GameObject menu;
    public GameObject classificacao;
    public GameObject shop;
    public GameObject menu_personagens;
    public GameObject menu_nome;
    public GameObject menu_multiplayer;

    //public static bool clasificacao_ativado;
    public static int indice_ativado;
    public static int num_perso;
    public InputField input_nome;
    public bool usuario_existente;
    public int num_player;
    public Text botao_name;

	// Use this for initialization
	void Start() 
    {
      DateTime utcTime = DateTime.UtcNow;
//      print(utcTime.Day);


    //eventos com datas
      if(utcTime.Year>=2023&&utcTime.Month>=3&&utcTime.Day>=2){
      //   print("ativar");
      }
      if(utcTime.Year>=2023&&utcTime.Month>=3&&utcTime.Day>=23){
        // print("ativar");
      }
      if(utcTime.Year>=2023&&utcTime.Month>=4&&utcTime.Day>=13){
         //print("ativar");
      }











       if(bancodedados.carregarString("nome_player")==""){
            indice_ativado = 4;
       }
        Application.targetFrameRate = 60;
        AudioManager.Instance.GetComponent<AudioSource>().Play();
	}
	
	// Update is called once per frame
	public void GoToGame()
    {
        jogo.Score =0;
        Hero.espada_ativada = false;
        if (loadingRoutine == null)
            loadingRoutine = StartCoroutine(LoadGameScene(2.0f));

    }
    private void Update() {
         if(input_nome.text!=""){
            usuario_existente= false;
            for(int i = 0; i < bancodedados.carregarint("tamanho"); i++) {
                if(bancodedados.carregarString(""+(i+1))==input_nome.text){
                    num_player = (i+1);
                    usuario_existente = true;
                }
            }
            if(usuario_existente){
                botao_name.text = "SELECT";
            }
            else{
                botao_name.text = "SAVE";
            }
        }
        if(indice_ativado==0){menu.SetActive(true);}
        else{menu.SetActive(false);}

        if(indice_ativado==1){classificacao.SetActive(true);}
        else{classificacao.SetActive(false);}

        if(indice_ativado==2){shop.SetActive(true);}
        else{shop.SetActive(false);}

        if(indice_ativado==3){menu_personagens.SetActive(true);}
        else{menu_personagens.SetActive(false);}

        if(indice_ativado==4){menu_nome.SetActive(true);}
        else{menu_nome.SetActive(false);}

        if(indice_ativado==5){menu_multiplayer.SetActive(true);}
        else{menu_multiplayer.SetActive(false);}
        
    }

    private IEnumerator LoadGameScene(float delayDuration)
    {
        yield return new WaitForSeconds(delayDuration);
        GameManager.CurrentLevel = 0;
        SceneManager.LoadScene("Game");
    }
    public void trocar_tela (int indice) {
        indice_ativado = indice;
    }
    public void selecionar_perso (int num) {
        num_perso = num;
    }
    public void salvar_nome () {
        if(input_nome.text!=""){
            if(!usuario_existente){
                bancodedados.salvarnome("nome_player",input_nome.text);
            }
            else{
                print(bancodedados.carregarString(""+num_player));
                bancodedados.salvarString("nome_player",bancodedados.carregarString(""+num_player));
            }
            indice_ativado =0;
            
        }
    }

  
}
