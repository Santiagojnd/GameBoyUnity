using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float floatAmplitude = 0.05f;
    public float floatspeed = 1.2f;
    public float tiltAmplitude = 2f;
    public float tiltSpeed = .8f;

    private Vector3 _startPos;
    private float _offset;
    void Start()
    {
        _startPos = transform.localPosition;
        _offset = Random.Range(0f, 2f * Mathf.PI);
    }

    // Update is called once per frame
    void Update()
    {
        float t= Time.time + _offset;
        transform.localPosition = _startPos + Vector3.up * Mathf.Sin(t * floatspeed) * floatAmplitude;

        float tiltX = Mathf.Sin(t * tiltSpeed * 0.7f) * tiltAmplitude;
        float tiltZ = Mathf.Cos(t * tiltSpeed) * tiltAmplitude * 0.5f;
        transform.localRotation = Quaternion.Euler(tiltX, 0f, tiltZ);
    }
}