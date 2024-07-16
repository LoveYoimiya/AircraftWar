using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCreator : MonoBehaviour
{
    private RectTransform _shootPoint;
    public GameObject bulletPrefab;
    public float shootRate = 0.5f;
    private float _nextShootTime;

    void Start()
    {
        _nextShootTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (_shootPoint == null) return;
        if (Time.time > _nextShootTime)
        {
            _nextShootTime += shootRate;
            var bullet = GameObject.Instantiate(bulletPrefab, GameObject.FindWithTag("GamePanel").transform);
            bullet.transform.position = _shootPoint.transform.position;
        }
    }
    public void SetShootPoint(RectTransform rectTransform)
    {
        _shootPoint = rectTransform;
    }
}
