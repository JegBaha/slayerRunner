using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planeTile : MonoBehaviour
{
    endlessSpawner _endlessSpawner;
    [SerializeField] private GameObject _obstaclePrefab;
    [SerializeField] int coinsToSpawn = 10;
    [SerializeField] private GameObject _scorePreFab;
    [SerializeField] private GameObject _horizontalObstacle;
    [SerializeField] private GameObject _grabAbleObstacle;
    [SerializeField] private GameObject _zombieT;
    [SerializeField] private GameObject _jumpPad;
    [SerializeField] private GameObject _rollAbleObstacle;
    [SerializeField] private GameObject _dashItem;

    private int horizontalObstIndex;
    void Start()
    {
        _endlessSpawner = GameObject.FindObjectOfType<endlessSpawner>();
        spawnThing();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void spawnThing()
    {
        int _randomThing = Random.Range(0, 15);
        if (_randomThing == 6)
        
            spawnZombie();
        if(_randomThing<6)
            spawnDashItem();
        if(_randomThing>12)
            spawnJumpPad();
        if (_randomThing > 10 && _randomThing <= 12)
            spawnGrabAbleting();

        spawnObstacleThing();
        spawnScore();
        spawnhorizontalObstacle();
    
    
     
      
    }
    private void OnTriggerExit(Collider other)
    {
        _endlessSpawner.spawnRoad();
        Destroy(gameObject, 2);
    }

    private void spawnObstacleThing()
    {
        int obstacleIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obstacleIndex).transform;
        if (obstacleIndex == 4)
        {
            int newIndex = Random.Range(7, 10);
            Transform rollAble = transform.GetChild(newIndex).transform;
            Instantiate(_rollAbleObstacle, rollAble.position, Quaternion.identity, transform);
        }
            
        else
            Instantiate(_obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);

        

    }
    private void spawnhorizontalObstacle()
    {
        int obstacleIndex = Random.Range(2, 5);
        horizontalObstIndex = obstacleIndex;
        Transform spawnPoint = transform.GetChild(obstacleIndex).transform;
      
        Instantiate(_horizontalObstacle, spawnPoint.position, Quaternion.identity, transform);
    }
    private void spawnGrabAbleting()
    {

        Transform spawnPoint = transform.GetChild(12).transform;

        Instantiate(_grabAbleObstacle, spawnPoint.position, Quaternion.identity, transform);
    }
    private void spawnJumpPad()
    {
       
        Transform spawnPoint = transform.GetChild(11).transform;
   
        Instantiate(_jumpPad, spawnPoint.position, Quaternion.identity, transform);
    }
    private void spawnDashItem()
    {
       
        Transform spawnPoint = transform.GetChild(11).transform;

        Instantiate(_dashItem, spawnPoint.position, Quaternion.identity, transform);
    }

    private void spawnZombie()
    {
        
        Transform spawnPoint = transform.GetChild(11).transform;
     
        Instantiate(_zombieT, spawnPoint.position, Quaternion.identity, transform);
    }
    private void spawnScore()
    {
      
        for (int i = 0;i < coinsToSpawn; i++){
            GameObject tempCoin=Instantiate(_scorePreFab,transform);
            tempCoin.transform.position = getRandomIntCollider(GetComponent<Collider>());
        }
       
    }
    Vector3 getRandomIntCollider(Collider col)
    {
        Vector3 point = new Vector3(
            Random.Range(col.bounds.min.x, col.bounds.max.x), Random.Range(col.bounds.min.y, col.bounds.max.y), Random.Range(col.bounds.min.z, col.bounds.max.z)
            );

        if (point != col.ClosestPoint(point)){
            point = getRandomIntCollider(col);
        }
        point.y = 1;
        return point;
    }
    
}
