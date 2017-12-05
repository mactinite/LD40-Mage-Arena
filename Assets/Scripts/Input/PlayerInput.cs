using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CustomInput
{
    public class PlayerInput : MonoBehaviour, IManagedInput
    {

        public Command<bool> JumpDown;
        public Command<bool> Jump;
        public Command<bool> JumpUp;
        public Command<bool> CastUp;
        public Command<bool> CastDown;
        public Command<bool> Cast;
        public Command<bool> VentUp;
        public Command<bool> VentDown;
        public Command<bool> Sprint;
        public Command<float> MoveX;
        public Command<float> MoveY;
        public Command<float> AimX;
        public Command<float> AimY;

        public Command<bool> SpellSwitchForward;
        public Command<bool> SpellSwitchBack;

        public KeyCode[] JumpKeys;
        public KeyCode[] CastKeys;
        public KeyCode[] VentKeys;
        public KeyCode[] SprintKeys;
        public KeyCode[] SpellSwitchForwardKeys;
        public KeyCode[] SpellSwitchBackKeys;

        [SerializeField]
        [HideInInspector]
        private string moveXAxis;
        [SerializeField]
        [HideInInspector]
        private string moveYAxis;
        [SerializeField]
        [HideInInspector]
        private string aimXAxis;
        [SerializeField]
        [HideInInspector]
        private string aimYAxis;

        public const string JUMP_BUTTON = "JumpDown";
        public const string JUMP_BUTTON_DOWN = "JumpDown";
        public const string JUMP_BUTTON_UP = "JumpUp";
        public const string CAST_BUTTON = "Cast";
        public const string CAST_BUTTON_DOWN = "CastDown";
        public const string CAST_BUTTON_UP = "CastUp";
        public const string VENT_BUTTON_DOWN = "VentDown";
        public const string VENT_BUTTON_UP = "VentUp";
        public const string SPRINT_BUTTON = "Sprint";
        public const string MOVE_X = "MoveX";
        public const string MOVE_Y = "MoveY";
        public const string AIM_X = "AimX";
        public const string AIM_Y = "AimY";

        public const string SWITCH_SPELL_FORWARD = "SpellSwitchForward";
        public const string SWITCH_SPELL_BACK = "SpellSwitchBack";

        public string MoveXAxis
        {
            get
            {
                return moveXAxis;
            }

            set
            {
                moveXAxis = value;
            }
        }

        public string MoveYAxis
        {
            get
            {
                return moveYAxis;
            }

            set
            {
                moveYAxis = value;
            }
        }

        public string AimXAxis
        {
            get
            {
                return aimXAxis;
            }

            set
            {
                aimXAxis = value;
            }
        }

        public string AimYAxis
        {
            get
            {
                return aimYAxis;
            }

            set
            {
                aimYAxis = value;
            }
        }
        // this is super ugly omg
        public float GetAxisInput(string name)
        {

            switch (name)
            {
                case MOVE_X:
                    return MoveX.State;
                case MOVE_Y:
                    return MoveY.State;
                case AIM_X:
                    return AimX.State;
                case AIM_Y:
                    return AimY.State;
                default:
                    Debug.Log("Input type not implemented.");
                    return 0;

            }
        }
        // this is super ugly omg
        public bool GetButtonInput(string name)
        {
            switch (name)
            {
                case JUMP_BUTTON_DOWN:
                    return JumpDown.State;
                case JUMP_BUTTON_UP:
                    return JumpUp.State;
                case CAST_BUTTON_DOWN:
                    return CastDown.State;
                case CAST_BUTTON_UP:
                    return CastUp.State;
                case VENT_BUTTON_DOWN:
                    return VentDown.State;
                case VENT_BUTTON_UP:
                    return VentUp.State;
                case SPRINT_BUTTON:
                    return Sprint.State;
                case CAST_BUTTON:
                    return Cast.State;
                case SWITCH_SPELL_FORWARD:
                    return SpellSwitchForward.State;
                case SWITCH_SPELL_BACK:
                    return SpellSwitchBack.State;
                default:
                    Debug.LogError("Input " + name + " not implemented.");
                    return false;
            }
        }

        // Use this for initialization
        void Start()
        {
            JumpDown = new Command<bool>(JUMP_BUTTON_DOWN, () => { return GetAllKeysDown(JumpKeys); });
            Jump = new Command<bool>(JUMP_BUTTON, () => { return GetAllKeys(JumpKeys); });
            JumpUp = new Command<bool>(JUMP_BUTTON_UP, () => { return GetAllKeysUp(JumpKeys); });
            Cast = new Command<bool>(CAST_BUTTON, () => { return GetAllKeys(CastKeys); });
            CastUp = new Command<bool>(CAST_BUTTON_UP, () => { return GetAllKeysUp(CastKeys); });
            CastDown = new Command<bool>(CAST_BUTTON_DOWN, () => { return GetAllKeysDown(CastKeys); });
            VentUp = new Command<bool>(VENT_BUTTON_DOWN, () => { return GetAllKeysUp(VentKeys); });
            VentDown = new Command<bool>(VENT_BUTTON_DOWN, () => { return GetAllKeysDown(VentKeys); });
            MoveX = new Command<float>(MOVE_X, () => { return Input.GetAxisRaw(MoveXAxis); });
            MoveY = new Command<float>(MOVE_Y, () => { return Input.GetAxisRaw(MoveYAxis); });
            AimX = new Command<float>(AIM_X, () => { return Input.GetAxisRaw(AimXAxis); });
            AimY = new Command<float>(AIM_Y, () => { return Input.GetAxisRaw(AimYAxis); });
            Sprint = new Command<bool>(JUMP_BUTTON_DOWN, () => { return GetAllKeys(SprintKeys); });

            SpellSwitchForward = new Command<bool>(SWITCH_SPELL_FORWARD, () => { return GetAllKeys(SpellSwitchForwardKeys); });
            SpellSwitchBack = new Command<bool>(SWITCH_SPELL_BACK, () => { return GetAllKeys(SpellSwitchBackKeys); });

        }


        bool GetAllKeysDown(KeyCode[] keys)
        {
            foreach (KeyCode key in keys)
            {
                if (Input.GetKeyDown(key))
                {
                    return true;
                }
            }
            return false;
        }

        bool GetAllKeysUp(KeyCode[] keys)
        {
            foreach (KeyCode key in keys)
            {
                if (Input.GetKeyUp(key))
                {
                    return true;      
                }    
            }
            return false;
        }

        bool GetAllKeys(KeyCode[] keys)
        {

            foreach (KeyCode key in keys)
            {
                if (Input.GetKey(key))
                {
                    return true;
                }
            }
            return false;
        }
    }
}