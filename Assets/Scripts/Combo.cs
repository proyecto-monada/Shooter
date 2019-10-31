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

