using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using System.IO;
using UnityEngine.UI;



public class clasificacao : MonoBehaviour
{
   // public CarregarPontuacaoJson [] pontuacoes;
    public InputField input_email;
    public InputField input_password;
    public string results;
    public bool erro;
    public Text[]nomes;
    public Text[]valores;

    public float[] temps;
    public float[] temps2;
    public float[] indices_organizado;
    public bool atualizar;
    public string[] partes;
    public string[] partes2;
    public int tamanhoMaximo;


    //public menuControler mControler;
    // Start is called before the first frame update

    private void OnEnable()
    {
        StartCoroutine(CarregarPontuacao("https://bancodedadosbetup2.onrender.com/login"));
        //StartCoroutine(salvarScore());
        /*
        temps= new float[bancodedados.carregarint("tamanho")];
        temps2= new float[bancodedados.carregarint("tamanho")];
        indices_organizado =  new float[bancodedados.carregarint("tamanho")];
        if(bancodedados.carregarint("tamanho")>10){tamanhoMaximo = 10;}
        else{tamanhoMaximo = bancodedados.carregarint("tamanho");}
        salvar_func();
        for(int i = 0; i < bancodedados.carregarint("tamanho"); i++) {
            temps[i] = bancodedados.carregarfloat("pontuacao "+bancodedados.carregarString(""+(i+1)));
        }
        atualizar = true;
        */
    }

    // Update is called once per frame
    void Update()
    {

        if(atualizar&&MainMenu.indice_ativado==1){
            for(int i = 0; i < bancodedados.carregarint("tamanho"); i++) {
                indices_organizado[i] = i;
                temps2[i] = temps[i];
            }
             
            for(int i = 0; i < bancodedados.carregarint("tamanho"); i++) {
                for(int j = 0; j < bancodedados.carregarint("tamanho"); j++) {
                    if(temps[j]<temps[i]){
                        float temp1 = i;
                        float temp2 = temps[i];
                        temps[i] = temps[j];
                        temps[j] = temp2;
                    }   
                }
               
            }
            for(int i = 0; i < bancodedados.carregarint("tamanho"); i++) {
                for(int j = 0; j < bancodedados.carregarint("tamanho"); j++) {
                    if(temps2[i]==temps[j]){
                        indices_organizado[j]=i;
                    }
                }
            }
            for(int i = 0; i < tamanhoMaximo; i++) {
                nomes[i].text = bancodedados.carregarString(""+(indices_organizado[i]+1));
                valores[i].text = bancodedados.carregarfloat("pontuacao "+bancodedados.carregarString(""+(indices_organizado[i]+1)))+"";
            }
            atualizar = false;
        }
    }
    public void salvar_func () {

       //StartCoroutine(CarregarPontuacao("https://api.mintdropz.com/player-score"));
       //StartCoroutine(SalvarPontuacao());
    }
    IEnumerator CarregarPontuacao(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(webRequest.downloadHandler.text);
                    string temptext = webRequest.downloadHandler.text;
                    partes = temptext.Split("*/");
                    //string partes_temp ="";
                    int cont = 0;
                    partes2 = new string[(partes.Length*2)];
                    for(int i = 0; i < partes.Length; i++) {
                        string [] controle = partes[i].Split("*#");
                        if(controle.Length>1){
                            partes2[cont] = partes[i].Split("*#")[0].Remove(0,6);
                            cont++;
                            partes2[cont] = partes[i].Split("*#")[1].Remove(0,7);
                            cont++;
                        }
                    }
                    cont =0;
                    int temptamanho = partes.Length;
                    if(temptamanho>10){temptamanho=10;}
                    for(int i = 0; i < temptamanho; i++) {
                        nomes[i].text = partes2[cont];
                        cont++;
                        valores[i].text = partes2[cont];
                        cont++;

                    }
                   
                    break;
            }
        }
    }
     IEnumerator salvarScore()
    {
        playerScore scoreAtual = new playerScore();
        scoreAtual.Name = "joaozinho";
        scoreAtual.Score = 3;
        
        string json = JsonUtility.ToJson(scoreAtual);
        var req = new UnityWebRequest ("https://bancodedadosbetup2.onrender.com/score/"+scoreAtual.Name+"/"+scoreAtual.Score, "POST"); 
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
        req.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
        req.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        req.SetRequestHeader("Content-Type", "application/json");
        
        
        yield return req.SendWebRequest();
        print(req.downloadHandler.text);
        
        
        
    }
    /*
    IEnumerator SalvarPontuacao()
    {
        SalvarpotuacaoJson potuacao_atual = new SalvarpotuacaoJson();
        List<Artifacts> artefatos = new List<Artifacts>();
        Artifacts artefato = new  Artifacts();
        Owner proprietario = new Owner();
        potuacao_atual.player = "Denis";
        potuacao_atual.score = 5;
        potuacao_atual.round = 9;
        potuacao_atual.collected_coins = 55;
        potuacao_atual.multiplier = 7;
        proprietario.kind = "test2";
        proprietario.item = "asdasd";
        potuacao_atual.owner = proprietario;
        artefato.worth = 11;
        artefato.kind ="if test2";
        artefatos.Add(artefato);
        potuacao_atual.artifacts = artefatos;
        string json = JsonUtility.ToJson(potuacao_atual);

        var req = new UnityWebRequest("https://api.mintdropz.com/player-score/add", "POST"); 
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
        req.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
        req.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        req.SetRequestHeader("Content-Type", "application/json");

        yield return req.SendWebRequest();

        if (req.isNetworkError)
        {
            results = req.error;
            Debug.Log("Error While Sending: " + req.error);
        }
        else
        {
            results = req.downloadHandler.text;
            erro =results.Contains("erro");
            if(erro){Debug.Log("ERRO");}
            else{}
            Debug.Log("Received: " + req.downloadHandler.text);
            print("resulta: "+results);

        }
    }*/

