using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;


public class NetworkControler : MonoBehaviourPunCallbacks
{
    public GameObject menu_partidas;
    public GameObject menu_login;
    [Header("Player")]
    //public InputField playerNameInput;
    public Text nome_player;
    string playerNameTemp;
    public GameObject myplayer;
    string roomNameTemp;
    
    public InputField roomName;
    public Text test_texto;
    public static bool online;
    public MainMenu menu;
   
    // Start is called before the first frame update
    void Start()
    {
        nome_player.text = "PLAYER NAME: "+bancodedados.carregarString("nome_player");
        //PhotonNetwork.ConnectUsingSettings();
        playerNameTemp = "Player "+Random.Range(1000, 10000);
        roomNameTemp = "Room "+Random.Range(1000, 10000);
        //playerNameInput.text =  playerNameTemp;
        roomName.text =  roomNameTemp;
        menu_partidas.SetActive(false);
        menu_login.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void PartidaRapida () {
        PhotonNetwork.JoinLobby();
    }
    public void criarSala () {
        
        if (roomName.text=="")
        {
            roomName.text=roomNameTemp;
        }
        roomNameTemp = roomName.text;
        RoomOptions roomOptions = new RoomOptions(){MaxPlayers=8};
        PhotonNetwork.JoinOrCreateRoom(roomNameTemp,roomOptions,TypedLobby.Default);
    }

    public void Login () {
        
        PhotonNetwork.NickName = bancodedados.carregarString("nome_player");
        menu_partidas.SetActive(true);
        menu_login.SetActive(false);
        PhotonNetwork.ConnectUsingSettings();
    }
  














    //PunCallbacks
    public override void OnConnected(){
        Debug.Log("OnConnected");
    }
    public override void OnConnectedToMaster(){
        Debug.Log("OnConnectedToMaster");
        Debug.Log("Server: "+PhotonNetwork.CloudRegion + " Ping: "+PhotonNetwork.GetPing());
        //PhotonNetwork.JoinLobby();
    }  
    public override void OnJoinedLobby(){
        PhotonNetwork.JoinRandomRoom();
    }    
    public override void  OnJoinRandomFailed(short returncode,string message){
        string roomTemp ="Room" + Random.Range(1000,10000);
        //PhotonNetwork.CreateRoom(roomTemp);
    }
    public override void OnJoinedRoom(){
        Debug.Log("OnJoinedRoom");
        test_texto.text = "Room Name: " + PhotonNetwork.CurrentRoom;
        menu_partidas.SetActive(false);
        menu_login.SetActive(false);
        online = true;
        menu.GoToGame();
        //PhotonNetwork.Instantiate(myplayer.name,myplayer.transform.position,myplayer.transform.rotation,0);
    }   
    public override void OnDisconnected(DisconnectCause cause){
        Debug.Log("OnDisconnected: " + cause);
    }  


}
