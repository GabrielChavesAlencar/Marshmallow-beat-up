using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class bancodedados 
{
     public static void salvarint(string texto,int valor) 
    {
        PlayerPrefs.SetInt(texto,valor);
    }
    public static int carregarint(string texto)
    {
        int salvo = PlayerPrefs.GetInt(texto,0);
        return salvo;
    }
    public static void salvarString(string KeyName, string Value)
    {
        PlayerPrefs.SetString(KeyName, Value);
       
    }

    public static string carregarString(string KeyName)
    {
        return PlayerPrefs.GetString(KeyName);
    }

     public static void salvarfloat(string texto,float valor) 
    {
        PlayerPrefs.SetFloat(texto,valor);
    }
    public static float carregarfloat(string texto)
    {
        float salvo = PlayerPrefs.GetFloat(texto,0);
        return salvo;
    }
    public static void salvar_pontuacao(string KeyName, float Value)
    {
        PlayerPrefs.SetFloat("pontuacao "+KeyName, Value);
    }
    public static void salvarnome(string KeyName, string Value)
    {
       
        PlayerPrefs.SetString(KeyName, Value);
        int temp = PlayerPrefs.GetInt("tamanho")+1;
        PlayerPrefs.SetString(""+temp,Value);
        PlayerPrefs.SetInt("tamanho",temp);
    }
}
