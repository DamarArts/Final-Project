using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float offsetx;
    public float offsety;
    public float CamSmoothing;
    public PlayerControls PlayerScript;

    private string sceneName;

    private void Start()
    {

        Scene currentScene = SceneManager.GetActiveScene();

        sceneName = currentScene.name;
    }

    private void FixedUpdate()
    {   
        Vector3 CamPosition = new Vector3(player.position.x + offsetx, player.position.y + offsety,-1) ;
        Vector3 SmoothCam = Vector3.Lerp(transform.position, CamPosition, CamSmoothing * Time.deltaTime);
        transform.position = SmoothCam;
    }
}
