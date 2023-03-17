using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ImplementNFTStorage : MonoBehaviour
{
    //private string test_arg ="{ \"attributes\": [ { \"trait_type\": \"Foreground\", \"value\": \"Energy\" }, { \"trait_type\": \"Leftarm\", \"value\": \"Gold Bracelet\" }, { \"trait_type\": \"Handacc\", \"value\": \"Wallet\" }, { \"trait_type\": \"Neckacc\", \"value\": \"Bow Tie\" }, { \"trait_type\": \"Headacc\", \"value\": \"Red Hat\" }, { \"trait_type\": \"Eyesacc\", \"value\": \"Sports Sunglass\" }, { \"trait_type\": \"Eyes\", \"value\": \"Happy\" }, { \"trait_type\": \"Mouth\", \"value\": \"Red Fish\" }, { \"trait_type\": \"Body\", \"value\": \"Seaweed\" }, { \"trait_type\": \"Industry\", \"value\": \"Healthcare\" } ], \"description\": \"whale\", \"image\": \"ipfs://bafybeideq2e6k5qdlzjn2ng2p765pdy2ozi57ntfcq57fgwdfzqcv75uze\", \"name\": \"test\"}";
    public GameObject Cid;
    public GameObject personagem;
    string fullPath;
    public NFTStorage.NFTStorageClient NSC;
    private byte[]bytes;
    public float ratioToScreen;
    public NFTData nftData;
    public GameObject nft;
    public GameObject menus;
    public GameObject img_loading;
    private string jsonPath;

    public static int fase;

    public GameObject menu_custon;
    public GameObject mint_botao;

    public RectTransform imagem_mint;

     public GameObject tela_loading;
    
    private void Update()
    {
      
        if(fase==2){
            fase =3;
            UploadJsonToNFTStogare();
        }
        if(fase==4){
            mint_botao.SetActive(true);
            menu_custon.SetActive(false);
            imagem_mint.localScale = new Vector3(1,1,1);
        }


    }
    //0xcd855bd189f2df6ab831d8e309308b5a37dc5f2bf94550358bf1e3d24cc1240e
    public void criarCid () {
        fase = 1;
        tela_loading.SetActive(true);
        StartCoroutine(CoroutineScreenshot());
    }
    
    private IEnumerator CoroutineScreenshot(){
        menus.SetActive(false);
        img_loading.SetActive(false);
        ratioToScreen = 0.5f;
        // personagem = GameObject.Find("ape construcao");
        personagem = GameObject.Find("dog ape construcao");
        yield return new WaitForEndOfFrame();
        int x = (int)personagem.transform.position.x;
        int y = (int)personagem.transform.position.y;
        Vector3 pos = Camera.main.WorldToScreenPoint(personagem.transform.position);
        Debug.Log(pos.x + " "+ pos.y);
        int screenWidth = Screen.width;
        int screenHeight = screenWidth;
       // ratioToScreen =  (float)Screen.width / Screen.height;
        int width =(int)(screenWidth * ratioToScreen);
        int height = (int)(screenHeight * ratioToScreen);

        Texture2D texture = new Texture2D(width,height,TextureFormat.ARGB32,false);
        if(metadados.num_perso == 0){
            texture.ReadPixels(new Rect(130+pos.x - width/2,(pos.y) - height/10f,width,height),0,0);}
        
        if(metadados.num_perso == 1){
        texture.ReadPixels(new Rect(130+pos.x - width/2,(pos.y+100) - height/2.5f,width,height),0,0);}
        texture.Apply();
        bytes = texture.EncodeToPNG();
        bancodedados.salvarint("totalPerso",bancodedados.carregarint("totalPerso")+1);
        fullPath = Application.persistentDataPath + "/screenshot" + bancodedados.carregarint("totalPerso") + ".png";
        System.IO.File.WriteAllBytes(fullPath,bytes);

        Image img= nft.GetComponent<Image>();
        img.sprite = Sprite.Create(texture,new Rect(0,0,texture.width,texture.height),new Vector2(0.5f,0.5f));
        menus.SetActive(true);
        img_loading.SetActive(true);
        NSC.UploadDataFromStringUnityWebrequest(fullPath);

    }
    public void UploadJsonToNFTStogare () {
        Debug.Log("Gerenating Json file");
        GenerateJson();
        Debug.Log("Start to  upload Json to NFT Storage");
        if(jsonPath != null&&jsonPath!=""){
            NSC.UploadDataFromStringUnityWebrequest(jsonPath);
            Debug.Log("Uploaded JSON to NFT Storage");
        }
        
    }
    public void GenerateJson () {
        
       // pegarCid ();
        nftData = new NFTData();
        
        metadados.criarAtributos();
        Text cidText = Cid.GetComponent<Text>();
        nftData.image = "ipfs://"+cidText.text;
        nftData.name= metadados.name;
        nftData.description = metadados.description;

        Debug.Log(nftData.image);
        string jsonData = JsonUtility.ToJson(nftData);
        jsonData = jsonData.Remove(0,1);
        string jsonreal ="{"+metadados.atributos+","+jsonData;
        Debug.Log(jsonreal);
        System.IO.File.WriteAllText(Application.persistentDataPath+"/nftData.json",jsonreal);
        jsonPath = Application.persistentDataPath+"/nftData.json";



    }
    [System.Serializable]
    public class NFTData{
      //  public string attributes = "";

        public string description = "a gamified experience for DAO contributors";
        public string image;
        public string name ="";
    }

}
