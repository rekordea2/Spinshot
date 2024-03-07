using UnityEngine;
using UnityEngine.UI;

public class FeverSet : MonoBehaviour
{
    public static bool feveron;

    [SerializeField] [Range(0, 1f)] private float buff;
    [SerializeField] [Range(0, 1f)] private float nerf_ps;
    [SerializeField] [Min(0)] private float decoy;
    private float currentdec;
    [Space]
    [SerializeField] private Image barfill;
    [SerializeField] private CanvasGroup vignette;

    private void Update()
    {
        if (!LevelManager.instance.levelon) return;
        if (!FeverBlock.feverapplicable) return;

        //vignette.alpha = barfill.fillAmount >= 0.98 ? 1 : 0;


        if (currentdec <= 0)
            BarNerf(nerf_ps * Time.deltaTime);
        currentdec -= Time.deltaTime;

        feveron = barfill.fillAmount >= 0.92f;
    }

    private void BarBuff()
    {
        if (!FeverBlock.feverapplicable) return;

        barfill.fillAmount += buff;
        if (barfill.fillAmount == 1) currentdec = decoy;

        if (barfill.fillAmount >= 0.92f) UpdateVignette();
    }

    private void BarNerf(float amount)
    {
        if (!FeverBlock.feverapplicable) return;

        barfill.fillAmount -= amount;

        if (barfill.fillAmount >= 0.9f) UpdateVignette();
        else vignette.alpha = 0;
    }

    private void UpdateVignette()
    {
        vignette.alpha = barfill.fillAmount;
    }

    public void ResetTheFever()
    {
        barfill.fillAmount = 0;
        UpdateVignette();
    }

    private void OnEnable() => BallAdopt.balladopted += BarBuff;
    private void OnDisable() => BallAdopt.balladopted -= BarBuff;
}