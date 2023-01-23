using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class FinalScene : MonoBehaviour
{
    [SerializeField]
    private GameObject[] imagens;
    private int imagemAtual = 0;

    public TextMeshProUGUI finalText;

    public TMP_Text frutasText;
    public TMP_Text sodasText;
    public TMP_Text candysText;
    public TMP_Text laçosText;

    public int frutas = 0;

    void Start()
    {
        Application.targetFrameRate = 60;

        frutasText.text += PlayerPrefs.GetInt("estatisticsFrutas").ToString() + " coletadas";
        sodasText.text += PlayerPrefs.GetInt("estatisticsSodas").ToString() + " coletadas";
        candysText.text += PlayerPrefs.GetInt("estatisticsCandys") + " coletados";
        laçosText.text += PlayerPrefs.GetInt("estatisticsLaços").ToString() + " coletados";

        Invoke("ShowEstatistics", 8f);
    }

    void Update()
    {
        imagens[imagemAtual].GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, 0.01f);

        finalText.color += new Color(0, 0, 0, 0.01f);
    }

    private void ShowEstatistics()
    {
        imagens[imagemAtual].SetActive(false);

        imagens[imagemAtual + 1].SetActive(true);
    }
}
