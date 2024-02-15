using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    // 現在のGameState
    public GameState currentState = GameState.Opening;
    // Player_Unitychan
    public GameObject player;
    // バルーンのPrefab
    public GameObject balloon;
    // 照準（AimMarker.png）のPrefab
    public GameObject aimMarker;
    public TextMeshProUGUI bounceText;
    public TextMeshProUGUI dropText;

    public int MaxBalloons = 3; // Number of balloons to spawn

    // 下の変数から制御するので非公開変数
    private int bounceCount; // Bouncesで表示されるバウンス回数
    private int droppedCount; // Droppedで表示される落下回数

    // インスタンスをGameManager.csで管理し、全てのballonInstanceについて一元管理でaimMarkerが追従できるようにする
    private GameObject[] balloonInstances;
    private GameObject[] aimMarkerInstances;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player_unitychan");
        balloon = GameObject.Find("BalloonSphere");
        aimMarker = GameObject.Find("AimMarker");
        // bounceText = GameObject.Find("Bouncetext (TMP)");

        
        // Instantiate balloons and aim markers
        balloonInstances = new GameObject[MaxBalloons];
        aimMarkerInstances = new GameObject[MaxBalloons];
        // Vector3 pos = new Vector3(0.0f, 10.0f, 0.0f);

        for (int i = 0; i < MaxBalloons; i++)
        {
            balloonInstances[i] = Instantiate(balloon, new Vector3(i * 4, 3, 0), Quaternion.identity);
            aimMarkerInstances[i] = Instantiate(aimMarker, new Vector3(i * 4, 0.001f, 0.0f), Quaternion.Euler(90f, 0f, 0f));
        }

        FollowBalloons();
    }

    // Update is called once per frame
    void Update()
    {
        FollowBalloons();
    }

    // AimMarkerが常にBalloonの下の地面に来るようにしている関数
    void FollowBalloons()
    {
        for (int i = 0; i < MaxBalloons; i++)
        {
            if (balloonInstances[i] != null && aimMarkerInstances[i] != null)
            {
                Vector3 balloonPosition = balloonInstances[i].transform.position;
                aimMarkerInstances[i].transform.position = new Vector3(balloonPosition.x, aimMarkerInstances[i].transform.position.y, balloonPosition.z);
            }
        }
    }

    public void addBounce()
    {
        bounceCount += 1;
        bounceText.text = $"Bounce : {bounceCount}";
    }

    public void addDropped()
    {
        droppedCount += 1;
        dropText.text = $"Dropped : {droppedCount}";
        if (droppedCount > 2) {
            dropText.color = new Color(0.9f, 0.2f, 0.2f, 1.0f);
        }
    }

}
