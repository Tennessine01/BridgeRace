using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] public List<GameObject> mapPrefabs = new List<GameObject>();
    private List<GameObject> characters = new List<GameObject>();
    [SerializeField] private GameObject enemy;
    GameObject currentEnemy = null;
    [SerializeField] Player player;
    [SerializeField] Platform_manager platform_Manager;

    [SerializeField] Transform startPos;
    //[SerializeField] public GameObject joyStick;
    private int currentMapIndex = 0;

    private GameObject currentMap;

    private Transform _endPosition;
    public Transform endPosTransform
    {
        get
        {
            return _endPosition;
        }
    }

    
    public void OnInit()
    {
        //khoi tao map
        currentMapIndex = Random.Range(0, mapPrefabs.Count);
        currentMap = Instantiate(mapPrefabs[currentMapIndex], transform);
        //tao vi tri ban dau cho map
        platform_Manager.platformPos = currentMap.transform;

        platform_Manager.OnInit();


        CacheEndPosition();
        //khoi tao character
        player.OnInit();
        player.transform.position = startPos.position;

        currentEnemy = Instantiate(enemy, startPos);
        characters.Add(currentEnemy);
        Enemy E = currentEnemy.GetComponent<Enemy>();
        E.OnInit();
        E.winPos = endPosTransform;


        //characters[i].transform.position = MapManager.Ins.startPosition.position;


        //khoi tao currentEnemy
        //foreach (GameObject enemy in enemyPrefabs)
        //{
        //    Instantiate(enemy, transform);
        //}

        //player.position = MapManager.instance.startPosition.position;


        //UIManager.Ins.backGround.SetActive(false);
        //UIManager.Ins.nextLevelButton.SetActive(false);
        //UIManager.Ins.restartButton.SetActive(false);

    }
    private void CacheEndPosition()
    {
        Debug.Log(currentMap!=null);
        if (currentMap != null)
        {
            Transform endPos = currentMap.transform.Find("EndPos");
            if (endPos != null)
            {
                _endPosition = endPos;
            }
            else
            {
                Debug.LogError("ffffffff");
            }
        }
        else
        {
            Debug.LogError("gggggggg");
        }
    }
    public void OnDespawn() 
    {
        Destroy(currentMap);
        Destroy(currentEnemy);
        platform_Manager.OnDespawn();

    }

    public void NextLevel()
    {
        currentMapIndex = (currentMapIndex + 1) % mapPrefabs.Count;
        OnDespawn();
        OnInit();
    }

    public void RestartLevel()
    {
        OnDespawn();

        //UIManager.Ins.backGround.SetActive(false);
        //UIManager.Ins.nextLevelButton.SetActive(false);
        //UIManager.Ins.restartButton.SetActive(false);
        currentMap = Instantiate(mapPrefabs[currentMapIndex], transform);

        //player.position = Platform_manager.Ins.startPosition.position;

    }
}
