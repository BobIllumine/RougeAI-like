using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Status {
    OK,
    STUNNED,
    ENSNARED,
    MUTE,
    DISARMED
}

public enum ActionStatus {
    IDLE,
    ATTACK,
    RUN,
    JUMP,
    HURT,
    FALL,
    DIE,
}

public enum ProjectileStatus {
    CAST,
    MOVE,
    HIT
}

public enum ErrCode
{
    INVALID_CAST,
    OK
}

public enum Button {
    JUMP,
    DEFAULT_ATTACK,
    SKILL_1,
    SKILL_2,
    SKILL_3,
    SKILL_4
}
