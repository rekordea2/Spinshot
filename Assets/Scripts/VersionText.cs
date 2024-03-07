using UnityEngine;

public class VersionText : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text versiondisplaytext;

    private void Awake() => versiondisplaytext.SetText(Application.version);
}