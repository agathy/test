using UnityEngine;

namespace hgcxt
{
    public class PlayerInput : InputComponent, IDataPersister
    {
        public static PlayerInput Instance
        {
            get { return s_Instance; }
        }

        protected static PlayerInput s_Instance;
    
    
        public bool HaveControl { get { return m_HaveControl; } }
        //UI
        public InputButton Option = new InputButton(KeyCode.Escape, XboxControllerButtons.Menu);//系统设置
        public InputButton Pause = new InputButton(KeyCode.Space, XboxControllerButtons.A);//暂停
        public InputButton ClueMap = new InputButton(KeyCode.J, XboxControllerButtons.View);//线索图
        public InputButton Inventory = new InputButton(KeyCode.B, XboxControllerButtons.Rightstick);//背包

        //交互
        public InputButton Interact = new InputButton(KeyCode.F, XboxControllerButtons.Y);
        public InputButton Skill = new InputButton(KeyCode.M, XboxControllerButtons.LeftBumper);
        public InputButton MeleeAttack = new InputButton(KeyCode.K, XboxControllerButtons.X);
        public InputButton RangedAttack = new InputButton(KeyCode.O, XboxControllerButtons.B);
       
        //移动
        public InputAxis Horizontal = new InputAxis(KeyCode.D, KeyCode.A, XboxControllerAxes.LeftstickHorizontal);
        public InputAxis Vertical = new InputAxis(KeyCode.W, KeyCode.S, XboxControllerAxes.LeftstickVertical);
        public InputButton Accelerate = new InputButton(KeyCode.LeftShift, XboxControllerButtons.RightBumper);
        
        [HideInInspector]
        public DataSettings dataSettings;

        protected bool m_HaveControl = true;

        protected bool m_DebugMenuIsOpen = false;

        void Awake ()
        {
            if (s_Instance == null)
                s_Instance = this;
            else
                throw new UnityException("There cannot be more than one PlayerInput script.  The instances are " + s_Instance.name + " and " + name + ".");
        }

        void OnEnable()
        {
            if (s_Instance == null)
                s_Instance = this;
            else if(s_Instance != this)
                throw new UnityException("There cannot be more than one PlayerInput script.  The instances are " + s_Instance.name + " and " + name + ".");
        
            PersistentDataManager.RegisterPersister(this);
        }

        void OnDisable()
        {
            PersistentDataManager.UnregisterPersister(this);

            s_Instance = null;
        }

        protected override void GetInputs(bool fixedUpdateHappened)
        {
            Pause.Get(fixedUpdateHappened, inputType);
            Option.Get(fixedUpdateHappened, inputType);
            ClueMap.Get(true, inputType);
            Inventory.Get(true, inputType);

            //Interact.Get(fixedUpdateHappened, inputType);
            Interact.Get(true, inputType);
            Skill.Get(true, inputType);
            MeleeAttack.Get(fixedUpdateHappened, inputType);
            //MeleeAttack.Get(fixedUpdateHappened, inputType);
            RangedAttack.Get(fixedUpdateHappened, inputType);
           
            Horizontal.Get(inputType);
            Vertical.Get(inputType);
            Accelerate.Get(fixedUpdateHappened, inputType);

            if (Input.GetKeyDown(KeyCode.F12))
            {
                m_DebugMenuIsOpen = !m_DebugMenuIsOpen;
            }
        }

        public override void GainControl()
        {
            m_HaveControl = true;

            GainControl(Pause);
            GainControl(Option);
            GainControl(ClueMap);
            GainControl(Inventory);

            GainControl(Interact);
            GainControl(Skill);
            GainControl(MeleeAttack);
            GainControl(RangedAttack);
            
            GainControl(Horizontal);
            GainControl(Vertical);
            GainControl(Accelerate);
        }

        public override void ReleaseControl(bool resetValues = true)
        {
            m_HaveControl = false;

            ReleaseControl(Pause, resetValues);
            ReleaseControl(Option, resetValues);
            ReleaseControl(ClueMap, resetValues);
            ReleaseControl(Inventory, resetValues);

            ReleaseControl(Interact, resetValues);
            ReleaseControl(Skill, resetValues);
            ReleaseControl(MeleeAttack, resetValues);
            ReleaseControl(RangedAttack, resetValues);
            
            ReleaseControl(Horizontal, resetValues);
            ReleaseControl(Vertical, resetValues);
            ReleaseControl(Accelerate, resetValues);
        }

        public void DisableMeleeAttacking()
        {
            MeleeAttack.Disable();
        }

        public void EnableMeleeAttacking()
        {
            MeleeAttack.Enable();
        }

        public void DisableRangedAttacking()
        {
            RangedAttack.Disable();
        }

        public void EnableRangedAttacking()
        {
            RangedAttack.Enable();
        }

        public DataSettings GetDataSettings()
        {
            return dataSettings;
        }

        public void SetDataSettings(string dataTag, DataSettings.PersistenceType persistenceType)
        {
            dataSettings.dataTag = dataTag;
            dataSettings.persistenceType = persistenceType;
        }

       public Data SaveData()
        {
            //return new Data<bool, bool>(MeleeAttack.Enabled, RangedAttack.Enabled);
            return new Data<bool, bool>(false, false);
        }

           public void LoadData(Data data)
           {
               Data<bool, bool> playerInputData = (Data<bool, bool>)data;

               if (playerInputData.value0)
                   MeleeAttack.Enable();
               else
                   MeleeAttack.Disable();

               if (playerInputData.value1)
                   RangedAttack.Enable();
               else
                   RangedAttack.Disable();
           }

        void OnGUI()
        {
            if (m_DebugMenuIsOpen)
            {
                const float height = 100;

                GUILayout.BeginArea(new Rect(30, Screen.height - height, 200, height));

                GUILayout.BeginVertical("box");
                GUILayout.Label("Press F12 to close");

                bool meleeAttackEnabled = GUILayout.Toggle(MeleeAttack.Enabled, "Enable Melee Attack");
                bool rangeAttackEnabled = GUILayout.Toggle(RangedAttack.Enabled, "Enable Range Attack");

                if (meleeAttackEnabled != MeleeAttack.Enabled)
                {
                    if (meleeAttackEnabled)
                        MeleeAttack.Enable();
                    else
                        MeleeAttack.Disable();
                }

                if (rangeAttackEnabled != RangedAttack.Enabled)
                {
                    if (rangeAttackEnabled)
                        RangedAttack.Enable();
                    else
                        RangedAttack.Disable();
                }
                GUILayout.EndVertical();
                GUILayout.EndArea();
            }
        }
    }
}
