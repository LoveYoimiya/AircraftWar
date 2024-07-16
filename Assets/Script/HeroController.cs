using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    private int _hp = 100;
    public float moveSpeed = 100f;

    private float _screenWidth;
    private float _screenHeight;

    void Start()
    {
        _screenWidth = Screen.width;
        _screenHeight = Screen.height;
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector2 newPosition = this.GetComponent<RectTransform>().anchoredPosition + new Vector2(moveX, moveY) * moveSpeed * Time.deltaTime;

        newPosition.x = Mathf.Clamp(newPosition.x, -_screenWidth / 2 + this.GetComponent<RectTransform>().rect.width / 2, _screenWidth / 2 - this.GetComponent<RectTransform>().rect.width / 2);
        newPosition.y = Mathf.Clamp(newPosition.y, -_screenHeight / 2 + this.GetComponent<RectTransform>().rect.height / 2, _screenHeight / 2 - this.GetComponent<RectTransform>().rect.height / 2);

        this.GetComponent<RectTransform>().anchoredPosition = newPosition;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyController>())
        {
            _hp -= 20;
            GameObject.FindWithTag("HP").GetComponent<TextMeshProUGUI>().text = _hp.ToString();
            Destroy(collision.gameObject);
        }
        if (_hp <= 0)
        {
            GameObject.FindWithTag("Canvas").GetComponent<PanelManager>().ShowPanel("GameOverPanel");
        }
    }
}
