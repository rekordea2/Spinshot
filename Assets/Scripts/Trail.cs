using System.Collections;
using UnityEngine;

[RequireComponent(typeof(TrailRenderer))]
public class Trail : MonoBehaviour
{
    private bool able;
    private TrailRenderer trailrenderer;

    private void Awake()
    {
        trailrenderer = GetComponent<TrailRenderer>();
    }
    private void Update()
    {
        if (!FeverBlock.feverapplicable)
        {
            able = false;
            trailrenderer.enabled = false;
            return;
        }

        if (FeverSet.feveron) able = true;
        else
        {
            able = false;
            trailrenderer.enabled = false;
        }
    }

    public void Show()
    {
        if (!FeverBlock.feverapplicable) return;

        if (!able) return;
        trailrenderer.enabled = true;
    }
    public void Hide()
    {
        StartCoroutine(Hitit());
    }

    private IEnumerator Hitit()
    {
        yield return new WaitForSeconds(trailrenderer.time * 0.22f);
        trailrenderer.enabled = false;
    }
}