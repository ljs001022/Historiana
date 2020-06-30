using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Transform tr;
    public float speed;
    public float speed2;
    // Start is called before the first frame update
    void Start()
    {
        speed = 2.0f;
        tr = GetComponent<Transform>();
        speed2 = (GameObject.Find("GameManager").GetComponent<Score>().score/100+1);
        StartCoroutine(DestroySelf());
    }

    // Update is called once per frame
    void Update()
    {
        tr.Translate(Vector2.down * speed * speed2 * Time.deltaTime); 
        //Vector2.up 은 new Vector2(0,1)을 단축한 것, 해당 값에 SPEED를 곱하면 위로 움직인다.
    }

    IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(6.0f);
        Destroy(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector2 gps = new Vector2(tr.position.x, tr.position.y);
        if (gps.y<3.3)
        {
            Destroy(this.gameObject);
            GameObject.Find("GameManager").GetComponent<Score>().score += 10;
        }
        Destroy(collision.gameObject);
    }
}
