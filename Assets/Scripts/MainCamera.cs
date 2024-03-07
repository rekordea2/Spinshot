using UnityEngine;

[RequireComponent(typeof(Camera))]
public class MainCamera : MonoBehaviour
{
    public static Camera maincamera;

    [SerializeField] private bool capFrameRate = true;

    public static float camerawidth => maincamera.aspect * maincamera.orthographicSize;

    private void OnEnable()
    {
        maincamera = GetComponent<Camera>();

#if UNITY_EDITOR
        UnityEngine.Debug.unityLogger.logEnabled = true;
#else
       if (capFrameRate) Application.targetFrameRate = 60;
       Debug.unityLogger.logEnabled = false;
#endif
    }
}