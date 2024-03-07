using UnityEngine;

[RequireComponent(typeof(BallShoot))]
public class BallAdopt : MonoBehaviour
{
    public static event System.Action balladopted;

    private BallShoot ballshoot;

    private void Awake()
    {
        ballshoot = GetComponent<BallShoot>();
    }
    private void OnCollisionEnter2D(Collision2D cd)
    {
        if (cd.gameObject.TryGetComponent(out Circle cider) && cd.transform != ballshoot.currentcircle && LevelManager.instance.levelon)
        {
            if (Time.timeSinceLevelLoad > 0.1f) Party(cd.GetContact(0).point, cider.GetComponent<SpriteRenderer>().color);
            ballshoot.Settle(cider);
            if (Time.timeSinceLevelLoad > 0.1f) balladopted?.Invoke();
        } else
        {
            ballshoot.rb.velocity = Vector2.zero;
        }
    }

    private void Party(Vector2 point, Color color)
    {
        ParticleSystem pat = LevelManager.instance.ballpartisystem;

        pat.gameObject.transform.position = point;
        pat.startColor = color;
        pat.Play();
    }
}