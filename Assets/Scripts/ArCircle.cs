using UnityEngine;

public class ArCircle : Circle
{
    [Space]
    [SerializeField] [Min(0)] private float speedmulti = 0.85f;
    [SerializeField] private bool clockwise = true;
    [SerializeField] [Min(0)] private float timeskel = 1f;

    protected override void OnValidate()
    {
        Time.timeScale = timeskel;

        speedi = preset.speed;
        speedi = speedcurve.Evaluate(preset.number) * speedmulti;
        speedi *= clockwise ? -1f : 1f;
        //if (sprenderer != null) sprenderer.size = Vector2.one * size;
        //else GetComponent<SpriteRenderer>().size = Vector2.one * size;
        if (colly != null) colly.radius = size * 0.5f;
        else GetComponent<CircleCollider2D>().radius = size * 0.5f;

        numbertext.SetText(preset.number.ToString());
        sprenderer.color = preset.color;
    }
}