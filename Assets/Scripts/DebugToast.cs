using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

//ATTACH TO A "DEBUG CANVAS"
public class DebugToast : Singleton<DebugToast>
{
    [SerializeField] private TMP_Text toasttext;

    private bool toasting;
    private Queue<Toast> toastline = new();

    protected override void Awake()
    {
        base.Awake();
        toasttext.gameObject.SetActive(false);
    }

    public static async void MakeToast(Toast toast)
    {
        if (string.IsNullOrEmpty(toast.message)) return;

        instance.toastline.Enqueue(toast);

        while (!instance.toasting && instance.toastline.Count != 0)
            await PopToast(instance.toastline.Dequeue());
    }

    private static async Task PopToast(Toast toast)
    {
        instance.toasting = true;
        instance.toasttext.gameObject.SetActive(true);
        instance.toasttext.SetText(toast.message);

        await Task.Delay((int)(toast.duration * 1000f));
        if (!Application.isPlaying) return;
        instance.toasttext.gameObject.SetActive(false);
        instance.toasting = false;
    }
}

public struct Toast
{
    public readonly string message;
    public readonly float duration;

    public Toast(string message, float duration = 2.5f)
    {
        this.message = message;
        this.duration = duration;
    }
}