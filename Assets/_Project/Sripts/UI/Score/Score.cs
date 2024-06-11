using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField]
    private TMP_Text scoreText;    

    private float time;

    void Update()
    {
        time += Time.deltaTime;
        scoreText.text = time.ToString("N0");
    }

}
