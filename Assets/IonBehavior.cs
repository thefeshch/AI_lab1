using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IonBehavior : MonoBehaviour
{
    [SerializeField] private float range = 5f;
    [SerializeField] private float minSpeed = 1f;
    [SerializeField] private float maxSpeed = 6f;
    private float currentSpeed;
    private TMP_Text speedLabel;
    [SerializeField] private Transform player;
    private Rigidbody2D _rigidbody;
    private Vector2 direction;
    public float CurrentSpeed
    {
        get
        {
            return currentSpeed;
        }
        private set
        {
            currentSpeed = value;
            speedLabel.text = $"Speed: {value:F}";
        }
    }
    void Start()
    {
        speedLabel = GetComponentInChildren<TMP_Text>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float distance = Vector2.Distance(player.position, transform.position);
        if (distance > range) { return; }
        CurrentSpeed = EvaluateSpeed(distance);
        direction = (transform.position - player.position).normalized;
    }
    private void FixedUpdate()
    {
        _rigidbody.velocity = direction * CurrentSpeed;
    }
    private float EvaluateSpeed(float distance)
    {
        return Mathf.Lerp(minSpeed, maxSpeed, 1f - distance / range);

    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + direction);
    }
}
