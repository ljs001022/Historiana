using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreate : MonoBehaviour
{
    public GameObject prefabEnemy;
    public float timing;
    public Vector2 limitMin;
    public Vector2 limitMax;
    // Start is called before the first frame update
    void Start()
    {
        timing = 3.0f;
        StartCoroutine(CreateEnemy());
    }

    IEnumerator CreateEnemy()
    {
        while (true)
        {
            float r = Random.Range(limitMin.x, limitMax.x);
            Vector2 creatingPoint = new Vector2(r, limitMin.y);

            Instantiate(prefabEnemy, creatingPoint, Quaternion.identity);
            int score = (GameObject.Find("GameManager").GetComponent<Score>().score/100);
            if (score > 5)
                score = 5;
            float creatingTime;
            creatingTime = timing-score/2.0f;
            yield return new WaitForSeconds(creatingTime);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawLine(limitMin, limitMax);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
