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
		if (tiempo>0){
		tiempo -= Time.deltaTime; 
		contador.text = "" + tiempo.ToString("f0");	
		}
	}
	

}
