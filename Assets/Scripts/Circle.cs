using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(CircleCollider2D))]
public class Circle : MonoBehaviour
{
    public bool spinnala = true;
    [SerializeField] protected float size = 1f;
    [Space]
    protected float speedi;
    [SerializeField] protected CirclePreset preset;
    [SerializeField] protected TMPro.TMP_Text numbertext;
    public SpriteRenderer sprenderer;
    protected CircleCollider2D colly;
    protected Rigidbody2D rb;
    public AnimationCurve speedcurve;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprenderer = GetComponent<SpriteRenderer>();
        colly = GetComponent<CircleCollider2D>();
    }
    private void Start()
    {
        OnValidate();
        sprenderer.size = Vector2.one * size;
    }
    private void FixedUpdate()
    {
        //rb.angularVelocity = (LevelManager.instance.levelon && spinnala) ? speedi : 0;

        if (spinnala) rb.angularVelocity = speedi;
    }

    protected virtual void OnValidate()
    {
        //speedi = preset.speed;
        speedi = speedcurve.Evaluate(preset.number) * .7f;
        if (preset.randomdirection) speedi *= Random.value > 0.5f ? 1f : -1f;
        //if (sprenderer != null) sprenderer.size = Vector2.one * size;
        //else GetComponent<SpriteRenderer>().size = Vector2.one * size;
        if (colly != null) colly.radius = size * 0.5f;
        else GetComponent<CircleCollider2D>().radius = size * 0.5f;

        numbertext.SetText(preset.number.ToString());
        sprenderer.color = preset.color;
    }
}