using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Puntuacion : MonoBehaviour
{
	public static int score = 0;
	public static int extra=0;
	public static int combo = 1;

	Text puntuacion;
	
	void Start () {
		puntuacion  = GetComponent<Text>();
	}
	
    void Update()
    {	
        puntuacion.text= "Puntos: " + score;
	}
}
