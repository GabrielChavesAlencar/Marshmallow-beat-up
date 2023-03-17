using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;

public class salvarPontuacao : MonoBehaviour
{
    public string results;
    public bool erro;
    // Start is called before the first frame update
    void Start()
    {
        salvar(bancodedados.carregarString("nome_player"),bancodedados.carregarint("melhor_score"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public void salvar (string name, int score) {
     StartCoroutine(salvarScore(name,score));
   }
    IEnumerator salvarScore(string Name,int Score)
    {
        playerScore scoreAtual = new playerScore();
        scoreAtual.Name = Name;
        scoreAtual.Score = Score;
        
        string json = JsonUtility.ToJson(scoreAtual);
        var req = new UnityWebRequest ("https://bancodedadosbetup2.onrender.com/score/"+scoreAtual.Name+"/"+scoreAtual.Score, "POST"); 
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
        req.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
        req.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        req.SetRequestHeader("Content-Type", "application/json");
        
        
        yield return req.SendWebRequest();
        print(req.downloadHandler.text);
    }
}
