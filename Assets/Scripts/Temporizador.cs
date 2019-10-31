using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI; 

public class Temporizador : MonoBehaviour
{
	public Text contador;
	public float tiempo = 0.0f;

	
	public void Update() 
	{
		tiempo -= Time.deltaTime; 
		contador.text = "" + tiempo.ToString("f0");	
		
	}
	

}
