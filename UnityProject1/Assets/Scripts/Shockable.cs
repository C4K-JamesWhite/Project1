﻿using System.Collections;
using UnityEngine;

public class Shockable : MonoBehaviour
{
    [SerializeField]
    private GameObject _shocker;

    [SerializeField]
    private GameObject _setActiveOnCollision;

    [SerializeField]
    private float _shockTime;

    private void Awake()
    {
        _setActiveOnCollision.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject == _shocker)
        {
            _setActiveOnCollision.SetActive(true);
            GetComponent<Patrol>().enabled = false;
            StartCoroutine(ShockForShockTime());
        }
    }

    private IEnumerator ShockForShockTime()
    {
        yield return new WaitForSeconds(_shockTime);
        GetComponent<Patrol>().enabled = true;
        _setActiveOnCollision.SetActive(false);
    }
}
