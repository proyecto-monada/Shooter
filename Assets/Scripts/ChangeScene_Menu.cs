﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene_Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
	
	public void OnMouseClick()
    {
        Application.LoadLevel("Menu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
