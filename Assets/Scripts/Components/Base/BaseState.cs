using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Reflection;

public abstract class BaseState : MonoBehaviour
{
    private int _curHP, _maxHP; 
    public int HP 
    { 
        get { return _curHP; } 
        protected set { _curHP = value > _maxHP ? _maxHP : value; } 
    }
    public int MaxHP 
    {
        get { return _maxHP; }
        protected set { _maxHP = value; _curHP = _maxHP < _curHP ? _maxHP : _curHP; }
    }

    public int AD { get; protected set; }
    public float MS { get; protected set; }
    public float AS { get; protected set; }
    public float CR { get; protected set; }
    public Status status { get; protected set; }
    public abstract void ApplyChanges(Dictionary<PropertyInfo, object> other);
    public abstract void ApplyTimedChanges(Dictionary<PropertyInfo, object> other, float duration);
    public virtual IEnumerator TimedRevert(Dictionary<PropertyInfo, object> copy, float duration) {
        yield return new WaitForSeconds(duration);
        ApplyChanges(copy);
    }
}
