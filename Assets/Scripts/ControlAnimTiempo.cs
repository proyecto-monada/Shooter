using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlAnimTiempo : MonoBehaviour
{
	[SerializeField] private Animator Control;
	public float tiempo = 0.0f;
	
	public void Update() 
	{
		tiempo -= Time.deltaTime; 
		if(tiempo < 6.0){
			Control.SetBool("Activar", true);
		}else{
			Control.SetBool("Activar", false);
		}

	}
}



