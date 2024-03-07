using UnityEngine;
using UnityEngine.UI;

public class LevelBarSet : MonoBehaviour
{
    private const float magicnumber = 1.91f;
    private Transform multirulerpos;
    private float ballhighestyet;
    private float goalpos_y;
    private float disti;
    private Transform gameball;
    [Space]
    [SerializeField] private Image barfill;

    private void Start()
    {
        //if (multirulerpos == null) Debug.LogError($"multirulerpos of {this} @ {name} not set!");
        ResetTheProgression();
    }
    private void Update()
    {
        if (!LevelManager.instance.levelon) return;

        float pos_y = gameball.position.y;

        if (pos_y > ballhighestyet)
        {
            ballhighestyet = pos_y;
            UpdateFill();
        }
    }

    private void UpdateFill()
    {
        if (!LevelManager.instance.levelon) return;

        barfill.fillAmount = 1 - Mathf.Clamp01((goalpos_y - gameball.position.y) / disti);
    }

    public void ResetTheProgression()
    {
        //gameball = GameObject.FindGameObjectWithTag("Ball").transform;
        gameball = LevelManager.instance.gameball.transform;
        multirulerpos = GameObject.FindGameObjectWithTag("Ruler").transform;
        goalpos_y = multirulerpos.position.y - magicnumber;
        disti = goalpos_y - gameball.position.y;
        ballhighestyet = gameball.position.y;
        barfill.fillAmount = 0;
    }
}