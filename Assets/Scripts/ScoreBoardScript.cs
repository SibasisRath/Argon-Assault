using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoardScript : MonoBehaviour
{
    private int _score = 0;

    public void Scoreing(int _scoreIncrement)
    {
        _score += _scoreIncrement;
        Debug.Log($"Your score is: {_score}");
    }

    public int GetScore()
    {
        return _score;
    }
}
