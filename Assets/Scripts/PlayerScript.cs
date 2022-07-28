using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{


    public float moveSpeed = 10f;

    [SerializeField] float paddingLeft;
    [SerializeField] float paddingRight;
    [SerializeField] float paddingDown;
    [SerializeField] float paddingUp;
    Vector2 minBounds;
    Vector2 maxBounds;
    Vector2 rawInput;
    SceneChanger sceneChanger;

    private void Awake()
    {
        sceneChanger = FindObjectOfType<SceneChanger>();
    }
    private void Start()
    {
        InitBounds();
    }


    void Update()
    {
        MovePlayer();
    }

    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1,1));
    }

    private void MovePlayer()
    {
        Vector3 delta = rawInput * moveSpeed * Time.deltaTime;
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + paddingLeft, maxBounds.x - paddingRight);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y+ paddingDown, maxBounds.y - paddingUp);
        transform.position = newPos;

        var currentPosition = transform.position;

        var horizontal = Input.GetAxis("Horizontal");
        {
            transform.position = transform.position + new Vector3(horizontal, 0, 0) * Time.deltaTime* moveSpeed;
        }

        var vertical = Input.GetAxis("Vertical");
        {
            transform.position = transform.position + new Vector3(0, vertical, 0) * Time.deltaTime * moveSpeed;
        }

       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Thunder")
        {
            Time.timeScale = 0f;
            sceneChanger.GameOver();
        };
        
    }
}
