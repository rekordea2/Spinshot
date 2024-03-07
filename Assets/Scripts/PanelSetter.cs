using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PanelSetter : MonoBehaviour
{
    [Header("Win Panel")]
    [SerializeField] private GameObject winpanel;
    [SerializeField] private Button nextlevelbutton;
    [SerializeField] private Button tryagainbutton;
    [SerializeField] private Image winemojislot;
    [SerializeField] private TMPro.TMP_Text positivetext;
    [SerializeField] private Sprite[] winemojis;
    [SerializeField] private ParticleSystem[] winparticles;
    [SerializeField] private string[] positivemessages;

    [Header("Fail Panel")]
    [SerializeField] private GameObject failpanel;
    [SerializeField] private Button restartbutton;
    [SerializeField] private Image failemojislot;
    [SerializeField] private Sprite[] failemojis;

    public void SetWinPanel()
    {
        nextlevelbutton.onClick.AddListener(() => LevelManager.instance.LoadLevel(LevelManager.instance.currentlevelnumber + 1));
        tryagainbutton.onClick.AddListener(() => LevelManager.instance.LoadLevel(LevelManager.instance.currentlevelnumber));
        if (winemojis != null && winemojis.Length != 0) winemojislot.sprite = winemojis.OrderBy(s => Random.value).First();
        if (positivemessages != null && positivemessages.Length != 0) positivetext.text = positivemessages.OrderBy(s => Random.value).First();
        winpanel.SetActive(true);
        if (winparticles != null && winparticles.Length != 0)
            foreach (var parti in winparticles)
                parti.Play(true);
    }

    public void SetFailPanel()
    {
        restartbutton.onClick.AddListener(() => LevelManager.instance.LoadLevel(LevelManager.instance.currentlevelnumber));
        if (failemojis != null && failemojis.Length != 0) failemojislot.sprite = failemojis.OrderBy(s => Random.value).First();
        failpanel.SetActive(true);
    }

    public void ResetPanels()
    {
        winpanel.SetActive(false);
        failpanel.SetActive(false);

        nextlevelbutton.onClick.RemoveAllListeners();
        restartbutton.onClick.RemoveAllListeners();
    }
}