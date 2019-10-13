using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Puntuacion : MonoBehaviour
{
	public static int score = 0;
	Text puntuacion;
	
	void Start () {
		puntuacion  = GetComponent<Text>();
	}
	
    void Update()
    {	
        puntuacion.text= "Puntos: " + score;
	}
}
