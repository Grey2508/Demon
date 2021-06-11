using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBomb : MonoBehaviour
{
    public Sprite UsedBomb;
    public Sprite SimpleBomb;
    public List<Image> Bombs;

    public void ToggleToUsed(int index)
    {
        Bombs[index].sprite = UsedBomb;
    }
    public void ToggleToReady(int index)
    {
        Bombs[index].sprite = SimpleBomb;
    }
}
