using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // TopLeftBorder and BotRightBorder are two empty game objects that you 
    // can move around the map to easily change the bounds of the camera.
    public GameObject TopLeftBorder;
    public GameObject BotRightBorder;
    public Camera Cam;
    public Transform Player;
    
    [SerializeField] private float LerpValue;
    private float _viewWidth, _viewHeight, _leftBound, _rightBound, _topBound, _botBound;

    void Start() 
    {
        _viewWidth = 2f * Cam.orthographicSize * Screen.width / Screen.height;
        _viewHeight = 2f * Cam.orthographicSize * Screen.height / Screen.width;
        _leftBound = TopLeftBorder.transform.position.x + _viewWidth/2f;
        _rightBound = BotRightBorder.transform.position.x - _viewWidth/2f;
        _botBound = BotRightBorder.transform.position.y + _viewHeight/1.5f;
        _topBound = TopLeftBorder.transform.position.y - _viewHeight/1.5f;

        // Instantiate Camera Position.
        transform.position = new Vector3(Player.transform.position.x,
        Player.transform.position.y,-10f);
    }

    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position,
        new Vector3(FindXBound(), FindYBound(), transform.position.z), LerpValue);
    }

    private float FindXBound()
    {
        if(Player.transform.position.x < _leftBound) return _leftBound;
        else if(Player.transform.position.x > _rightBound) return _rightBound;
        else return Player.transform.position.x;
    }

    private float FindYBound()
    {
        if(Player.transform.position.y > _topBound) return _topBound;
        else if (Player.transform.position.y < _botBound) return _botBound;
        else return Player.transform.position.y;
    }
}
