﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generacion : MonoBehaviour
{		//genera enemigos de forma aleatoria en una zona determinada

	public GameObject theEnemy;
	public float xPos=0;
	public float zPos=0;
	public float yPos=0;
	public float yRot=0;
	public float time1=0;
	public float time2=0;
	public int enemyCount;
	public int enemyCountMax;

    void Start()
    {
        StartCoroutine(EnemyDrop());
    }
	
	IEnumerator EnemyDrop()
	{
		while(enemyCount < enemyCountMax)
		{	//area de generacion y tiempo entre spawn
			//xPos = 0;
			//zPos = Random.Range(0,5);
			//timeGenerator = Random.Range(1,4);

			//crea el enemigo(sin mas(esta comentado), o cambiando el angulo)
		//	Instantiate(theEnemy, new Vector3(xPos, 0, zPos), Quaternion.identity);
			Instantiate(theEnemy, new Vector3(xPos, yPos, zPos), Quaternion.Euler(0,yRot,0));
			yield return new WaitForSeconds(Random.Range(time1,time2));
			enemyCount += 1;
		}
	}

}