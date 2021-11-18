using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    private GameObject _enemy;
    public const float baseSpeed = 6.0f;


    private void Awake()
    {
        
    }
    private void OnDestroy()
    {
        
    }
    private void OnSpeedChanged(float value)
    {
        
    }


    private void Update()
    {
        if (_enemy==null)
        {
            _enemy = Instantiate(enemyPrefab) as GameObject;
            //_enemy.transform.position = new Vector3(-5, 3, 0);
            _enemy.transform.position = new Vector3(-13,0,12);
            float angle = Random.Range(0, 360);
            _enemy.transform.Rotate(0, angle, 0);
        }
    }

}
