using UnityEngine;
using UnityEngine.SceneManagement;

public class Welcome : MonoBehaviour
{
    private void Start() => SceneManager.LoadScene(LevelPrefs.GetGroove());
}