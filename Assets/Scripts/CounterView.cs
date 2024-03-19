using System;
using System.Globalization;
using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
	[SerializeField] private Counter _counter;
	
	private TextMeshProUGUI _counterText;

	private void OnEnable() =>
		_counter.ValueChanged += UpdateCounterText;

	private void OnDisable() =>
		_counter.ValueChanged -= UpdateCounterText;

	private void Awake() =>
		_counterText = GetComponent<TextMeshProUGUI>();

	private void Start() =>
		UpdateCounterText();

	private void UpdateCounterText() =>
		_counterText.text = _counter.Value.ToString(CultureInfo.CurrentCulture);
}