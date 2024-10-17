using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using JetBrains.Annotations;
using System.IO;

[System.Serializable]//objeto que puede pasar a formato Json, binario... y biceversa es un objeto serializable, que se identifica  se indica cono el codigo se antes y hay q ponerlo o no funciona
struct PlayerData //una clase pero mas pequeña q usabos solo para guardar atributos

{
    public Vector3 Position;
    public int puntuation;
    public List<string> hours; //guardar lista de horas

}
public class save_Jshon : MonoBehaviour
{
    public string fileName = "test.jshon";
    // Start is called before the first frame update
    void Start()
    {
        Load();
    }


    private void OnAplicationQick()
    {
        Save(); // guarda cuando te sales la posicion
    }
    private void Save()
    {
        StreamWriter streamWriter = new StreamWriter(Application.persistentDataPath + '\\' + fileName);
        PlayerData playerData = new PlayerData(); //instancio objeto que vamos a guardar
        playerData.Position = transform.position;   //guardar su posicion y rellenamos de info 

        string jshon = JsonUtility.ToJson(playerData); //pasar de un objeto serializable a un string en formato Json 
        streamWriter.Write(jshon); //lo escribimos

        // playerData.puntuation = gamemanager.instance.GetScore(); para que guarde los puntos 
        //List<string> hoursAux = new GameManager.Instance.GetHours();
        //hoursAux.Add(DateTime.Now.ToString("HH:mm:ss")); //hace la lista para guardar las horas
        //playerData.hours = hours; // en playerData accedo a las horas y acedo a la lista para guardar las horas
        streamWriter.Close();
    }
    private void Load()
    {
        if (File.Exists(Application.persistentDataPath + '\\' + fileName)) //si el atchivo existe se carga, y se pone esto oara q no intente cargar archivos inexixtentes 
        {
            StreamReader streamRender = new StreamReader(Application.persistentDataPath + '\\' + fileName); //cargar la partida guardada en la posicion guardada

            try
            {
                PlayerData playerData = JsonUtility.FromJson<PlayerData>(streamRender.ReadToEnd()); // el fromJson pasa de Json a objeto Serializable
                transform.position = playerData.Position; //posicionarlo
                //GM.intance.SetScore(playerData.puntuation); //guardar la puntuacion 
                GameManager.Instance.SetHours(playerData.hours); // para que cargue la info 
            }
            catch (System.Exception e) //como no guardamos la info en ningun servidor lo guardamos en Local, no tenemos control sobre el archivo del susuario.
                                       //nos aseguramos que si algo va mal, este todo controlado
            {
                Debug.Log(e.Message); // poner cualquier mensaje
            }

            streamRender.Close();


        }
    }
}
