using UnityEngine;

[CreateAssetMenu]
public class CirclePreset : ScriptableObject
{
    public int number;
    public Color color = Color.white;
    [Space]
    public float speed;
    public bool randomdirection = true;
}