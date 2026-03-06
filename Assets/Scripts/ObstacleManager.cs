using System;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    private Transform[] spawnPositions;
    public ObstacleSpawn[,] spawnPointsMatrizA = new ObstacleSpawn[9,3];
    public ObstacleSpawn[,] spawnPointsMatrizB = new ObstacleSpawn[9,3];
    private bool matrizFlowControl = true;
    private LevelManager levelManager;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameController.gameController.obstacleManager = this;
        levelManager = GameController.gameController.levelManager;        
    }

    public void UpdateMatriz(ObstacleSpawn[,] matriz)
    {
        if(matrizFlowControl) 
            spawnPointsMatrizA = matriz;
        else 
            spawnPointsMatrizB = matriz;

        matrizFlowControl = !matrizFlowControl;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            //spawnPointsMatrizA = levelManager.currentPrefab
            for (int i = 0; i < spawnPointsMatrizA.GetLength(0); i++)
            {
                for (int j = 0; j < spawnPointsMatrizA.GetLength(1); j++)
                {
                    Debug.Log("Elemento [" + i + "," + j + "] = " + spawnPointsMatrizA[i, j]);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            //spawnPointsMatrizA = levelManager.currentPrefab
            for (int i = 0; i < spawnPointsMatrizB.GetLength(0); i++)
            {
                for (int j = 0; j < spawnPointsMatrizB.GetLength(1); j++)
                {
                    Debug.Log("Elemento [" + i + "," + j + "] = " + spawnPointsMatrizB[i, j]);
                }
            }
        }
    }
}
