using System.Collections;
using System.Numerics;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Specialized;


public class ERC721BalanceOfExampleb : MonoBehaviour
{

    public string jsontest;
    public Text balance_text;
    private void Start() {
        balance();
     //   jsontest ="{\"attributes\": [{ \"trait_type\": \"Foreground\", \"value\": \"Energy\" },{ \"trait_type\": \"Leftarm\", \"value\": \"Gold Bracelet\" },{ \"trait_type\": \"Handacc\", \"value\": \"Wallet\" },{ \"trait_type\": \"Neckacc\", \"value\": \"Bow Tie\" },{ \"trait_type\": \"Headacc\", \"value\": \"Red Hat\" },{ \"trait_type\": \"Eyesacc\", \"value\": \"Sports Sunglass\" },{ \"trait_type\": \"Eyes\", \"value\": \"Happy\" },{ \"trait_type\": \"Mouth\", \"value\": \"Red Fish\" },{ \"trait_type\": \"Body\", \"value\": \"Seaweed\" },{ \"trait_type\": \"Industry\", \"value\": \"Healthcare\" }],\"description\": \"whale\",\"image\": \"  \",\"name\": \"test\"}";
    }
    public async void balance()
    {
        
        string chain = "ethereum";
        string network = "goerli";
        string contract = "0xC9ea53fA341cae2ED5f71B564c80837b2d02DecE";
        //string account = PlayerPrefs.GetString("Account");
        string account = PlayerPrefs.GetString("Account");

        int balance = await ERC721.BalanceOf(chain, network, contract, account);
        //print(balance);
        //balance_text.text = "balance: "+ balance;

        print("Balance: " + balance);

    }
    public void export_json () {
        StartCoroutine(Upload());
        
    }
    
     IEnumerator Upload() {
        byte[] myData = System.Text.Encoding.UTF8.GetBytes(jsontest);
        UnityWebRequest www = UnityWebRequest.Put("https://api.pinata.cloud/pinning/pinFileToIPFS", myData);
        yield return www.SendWebRequest();
 
        if (www.result != UnityWebRequest.Result.Success) {
            Debug.Log(www.error);
        }
        else {
            Debug.Log("Upload complete!");
        }
    }
    
}

