using System.Collections;
using UnityEngine;
using TMPro;

public class Couner : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private float _delay = 0.5f;

    private int _amount;
    private bool _isActive = false;
    private Coroutine timer;

    private IEnumerator Timer(float delay)
    {
        WaitForSeconds wait = new WaitForSeconds(delay);

        while (_isActive)
        {
            _text.text = _amount++.ToString();
            yield return wait;
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!_isActive)
            {
                _isActive = true;
                timer = StartCoroutine(Timer(_delay));
            }
            else
            {
                _isActive = false;
                StopCoroutine(timer);
            }
        }
    }
}
