using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BUTTON : MonoBehaviour
{
    // Start is called before the first frame update
    public void ExitGame()
    {
        gamemanager1.instance.ExitGame();
    }
    public void LoadScene(string SeneName)
    {
        gamemanager1.instance.LoadScene(SeneName); // al pulsar el boton cambiara de escena

    }
}
