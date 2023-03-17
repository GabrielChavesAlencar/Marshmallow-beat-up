using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ajustedelayer : MonoBehaviour
{
    public SpriteRenderer render;
    public int sortingOrder;
    public int z;
    public string nome_obj;
    public GameObject objeto;
    public bool inimigo;
    // Start is called before the first frame update
    void Start()
    {
        //objeto = GameObject.Find(nome_obj);
        render = GetComponent<SpriteRenderer>();
        sortingOrder = render.sortingOrder;
        if(inimigo){
            nome_obj = objeto.name;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(objeto!=null){
            //5,4
            //27
            z = (int)(objeto.transform.position.z*10);
            //render.sortingOrder= sortingOrder+z;
            
            if(z>24.3f){
                render.sortingLayerName ="1";
            }
            if(z<24.3f&&z>21.6f){
                render.sortingLayerName ="2";
            }
            if(z<21.6f&&z>18.9f){
                render.sortingLayerName ="3";
            }
            if(z<18.9f&&z>16.2f){
                render.sortingLayerName ="4";
            }
            if(z<16.2f&&z>13.5f){
                render.sortingLayerName ="5";
            }
            if(z<13.5f&&z>10.8f){
                render.sortingLayerName ="6";
            }
            if(z<13.5f&&z>10.8f){
                render.sortingLayerName ="7";
            }
            if(z<10.8f&&z>8.1f){
                render.sortingLayerName ="8";
            }
            if(z<8.1f&&z>5.4f){
                render.sortingLayerName ="9";
            }
            if(z<5.4f&&z>2.7f){
                render.sortingLayerName ="10";
            }
            if(z<2.7f&&z>0f){
                render.sortingLayerName ="11";
            }
            if(z<0f&&z>-2.7f){
                render.sortingLayerName ="12";
            }
            if(z<-2.7f&&z>-5.4f){
                render.sortingLayerName ="13";
            }
            if(z<-5.4f&&z>-8.1f){
                render.sortingLayerName ="14";
            }
            if(z<-8.1f&&z>-10.8f){
                render.sortingLayerName ="15";
            }
            if(z<-10.8f&&z>-13.5f){
                render.sortingLayerName ="16";
            }
            if(z<-13.5f&&z>-16.2f){
                render.sortingLayerName ="17";
            }
            if(z<-16.2f&&z>-18.9f){
                render.sortingLayerName ="18";
            }
            if(z<-18.9f&&z>-21.6f){
                render.sortingLayerName ="19";
            }
            if(z<-21.6f){
                render.sortingLayerName ="20";
            }
        //print(render.sortingLayerName);

        }
    }
}
