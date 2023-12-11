using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
    private static T _instance;

    public static T instance { get { return _instance; } }

    protected void Awake()
    {
        if (instance == null)
        {
            _instance = this as T;
        }
        else
        {
            Debug.LogWarning("More than one " + typeof(T) + " Singleton");
        }
    }
} 

