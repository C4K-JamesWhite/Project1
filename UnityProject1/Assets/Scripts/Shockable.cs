using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shockable : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _shockers;

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
        bool shockerHit = false;
        foreach(var shocker in _shockers)
        {
            if(col.gameObject == shocker)
            {
                shockerHit = true;
            }
        }
        if(shockerHit)
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
