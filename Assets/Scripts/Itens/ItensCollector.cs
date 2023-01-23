using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ItensCollector : MonoBehaviour
{
    public int frutas = 0;
    public int laços = 0;
    public int sodas = 0;
    public int candys = 0;

    [SerializeField]
    private Text frutasText;

    [SerializeField]
    private Text powerupsText;

    [SerializeField]
    private Text coletaveisText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Frutas"))
        {
            Destroy(collision.gameObject);
            AudioManager.instance.Play("Itens");
            frutas++;
            PlayerPrefs.SetInt("estatisticsFrutas", frutas);
            frutasText.text = "Frutas: " + frutas;
            GameObject.Find("Panel").GetComponent<ProgressBar>().BarraAtt(-3f);
        }

        if (collision.CompareTag("Laços"))
        {
            Destroy(collision.gameObject);
            AudioManager.instance.Play("Itens");
            laços++;
            PlayerPrefs.SetInt("estatisticsLaços", laços);
        }

        if (collision.CompareTag("Soda"))
        {
            Destroy(collision.gameObject);
            AudioManager.instance.Play("Itens");
            Invoke("DebuffVelocity", 3f);
            GetComponent<PlayerMoviment>().moveSpeed = 10f;
            sodas++;
            PlayerPrefs.SetInt("estatisticsSodas", sodas);

            if (sodas > 2)
            {
                sodas = 0;
                GameObject.Find("Panel").GetComponent<ProgressBar>().BarraAtt(20f);
            }
        }

        if (collision.CompareTag("Candy"))
        {
            Destroy(collision.gameObject);
            AudioManager.instance.Play("Itens");
            Invoke("DebuffInvencibility", 3f);
            GetComponent<PlayerMoviment>().invencible = true;
            candys++;
            PlayerPrefs.SetInt("estatisticsCandys", candys);
            
            if (candys > 2)
            {
                candys = 0;
                GameObject.Find("Panel").GetComponent<ProgressBar>().BarraAtt(20f);
            }
        }

        if (collision.CompareTag("Final"))
        {
            AudioManager.instance.Play("Win");
            SceneManager.LoadScene("FinalScene");
        }
    }

    private void DebuffVelocity()
    {
        GetComponent<PlayerMoviment>().moveSpeed = GetComponent<PlayerMoviment>().moveSpeedInitial;
    }

    private void DebuffInvencibility()
    {
        GetComponent<PlayerMoviment>().invencible = false;
    }
}
