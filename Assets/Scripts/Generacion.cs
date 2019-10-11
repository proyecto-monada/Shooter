﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generacion : MonoBehaviour
{		//genera enemigos de forma aleatoria en una zona determinada

	public GameObject theEnemy;
	public float xPos;
	public float zPos;
	public float timeGenerator;
	public int enemyCount;

    void Start()
    {
        StartCoroutine(EnemyDrop());
    }
	
	IEnumerator EnemyDrop()
	{
		while(enemyCount < 20)
		{	//area de generacion y tiempo entre spawn
			xPos = 0;
			zPos = Random.Range(0,5);
			timeGenerator = Random.Range(1,4);

			//crea el enemigo(sin mas(esta comentado), o cambiando el angulo)
		//	Instantiate(theEnemy, new Vector3(xPos, 0, zPos), Quaternion.identity);
			Instantiate(theEnemy, new Vector3(xPos, 6, zPos), Quaternion.Euler(0,90,0));
			yield return new WaitForSeconds(timeGenerator);
			enemyCount += 1;
		}
	}

}