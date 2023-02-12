using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static object _Lock = new object();
    private static T _Instance;

    public static T ins
    {
        get
        {
            if (_Instance == null)
            {
                _Instance = (T)FindObjectOfType(typeof(T));

                var obj = FindObjectOfType<T>();

                if (_Instance == null)
                {
                    var singletonObject = new GameObject();
                    _Instance = singletonObject.AddComponent<T>();
                    singletonObject.name = typeof(T).ToString() + " (Singleton)";

                    DontDestroyOnLoad(singletonObject);
                }
            }
            return _Instance;
        }
    }
}