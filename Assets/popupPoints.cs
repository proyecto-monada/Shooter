using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popupPoints : MonoBehaviour
{
	int score;


    // Start is called before the first frame update
    void Start()
    {
	score = (int)((100 + Puntuacion.extra) * Puntuacion.combo * (1+((60-Temporizador.tiempo)/30))/2);
    }

    // Update is called once per frame
    void Update()
    {
	
        GetComponent<TextMesh>().text = score + "p";
	Destroy(gameObject, 1f);

    }
}
