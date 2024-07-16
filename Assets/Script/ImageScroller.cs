using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ImageScroller : MonoBehaviour
{
    public GameObject pb0;
    public GameObject pb1;
    public GameObject pb2;
    public RectTransform bg;
    public RectTransform bg1;
    public GameObject bulletCreator;
    public float scrollSpeed = 100f;

    private float _imageHeight;
    private float _screenHeight;

    void Start()
    {
        _imageHeight = bg.rect.height;
        _screenHeight = Screen.height;
        GameObject pb;
        switch(GameManager.Instance.selectPrefab)
        {
            case 0:
                pb = GameObject.Instantiate(pb0, this.transform);
                break;
            case 1:
                pb = GameObject.Instantiate(pb1, this.transform);
                break;
            case 2:
                pb = GameObject.Instantiate(pb2, this.transform);
                break;
            default:
                pb = GameObject.Instantiate(pb0, this.transform);
                break;
        }
        
        pb.transform.position = new Vector3(GameObject.FindWithTag("HeroPoint").transform.position.x, GameObject.FindWithTag("HeroPoint").transform.position.y, -1);
        bulletCreator.GetComponent<BulletCreator>().SetShootPoint(GameObject.FindWithTag("ShootPoint").GetComponent<RectTransform>());
    }

    void Update()
    {
        float newY = bg.anchoredPosition.y - scrollSpeed * Time.deltaTime;
        if (newY <= -_screenHeight)
        {
            newY = _imageHeight;
        }
        bg.anchoredPosition = new Vector2(bg.anchoredPosition.x, newY);
        newY = bg1.anchoredPosition.y - scrollSpeed * Time.deltaTime;
        if (newY <= -_screenHeight)
        {
            newY = _imageHeight;
        }
        bg1.anchoredPosition = new Vector2(bg1.anchoredPosition.x, newY);
    }
}
