using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI; 

public class Temporizador : MonoBehaviour
{
	public Text contador;
	public static float tiempo = 60f;
	
	
	public void Update() 
	{
		if(tiempo > 0) {
			tiempo -= Time.deltaTime; 
			contador.text = "" + tiempo.ToString("f0");
		}
		  
	
		if(tiempo <= 0) Application.LoadLevel("Table");
	}
	
}
