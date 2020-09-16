using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Singleton
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (isDestroying)
                return null;

            // 인스턴스가 없는 경우에 접근하려 하면 인스턴스를 할당해준다.
            if (!instance)
            {
                var res = Resources.Load<GameObject>("GameManager");
                instance = GameObject.Instantiate(res).GetComponent<GameManager>();
                instance.gameObject.name = res.name;

                if (!instance)
                    Debug.LogError("GameManager 찾기 실패");

                DontDestroyOnLoad(instance.gameObject);
            }
            return instance;
        }
    }
    #endregion
    //======================================


    public GameData Data { get; private set; }

    private GameObject userPrefab;
    private PlayerParams savedPlayerParams;

    static bool isDestroying = false;

    private void Awake()
    {
        if (instance != null && this != instance)
        {
            Destroy(gameObject);
        }
        else if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        Data = GetComponent<GameData>();
    }


    private void Update()
    {
        
    }

    private void OnApplicationQuit()
    {
        isDestroying = true;
    }

    private void OnDestroy()
    {
        isDestroying = true;
    }

    public void SpawnPlayer(string playerStartName = null)
    {
        if (FindPlayer() != null)
            return;

        if (!userPrefab)
            userPrefab = Resources.Load<GameObject>("User/User");
        if (!userPrefab)
            Debug.LogError("Error");

        var user = Instantiate<GameObject>(userPrefab);
        var player = user.transform.Find("Player");
        var playerStart = FindPlayerStart(playerStartName);

        player.SetPositionAndRotation(playerStart.transform.position, playerStart.transform.rotation);

    }

    public GameObject FindPlayer()
    {
        return FindObjectOfType<PlayerController>()?.gameObject;
    }

    public GameObject FindPlayerStart(string name = null)
    {
        GameObject playerStart;
        GameObject[] foundPlayerStarts = GameObject.FindGameObjectsWithTag("PlayerStart");

        if (string.IsNullOrEmpty(name))
        {
            playerStart = foundPlayerStarts.FirstOrDefault();
        }
        else
        {
            playerStart = foundPlayerStarts.Where(a => a.name == name).FirstOrDefault();
        }

        return playerStart;
    }

    public void SavePlayerTemporary()
    {

    }

}
