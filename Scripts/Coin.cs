using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

 public class Coin : MonoBehaviour
{
    [SerializeField] private Text _scoreText;

    public static int Score = 0;

    private void Update()
    {
        _scoreText.text = "Score: " + Score.ToString();
    }
}
