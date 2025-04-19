using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Fps : MonoBehaviour
{

    private void Awake()
    {
        Application.targetFrameRate = 300;
    }

}