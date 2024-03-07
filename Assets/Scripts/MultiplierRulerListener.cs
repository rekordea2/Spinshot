using UnityEngine;

public class MultiplierRulerListener : MonoBehaviour
{
    public static bool running = true;

    [SerializeField] private Color hitcolor = Color.black;

    private void OnEnable() => running = true;

    private void OnCollisionEnter2D(Collision2D cd)
    {
        if (!running || !LevelManager.instance.levelon) return;
        running = false;
        BorderListener.listening = false;

        GetComponent<SpriteRenderer>().color = hitcolor;
        int simulti = int.Parse(name);
        simulti *= simulti == 10 ? 2 : 1;
        LevelManager.instance.Endgame(true, simulti);
    }
}