﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generacion : MonoBehaviour
{		//genera enemigos de forma aleatoria en una zona determinada

	public GameObject theEnemy;
	//public GameObject theEnemy2;
	//public GameObject theEnemy3;
	private int enemys = 1;
	public float xScale=0;
	public float zScale=0;
	public float yScale=0;
	public float xPos=0;
	public float zPos=0;
	public float yPos=0;
	public float yRot=0;
	public float time1=0;
	public float time2=0;
	public int enemyCount;
	public int enemyCountMax;
	//private Health health;
		//theEnemy.GetComponent<Animator>();

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

			//Instantiate(theEnemy, new Vector3(xPos, yPos, zPos), Quaternion.Euler(0,yRot,0));


		//genera enemigo random:
				//enemys=Random.Range(1,4);
				//xScale = Random.Range(8,12);
				//zScale = Random.Range(8,12);
				//yScale = Random.Range(8,12);

			if(enemys==1)Instantiate(theEnemy, new Vector3(xPos, yPos, zPos), Quaternion.Euler(0,yRot,0));
				//theEnemy.transform.localScale = new Vector3(xScale/10, yScale/10, zScale/10);
						//theEnemy.GetComponent<Animator>().speed = 4;
	
			//if(enemys==2)Instantiate(theEnemy2, new Vector3(xPos, yPos, zPos), Quaternion.Euler(0,yRot,0));
			//	theEnemy2.transform.localScale = new Vector3(xScale/10, yScale/10, zScale/10);
		
			//if(enemys==3)Instantiate(theEnemy3, new Vector3(xPos, yPos, zPos), Quaternion.Euler(0,yRot,0));
			//	theEnemy3.transform.localScale = new Vector3(xScale/10, yScale/10, zScale/10);


			yield return new WaitForSeconds(Random.Range(time1-((60-Temporizador.tiempo)/20) ,time2-((60-Temporizador.tiempo)/13) ));
			enemyCount += 1;
		}
	}

}