﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generacion : MonoBehaviour
{
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
		while(enemyCount < 100)
		{
			xPos = -8;
			zPos = Random.Range(-5,0);
			timeGenerator = Random.Range(1,4);

		//	Instantiate(theEnemy, new Vector3(xPos, 0, zPos), Quaternion.identity);
			Instantiate(theEnemy, new Vector3(xPos, 0, zPos), Quaternion.Euler(0,90,0));
			yield return new WaitForSeconds(timeGenerator);
			enemyCount += 1;
		}
	}

}