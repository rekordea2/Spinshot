using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T instance { get; private set; }

    [SerializeField] private SingletonProperties singletonProperties;

    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
            if (singletonProperties.dontDestroyOnLoad) DontDestroyOnLoad(gameObject);
        } else
        {
            if (singletonProperties.destroyObjectOnDuplicate) Destroy(gameObject);
            else Destroy(this);
        }
    }
}

[System.Serializable]
public struct SingletonProperties
{
    public bool dontDestroyOnLoad;
    public bool destroyObjectOnDuplicate;
}