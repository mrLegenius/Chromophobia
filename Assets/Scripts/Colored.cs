﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colored : MonoBehaviour
{
    public SpriteRenderer sprite;

    private Vector3 _originalPosition;
    private Vector3 _targetPosition = Vector3.zero;

    private bool _reverseDirection;
    private float _speed;

    public OnColoredClick OnColoredClick;

    public void StartMoving(Vector3 targetPosition, float speed)
    {
        _originalPosition = transform.position;
        _targetPosition = targetPosition;
        _speed = speed;
    }

    public bool IsMoving()
    {
        return _targetPosition != Vector3.zero;
    }

    void Update()
    {
        MoveBetweenTwoPoints();
    }

    void MoveBetweenTwoPoints()
    {
        if(_targetPosition == Vector3.zero) return;

        var target = _reverseDirection ? _originalPosition : _targetPosition;

        transform.position = Vector3.MoveTowards(transform.position, target, _speed * Time.deltaTime);

        if ((target - transform.position).sqrMagnitude <= 0.1f)
            _reverseDirection = !_reverseDirection;
    }

    void OnMouseDown()
    {
        _targetPosition = Vector3.zero;
        gameObject.SetActive(false);

        OnColoredClick(sprite.color);
    }
}
