using System.Globalization;
using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
	[SerializeField] private Counter _counter;
	
	private TextMeshProUGUI _counterText;

	private void Awake() =>
		_counterText = GetComponent<TextMeshProUGUI>();

	private void Update()
	{
		SetCounterValue();
	}

	private void SetCounterValue()
	{
		if (_counterText != null && _counter != null)
		{
			_counterText.text = _counter.Value.ToString(CultureInfo.CurrentCulture);
		}
		else
		{
			Debug.LogError("Counter or TextMeshProUGUI reference is missing.");
		}
	}
}