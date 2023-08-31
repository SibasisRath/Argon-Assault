using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMeshProUGUI;

    [SerializeField] GameObject score;

    // Update is called once per frame
    void Update()
    {
        int result = score.GetComponent<ScoreBoardScript>().GetScore();
        textMeshProUGUI.text = $"Score: {result}";
    }
}
