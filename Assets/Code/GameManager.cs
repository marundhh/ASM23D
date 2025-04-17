using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public int lives = 3;

    // Phương thức tính điểm
    public void AddPoints(int points)
    {
        score += points;
        if (score > 100)
        {
            score = 100;
        }
    }
    public void SubtractPoints(int points)
    {
        score -= points;
    }
    public string CheckGameState()
    {
        if (score >= 100)
        {
            return "Win";
        }
        else
        {
            return "Lose";
        }
    }
}

