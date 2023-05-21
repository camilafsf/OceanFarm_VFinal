using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playaudioclick : MonoBehaviour
{
    public AudioClip somBotao;
    private AudioSource audioSource;

    void Start()
    {
        // Obter o componente AudioSource na cena
        audioSource = GetComponent<AudioSource>();

        // Definir o som do bot�o
        if (somBotao != null)
        {
            audioSource.clip = somBotao;
        }
    }

    public void TocarSom()
    {
        // Tocar o som do bot�o
        if (audioSource != null && somBotao != null)
        {
            audioSource.PlayOneShot(somBotao);
        }
    }
}
