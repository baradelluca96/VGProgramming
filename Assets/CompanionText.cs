using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CompanionText : MonoBehaviour
{
	TMP_Text _tmpProText;
	string writer;

	[SerializeField] float delayBeforeStart = 0f;
	[SerializeField] float timeBtwChars = 0.1f;

	// Use this for initialization
	public void PrintText()
	{
		_tmpProText = GetComponent<TMP_Text>()!;


		if (_tmpProText != null)
		{
			writer = _tmpProText.text;
			_tmpProText.text = "";

			StartCoroutine("TypeWriterTMP");
		}
	}
	IEnumerator TypeWriterTMP()
    {
        _tmpProText.text = System.String.Empty;

        yield return new WaitForSeconds(delayBeforeStart);

		foreach (char c in writer)
		{
			if (_tmpProText.text.Length > 0)
			{
				_tmpProText.text = _tmpProText.text.Substring(0, _tmpProText.text.Length);
			}
			_tmpProText.text += c;
			yield return new WaitForSeconds(timeBtwChars);
		}
	}
}