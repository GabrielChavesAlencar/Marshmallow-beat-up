using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class Hero : Actor
{
    public float walkSpeed = 2;
    public float runSpeed = 5;

    //variable declarations for running
    bool isRunning;
    bool isMoving;
    float lastWalk = 0.0f;
    public bool canRun = true;
    float tapAgainToRunTime = 0.2f;
    Vector3 lastWalkVector = Vector3.zero;

    Vector3 curDirection;
    bool isFacingLeft;

    //variables for jumping
    bool isJumpLandAnim;
    bool isJumpingAnim;

    public InputHandler input;

    public float jumpForce = 1750;
    private float jumpDuration = 0.2f;
    private float lastJumpTime;

    //variables for attacking
    bool isAttackingAnim;
    float lastAttackTime;
    float attackLimit = 0.14f;

    //variables for entrance
    public Walker walker;
    public bool isAutoPiloting;
    public bool controllable = true;

    //variables for jump attack
    public bool canJumpAttack = true;
    private int currentAttackChain = 1;
    public int evaluatedAttackChain = 0;
    public AttackData jumpAttack;

    bool isHurtAnim;

    //variables for run attack
    public AttackData runAttack;
    public float runAttackForce = 1.8f; // how far the attack will go

    //variables for combo
    public AttackData normalAttack2;
    public AttackData normalAttack3;

    float chainComboTimer;
    public float chainComboLimit = 0.3f;
    const int maxCombo = 3;

    //variables for hero knockdown tolerance
    public float hurtTolerance;
    public float hurtLimit = 20;
    public float recoveryRate = 5;

    bool isPickingUpAnim;
    bool weaponDropPressed = false; // when player jumps
    public bool hasWeapon;

    public bool canJump = true;

    public SpriteRenderer powerupSprite;
    public Powerup nearbyPowerup;
    public Powerup currentPowerup;
    public GameObject powerupRoot;

    public AudioClip hit2Clip; //hero's strong attack sfx

    public GameManager gameManager;

    public GameObject espada;
    public GameObject espada2;
    public GameObject espada3;
     public GameObject espada_local;
    public GameObject local_arremecar;
    public GameObject espada_projetil;
    public GameObject projetil;
    public GameObject arremecar_obj;
    public JumpCollider jumpCollider;
    public Sprite [] imagens_armas;

    public SpriteRenderer sprite_arma;
    public SpriteRenderer sprite_arma2;
    public SpriteRenderer sprite_arma3;

    public float tempo;

    public static bool espada_ativada;

    public bool especial;
    public bool arremecado;
    public  int num_arma;
    public static Sprite espada_sprite;

    public static int dano_maior;
    public Animator anim2;
    public Animator anim_boneco;
    public GameObject coruja;
    public GameObject ape;
    
    public GameObject bonequinho;
    public Sprite [] icones;
    public Image icone;
    public PhotonView photonView;
    

    protected override void Start()
    {
        photonView = GetComponent<PhotonView>();
            if(photonView.IsMine||!NetworkControler.online){
            actorThumbnail = icones[MainMenu.num_perso];
            icone = GameObject.Find("HeroThumbnail").GetComponent<Image>();
            input = GameObject.Find("MyGameManager").GetComponent<InputHandler>();
            gameManager = GameObject.Find("MyGameManager").GetComponent<GameManager>();
            //icone  =
            icone.sprite = icones[MainMenu.num_perso];
            if(MainMenu.num_perso<5){

               // baseAnim = anim2;
               // espada =espada2;
             //   coruja.SetActive(true);
                ape.SetActive(false);
                bonequinho.SetActive(true);
                sprite_arma = sprite_arma3;
                baseAnim = anim_boneco;
                espada =espada3;
              //  sprite_arma = sprite_arma2;
            }
            else{
                MainMenu.num_perso = 3;
//                coruja.SetActive(false);
                bonequinho.SetActive(false);
               
                 ape.SetActive(true);
            }
            
            
            base.Start();
            lifeBar = GameObject.FindGameObjectWithTag("HeroLifeBar").GetComponent<LifeBar>();
            lifeBar.SetProgress(currentLife / maxLife);
            if(espada_ativada){
                
                baseAnim.SetBool("espada",true);
                espada.SetActive(true);
                sprite_arma.sprite = espada_sprite;
            }
        }
        
        
    }
    public void ativar_espada () {
        
            espada.SetActive(true);
            espada_ativada = true;
        
    }

    public override void Update()
    {
        if(baseAnim.GetCurrentAnimatorStateInfo(0).IsName("Idle")||baseAnim.GetCurrentAnimatorStateInfo(0).IsName("pulando_soco")){
            baseAnim.SetBool("soco_caindo",false);
            GetComponent<Rigidbody>().useGravity = true;
         }
         if(baseAnim.GetCurrentAnimatorStateInfo(0).IsName("pulando_soco")){
             GetComponent<Rigidbody>().velocity = new Vector3(0,-8,0);
         }
         if(baseAnim.GetCurrentAnimatorStateInfo(0).IsName("parado")){
                if(espada_ativada){
                    espada.SetActive(false);
                    espada_ativada = false;
                    baseAnim.SetBool("espada",false);
                    GameObject temp = Instantiate(espada_projetil);
                        
                    temp.transform.position = espada.transform.position;
                    if(transform.localScale.x<0){
                    temp.transform.localScale = new Vector3(-0.6f,0.6f,1);
                    }
                    temp.GetComponent<SpriteRenderer>().sprite = imagens_armas[num_arma];
                }
         }
         if(baseAnim.GetCurrentAnimatorStateInfo(0).IsName("lancar_arma")){
                baseAnim.SetBool("lancar",false);
               
         }
        if(baseAnim.GetCurrentAnimatorStateInfo(0).IsName("especial_chute_giratorio")){
            baseAnim.SetBool("especial_giratorio",false);
        }
        if(transform.position.y<-10){
            Vector3 j= new Vector3(0,0,0);
            TakeDamage(maxLife,j,false);
        }
        if(espada_ativada){
             if(num_arma!=0){
                espada_local.transform.localScale = new Vector3(0.6f,0.6f,1);
            }else{
                espada_local.transform.localScale = new Vector3(0.4f,0.6f,1);
            }
        }
        //calls superclass
        base.Update();
         if(Input.GetKeyDown(KeyCode.S)){
            // baseAnim.SetBool("lancar",true);
         }
        if(Input.GetKeyDown(KeyCode.S)&&espada_ativada){
            baseAnim.SetBool("espada",true);
            lancar_cano();
            

        }
         if(Input.GetKeyDown(KeyCode.A)){
            if(baseAnim.GetCurrentAnimatorStateInfo(0).IsName("Idle")){
            especial = true;}
            
         }
         if(Input.GetKeyDown(KeyCode.Q)){
            arremecado = true;
         }
         if(especial){
            tempo+=Time.deltaTime;
            baseAnim.SetBool("especial",true);
         }
         if(arremecado){
            tempo+=Time.deltaTime;
            baseAnim.SetBool("arremecar",true);
         }
         
         if(tempo>0.5f&&especial){
            tempo = 0;
            especial = false;
            baseAnim.SetBool("especial",false);
            GameObject temp = Instantiate(projetil);
            temp.transform.position = espada.transform.position;
            if(transform.localScale.x<0){
                temp.transform.localScale = new Vector3(-0.5f,0.5f,1);
            }
         }
         if(tempo>0.5f&&arremecado){
            tempo = 0;
            arremecado = false;
            baseAnim.SetBool("arremecar",false);
            GameObject temp = Instantiate(arremecar_obj);
            temp.transform.position = local_arremecar.transform.position;
            if(transform.localScale.x<0){
                temp.transform.localScale = new Vector3(-0.5f,0.5f,1);
            }
         }

        //handles button presses after death
        if (!isAlive)
            return;

        //updates animation variable that stores whether hero is attacking or not
        isAttackingAnim =
            baseAnim.GetCurrentAnimatorStateInfo(0).IsName("attack1") ||
                    baseAnim.GetCurrentAnimatorStateInfo(0).IsName("attack2") ||
                    baseAnim.GetCurrentAnimatorStateInfo(0).IsName("attack3") || 
                    baseAnim.GetCurrentAnimatorStateInfo(0).IsName("jump_attack") || 
                    baseAnim.GetCurrentAnimatorStateInfo(0).IsName("pulando_soco") || 
                    baseAnim.GetCurrentAnimatorStateInfo(0).IsName("especial_chute_giratorio") || 
                    baseAnim.GetCurrentAnimatorStateInfo(0).IsName("run_attack");

        //These lines update the variables that store whether the hero is jumping or not.
        isJumpLandAnim =
            baseAnim.GetCurrentAnimatorStateInfo(0).IsName("jump_land");
        isJumpingAnim =
            baseAnim.GetCurrentAnimatorStateInfo(0).IsName("jump_rise") ||
                    baseAnim.GetCurrentAnimatorStateInfo(0).IsName("jump_fall");

        //tracks when the hurt animation is played
        isHurtAnim =
            baseAnim.GetCurrentAnimatorStateInfo(0).IsName("hurt");

        //tracks when pickup animation is played
        isPickingUpAnim =
            baseAnim.GetCurrentAnimatorStateInfo(0).IsName("pickup");

        //prevents from performing actions during entrance
        if (isAutoPiloting)
            return;

        if(photonView.IsMine||!NetworkControler.online){
            float h = input.GetHorizontalAxis();
            float v = input.GetVerticalAxis();

            bool jump = input.GetJumpButtonDown();
            bool attack = false;
            if(input.GetAttackButtonDown()){
                attack= true;
                baseAnim.SetBool("chutes",false);
            }
            if(Input.GetKeyDown(KeyCode.W)){
                attack = true;
                baseAnim.SetBool("chutes",true);
                if(baseAnim.GetCurrentAnimatorStateInfo(0).IsName("jump_fall")){
                    
                    baseAnim.SetBool("soco_caindo",true);
                    dano_maior = 30;
                    Attack();
                    GetComponent<Rigidbody>().AddForce(0,500,0);
                    
                }
                
            }
            if(Input.GetKeyDown(KeyCode.D)){
                attack = true;
                baseAnim.SetBool("especial_giratorio",true);
            // Attack();
                dano_maior = 20;
                
            }
            
            

            curDirection = new Vector3(h, 0, v);
            curDirection.Normalize();

            if (!isAttackingAnim)
            {
                if (chainComboTimer > 0)
                {
                    chainComboTimer -= Time.deltaTime;
                    if (chainComboTimer < 0)
                    {
                        chainComboTimer = 0;
                        currentAttackChain = 0;
                        evaluatedAttackChain = 0;
                        baseAnim.SetInteger("CurrentChain", currentAttackChain);
                        baseAnim.SetInteger("EvaluatedChain", evaluatedAttackChain);
                    }
                }
                if (v == 0 && h == 0)
                {
                    Stop();
                    isMoving = false;
                }
                else if (!isMoving && (v != 0 || h != 0))
                {
                    isMoving = true;
                    float dotProduct = Vector3.Dot(curDirection, lastWalkVector);

                    if (canRun && Time.time < lastWalk + tapAgainToRunTime && dotProduct > 0)
                        Run();
                    else
                    {
                        Walk();

                        if (h != 0)
                        {
                            lastWalkVector = curDirection;
                            lastWalk = Time.time;
                        }
                    }
                }
            }

            if (jump && hasWeapon)
            {
                weaponDropPressed = true;
                DropWeapon();
            }
            

            if (weaponDropPressed && !jump)
                weaponDropPressed = false;

            //triggers/calls Jump
            if (canJump && jump && !isKnockedOut && jumpCollider.CanJump(curDirection, frontVector) && 
                !isJumpLandAnim && !isAttackingAnim && !isPickingUpAnim && !weaponDropPressed &&
                (isGrounded || (isJumpingAnim && Time.time < lastJumpTime + jumpDuration)))
                Jump(curDirection);

            //pickups have priority over attacking
            if (attack && Time.time >= lastAttackTime + attackLimit && isGrounded && !isPickingUpAnim)
            {
                if (nearbyPowerup != null && nearbyPowerup.CanEquip())
                {
                    lastAttackTime = Time.time;
                    Stop();
                    PickupWeapon(nearbyPowerup);
                }
            }
            
            //triggers/calls Attack
            if (attack && Time.time >= lastAttackTime + attackLimit && !isKnockedOut && !isPickingUpAnim)
            {
                lastAttackTime = Time.time;
                Attack();
            }
            

            //calculates knockdown tolerance
            if (hurtTolerance < hurtLimit)
            {
                hurtTolerance += Time.deltaTime * recoveryRate;
                hurtTolerance = Mathf.Clamp(hurtTolerance, 0, hurtLimit);
            }
        }
    }
    public void lancar_cano () {
        if(baseAnim.GetCurrentAnimatorStateInfo(0).IsName("Idle")){
            if(num_arma==7){
                
                
                baseAnim.SetBool("lancar",true);
            }
        }
    }

    private void FixedUpdate()
    {
        //prevents movements after death
        if (!isAlive)
            return;

        if (!isAutoPiloting)
        {
            Vector3 moveVector = curDirection * speed;

            if (isGrounded && !isAttackingAnim && !isJumpLandAnim && !isKnockedOut && !isHurtAnim)
            {
                body.MovePosition(transform.position + moveVector * Time.fixedDeltaTime);
                baseAnim.SetFloat("Speed", moveVector.magnitude);

                //flips sprite towards movement direction
                if (moveVector != Vector3.zero && isGrounded && !isKnockedOut && !isAttackingAnim)
                {
                    if (moveVector.x != 0)
                        isFacingLeft = moveVector.x < 0;
                    FlipSprite(isFacingLeft);
                }
            }
        }
    }

    //whenever hero is on floor, he's able to do a jump attack
    protected override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
        if (collision.collider.name == "Floor")
            canJumpAttack = true;
    }

    protected override IEnumerator KnockdownRoutine()
    {
        body.useGravity = true;
        return base.KnockdownRoutine();
    }

    public override void TakeDamage(float value, Vector3 hitVector, bool knockdown = false)
    {
        hurtTolerance -= value;
        if (hurtTolerance <= 0 || !isGrounded) // a knockdown was scored
        {
            hurtTolerance = hurtLimit; // reset hurtTolerance for knockdown
            knockdown = true;
        }
        if (hasWeapon)
            DropWeapon();
        base.TakeDamage(value, hitVector, knockdown);
    }

    public override bool CanWalk()
    {
        return (isGrounded && !isAttackingAnim && !isJumpLandAnim && !isKnockedOut && !isHurtAnim);
    }

    public void Stop()
    {
        speed = 0;
        isRunning = false;
        baseAnim.SetBool("IsRunning", isRunning);
        baseAnim.SetFloat("Speed", speed);
    }

    public void Walk()
    {
        speed = walkSpeed;
        isRunning = false;
        baseAnim.SetBool("IsRunning", isRunning);
        baseAnim.SetFloat("Speed", speed);
    }

    public void Run()
    {
        speed = runSpeed;
        isRunning = true;
        baseAnim.SetBool("IsRunning", isRunning);
        baseAnim.SetFloat("Speed", speed);
    }

    void Jump(Vector3 direction)
    {
        if (!isJumpingAnim)
        {
            baseAnim.SetTrigger("Jump");
            lastJumpTime = Time.time;
            Vector3 horizontalVector = new Vector3(direction.x, 0, direction.z) * speed * 40;
            body.AddForce(horizontalVector, ForceMode.Force);
        }

        Vector3 verticalVector = Vector3.up * jumpForce * Time.deltaTime;
        body.AddForce(verticalVector, ForceMode.Force);
    }

    public override void Attack()
    {
        if (currentAttackChain <= maxCombo)
        {
            if (!isGrounded)
            {
                //jump attack
                if (isJumpingAnim && canJumpAttack)
                {
                    canJumpAttack = false; //limits jump attack to 1
                    currentAttackChain = 1;
                    evaluatedAttackChain = 0;
                    baseAnim.SetInteger("EvaluatedChain", evaluatedAttackChain);
                    baseAnim.SetInteger("CurrentChain", currentAttackChain);

                    body.velocity = Vector3.zero;
                    body.useGravity = false;
                }
            }
            else
            {
                if (isRunning) // run attack
                {
                    //creates lunge with upward and forward force
                    body.AddForce((Vector3.up + (frontVector * 5)) * runAttackForce, ForceMode.Impulse);

                    currentAttackChain = 1;
                    evaluatedAttackChain = 0;
                    baseAnim.SetInteger("CurrentChain", currentAttackChain);
                    baseAnim.SetInteger("EvaluatedChain", evaluatedAttackChain);
                }
                else // normal attack
                {
                    if (currentAttackChain == 0 || chainComboTimer == 0)
                    {
                        currentAttackChain = 1;
                        evaluatedAttackChain = 0;
                    }
                    baseAnim.SetInteger("EvaluatedChain", evaluatedAttackChain);
                    baseAnim.SetInteger("CurrentChain", currentAttackChain);
                }
            }
        }
    }

    private void AnalyzeNormalAttack(AttackData attackData, int attackChain, Actor actor, Vector3 hitPoint, Vector3 hitVector)
    {
        actor.EvaluateAttackData(attackData, hitVector, hitPoint);
        currentAttackChain = attackChain;
        chainComboTimer = chainComboLimit;
    }

    private void AnalyzeSpecialAttack(AttackData attackData, Actor actor, Vector3 hitPoint, Vector3 hitVector)
    {
        actor.EvaluateAttackData(attackData, hitVector, hitPoint);
        chainComboTimer = chainComboLimit;
    }

    protected override void HitActor(Actor actor, Vector3 hitPoint, Vector3 hitVector)
    {
        if (baseAnim.GetCurrentAnimatorStateInfo(0).IsName("attack1"))
        {
            AttackData attackData = hasWeapon ? currentPowerup.attackData1 : normalAttack;
            AnalyzeNormalAttack(attackData, 2, actor, hitPoint, hitVector);
            PlaySFX(hitClip);
            if (hasWeapon)
                currentPowerup.Use();
        }
        else if (baseAnim.GetCurrentAnimatorStateInfo(0).IsName("attack2"))
        {
            AttackData attackData = hasWeapon ? currentPowerup.attackData2 : normalAttack2;
            AnalyzeNormalAttack(attackData, 3, actor, hitPoint, hitVector);
            PlaySFX(hitClip);
            if (hasWeapon)
                currentPowerup.Use();
        }
        else if (baseAnim.GetCurrentAnimatorStateInfo(0).IsName("attack3"))
        {
            AttackData attackData = hasWeapon ? currentPowerup.attackData3 : normalAttack3;
            AnalyzeNormalAttack(attackData, 1, actor, hitPoint, hitVector);
            PlaySFX(hit2Clip);
            if (hasWeapon)
                currentPowerup.Use();
        }
        else if (baseAnim.GetCurrentAnimatorStateInfo(0).IsName("jump_attack"))
        {
            AnalyzeSpecialAttack(jumpAttack, actor, hitPoint, hitVector);
            PlaySFX(hit2Clip);
        }
        else if (baseAnim.GetCurrentAnimatorStateInfo(0).IsName("pulando_soco"))
        {
            AnalyzeSpecialAttack(jumpAttack, actor, hitPoint, hitVector);
            PlaySFX(hit2Clip);
        }
        else if (baseAnim.GetCurrentAnimatorStateInfo(0).IsName("especial_chute_giratorio"))
        {
            AnalyzeSpecialAttack(jumpAttack, actor, hitPoint, hitVector);
            PlaySFX(hit2Clip);
        }
        else if (baseAnim.GetCurrentAnimatorStateInfo(0).IsName("run_attack"))
        {
            AnalyzeSpecialAttack(runAttack, actor, hitPoint, hitVector);
            PlaySFX(hit2Clip);
        }
    }

    public void DidChain(int chain)
    {
        evaluatedAttackChain = chain;
        baseAnim.SetInteger("EvaluatedChain", evaluatedAttackChain);
    }

    protected override void DidLand()
    {
        base.DidLand();
        Walk();
    }

    //turns gravity back on after jump attack
    public void DidJumpAttack()
    {
        body.useGravity = true;
    }

    public void AnimateTo(Vector3 position, bool shouldRun, Action callback)
    {
        if (shouldRun)
            Run();
        else
            Walk();
        walker.MoveTo(position, callback);
    }

    public void UseAutopilot(bool useAutopilot)
    {
        isAutoPiloting = useAutopilot;
        walker.enabled = useAutopilot;
    }

    public override void DidHitObject(Collider collider, Vector3 hitPoint, Vector3 hitVector)
    {
        Container containerObject = collider.GetComponent<Container>();

        if (isAttackingAnim && containerObject != null)
        {
            containerObject.Hit(hitPoint);
            PlaySFX(hitClip);
            if (containerObject.CanBeOpened() && collider.tag != gameObject.tag)
                containerObject.Open(hitPoint);
        }
        else
            base.DidHitObject(collider, hitPoint, hitVector);
    }

    public void PickupWeapon(Powerup powerup)
    {
        baseAnim.SetTrigger("PickupPowerup");
    }

    public void DidPickupWeapon()
    {
        if (nearbyPowerup != null && nearbyPowerup.CanEquip())
        {
            Powerup powerup = nearbyPowerup;
            hasWeapon = true;
            currentPowerup = powerup;
            nearbyPowerup = null;
            powerupRoot = currentPowerup.rootObject;
            powerup.user = this;

            currentPowerup.body.velocity = Vector3.zero;
            powerupRoot.SetActive(false);
            Walk();

            powerupSprite.enabled = true;
            canRun = false;
            canJump = false;
        }
    }

    public void DropWeapon()
    {
        powerupRoot.SetActive(true);
        powerupRoot.transform.position = transform.position + Vector3.up;
        currentPowerup.body.AddForce(Vector3.up * 100);

        powerupRoot = null;
        currentPowerup.user = null;
        currentPowerup = null;
        nearbyPowerup = null;

        powerupSprite.enabled = false;
        canRun = true;
        hasWeapon = false;
        canJump = true;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Powerup"))
        {
            Powerup powerup = collider.gameObject.GetComponent<Powerup>();
            if (powerup != null)
                nearbyPowerup = powerup;
        }
         if(collider.gameObject.tag =="Dog"){
         //   print("entrou!");
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Powerup"))
        {
            Powerup powerup = collider.gameObject.GetComponent<Powerup>();
            if (powerup == nearbyPowerup)
                nearbyPowerup = null;
        }
    }

    protected override void Die()
    {
        base.Die();
        gameManager.GameOver();
    }
}