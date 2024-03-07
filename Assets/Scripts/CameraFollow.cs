using UnityEngine;
using UnityEngine.Serialization;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private BallShoot gameball;
    [Space]
    [SerializeField] private float offset = 2.2f;
    [SerializeField] private float smoothe = 0.14f;
    [SerializeField] private float maxspeede = 9.35f;
    private Vector3 trash;

    private void LateUpdate()
    {
        if (!LevelManager.instance.levelon) return;

        if (gameball.currentcircle == gameball.startcircle) return;

        if (gameball.currentcircle.transform.position.y > transform.position.y - offset)
        {
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(0, gameball.currentcircle.transform.position.y + offset, -10), ref trash, smoothe, maxspeede);
        }
    }
}