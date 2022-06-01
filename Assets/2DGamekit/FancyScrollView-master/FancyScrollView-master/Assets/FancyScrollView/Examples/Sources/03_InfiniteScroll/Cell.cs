/*
 * FancyScrollView (https://github.com/setchi/FancyScrollView)
 * Copyright (c) 2020 setchi
 * Licensed under MIT (https://github.com/setchi/FancyScrollView/blob/master/LICENSE)
 */

using UnityEngine;
using UnityEngine.UI;

namespace hgcxt.Example03
{
    class Cell : FancyCell<ItemData, Context>
    {
        [SerializeField] Animator animator = default;
        [SerializeField] Text name = default;
        [SerializeField] Image head = default;
        //[SerializeField] Text messageLarge = default;
        [SerializeField] Image image = default;
 //       [SerializeField] Image imageLarge = default;
        [SerializeField] Button button = default;
        private GameObject prefab_ClueItem;
        Transform CluesFather ;
        Transform[] items;
        bool flag;
        static class AnimatorHash
        {
            public static readonly int Scroll = Animator.StringToHash("scroll");

        }

        void Start()
        {
           
            flag = false;
            prefab_ClueItem = Resources.Load<GameObject>("Clues_Item");
            print("1" + prefab_ClueItem.name);
            button.onClick.AddListener(() => Context.OnCellClicked?.Invoke(Index));
            Transform CluesFather = transform.parent.parent.parent.Find("Clues");
            var selected = Context.SelectedIndex == Index;            
            if (selected)
            {
                ClueConf clueConf = Resources.Load<ClueConf>("Conf/" + name.text + "线索");

                for (int i = 0; i < clueConf.IsClueGet.Count; i++)
                {
                    print("2" + prefab_ClueItem.name);
                    if (clueConf.IsClueGet[i])
                    {
                        print(prefab_ClueItem.name);
                        print(CluesFather.name);
                        var item = Instantiate<GameObject>(prefab_ClueItem, CluesFather).GetComponent<UI_Clues_Item>();
                        //var item = NPCManager.Instantiate<GameObject>(prefab_OptionItem, Options).GetComponent<UI_Options_Item>();

                        item.Init(clueConf.Clues[i]);
                    }
                }
            }
        }

        private void Update()
        {
            Transform CluesFather = transform.parent.parent.parent.Find("Clues");
            Transform[] items = CluesFather.GetComponentsInChildren<Transform>();
            if (Context.SelectedIndex == Index && !flag)
            {
         
                for (int i = 1; i < items.Length; i++)
                {
                    Destroy(items[i].gameObject);
                    print("删除一个");
                }
                flag = true;
            }
            else if(Context.SelectedIndex == Index)
            {
                flag = false;
            }
        }
        public override void UpdateContent(ItemData itemData)
        {
            name.text = itemData.Name;
            head.sprite = itemData.Head;
           // messageLarge.text = Index.ToString();

            var selected = Context.SelectedIndex == Index;
            image.color = selected
                ? new Color32(255, 255, 255, 255)
                : new Color32(255, 255, 255, 77);
      
        }

        public override void UpdatePosition(float position)
        {
            currentPosition = position;

            if (animator.isActiveAndEnabled)
            {
                animator.Play(AnimatorHash.Scroll, -1, position);
            }

            animator.speed = 0;
        }

        // GameObject が非アクティブになると Animator がリセットされてしまうため
        // 現在位置を保持しておいて OnEnable のタイミングで現在位置を再設定します
        float currentPosition = 0;

        void OnEnable() => UpdatePosition(currentPosition);
    }
}
