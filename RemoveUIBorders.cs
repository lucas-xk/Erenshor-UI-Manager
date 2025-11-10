using UnityEngine;
using UnityEngine.UI;

namespace remove_ui_borders
{    
    public class RemoveUIBorders
    {
        
        public void DisableBorders(bool option)
        {
            var borderObj = GameObject.Find("UI/UIElements/Canvas/HotbarPar/Image (1)");
            if (borderObj != null)
            {
                borderObj.SetActive(option);
            }

            borderObj = GameObject.Find("UI/UIElements/NewGroupPar/Image (4)");
            if (borderObj != null)
            {
                borderObj.SetActive(option);
            }

            borderObj = GameObject.Find("UI/UIElements/PlayerLifePar/Image (3)");
            if (borderObj != null)
            {
                borderObj.SetActive(option);
            }

            borderObj = GameObject.Find("UI/UIElements/CharmedPar/CharmedNPC");
            if (borderObj != null)
            {
                var borderComp = borderObj.GetComponent<Image>();
                if (borderComp != null)
                    borderComp.enabled = option;
            }

            borderObj = GameObject.Find("UI/UIElements/TargCanv/NewTargetWindow/Image (1)");
            if (borderObj != null)
            {
                borderObj.SetActive(option);
            }

            borderObj = GameObject.Find("UI/UIElements/TargCanv/NewTargetWindow/LifeNumBG (1)");
            if (borderObj != null)
            {
                borderObj.SetActive(option);
            }

            borderObj = GameObject.Find("UI/UIElements/TargCanv/NewTargetWindow/Image");
            if (borderObj != null)
            {
                borderObj.SetActive(option);
            }
        }
    }
}