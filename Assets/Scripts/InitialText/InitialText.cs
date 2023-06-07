using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InitialText : MonoBehaviour
{
    public TextMeshProUGUI initialText;
    public Image objectiveImage;
    private bool image;
    public GameObject player;

    void Start()
    {
        Invoke("Objective", 3f);

        player.GetComponent<PlayerMoviment>().movement = false;
    }

    void Update()
    {
        if (image == false)
        {
            objectiveImage.GetComponent<Image>().color += new Color(0, 0, 0, 0.01f);
            initialText.color += new Color(0, 0, 0, 0.01f);
        }

        else
        {
            player.GetComponent<PlayerMoviment>().movement = true;
            objectiveImage.GetComponent<Image>().color -= new Color(0, 0, 0, 0.01f);
            initialText.color -= new Color(0, 0, 0, 0.01f);
        }
    }

    private void Objective()
    {
        image = true;
    }
}
