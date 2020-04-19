using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_Manager : MonoBehaviour
{
    #region Singleton
    private static game_Manager instance;

    public static game_Manager Instance
    {
        get { return instance; }
        set { }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(this);
        }
    }
    #endregion
    public GameObject player;
    public EnemyController enemyController;
    public List<GameObject> mobs = new List<GameObject>();

    public int mobCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
