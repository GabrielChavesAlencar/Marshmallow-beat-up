using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chuva_fogo : MonoBehaviour
{
    public GameObject fogo;
    public float tempo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tempo+=Time.deltaTime;
        if(tempo>0.5f){
            GameObject temp = Instantiate(fogo);
            temp.transform.position = new Vector3(Random.Range(11,43),52,0);

            tempo = 0;
        }
    }
    
}
