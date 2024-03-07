using TMPro;
using UnityEngine;

//ATTACH TO A "DEBUG CANVAS"
public class ScreenResolutionText : MonoBehaviour
{
    [SerializeField] private bool consoleprint;
    [SerializeField] private TMP_Text text;
    private const string s_spacecolonspace = " : ";
    private const string s_ex = "x";
    private Vector2 screenres;
    private int screenrefreshrate;

    private void Awake()
    {
        screenres = new Vector2(Screen.currentResolution.width, Screen.currentResolution.height);
        screenrefreshrate = Screen.currentResolution.refreshRate;

        if (consoleprint)
        {
            print(Screen.orientation);
            print(Screen.currentResolution);
        }
    }
    private void Start() => text.SetText(screenres.x + s_ex + screenres.y + s_spacecolonspace + screenrefreshrate);
}