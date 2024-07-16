using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreator : MonoBehaviour
{
    public int maxEnemyNum = 5;
    private int _curNum = 0;
    public GameObject enemy0;
    public GameObject enemy1;
    public GameObject enemy2;

    public RectTransform minPoint;
    public RectTransform maxPoint;
    public float createRate = 0.5f;
    private float _nextCreateTime;
    private float _screenWidth;
    private float _screenHeight;
    private float _minX;
    private float _maxX;
    private float _minY;
    private float _maxY;
    // Start is called before the first frame update
    void Start()
    {
        _nextCreateTime = 0;
        _screenWidth = Screen.width;
        _screenHeight = Screen.height;
        _minX = -_screenWidth / 2 + this.GetComponent<RectTransform>().rect.width / 2;
        _maxX = _screenWidth / 2 - this.GetComponent<RectTransform>().rect.width / 2;
        _minY = -_screenHeight / 2 + this.GetComponent<RectTransform>().rect.height / 2;
        _maxY = _screenHeight / 2 - this.GetComponent<RectTransform>().rect.height / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > _nextCreateTime)
        {
            _nextCreateTime += createRate;
            GameObject enemy;
            int[] numbers = { 0, 1, 2 };
            int randomIndex = Random.Range(0, numbers.Length);
            switch (numbers[randomIndex])
            {
                case 0:
                    enemy = GameObject.Instantiate(enemy0, this.transform);
                    break;
                case 1:
                    enemy = GameObject.Instantiate(enemy1, this.transform);
                    break;
                case 2:
                    enemy = GameObject.Instantiate(enemy2, this.transform);
                    break;
                default:
                    enemy = GameObject.Instantiate(enemy0, this.transform);
                    break;
            }
            float newX = Random.Range(minPoint.transform.position.x, maxPoint.transform.position.x);
            enemy.transform.position = new Vector3(newX, minPoint.transform.position.y, -1);
        }
    }
}
