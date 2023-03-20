﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : Enemy {

    public RobotColor color;
    public GameObject coin;
    public bool morreu;
    public GameObject local_criacao;

    public Rigidbody rig;
    public Collider col;
    public GameObject dog;

    public float virar;
   

    public SpriteRenderer smokeSprite;
    public SpriteRenderer beltSprite;
    private void Update() {
        
        if(currentLife<=0){
            virar +=Time.deltaTime*1000;
            if(dog.transform.localScale.x>0){
                 transform.rotation = Quaternion.Euler(new Vector3(0,0,virar));
                 rig.useGravity = false;
                rig.AddForce(-80,6,0);
            }
            else{
                transform.rotation = Quaternion.Euler(new Vector3(0,0,virar));
                 rig.useGravity = false;
                rig.AddForce(80,6,0);
            }
            

            
            col.enabled = false;
           // 
           if(!morreu){
            
            Vector3 pos_rand = new Vector3(0,0,0);
                 //print("morreu");
                 for(int i = 0; i <4 ; i++) {
                    pos_rand = new Vector3(Random.Range(-0.6f,0.6f),Random.Range(-0.6f,0.6f),0);
                    morreu = true;
                    GameObject temp = Instantiate(coin);
                    temp.transform.position = local_criacao.transform.position+pos_rand;
                   
                }
                 
           }
          
        }
    }
    public void SetColor(RobotColor color)
    {
        this.color = color;

        switch (color)
        {
            case RobotColor.Colorless:
                baseSprite.color = Color.white;
                smokeSprite.color = Color.white;
                beltSprite.color = Color.white;
                maxLife = 60.0f;
                normalAttack.attackDamage = 2;
                break;
            case RobotColor.Copper:
                baseSprite.color = new Color(1.0f, 0.75f, 0.62f);
                smokeSprite.color = new Color(0.38f, 0.63f, 1.0f);
                beltSprite.color = new Color(0.86f, 0.85f, 0.71f);
                maxLife = 60.0f;
                normalAttack.attackDamage = 4;
                break;
            case RobotColor.Silver:
                baseSprite.color = Color.white;
                smokeSprite.color = new Color(0.38f, 1.0f, 0.5f);
                beltSprite.color = new Color(0.5f, 0.5f, 0.5f);
                maxLife = 60.0f;
                normalAttack.attackDamage = 5;
                break;
            case RobotColor.Gold:
                baseSprite.color = new Color(0.91f, 0.7f, 0.0f);
                smokeSprite.color = new Color(0.42f, 0.15f, 0.10f);
                beltSprite.color = new Color(0.86f, 0.5f, 0.32f);
                maxLife = 60.0f;
                normalAttack.attackDamage = 6;
                break;
            case RobotColor.Random:
                baseSprite.color = new Color(Random.Range(0, 1.0f), Random.Range(0, 1.0f), Random.Range(0, 1.0f));
                smokeSprite.color = new Color(Random.Range(0, 1.0f), Random.Range(0, 1.0f), Random.Range(0, 1.0f));
                beltSprite.color = new Color(Random.Range(0, 1.0f), Random.Range(0, 1.0f), Random.Range(0, 1.0f));
                maxLife = Random.Range(60, 60);
                normalAttack.attackDamage = Random.Range(4, 10);
                break;
        }

        currentLife = maxLife;
    }


    //These methods have the ContextMenu attribute, which adds a command to the context menu that uses the string parameter for the command’s title. You access them by clicking the cog icon on the right side of the Inspector.
    [ContextMenu("Color: Copper")]
    void SetToCopper()
    {
        SetColor(RobotColor.Copper);
    }

    [ContextMenu("Color: Silver")]
    void SetToSilver()
    {
        SetColor(RobotColor.Silver);
    }

    [ContextMenu("Color: Gold")]
    void SetToGold()
    {
        SetColor(RobotColor.Gold);
    }

    [ContextMenu("Color: Random")]
    void SetToRandom()
    {
        SetColor(RobotColor.Random);
    }

    protected override IEnumerator KnockdownRoutine()
    {
        isKnockedOut = true;
        baseAnim.SetTrigger("Knockdown");
        ai.enabled = false;

        actorCollider.SetColliderStance(false);
        yield return new WaitForSeconds(2.0f);
        actorCollider.SetColliderStance(true);
        baseAnim.SetTrigger("GetUp");
        ai.enabled = true;

        knockdownRoutine = null;
    }
}


public enum RobotColor
{
    Colorless = 0,
    Copper,
    Silver,
    Gold,
    Random
}
