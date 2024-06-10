using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField]
    private TMP_Text scoreText;
    void Update()
    {
        scoreText.text = Time.deltaTime.ToString();
    }
}
