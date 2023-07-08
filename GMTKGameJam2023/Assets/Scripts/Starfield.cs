using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starfield : MonoBehaviour
{
    public GameObject starPrefab;

    public int numStars = 10;

    void Start()
    {
        for (int i = 0; i < numStars; i++)
        {
            GameObject star = Instantiate(starPrefab, new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0), Quaternion.identity);
            star.transform.parent = gameObject.transform;
        }
    }

    void Update()
    {
        foreach (Transform child in transform)
        {
            child.transform.Rotate(0, 0, Random.Range(-1f, 1f));
            Color color = child.GetComponent<SpriteRenderer>().color;
            color.a = Mathf.Lerp(0, 1, Time.time / 100);
            child.GetComponent<SpriteRenderer>().color = color;
        }
    }
}
