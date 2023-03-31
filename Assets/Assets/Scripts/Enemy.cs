using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Actor {

    public EnemyAI ai;

    public static int TotalEnemies;
    public Walker walker;
    

    public bool stopMovementWhenHit = true;
    public bool obstaculo;

    protected override void Start()
    {
        base.Start();
        lifeBar = GameObject.FindGameObjectWithTag("EnemyLifeBar").GetComponent<LifeBar>();
        lifeBar.SetProgress(currentLife);
    }

    public void RegisterEnemy()
    {
        TotalEnemies++;
    }

    protected override void Die()
    {
        base.Die();
        ai.enabled = false;
        walker.enabled = false;
        if(!obstaculo){
            TotalEnemies--;
        }
        
    }

    public void MoveTo(Vector3 targetPosition)
    {
        if(walker.enabled)walker.MoveTo(targetPosition);
        
    }

    //determines whether the enemy can walk to the right (positive offset) or the left (negative offset) of the targetPosition. This allows the enemy to move to a free space next to the hero.
    public void MoveToOffset(Vector3 targetPosition, Vector3 offset)
    {
        if (!walker.MoveTo(targetPosition + offset)&&walker.enabled)
        {
            walker.MoveTo(targetPosition - offset);
        }
    }

    public void Wait()
    {
        walker.StopMovement();
    }

    public override void TakeDamage(float value, Vector3 hitVector, bool knockdown = false)
    {
        if(Hero.dano_maior>10){
            knockdown = true;
            hitVector = new Vector3(10,0,6);
        }
        if (stopMovementWhenHit)
            walker.StopMovement();
        base.TakeDamage(value, hitVector, knockdown);
        Hero.dano_maior = 0;
        
    }
     public override void EvaluateAttackData(AttackData data, Vector3 hitVector, Vector3 hitPoint){
        if(Hero.dano_maior>10){
            float temp_num = data.attackDamage+Hero.dano_maior;
             TakeDamage(temp_num, hitVector, data.knockdown);
             ShowHitEffects(temp_num, hitPoint);
        }
        else{
             TakeDamage(data.attackDamage, hitVector, data.knockdown);
             ShowHitEffects(data.attackDamage, hitPoint);
        }
        //base.EvaluateAttackData(data,hitVector,hitPoint);
        
     }

    public override bool CanWalk()
    {
        return !baseAnim.GetCurrentAnimatorStateInfo(0).IsName("hurt") && 
                        !baseAnim.GetCurrentAnimatorStateInfo(0).IsName("getup");
    }
}
