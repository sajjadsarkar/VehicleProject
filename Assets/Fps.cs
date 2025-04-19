using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Fps : MonoBehaviour
{
    public TextMeshProUGUI fpsText;

    private float deltaTime = 0.0f;
    private void Awake()
    {
        Application.targetFrameRate = 300;
    }
    void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        fpsText.text = "FPS: " + Mathf.Round(fps);
    }

}