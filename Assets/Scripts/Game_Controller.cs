using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Controller : MonoBehaviour
{
    public Texture[] channels = new Texture[5];
    public GameObject tvScreen;
    private Renderer tvRenderer;

    void Start()
    {
        tvRenderer = tvScreen.GetComponent<Renderer>();
        tvRenderer.material.EnableKeyword("_Screen");
        tvRenderer.material.EnableKeyword("_Intensity");

        
    }

    public void ChangeChannel(int channelID)
    {
        tvRenderer.material.SetTexture("_Screen", channels[channelID]);
    }

    public void SetStatic(float intensity)
    {
        tvRenderer.material.SetFloat("_Intensity", intensity);
    }
}
