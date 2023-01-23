using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Menu : MonoBehaviour
{
    public int ilevelToLoad;
    public string sLevelToLoad;
    public bool useIntToLoadLevel = false;

    public Slider volumeSlider;
    public AudioMixer mixer;
    //private float value;

    private void Start()
    {
        //mixer.GetFloat("volume", out value);
        //volumeSlider.value = value;
    }

    public void StartGame()
    {
        MudarCena();
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void SetVolume()
    {
        mixer.SetFloat("volume", volumeSlider.value);
    }

    public void MudarCena()
    {
        if (useIntToLoadLevel)
        {
            SceneManager.LoadScene(ilevelToLoad);
        }
        else
        {
            SceneManager.LoadScene(sLevelToLoad);
            //personagemCasa.SetActive(true);
        }
    }
}
