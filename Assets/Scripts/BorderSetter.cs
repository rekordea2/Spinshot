using UnityEngine;

public class BorderSetter : MonoBehaviour
{
    [SerializeField] private Transform U;
    [SerializeField] private Transform R;
    [SerializeField] private Transform L;
    [SerializeField] private Transform D;

    [SerializeField] private float U_offset;
    [SerializeField] private float R_offset;
    [SerializeField] private float L_offset;
    [SerializeField] private float D_offset;

    private void OnEnable()
    {
        if (MainCamera.maincamera == null) return;
        if (!(U || R || L || D)) return;

        U.position = new Vector2(0, MainCamera.maincamera.orthographicSize + U_offset);
        R.position = new Vector2(MainCamera.camerawidth + R_offset, 0);
        L.position = new Vector2(-MainCamera.camerawidth - L_offset, 0);
        D.position = new Vector2(0, -MainCamera.maincamera.orthographicSize - D_offset);
    }
}