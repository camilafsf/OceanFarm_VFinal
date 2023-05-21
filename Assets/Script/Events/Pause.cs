using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Pause : MonoBehaviour
{
    public static Pause pause;
    public Button[] bts;
    public bool resourcePause;
    // Start is called before the first frame update
    private void Awake()
    {
        pause = this;
    }
    public void Paused()
    {
        resourcePause= false;
        foreach( var b in bts)
        {
            b.interactable = false;
        }
        TImer.Timer.stop = true;
        Calendar.date.Paused = true;
    }

    // Update is called once per frame
    public void UnPaused()
    {
        resourcePause = true;
        foreach (var b in bts)
        {
            b.interactable = true;
        }
        TImer.Timer.stop = false;
        Calendar.date.Paused = false;
        Calendar.date.day++;
    }
}
