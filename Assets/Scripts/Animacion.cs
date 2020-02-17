using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animacion : MonoBehaviour
{
	[SerializeField] private Animator Contador;

	
	public void Update() 
	{

		if(Temporizador.tiempo < 11.0){
			Contador.SetBool("Activar", true);
		}else{
			Contador.SetBool("Activar", false);
		}
	}
}



