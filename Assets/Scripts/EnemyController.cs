using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{		//este scrip se le añade al enemigo en cuestion

	public float hValue=100f;
	public GameObject points;
	public float animationSpeedIncrementer = 1f;

	public void TakeDamage(float damage){
		hValue-=damage;			///////////////////////////
	}
    
    void Start()
    {//desactivamos los collider y activamos el animador

          setRigidbodyState(true);
        setColliderState(false);
        GetComponent<Animator>().enabled = true;	
    }

    void Update()	
    {				// comprobamos a ver si el zombie tiene vida, y aumentamos su velocidad de forma gradual
        CheckHealth();
	GetComponent<Animator>().speed =1+((60-Temporizador.tiempo)/20);	//a los 60 seg, va a velocidad x4
    }

	void CheckHealth(){
		if(hValue <=0){
			die();}
	}

		//funcion muerte: cambia collider y rigid body y desactiva el animador, provocando el ragdoll
			//destrulle el objeto despues de 2s
	public void die(){
		hValue=1;
   	     GetComponent<Animator>().enabled = false;	//desactivamos animador para que deje de caminar
   	     setRigidbodyState(false);			//activa el rigid global del zombie y desactiva el de sus piezas
    	    setColliderState(true);			//desactiva el collider global del zombie y activa el de sus piezas
		
  	      if (gameObject != null)
  	      {
			
			Puntuacion.score += (int)((100 + Puntuacion.extra) * Puntuacion.combo * (1+((60-Temporizador.tiempo)/30))); 
			//puntos por baja   base    p extra	    k por matar si fallar	k relacionado con la velocidad y la generacion de los zombies (max: x3)
			Puntuacion.combo++;
	
			Instantiate(points, new Vector3(transform.position.x, transform.position.y+3,transform.position.z+1),Quaternion.Euler(0,0,0));

   	        Destroy(gameObject, 2f);
   	     }
 	   }


//coje todos los rigibodys y los kinematiza/no salvo el padre q lo no/kinematiza
	void setRigidbodyState(bool state)
  	  {	
		 Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();
   	     foreach (Rigidbody rigidbody in rigidbodies)
  	      {
   	         rigidbody.isKinematic = state;
   	     }
   	     GetComponent<Rigidbody>().isKinematic = !state;
   	}

//coje todos los colliders y los desactiva/activa salvo el padre q lo activa/desactiva
 	   void setColliderState(bool state)
	{
  	      Collider[] colliders = GetComponentsInChildren<Collider>();
     	   foreach (Collider collider in colliders)
      	  {
     	       collider.enabled = state;
     	   }
	GetComponent<Collider>().enabled = !state;
	}
}
