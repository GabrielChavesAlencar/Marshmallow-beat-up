using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carro : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(GameManager.CurrentLevel == 1){
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
