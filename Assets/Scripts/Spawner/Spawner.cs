using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform container;
    [SerializeField] private int repeatCount;

    [Header("Distance")]
    [SerializeField] private int distanceBetweenFullLine;
    [SerializeField] private int distanceBetweenRandLine;
    
    [Header("Wall")]
    [SerializeField] private Wall wallPrefab;
    [SerializeField] private int wallSpawnChance;

    [Header("Block")]
    [SerializeField] private Block blockPrefab;
    [SerializeField] private int blockSpawnChance;

    [Header("Bonus")]
    [SerializeField] private Bonus bonusPrefab;
    [SerializeField] private int bonusSpawnChance;

    private BlockSpawnPoint[] blockSpawnPoints;
    private WallSpawnPoint[] wallSpawnPoints;
    private BonusSpawnPoint[] bonusSpawnPoints;

    private void Start()
    {
        blockSpawnPoints = GetComponentsInChildren<BlockSpawnPoint>();
        wallSpawnPoints = GetComponentsInChildren<WallSpawnPoint>();
        bonusSpawnPoints = GetComponentsInChildren<BonusSpawnPoint>();
            GenerateRoad();
    }
    private void GenerateRoad()
    {
        MoveSpawner(distanceBetweenFullLine);
        GenerateRandomElement(wallSpawnPoints, wallPrefab.gameObject, wallSpawnChance, Random.Range(0.5f, 4f));
        GenerateRandomElement(bonusSpawnPoints, bonusPrefab.gameObject, bonusSpawnChance,6f);
        GenerateFullLine(blockSpawnPoints, blockPrefab.gameObject);
        MoveSpawner(distanceBetweenRandLine);
        GenerateRandomElement(blockSpawnPoints, blockPrefab.gameObject, blockSpawnChance);
        StartCoroutine("GenerateRoadCoroutine");
    }
    private void GenerateFullLine(SpawnPoint[] spawnPoints,GameObject generateElement)
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            GenerateElement(spawnPoints[i].transform.position, generateElement);
        }
    }
    private void GenerateRandomElement(SpawnPoint[] spawnPoints,GameObject generateElement,int spawnChance,float scaleY=8f)
    {
        for(int i=0;i<spawnPoints.Length;i++)
        {
            if(Random.Range(0,100)<spawnChance)
            {
                GameObject element = GenerateElement(spawnPoints[i].transform.position, generateElement);
                element.transform.localScale = new Vector3(element.transform.localScale.x, scaleY, element.transform.localScale.z);
            }
        }
    }
    private GameObject GenerateElement(Vector3 spawnPoint, GameObject spawnElement)
    {
        spawnPoint.y -= spawnElement.transform.localScale.y / 2;
        return Instantiate(spawnElement, spawnPoint, Quaternion.identity,container);
    }
    private void MoveSpawner(int distanceY)
    {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y+distanceY, this.transform.position.z);
    }
    private IEnumerator GenerateRoadCoroutine()
    {
        yield return new WaitForSeconds(2f);
        if(Snake.isPlayerAlive)
        GenerateRoad();
    }
}
