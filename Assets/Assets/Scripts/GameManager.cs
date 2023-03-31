using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public LifeBar enemylifeBar;
    public GameObject goIndicator;

    public Hero actor;
    public bool cameraFollows = true;
    public CameraBounds cameraBounds;

    public LevelData currentLevelData;
    private BattleEvent currentBattleEvent;
    private int nextEventIndex;
    public bool hasRemainingEvents;

    public List<GameObject> activeEnemies;
    public Transform[] spawnPositions;

    public GameObject currentLevelBackground;

    public GameObject robotPrefab;
    public GameObject bossPrefab;

    public GameObject PlantPrefab;
    public GameObject Plant2Prefab;

    //references to prefabs of the level and gameover texts. 
    public GameObject levelNamePrefab;
    public GameObject gameOverPrefab;

    //parent transform of all UI elements
    public RectTransform uiTransform;

    public GameObject loadingScreen;

    //for hero entrance
    public Transform walkInStartTarget;
    public Transform walkInTarget;

    //for exit on level completion
    public Transform walkOutTarget;

    //for loading and keeping track of levels
    public LevelData[] levels;
    public static int CurrentLevel = 0;
    public bool hora_incacao;
    public GameObject [] invocados;
    public int indice_invocados;

    public float tempo;

    

    private GameObject SpawnEnemy(EnemyData data)
    {
        //By calling Instantiate, you create a new GameObject that has all the data from that prefab.
        GameObject enemyObj;
        if (data.type == EnemyType.Boss)
            enemyObj = Instantiate(bossPrefab);
        else if  (data.type == EnemyType.Plant)
            enemyObj = Instantiate(PlantPrefab);
        else if  (data.type == EnemyType.Plant2)
            enemyObj = Instantiate(Plant2Prefab);
        else 
            enemyObj = Instantiate(robotPrefab);

        Vector3 position = spawnPositions[data.row].position;
        position.x = cameraBounds.activeCamera.transform.position.x +
            (data.offset * (cameraBounds.cameraHalfWidth + 1));
        enemyObj.transform.position = position;
        invocados[indice_invocados]=enemyObj;
        indice_invocados++;
        enemyObj.SetActive(false);
        if (data.type == EnemyType.Robot)
            enemyObj.GetComponent<Robot>().SetColor(data.color);


        enemyObj.GetComponent<Enemy>().RegisterEnemy();
        return enemyObj;
       
    }
    
 


    private void PlayBattleEvent(BattleEvent battleEventData)
    {
        currentBattleEvent = battleEventData;
        nextEventIndex++;

        cameraFollows = false;
        cameraBounds.SetXPosition(battleEventData.column);

        //Destroys remnants of prior battle events
        //foreach (GameObject enemy in activeEnemies)
        //    Destroy(enemy);
        activeEnemies.Clear();
        Enemy.TotalEnemies = 0;
        
        hora_incacao = true;
        foreach (EnemyData enemyData in currentBattleEvent.enemies)
            activeEnemies.Add(SpawnEnemy(enemyData));
            
    }

    private void CompleteCurrentEvent()
    {
        currentBattleEvent = null;

        cameraFollows = true;
        cameraBounds.CalculateOffset(actor.transform.position.x);
        hasRemainingEvents = currentLevelData.battleData.Count > nextEventIndex;

        enemylifeBar.EnableLifeBar(false);

        //with no more battle events. hero will walk off screen
        if (!hasRemainingEvents)
            StartCoroutine(HeroWalkout());
        else
            ShowGoIndicator();
    }

    void Start()
    {

        actor = GameObject.Find(jogo.nome_jogador).GetComponent<Hero>();
        nextEventIndex = 0;
        StartCoroutine(LoadLevelData(levels[CurrentLevel]));
        cameraBounds.SetXPosition(cameraBounds.minVisibleX);
    }

    private void Awake()
    {
        loadingScreen.SetActive(true);
        invocados = new GameObject[25];
       
    }

    void Update()
    {
        if(hora_incacao){
            tempo+=Time.deltaTime;
            if(tempo>(2.5f-(jogo.dificuldade/3.5f))){
                tempo =0;
                 indice_invocados--;
                invocados[indice_invocados].SetActive(true);
               
                if(indice_invocados==0){
                    hora_incacao = false;
                }
            }
        }
        if (currentBattleEvent == null && hasRemainingEvents)
        {
            if (Mathf.Abs(currentLevelData.battleData[nextEventIndex].column - 
                          cameraBounds.activeCamera.transform.position.x) < 0.2f)
            {
                PlayBattleEvent(currentLevelData.battleData[nextEventIndex]);
            }
        }

        if (currentBattleEvent != null)
        {
            // has event, check if enemies are alive
            if (Robot.TotalEnemies == 0)
                CompleteCurrentEvent();
        }

        if (cameraFollows&&actor!=null){
            
            cameraBounds.SetXPosition(actor.transform.position.x);
        }
    }

    private IEnumerator LoadLevelData(LevelData data)
    {
        cameraFollows = false;
        currentLevelData = data;

        hasRemainingEvents = currentLevelData.battleData.Count > 0;
        activeEnemies = new List<GameObject>();

        //pauses the method for one frame
        yield return null;
        cameraBounds.SetXPosition(cameraBounds.minVisibleX);

        //destroys old level before loading new level
        if (currentLevelBackground != null)
            Destroy(currentLevelBackground);
        currentLevelBackground = Instantiate(currentLevelData.levelPrefab);

        cameraBounds.EnableBounds(false);
        actor.transform.position = walkInStartTarget.transform.position;

        yield return new WaitForSeconds(0.1f);

        actor.UseAutopilot(true);
        actor.AnimateTo(walkInTarget.transform.position, false, DidFinishIntro);

        cameraFollows = true;

        ShowTextBanner(currentLevelData.levelName);

        loadingScreen.SetActive(false);
    }

    private void DidFinishIntro()
    {
        actor.UseAutopilot(false);
        actor.controllable = true;
        cameraBounds.EnableBounds(true);
        ShowGoIndicator();
    }

    private IEnumerator HeroWalkout()
    {
        cameraBounds.EnableBounds(false);
        cameraFollows = false;
        actor.UseAutopilot(true);
        actor.controllable = false;
        actor.walkSpeed = 2f;
        actor.runSpeed = 2f;
        actor.AnimateTo(walkOutTarget.transform.position, true, DidFinishWalkout);
        yield return null;
    }

    private void DidFinishWalkout()
    {
        CurrentLevel++;
        if (CurrentLevel >= levels.Length)
        {
            Victory();
        }
        else
            StartCoroutine(AnimateNextLevel());
        cameraBounds.EnableBounds(true);
        cameraFollows = false;
        actor.UseAutopilot(false);
        actor.controllable = false;
    }

    private IEnumerator AnimateNextLevel()
    {
        ShowTextBanner(currentLevelData.levelName + " COMPLETED");
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("Game");
    }

    private void ShowGoIndicator()
    {
        StartCoroutine(FlickerGoIndicator(4));
    }

    private IEnumerator FlickerGoIndicator(int count = 4)
    {
        while (count > 0)
        {
            goIndicator.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            goIndicator.SetActive(false);
            yield return new WaitForSeconds(0.2f);
            count--;
        }
    }

    //ShowBanner creates an instance of its prefab parameter and parents it to the class’
    //uiTransform field.It also sets the title of the prefab’s Text component to the value
    //of the bannerText parameter.
    private void ShowBanner(string bannerText, GameObject prefab)
    {
        GameObject obj = Instantiate(prefab);
        obj.GetComponent<Text>().text = bannerText;
        RectTransform rectTransform = obj.transform as RectTransform;
        rectTransform.SetParent(uiTransform);
        rectTransform.localScale = Vector3.one;
        rectTransform.anchoredPosition = Vector2.zero;
    }

    public void GameOver()
    {
        ShowBanner("GAME OVER", gameOverPrefab);
    }

    public void Victory()
    {
        ShowBanner("YOU WON", gameOverPrefab);
    }

    public void ShowTextBanner(string levelName)
    {
        ShowBanner(levelName, levelNamePrefab);
    }
}
