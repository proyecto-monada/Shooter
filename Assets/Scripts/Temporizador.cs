using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI; 

public class Temporizador : MonoBehaviour
{
	//public Text contador;
	public float tiempo = 10;

	
	public void Update() 
	{
<<<<<<< HEAD
		tiempo -= Time.deltaTime; 
		contador.text = "" + tiempo.ToString("f0");	
		
=======
		
		if(tiempo > 0) tiempo -= Time.deltaTime; 
		//contador.text = "" + tiempo.ToString("f0");	
		if(tiempo <= 0) Application.LoadLevel("Table");
>>>>>>> d351c77ead75c8131f99199819f32f4136b43b20
	}
	

}
