using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public abstract class CharacterState : MonoBehaviour
{
    public enum Status {
        OK,
        STUNNED,
        ENSNARED,
        MUTE,
        DISARMED
    }
    public class MaxState {
        private int _curHP, _maxHP;
        public int HP { 
            get { return _curHP; } 
            private set { _curHP = value > _maxHP ? _maxHP : value; } 
        }
        public int MaxHP {
            get { return _maxHP; }
            private set { _maxHP = value; }
        }
        public int AD { get; private set; }
        public int AS { get; private set; }
        public int MS { get; private set; }
        public float CR { get; private set; }
        public Status status { get; private set; }
        public MaxState(int HP = 100, int AD = 10, int AS = 1, int MS = 10, float CR = 0.0f, Status status = Status.OK) {
            this.HP = HP;
            this.AD = AD;
            this.AS = AS;
            this.MS = MS;
            this.CR = CR;
            this.status = Status.OK;
        }

        public ErrCode UpdateState(params (string stat, int updateValue)[] kwargs) {
            foreach((string stat, int updateValue) in kwargs) {
                switch(stat) {
                    case "HP":
                        try {
                            this.HP = updateValue;
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
    }

    protected virtual void Start()
    {
        
    }
}
