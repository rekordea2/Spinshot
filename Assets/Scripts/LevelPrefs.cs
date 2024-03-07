using UnityEngine;

public class LevelPrefs : MonoBehaviour
{
    private const string SKV = "niveau";

    private void OnApplicationPause(bool pause) => Scratch();

    private void OnApplicationQuit() => Scratch();

    public static void Scratch(int custom = -67)
    {
        int x = custom == -67 ? LevelManager.instance.currentlevelnumber : custom;

        PlayerPrefs.SetInt(SKV, x);
        //print(PlayerPrefs.GetInt(SKV));
        PlayerPrefs.Save();
    }

    public static int GetGroove() => PlayerPrefs.HasKey(SKV) && PlayerPrefs.GetInt(SKV) != 0 ? PlayerPrefs.GetInt(SKV) : 1;
}