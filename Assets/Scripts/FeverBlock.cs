using UnityEngine;

public class FeverBlock : MonoBehaviour
{
    public static bool feverapplicable;

    [Min(1)] public int feverunlocklevel;
    [SerializeField] private GameObject[] feverobjects;

    public void Unlock(bool Truman)
    {
        feverapplicable = Truman;
        foreach (GameObject fevik in feverobjects) fevik.SetActive(Truman);
    }
}