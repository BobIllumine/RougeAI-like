using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public abstract class BaseState : MonoBehaviour
{
    private int _curHP, _maxHP; 
    public int HP { 
        get { return _curHP; } 
        protected set { _curHP = value > _maxHP ? _maxHP : value; } 
    }
    public int MaxHP {
        get { return _maxHP; }
        protected set { _maxHP = value; _curHP = _maxHP < _curHP ? _maxHP : _curHP; }
    }

    public float AD { get; private set; }
    [SerializeField] public float MS { get; private set; }
    public float AS { get; private set; }
    public float CR { get; private set; }
    public Status status { get; private set; }
    public ActionStatus actionStatus { get; private set; }

    protected virtual ErrCode UpdateState(params (string stat, object updateValue)[] kwargs) {
        foreach((string stat, object updateValue) in kwargs) {
            switch(stat) {
                case "MaxHP":
                    try {
                        this.MaxHP = (int)updateValue;
                    } catch(InvalidCastException) {
                        return ErrCode.INVALID_CAST;
                    }
                    break;
                case "HP":
                    try {
                        this.HP = (int)updateValue;
                    } catch(InvalidCastException) {
                        return ErrCode.INVALID_CAST;
                    }
                    break;
                case "AD":
                    try {
                        this.AD = (float)updateValue;
                    } catch(InvalidCastException) {
                        return ErrCode.INVALID_CAST;
                    }
                    break;
                case "AS":
                    try {
                        this.AS = (float)updateValue;
                    } catch(InvalidCastException) {
                        return ErrCode.INVALID_CAST;
                    }
                    break;
                case "MS":
                    try {
                        this.MS = (float)updateValue;
                    } catch(InvalidCastException) {
                        return ErrCode.INVALID_CAST;
                    }
                    break;
                case "CR":
                    try {
                        this.CR = (float)updateValue;
                    } catch(InvalidCastException) {
                        return ErrCode.INVALID_CAST;
                    }
                    break;
                case "status":
                    try {
                        this.status = (Status)updateValue;
                    } catch(InvalidCastException) {
                        return ErrCode.INVALID_CAST;
                    }
                    break;
                case "actionStatus":
                    try {
                        this.actionStatus = (ActionStatus)updateValue;
                    } catch(InvalidCastException) {
                        return ErrCode.INVALID_CAST;
                    }
                    break;
                default:
                    break;
            }
        }
        return ErrCode.OK;
    }

    public void DealDamage(int damage) {
        UpdateState(("HP", HP - damage), ("actionStatus", ActionStatus.HURT));
    }

    public void ChangeStatus(Status newStatus) {
        UpdateState(("status", newStatus));
    }

    public void ChangeActionStatus(ActionStatus newActionStatus) {
        UpdateState(("actionStatus", newActionStatus));
    }

    protected virtual void Start() {
        this.MaxHP = 100;
        this.HP = 100;
        this.AD = 10.0f;
        this.MS = 500.0f;
        this.AS = 1.0f;
        this.CR = 0.0f;
        this.status = Status.OK;
        this.actionStatus = ActionStatus.IDLE;
    }
}
