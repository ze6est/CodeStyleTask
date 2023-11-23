using System.Collections;
using UnityEngine;

public class SizeIncreasing : MonoBehaviour
{
    [SerializeField] private float _increasingSizeSpeed;
    [SerializeField] private bool _isGameOn;

    private Coroutine _increasingJob;

    private void Start()
    {
        _isGameOn = true;
        _increasingJob = StartCoroutine(IncreaseSize());
    }

    private void OnDestroy() => 
        StopCoroutine(_increasingJob);

    private IEnumerator IncreaseSize()
    {
        float _scaleSpeedOnFrame = _increasingSizeSpeed * Time.deltaTime;

        while (_isGameOn)
        {            
            transform.localScale += new Vector3(_scaleSpeedOnFrame, _scaleSpeedOnFrame, _scaleSpeedOnFrame);
            yield return null;
        }
    }
}