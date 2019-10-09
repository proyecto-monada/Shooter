using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{		//este scrip se le añade al enemigo en cuestion
    
    void Start()
    {//desactivamos los collider y activamos el animador

          setRigidbodyState(true);
        setColliderState(false);
        GetComponent<Animator>().enabled = true;
    }

    
    void Update()
    {
        
    }

//funcion muerte: cambia collider y rigid body y desactiva el animador, probocando el ragdoll
	//destrulle el objeto despues de 5s
	public void die()
   	 {

   	     GetComponent<Animator>().enabled = false;
   	     setRigidbodyState(false);
    	    setColliderState(true);

  	      if (gameObject != null)
  	      {
   	         Destroy(gameObject, 5f);
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
