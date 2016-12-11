using UnityEngine;
using System.Collections;

namespace WizardsTournament
{
    public enum InputCommand { TriggerPressed, TriggerReleased, TouchpadPressed, TouchpadReleased, GripPressed, GripReleased, LeftTriggerPressed, LeftTriggerReleased, RightTriggerPressed, RightTriggerReleased, LeftTouchpadPressed, LeftTouchpadReleased, RightTouchpadPressed, RightTouchpadReleased, LeftGripPressed, LeftGripReleased, RightGripPressed, RightGripReleased }

    public enum Hand { Left, Right}

    public enum SpellName { Skull, SoulSteeler, HologramTeleporter, DeathSummon   }

    public enum TypeOfAttack { BasicAttack, ContinuousAttack, SummonAttack, SpecialAvility, UnBreakable}

    public enum CharacterName { Honovi, Vulcan, Angel}
}
