using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SangreAparece : MonoBehaviour
{
	
	public GameObject aparece;
	public GameObject aparece1;
	void Start (){
		aparece.SetActive(false);
		aparece1.SetActive(false);
	}
	
    void Update()
    {
        if (Puntuacion.combo>=7){
			aparece.SetActive(true);
			aparece1.SetActive(true);
		}else{
			aparece.SetActive(false);
			aparece1.SetActive(false);
		}
    }
}
