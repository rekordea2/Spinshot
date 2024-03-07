using TMPro;
using UnityEngine;

public class LevelTextManager : MonoBehaviour
{
    public TMP_Text leveltext;

    public void UpdateText(int levelnumber)
    {
        leveltext.SetText("LEVEL " + levelnumber);
    }
}