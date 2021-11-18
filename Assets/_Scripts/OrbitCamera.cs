using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCamera : MonoBehaviour
{
    [SerializeField] private Transform target;

    public float rotSpeed = 0.5f;

    private float _rotY;
    private Vector3 _offset;

    private void Start()
    {
        _rotY = transform.eulerAngles.y;
        _offset = target.position - transform.position;     // Сохранение начального смещения между камерой и целью
    }


    private void LateUpdate()
    {
        //float horInput = Input.GetAxis("Horizontal");
        //if (horInput !=0)       // Медленный поворот камеры при помощи клавищ со стрелками
        //{
        //    _rotY += horInput * rotSpeed;
        //}
        //else
        //{
        //    _rotY += Input.GetAxis("Mouse X") * rotSpeed * 3;       // Или быстрый поворот с помощью мыщи
        //}

        //Quaternion rotation = Quaternion.Euler(0, _rotY, 0);
        //transform.position = target.position - (rotation * _offset);        // Поддерживаем начальное смещение, сдвигаемое в соответстии с поворотом камеры
        //transform.LookAt(target);

        float horInput = Input.GetAxis("Horizontal") * rotSpeed;
        Quaternion rotation = Quaternion.Euler(0, _rotY, 0);
        transform.position = target.transform.position - (rotation * _offset);
        transform.LookAt(target);
    }

}