/*
    IEnumerator CarregarPontuacao(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    string temptext = webRequest.downloadHandler.text;
                   // CarregarPontuacaoJson  temp = new CarregarPontuacaoJson();
                    //temp = JsonUtility.FromJson<CarregarPontuacaoJson>(webRequest.downloadHandler.text);
                    //temp = JsonUtility.FromJson<CarregarPontuacaoJson>(webRequest.downloadHandler.text);
                     CarregarPontuacaoJson temp = new CarregarPontuacaoJson();
        
                    //string test = "[{\"_id\":\"63da93eb05583c762c26aa80\",\"artifacts\":[],\"collected_coins\":99,\"createdAt\":\"2023-02-01T16:31:39.792Z\",\"multiplier\":4,\"player\":\"TEST\",\"round\":3,\"score\":2,\"updatedAt\":\"2023-02-01T16:31:39.792Z\"},{\"_id\":\"63da93eb05583c762c26aa80\",\"artifacts\":[],\"collected_coins\":99,\"createdAt\":\"2023-02-01T16:31:39.792Z\",\"multiplier\":4,\"player\":\"TEST\",\"round\":3,\"score\":2,\"updatedAt\":\"2023-02-01T16:31:39.792Z\"},{\"_id\":\"63da93eb05583c762c26aa80\",\"artifacts\":[],\"collected_coins\":99,\"createdAt\":\"2023-02-01T16:31:39.792Z\",\"multiplier\":4,\"player\":\"TEST\",\"round\":3,\"score\":2,\"updatedAt\":\"2023-02-01T16:31:39.792Z\"},{\"_id\":\"63da93eb05583c762c26aa80\",\"artifacts\":[],\"collected_coins\":99,\"createdAt\":\"2023-02-01T16:31:39.792Z\",\"multiplier\":4,\"player\":\"TEST\",\"round\":3,\"score\":2,\"updatedAt\":\"2023-02-01T16:31:39.792Z\"}]";
                    
                    print("antes: "+temptext);
                    temptext = temptext.Remove(0,1);
                    temptext = temptext.Remove(temptext.Length-1,1);
                    print("depois: "+temptext);
                    partes = temptext.Split(",{\"_id\"");
                       
                     
                        
                    
                    print(temp._id);
                    print("tamanho é "+partes.Length);
                    pontuacoes = new CarregarPontuacaoJson[partes.Length];
                    pontuacoes[0] = JsonUtility.FromJson<CarregarPontuacaoJson>(partes[0]);
                    temps[0] = pontuacoes[0].collected_coins;
                    for(int i = 1; i < partes.Length; i++) {
                         partes[i] = "{\"_id\""+partes[i];
                         pontuacoes[i] = JsonUtility.FromJson<CarregarPontuacaoJson>(partes[i]);
                         temps[i] = pontuacoes[i].collected_coins;
                         
                        
                    }
                    atualizar = true;
                    break;
            }
        }
    }*/
    
}
/*

[Serializable]
public class CarregarPontuacaoJson2{
    public IList<CarregarPontuacaoJson> artifacts { get; set; }
}
[Serializable]
public class CarregarPontuacaoJson{
    public string _id;
    public IList<Artifacts> artifacts { get; set; }

    public int collected_coins;

    public DateTime createdAt;
    public int multiplier;
    public string player;
    public int round;
    public int score;
    public DateTime updatedAt;
}

[Serializable]
public class SalvarpotuacaoJson
{
    public int score;
    public int round;
    public string player;

    public int collected_coins;

    public int multiplier;
    public IList<Artifacts> artifacts { get; set; }
    public Owner owner { get; set; } 


}
[Serializable]
public class Artifacts {
 public int worth { get; set; }
 public string kind { get; set; }

}
[Serializable]
public class Owner {
 public string kind { get; set; }
 public string item { get; set; }

}
*/

[Serializable]
public class playerScore
{
    public string Name;
    public int Score;
}






