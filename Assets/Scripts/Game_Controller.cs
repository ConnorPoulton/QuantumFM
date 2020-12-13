using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Controller : MonoBehaviour
{
    public Texture[] channels = new Texture[5];
    public Texture blankTVScreen;
    public int[] lightButtonCode = new int[3];
    public GameObject tvScreen;
    public UI_Obj_ProgressBulb[] progressBulbs = new UI_Obj_ProgressBulb[4];
    public float[] staticIntensity = { 0, 0 };
    private Renderer tvRenderer;
    private bool powerOn = true;
    private int channelID;
    private int lightButtonCodeIndex = 0;


    void Start()
    {
        tvRenderer = tvScreen.GetComponent<Renderer>();
        tvRenderer.material.EnableKeyword("_Screen");
        tvRenderer.material.EnableKeyword("_Intensity");
        tvRenderer.material.EnableKeyword("_Temperature");
    }

    public void ChangeChannelID(int newChannelID)
    {
        channelID = newChannelID;
        ChangeChannel();
    }

    public void ChangeChannel()
    {
        if (powerOn)
            tvRenderer.material.SetTexture("_Screen", channels[channelID]);
    }

    public void SetStatic()
    {
        float intensity = staticIntensity[0] + staticIntensity[1];
        tvRenderer.material.SetFloat("_Intensity", intensity);
    }

    public void LightButtonCode(int codeDigit)
    {
        if (codeDigit == lightButtonCode[lightButtonCodeIndex])
        {
            if (lightButtonCodeIndex == (lightButtonCode.Length - 1))
            {
                Debug.Log("code entered");
                lightButtonCodeIndex = 0;
                progressBulbs[0].LightUp();
            }
            else
            {
                lightButtonCodeIndex++;
            }
        }
        else
        {
            lightButtonCodeIndex = 0;
        }
    }

    public void TogglePower()
    {
        powerOn = !powerOn;
        StartCoroutine(Flash((float)0.5));

        if (!powerOn)
        {
            tvRenderer.material.SetTexture("_Screen", blankTVScreen);
            tvRenderer.material.SetFloat("_Intensity", 1);
        }
        else
        {
            SetStatic();
            ChangeChannel();
        }
    }

    private IEnumerator Flash(float waitTime)
    {
        float timer = 0;
        float temperature = 0;
        float degrees = 0;
        while (timer < waitTime)
        {
            timer += Time.deltaTime;
            degrees = (Mathf.Lerp(0, (float)Math.PI,  (timer / waitTime)));
            temperature = (float)Math.Abs(Math.Sin(degrees));
            tvRenderer.material.SetFloat("_Temperature", temperature);
            yield return null;
        }
    }


}
