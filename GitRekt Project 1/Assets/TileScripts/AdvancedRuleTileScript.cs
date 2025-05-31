using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Tilemaps;

// Learned from "How To Make Custom Rule Tiles In Unity" by Vinark117: https://www.youtube.com/watch?v=FwOxLkJTXag
namespace UnityEditor
{
    [CustomEditor(typeof(AdvancedRuleTile))]
    [CanEditMultipleObjects]
    public class AdvancedRuleTileScript : RuleTileEditor
    {
        // create your 2D texture references, one for every custom rule.
        // These rules are cases 3, 4, and 5 in the AdvancedRuleTile script 
        public Texture2D any;
        public Texture2D specified;
        public Texture2D empty;

        // overriding the parent class GUI from RuleTileEditor to update the image of the AdvancedRuleTile script.
        // this means images of arrows will be drawn in the place of numbers so we know what the AdvancedRuleTile scipt is doing.
        public override void RuleOnGUI(Rect rect, Vector3Int position, int neighbor)
        {
            switch (neighbor)
            {
                case 3:
                    GUI.DrawTexture(rect, any);
                    return;
                case 4:
                    GUI.DrawTexture(rect, specified);
                    return;
                case 5:
                    GUI.DrawTexture(rect, empty);
                    return;
            }
            base.RuleOnGUI(rect, position, neighbor);
        }
    }
}
