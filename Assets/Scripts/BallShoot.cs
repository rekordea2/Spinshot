using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Reticle), typeof(Trail))]
public class BallShoot : MonoBehaviour
{
    [SerializeField] private float shootspeed = 11;
    private bool flying;
    public Circle startcircle;
    private Reticle reticle;
    private Trail trail;
    [HideInInspector] public Circle currentcircle;
    [HideInInspector] public Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        reticle = GetComponent<Reticle>();
        trail = GetComponent<Trail>();
    }
    private void Start()
    {
        if (!startcircle) Debug.LogWarning("No Start Circle set for the ball");

        transform.parent = startcircle.transform;
        currentcircle = startcircle;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !flying && LevelManager.instance.levelon)
        {
            Send(shootspeed);
        }
    }

    public void Send(float force)
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.velocity = (transform.position - currentcircle.transform.position).normalized * force;

        Debug.DrawRay(transform.position, (transform.position - currentcircle.transform.position).normalized * 3, Color.red, 2);

        reticle.Hide();
        trail.Show();
        LevelManager.instance.ballpartisystem.Stop();
        transform.parent = null;
        flying = true;

        startcircle.spinnala = true;
    }

    public void Settle(Circle circle)
    {
        Transform circlet = circle.transform;

        float angel = -Mathf.Rad2Deg * Mathf.Atan2(transform.position.x - circlet.position.x, transform.position.y - circlet.position.y);
        if (Mathf.Sign(transform.position.x - circlet.position.x) == -1) angel += 360;

        rb.velocity = Vector2.zero;
        rb.bodyType = RigidbodyType2D.Kinematic;

        transform.SetParent(circlet);
        reticle.Show(angel);
        trail.Hide();

        Debug.DrawLine(circlet.position, new Vector2(circlet.position.x, circlet.position.y + Mathf.Abs(Vector2.Distance(circlet.position, transform.position))), Color.green, 2);
        Debug.DrawLine(circlet.position, transform.position, Color.green, 2);

        currentcircle = circle;
        flying = false;
    }
}