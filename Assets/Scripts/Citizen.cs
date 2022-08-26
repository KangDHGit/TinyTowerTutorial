using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TinyTower
{
    public class Citizen : MonoBehaviour
    {
        Vector3 _rightEnd;
        bool _arrive;
        Vector3 _leftEnd;
        public float _moveSpeed;

        private void Start()
        {
            int random = Random.Range(0, 2);
            if (random == 0)
                _arrive = true;
            else
                _arrive = false;

            _rightEnd = new Vector3(20, transform.position.y, transform.position.z);
            _leftEnd = new Vector3(0, transform.position.y, transform.position.z);
        }

        private void Update()
        {
            if (transform.position == _rightEnd)
                _arrive = true;
            else if (transform.position == _leftEnd)
                _arrive = false;

            if (!_arrive)
            {
                transform.position = Vector3.MoveTowards(transform.position, _rightEnd, _moveSpeed * Time.deltaTime);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 90, 0), 0.05f);
            }
            else if (_arrive)
            {
                transform.position = Vector3.MoveTowards(transform.position, _leftEnd, _moveSpeed * Time.deltaTime);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, -90, 0), 0.05f);
            }
        }
    }
}
