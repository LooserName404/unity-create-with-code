using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CongratScript : MonoBehaviour
{
    public TextMesh Text;
    public ParticleSystem SparksParticles;
    
    private List<string> _textToDisplay = new List<string>();
    
    private float _rotatingSpeed;
    private float _timeToNextText;

    private int _currentText;
    
    // Start is called before the first frame update
    void Start()
    {
        _timeToNextText = 0.0f;
        _currentText = 0;
        
        _rotatingSpeed = 1.0f;

        _textToDisplay.Add("Congratulation");
        _textToDisplay.Add("All Errors Fixed");

        Text.text = _textToDisplay[0];
        
        SparksParticles.Play();
    }

    // Update is called once per frame
    void Update()
    {
        _timeToNextText += Time.deltaTime;

        if (_timeToNextText > 1.5f)
        {
            _timeToNextText = 0.0f;
            
            _currentText++;
            if (_currentText >= _textToDisplay.Count)
            {
                _currentText = 0;

            }

            Text.text = _textToDisplay[_currentText];
        }
        Text.gameObject.transform.Rotate(Vector3.up * _rotatingSpeed);
    }
}