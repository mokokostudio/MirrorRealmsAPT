using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class WindowBattleBehaviour : MonoBehaviour
{
    [SerializeField]private InputActionAsset inputActionAsset;

    private InputAction m_MoveAction;
    private InputAction m_LookAction;
    private InputAction m_MouseLookAction;
    private InputAction m_DodgeAction;
    private InputAction m_FightAction;
    private InputAction m_MouseFightAction;
    private InputAction m_DefenseAction;
    private InputAction m_DiscardAction;
    private InputAction m_Skill1Action;
    private InputAction m_Skill2Action;
    private InputAction m_Skill3Action;

    public UnityAction MoveCallback;

    private void Awake()
    {
        foreach (var map in inputActionAsset.actionMaps)
            foreach (var action in map)
                action.Enable();
    }

    public InputAction GetInputAction(string actionName)
    {
        return inputActionAsset.FindAction(actionName);
    }
/*
    void InitActions()
    {
        m_MoveAction = inputActionAsset.FindActionMap("Player").FindAction("Move");
        m_MoveAction.started += MoveAction_started;
        m_MoveAction.performed += MoveAction_performed;
        m_MoveAction.canceled += MoveAction_canceled;

        m_LookAction = inputActionAsset.FindAction("Player/Look");
        m_LookAction.performed += LookAction_performed;

        m_MouseLookAction = inputActionAsset.FindAction("Player/MouseLook");
        m_MouseLookAction.performed += MouseLookAction_performed;

        m_DodgeAction = inputActionAsset.FindAction("Player/Dodge");
        m_DodgeAction.started += DodgeAction_started;
        m_DodgeAction.canceled += DodgeAction_canceled;

        m_FightAction = inputActionAsset.FindAction("Player/Fire");
        m_FightAction.started += FightAction_started;
        m_FightAction.canceled += FightAction_canceled;

        m_MouseFightAction = inputActionAsset.FindAction("Player/MouseFire");
        m_MouseFightAction.started += MouseFightAction_started;
        m_MouseFightAction.canceled += MouseFightAction_canceled;

        m_DefenseAction = inputActionAsset.FindAction("Player/Defense");
        m_DefenseAction.started += DefenseAction_started;

        m_DiscardAction = inputActionAsset.FindAction("Player/Discard");
        m_DiscardAction.started += m_DiscardAction_started;

        m_Skill1Action = inputActionAsset.FindAction("Player/Skill1");
        m_Skill1Action.started += OnSkill1;

        m_Skill2Action = inputActionAsset.FindAction("Player/Skill2");
        m_Skill2Action.started += OnSkill2;

        m_Skill3Action = inputActionAsset.FindAction("Player/Skill3");
        m_Skill3Action.started += OnSkill3;
    }

    public void PushInput<T>(T data) where T : class, IOperateData, new() => m_Battle.OperateDataProcesser.PushInput(data);

    private void DodgeAction_started(InputAction.CallbackContext obj)
    {
        PushInput(new OperateDodgeStart());
    }

    private void DodgeAction_canceled(InputAction.CallbackContext obj)
    {
        PushInput(new OperateDodgeEnd());
    }

    private void MoveAction_started(InputAction.CallbackContext obj)
    {
        PushInput(new OperateMoveStart());
        moveFGGo.SetActive(true);
    }

    private void MoveAction_performed(InputAction.CallbackContext obj)
    {
        PushInput(new OperateMoveUpdate { toward = GetLookRad() + GetMoveRad() });
        var f = m_MoveAction.ReadValue<Vector2>();
        var a = Mathf.Atan2(f.y, f.x);
        moveFGGo.transform.localEulerAngles = new Vector3(0, 0, a * Mathf.Rad2Deg - 90);
    }

    private void MoveAction_canceled(InputAction.CallbackContext obj)
    {
        PushInput(new OperateMoveStop());
        moveFGGo.SetActive(false);
    }

    private void LookAction_performed(InputAction.CallbackContext obj)
    {
        var f = obj.ReadValue<Vector2>();
        if (!m_MouseCameraMode && f.x != 0)
        {
            var ld = GetLookRad();
            PushInput(new OperateCameraMove { toward = ld });
            if (m_MoveAction.IsPressed())
            {
                var md = GetMoveRad();
                PushInput(new OperateMoveUpdate { toward = ld + md });
            }
        }
    }

    private void MouseLookAction_performed(InputAction.CallbackContext obj)
    {
        var f = obj.ReadValue<Vector2>();
        if (m_MouseCameraMode && f.x != 0)
        {
            var ld = GetLookRad();
            PushInput(new OperateCameraMove { toward = ld });
            if (m_MoveAction.IsPressed())
            {
                var md = GetMoveRad();
                PushInput(new OperateMoveUpdate { toward = ld + md });
            }
        }
    }

    private void FightAction_started(InputAction.CallbackContext obj)
    {
        if (!m_MouseCameraMode)
            PushInput(new OperateAttackStart());
    }

    private void FightAction_canceled(InputAction.CallbackContext obj)
    {
        if (!m_MouseCameraMode)
            PushInput(new OperateAttackEnd());
    }

    private void MouseFightAction_started(InputAction.CallbackContext obj)
    {
        if (m_MouseCameraMode)
            PushInput(new OperateAttackStart());
    }

    private void MouseFightAction_canceled(InputAction.CallbackContext obj)
    {
        if (m_MouseCameraMode)
            PushInput(new OperateAttackEnd());
    }

    private void DefenseAction_started(InputAction.CallbackContext obj)
    {
        if (defBtnGo.activeInHierarchy)
            PushInput(new OperateDefense());
    }

    private void m_DiscardAction_started(InputAction.CallbackContext obj)
    {
        PushInput(new OperateDiscardWeapon());
    }

    private void OnSkill1(InputAction.CallbackContext obj)
    {
        PushInput(new OperateSelectCard { index = 0 });
    }

    private void OnSkill2(InputAction.CallbackContext obj)
    {
        PushInput(new OperateSelectCard { index = 1 });
    }

    private void OnSkill3(InputAction.CallbackContext obj)
    {
        PushInput(new OperateSelectCard { index = 2 });
    }
*/
}

// EOF