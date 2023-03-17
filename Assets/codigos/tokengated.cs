using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using System.IO;
using UnityEngine.UI;

public class tokengated : MonoBehaviour
{
    public InputField input;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void start_token () {
        StartCoroutine(salvar_token());
    }
    IEnumerator salvar_token()
    {
        //contrato 0x3a74F108196938b484068cA0f6Cb66d9D8A3F9Dc
        //meu id 63e12fef05583c762c26aac3
        tokengatedpost token_temp = new tokengatedpost();
        token_temp.owner = "63e12fef05583c762c26aac3";
        token_temp.wallet_address = PlayerPrefs.GetString("Account");
        //token_temp.wallet_address = "0xa7330E6C82D785a3795B1F51dA133Dca5743511d";
       
        string json = JsonUtility.ToJson(token_temp);
        //https://api.mintdropz.com/login-metamask
        var req = new UnityWebRequest("https://api.mintdropz.com/login-metamask", "POST"); 
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
        req.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
        req.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        req.SetRequestHeader("Content-Type", "application/json");

        yield return req.SendWebRequest();

        if (req.isNetworkError)
        {
             string results = req.error;
            Debug.Log("Error While Sending: " + req.error);
        }
        else
        {
            string results = req.downloadHandler.text;
            bool erro =results.Contains("erro");
            if(erro){Debug.Log("ERRO");}
            else{}
            Debug.Log("Received: " + req.downloadHandler.text);

        }
    }
}
[Serializable]
public class tokengatedpost {
 public string owner { get; set; }
 public string wallet_address { get; set; }

}
