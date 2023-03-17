using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;


public class jogo : MonoBehaviour
{
    public static float coins;
    public static bool gameOver;
    public Text coin_text;
    public Text Score_text;
    public GameObject menu_gameOver;
    public GameObject efeito_escuro;
    public static bool escuro;
    public static int Score;
    public static bool more_artefatis;
    public salvarPontuacao pont;
    public GameObject player;
    public static string nome_jogador;
    public static int dificuldade;
    public Text level_text;
    
    // Start is called before the first frame update
    private void Awake() {
     //  GameManager.CurrentLevel = 4;
       if(!NetworkControler.online){
            GameObject temp = Instantiate(player);
            nome_jogador =  temp.name;
        }
        else{
            GameObject temp = PhotonNetwork.Instantiate(player.name,player.transform.position,player.transform.rotation,0);
            nome_jogador =  temp.name;
            print("versao online");
        }
        //Instantiate(player);
    }
    void Start()
    {
        escuro = false;
        gameOver = false;
        coin_text.text = ""+bancodedados.carregarfloat("coins");
    }

    // Update is called once per frame
    void Update()
    {
        level_text.text="LEVEL "+dificuldade;
        Score_text.text=""+Score;
        efeito_escuro.SetActive(escuro);
       // coin_text.text = ""+(int)coins;
        coin_text.text = ""+bancodedados.carregarfloat("coins");
        menu_gameOver.SetActive(gameOver);
    }
    public void jogar_novamente () {
        
        SceneManager.LoadScene("Game");
        Hero.espada_ativada = false;
       salvar_score();
       dificuldade= 0;
       Score=0;
    }
    public void menu () {
        SceneManager.LoadScene("MainMenu");
        salvar_score();
        dificuldade= 0;
        Score=0;
    }
    public void salvar_score(){
        int melhor = bancodedados.carregarint("melhor_score");
        if(melhor<Score){
          bancodedados.salvarint("melhor_score",Score);
          melhor = Score;
       }
        //pont.salvar(bancodedados.carregarString("nome_player"),melhor);
    }
}