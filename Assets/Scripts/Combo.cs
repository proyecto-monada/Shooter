using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Combo : MonoBehaviour
{
    // Start is called before the first frame update
	Text texto;
	
	void Start () {
		texto  = GetComponent<Text>();
	}
	
    void Update()
    {	
        texto.text= "Combo x" + Puntuacion.combo;
	}
}

/*		if(collisionExplosion=='Plane'){
				Puntuacion.combo=1;
			} */
			
			// Meter esa parte en algun sitio
			// colider cabeza +50;
			// acceder a la velocidad del zombie y dar puntos adicionales por ello 
			