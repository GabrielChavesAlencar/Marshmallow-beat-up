using System;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

//#if UNITY_WEBGL
public class WebLogin2 : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void Web3Connect();

    [DllImport("__Internal")]
    private static extern string ConnectAccount();

    [DllImport("__Internal")]
    private static extern void SetConnectAccount(string value);

    private int expirationTime;
    private string account; 
    public GameObject menu_login;
    public GameObject botao_login;

    public GameObject botao_semlogin;

    public GameObject menu_direto;

     public GameObject menu_criacao;

    public static bool inicio_test;

    public void OnLogin()
    {
        Web3Connect();
        OnConnected();
        inicio_test = false;
    }
    public void iniciorapido () {
        menu_login.SetActive(true);
        botao_login.SetActive(false);
        botao_semlogin.SetActive(false);
        
        inicio_test = true;
        if(bancodedados.carregarint("totalPerso")==0){
            menu_criacao.SetActive(true);
        }else{
            menu_direto.SetActive(true);
        }
    }

    async private void OnConnected()
    {
        account = ConnectAccount();
        while (account == "") {
            await new WaitForSeconds(1f);
            account = ConnectAccount();
        };
        // save account for next scene
        PlayerPrefs.SetString("Account", account);
        // reset login message
        SetConnectAccount("");
        //menu_login.SetActive(true);
        //botao_login.SetActive(false);
       // botao_semlogin.SetActive(false);
        // load next scene
       // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
       Debug.Log("conectado!");
    }

    public void OnSkip()
    {
        // burner account for skipped sign in screen
        PlayerPrefs.SetString("Account", "");
        // move to next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
//#endif
