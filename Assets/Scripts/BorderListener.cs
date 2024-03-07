using UnityEngine;

public class BorderListener : MonoBehaviour
{
    public static bool listening;

    private void OnEnable() => listening = true;

    private void OnTriggerEnter2D(Collider2D cd)
    {
        if (!listening || !LevelManager.instance.levelon) return;
        if (!cd.CompareTag("Ball")) return;

        listening = false;
        MultiplierRulerListener.running = false;
        LevelManager.instance.Endgame(false, 0);

    }
}