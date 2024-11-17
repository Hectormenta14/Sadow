using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamemanager1 : MonoBehaviour
{
   // contola todo 
    public static gamemanager1 instance; //esto hace que sea accesible a todo, no se relacionan con otros gameobjects del juego
    // Start is called before the first frame update
    public enum GameManagerVariables { TIME, POINTS }; // EL TIPO ENUMERADO VALE PARA FACILITAR LA LECTURA DEL CODIGO 
    private float time;
    private int points;
    private void Awake()
    { //singleton
        if (!instance) // si el 
        {
            instance = this;  // si llega  y esta solo se queda como el unico para que no hayan mas de 1 
            DontDestroyOnLoad(gameObject);
        }
        else // si tiene info (hay mas)
        {
            Destroy(gameObject);  //se destruye el gameobject para que solo haya 1
        }
    }
    void Start()
    {

    }

    // Update is called once per frame

    void Update()
    {
        time += Time.deltaTime;
    }
    //getter, obtener el valor de la variable
    public float GetTime()
    {
        return time;
    }
    public int GetPoint()
    {
        return points;
    }
    // setter
    public void SetPoints(int value)
    {
        points = value;
    }
    // callback---funcion que se va a llamar en el onclick() de los botones 
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName); //oye, audiomanager, limpia todos los sonidos que estan sonando 
       
    }
    public void ExitGame()
    {
        Debug.Log("Exit!!");
        Application.Quit();
    }
}
