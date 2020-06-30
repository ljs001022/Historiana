using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;

    Transform tr;
    Vector2 mousePosition;

    public Vector2 limitPoint1;
    public Vector2 limitPoint2;

    public GameObject prefabBullet;

    void Start()
    {
        limitPoint1 = new Vector2(-2, 3);
        limitPoint2 = new Vector2(2, -3);
        speed = 2;
        tr = GetComponent<Transform>();

        StartCoroutine(FireBullet());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (mousePosition.x < limitPoint1.x)
            {
                mousePosition = new Vector2(limitPoint1.x, mousePosition.y);
            }
            if (mousePosition.y > limitPoint1.y)
            {
                mousePosition = new Vector2(mousePosition.x, limitPoint1.y);
            }
            if (mousePosition.x > limitPoint2.x)
            {
                mousePosition = new Vector2(limitPoint2.x, mousePosition.y);
            }
            if (mousePosition.y < limitPoint2.y)
            {
                mousePosition = new Vector2(mousePosition.x, limitPoint2.y);
            }
            tr.position = Vector2.MoveTowards(tr.position, mousePosition, Time.deltaTime * speed);
            //Debug.Log(tr.position);
        }
    }
    IEnumerator FireBullet()
    {
        while (true)
        {
            Instantiate(prefabBullet, tr.position, Quaternion.identity);

            yield return new WaitForSeconds(0.3f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene("GameOver");
    }
    //void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.cyan;
    //    Gizmos.DrawLine(limitPoint1, new Vector2(limitPoint2.x, limitPoint1.y));
    //    Gizmos.DrawLine(limitPoint1, new Vector2(limitPoint1.x, limitPoint2.y));
    //    Gizmos.DrawLine(new Vector2(limitPoint1.x, limitPoint2.y), limitPoint2);
    //    Gizmos.DrawLine(new Vector2(limitPoint2.x, limitPoint1.y), limitPoint2);
    //}
}
