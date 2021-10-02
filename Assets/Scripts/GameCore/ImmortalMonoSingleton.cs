using UnityEngine;

public abstract class ImmortalMonoSingleton<T> : MonoBehaviour where T : ImmortalMonoSingleton<T>
{
    private static readonly object Lock = new object();
    private static bool ApplicationIsQuitting = false;

    private static T _instance;


    public static T Instance {
        get {
            if (ApplicationIsQuitting)
            {
                return null;
            }
            lock (Lock)
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<T>();
                }

                if (_instance == null)
                {
                    _instance = new GameObject($"[{typeof(T).Name}]", typeof(T)).GetComponent<T>();
                }
            }

            return _instance;
        }
    }

    protected virtual void OnEnable()
    {
        Application.quitting += () => ApplicationIsQuitting = true;
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this);
        }
        else
        {
            _instance = (T)this;
            DontDestroyOnLoad(_instance);
        }
    }
}
