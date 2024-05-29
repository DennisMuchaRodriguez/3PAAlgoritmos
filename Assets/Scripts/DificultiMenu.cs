using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class DificultiMenu : MonoBehaviour
{

    public GameObject difficultyPanel;
    public Text difficultyText;

    private DobleCirculListed listaDificultades;

    private void Awake()
    {
        listaDificultades = new DobleCirculListed();
        listaDificultades.A�adir("F�cil");
        listaDificultades.A�adir("Normal");
        listaDificultades.A�adir("Dif�cil");

        ActualizarTextoDificultad();
    }

    public void AbrirPanel()
    {
        difficultyPanel.SetActive(true);
        ActualizarTextoDificultad();
    }

    public void CerrarPanel()
    {
        difficultyPanel.SetActive(false);
    }

    public void SiguienteDificultad()
    {
        listaDificultades.Siguiente();
        ActualizarTextoDificultad();
    }

    public void AnteriorDificultad()
    {
        listaDificultades.Anterior();
        ActualizarTextoDificultad();
    }

    public void ConfirmarDificultad()
    {
        string dificultadSeleccionada = listaDificultades.ObtenerValorActual();
        Debug.Log("Dificultad seleccionada: " + dificultadSeleccionada);

        
        switch (dificultadSeleccionada)
        {
            case "F�cil":
                SceneManager.LoadScene("EasyScene");
                break;
            case "Normal":
                SceneManager.LoadScene("NormalScene");
                break;
            case "Dif�cil":
                SceneManager.LoadScene("HardScene");
                break;
            default:
                Debug.LogError("Dificultad no v�lida seleccionada.");
                break;
        }
    }

    private void ActualizarTextoDificultad()
    {
        difficultyText.text = listaDificultades.ObtenerValorActual();
    }

}
