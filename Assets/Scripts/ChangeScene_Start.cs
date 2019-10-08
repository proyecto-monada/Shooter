using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene_Start : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnMouseClick()
    {
        Application.LoadLevel("Escenario");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
