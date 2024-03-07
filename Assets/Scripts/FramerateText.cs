using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

//ATTACH TO A "DEBUG CANVAS"
public class FramerateText : MonoBehaviour
{
    [SerializeField] private float updatetime = 0.5f;
    [SerializeField] private bool warnlowfps = true;
    [SerializeField] private int warnfps = 60;
    private float timer;
    [SerializeField] private TMP_Text text;
    private List<float> rates = new List<float>();

    private void OnEnable() => timer = 0f;
    private void Update()
    {
        float unscaleddeltatime = Time.unscaledDeltaTime;

        if (warnlowfps && ((1f / unscaleddeltatime) < warnfps) && !Application.isFocused && (Time.realtimeSinceStartup > 0.5f) && (Time.timeSinceLevelLoad > 0.45f))
            Debug.LogWarning($"Low Framerate ({1f / unscaleddeltatime})");

        rates.Add(unscaleddeltatime);
        timer += unscaleddeltatime;


        if (timer >= updatetime)
        {
            timer = 0f;
            text.SetText((1f / rates.Average()).ToString("N0"));
            rates.Clear();
        }
    }
}