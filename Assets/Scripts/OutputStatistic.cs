using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutputStatistic : MonoBehaviour
{
    public Text MaxHeightText;
    public Text CurrentHeightText;
    public Text TotalMovementText;

    public void WriteTotalMovement(int value)
    {
        TotalMovementText.text = $"{value} m";
    }
    public void WriteMaxHeight(int value)
    {
        MaxHeightText.text = $"{value} m";
    }
    public void WriteHeight(int value)
    {
        CurrentHeightText.text = $"{value} m";
    }

}
