using UnityEngine;

public class Reticle : MonoBehaviour
{
    [SerializeField] private GameObject reticleholder;

    public void Show(float angle)
    {

        reticleholder.SetActive(true);
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);
    }
    public void Hide()
    {
        reticleholder.SetActive(false);
    }
}