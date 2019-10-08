using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    // Start is called before the first frame update
    public void Quit_Game()
    {
        Debug.Log("El juego se ha cerrado, pero en Unity no se nota.");
        Application.Quit();
    }
}
