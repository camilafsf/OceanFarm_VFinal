using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance; // Singleton

    public bool isMuted = false;

    private List<IAudioObserver> observers = new List<IAudioObserver>();

    private void Awake()
    {
        // Singleton
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // Carregar estado mutado se j� foi salvo
        if (PlayerPrefs.HasKey("audioMuted"))
        {
            isMuted = PlayerPrefs.GetInt("audioMuted") == 1;
        }
        else
        {
            isMuted = false;
        }
    }

    public void ToggleMute()
    {
        isMuted = !isMuted;

        // Notificar todos os observadores
        foreach (IAudioObserver observer in observers)
        {
            observer.OnAudioStateChanged(isMuted);
        }

        // Salvar o estado mutado
        PlayerPrefs.SetInt("audioMuted", isMuted ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void RegisterObserver(IAudioObserver observer)
    {
        observers.Add(observer);
    }

    public void UnregisterObserver(IAudioObserver observer)
    {
        observers.Remove(observer);
    }
}

public interface IAudioObserver
{
    void OnAudioStateChanged(bool isMuted);
}

public class AudioUI : MonoBehaviour, IAudioObserver
{
    private Button muteButton;

    private void Start()
    {
        muteButton = GetComponent<Button>();
        muteButton.onClick.AddListener(ToggleMute);

        // Registrar como um observador de �udio
        AudioManager.instance.RegisterObserver(this);
    }

    private void OnDestroy()
    {
        // Remover o registro como observador de �udio
        AudioManager.instance.UnregisterObserver(this);
    }

    public void OnAudioStateChanged(bool isMuted)
    {
        // Atualizar a apar�ncia do bot�o
        // Se isMuted � verdadeiro, mostre um �cone de som desativado. Caso contr�rio, mostre um �cone de som ativado.
        // Exemplo:
        // muteButton.image.sprite = isMuted ? mutedSprite : unmutedSprite;
    }

    private void ToggleMute()
    {
        AudioManager.instance.ToggleMute();
    }
}
