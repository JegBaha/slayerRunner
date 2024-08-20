using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endlessSpawner : MonoBehaviour
{
    [SerializeField] private GameObject groundPrefab;
    [SerializeField] Vector3 nextSpawn;
    void Start()
    {
      for(int i = 0; i < 15; i++)
        {
            spawnRoad();
        
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void spawnRoad()
    {
        GameObject tempObj= Instantiate(groundPrefab, nextSpawn, Quaternion.identity);
        nextSpawn = tempObj.transform.GetChild(1).transform.position;
    }
}
