using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance; // Singleton
    private List<string> hours; //almacenamos la lista de las horas en el gamemanager

    public Text scoreText; // Referencia al UI del texto de la puntuación
    public int score; // Puntuación inicial

    private void Awake()
    {
        // Configurar el GameManager como Singleton
        if (Instance == null)
        {
            Instance = this;
            hours = new List<string>(); //instancio la variable de horas
            DontDestroyOnLoad(gameObject); // Asegurar que no se destruye al cambiar de escena
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        //UpdateScoreText(); // Mostrar la puntuación inicial

    }

    ////// Método para aumentar la puntuación
    //public void AddScore(int amount)
    //{
    //    score += amount; // Aumentar la puntuación
    //    UpdateScoreText(); // Actualizar el texto de la puntuación
    //}

    ////// Método para actualizar el texto de la puntuación y ejecutar el fade-in/fade-out
    //private void UpdateScoreText()
    //{
    //    scoreText.text = "Score: " + score;
    //    StartCoroutine(FadeTextEffect());
    //}

    // Corrutina para el efecto de fade-out y fade-in en el texto
    IEnumerator FadeTextEffect()
    {
        // Fade-out
        for (float t = 1f; t >= 0; t -= Time.deltaTime)
        {
            Color color = scoreText.color;
            color.a = t;
            scoreText.color = color;
            yield return null;
        }

        // Fade-in
        for (float t = 0f; t <= 1; t += Time.deltaTime)
        {
            Color color = scoreText.color;
            color.a = t;
            scoreText.color = color;
            yield return null;
        }
    }
    public void SetHours(List<string> value)
    {
        hours = value;
    }
    public List<string> GetHours()
    {
        return hours;
    }

}
