using UnityEngine;
using System;
using System.Collections;

public class Counter : MonoBehaviour
{
	private const float Delay = 0.5f;
	
	private Coroutine _countCoroutine;
	private WaitForSeconds _waitForSeconds;
	private bool _isWorking;
	private float _counterValue;

	public event Action ValueChanged;

	public float Value 
	{ 
		get => _counterValue;

		private set 
		{
			_counterValue = value;
			ValueChanged?.Invoke();
		}
	}

	private void Awake()
	{
		_waitForSeconds = new WaitForSeconds(Delay);
		_isWorking = false;
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
			ToggleCounting();
	}

	private void ToggleCounting()
	{
		if (_countCoroutine != null)
		{
			StopCoroutine(_countCoroutine);
			_countCoroutine = null;
			_isWorking = false;
		}
		else
		{
			_countCoroutine = StartCoroutine(CountCoroutine());
			_isWorking = true;
		}
	}

	private IEnumerator CountCoroutine()
	{
		while (_isWorking)
		{
			Value++;
            
			yield return _waitForSeconds;
		}
	}
}