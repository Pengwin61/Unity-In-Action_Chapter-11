using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    public float speed = 3.0f;
    public float ostacleRange = 5.0f;

    private bool _alive;

    public const float baseSpeed = 3.0f;    // Базовая скорость меняемая в соответствии с положением ползунка



    [SerializeField] private GameObject fireballPrefab;
    private GameObject _fireball;

    private void Start()
    {
        _alive = true;
    }

    private void Awake()
    {
        //Messenger<float>.AddListener(GameEvent.SPEED_CHANGED,OnSpeedChanged);
    }
    private void OnDestroy()
    {
        //Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGED,OnSpeedChanged);
    }
    private void OnSpeedChanged(float value)
    {
        speed = baseSpeed * value;
    }


    private void Update()
    {
        if (_alive)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);

            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.SphereCast(ray, 0.75f, out hit))
            {
                if (_fireball == null)
                {
                    _fireball = Instantiate(fireballPrefab) as GameObject;
                    _fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                    _fireball.transform.rotation = transform.rotation;
                }
                else if (hit.distance < ostacleRange)
                {
                    float angle = Random.Range(-110, 110);
                    transform.Rotate(0, angle, 0);
                }
                //if (hit.distance < ostacleRange)
                //{
                //    float angle = Random.Range(-110, 110);
                //    transform.Rotate(0, angle, 0);
                //}
            }
        } 
    }
    public void SetAlive(bool alive)
    {
        _alive = alive;
    }
}
