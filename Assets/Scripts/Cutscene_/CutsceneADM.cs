using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class CutsceneADM : MonoBehaviour
{
    public int ilevelToLoad;
    public string sLevelToLoad;
    public bool useIntToLoadLevel = false;

    [SerializeField]
    private GameObject[] imagens;
    //public TextMeshProUGUI[] cutsceneInitialText;

    private int imagemAtual = 0;
    //private int cutsceneAtual = 0;

    void Start()
    {
        Application.targetFrameRate = 60;

        Invoke("ChangeImage", 7f);
    }

    void Update()
    {
        imagens[imagemAtual].GetComponent<SpriteRenderer>().color += new Color (0,0,0,0.01f);

        //cutsceneInitialText[cutsceneAtual].color += new Color(0, 0, 0, 0.01f);
    }

    private void ChangeImage()
    {
        if (imagemAtual < imagens.Length - 1)
        {
            imagens[imagemAtual].SetActive(false);

            imagens[imagemAtual + 1].SetActive(true);

            imagemAtual++;
        }

        else
        {
            SceneManager.LoadScene("ApartamentoSofia1");
        }

        Invoke("ChangeImage", 7f);
    }
}
