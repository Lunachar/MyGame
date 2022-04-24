using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Enemy enemyPrefab;
    private Vector3 enemyPosition = new Vector3(22f, -3f, -58f);
    private Enemy enemy;

    // Start is called before the first frame update
    void Start()
    {
        enemy = Instantiate(enemyPrefab, enemyPosition, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
