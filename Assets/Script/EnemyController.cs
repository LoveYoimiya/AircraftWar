using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private static int _score = 0;
    public float moveSpeed = 100f;

    private float _screenWidth;
    private float _screenHeight;
    private float _minX;
    private float _maxX;
    private float _minY;
    private float _maxY;

    void Start()
    {
        _screenWidth = Screen.width;
        _screenHeight = Screen.height;
        _minX = -_screenWidth / 2 + this.GetComponent<RectTransform>().rect.width / 2;
        _maxX = _screenWidth / 2 - this.GetComponent<RectTransform>().rect.width / 2;
        _minY = -_screenHeight / 2 + this.GetComponent<RectTransform>().rect.height / 2;
        _maxY = _screenHeight / 2 - this.GetComponent<RectTransform>().rect.height / 2;
    }

    void Update()
    {
        Vector2 newPosition = this.GetComponent<RectTransform>().anchoredPosition + new Vector2(0, -1) * moveSpeed * Time.deltaTime;

        if (newPosition.x < _minX || newPosition.x > _maxX || newPosition.y < _minY || newPosition.y > _maxY)
        {
            DestroyImmediate(gameObject);
            return;
        }

        this.GetComponent<RectTransform>().anchoredPosition = newPosition;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<HeroBullet>())
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            _score += 20;
            GameObject.FindWithTag("Score").GetComponent<TextMeshProUGUI>().text = _score.ToString();
        }
    }
}
