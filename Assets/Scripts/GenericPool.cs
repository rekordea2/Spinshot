using System.Collections.Generic;
using UnityEngine;

public abstract class GenericPool<T> : MonoBehaviour where T : Component
{
    public static GenericPool<T> instance { get; private set; }

    public int initialmake;
    [SerializeField] private bool expandable = true;
    public Transform parent;
    private bool filled;

    public T oboject;

    public Queue<T> queue = new Queue<T>();

    [Header("Debugging")]
    public bool uselest = false;
    public List<T> lest = new List<T>();

    private void Awake() => instance = this;
    private void Start() => MakeObject(initialmake);

    public void MakeObject(int amount)
    {
        if (!expandable && queue.Count == 0 && filled) return;
        for (int i = 0; i < amount; i++)
        {
            T obojectx = Instantiate(oboject);
            obojectx.gameObject.SetActive(false);
            if (parent) obojectx.transform.SetParent(parent);
            queue.Enqueue(obojectx);
            if (uselest) lest.Add(obojectx);
        }
        if (!filled) filled = true;
    }
    public T GetObject()
    {
        if (queue.Count == 0)
        {
            if (!expandable)
            {
                Debug.LogError($"Pool {this} not expandable!");
                return null;
            }
            MakeObject(2);
        }

        queue.Peek().gameObject.SetActive(true);
        if (uselest) lest.Remove(queue.Peek());
        return queue.Dequeue();
    }
    public void StoreObject(T obojecti)
    {
        obojecti.gameObject.SetActive(false);
        if (uselest) lest.Add(obojecti);
        queue.Enqueue(obojecti);
    }
}