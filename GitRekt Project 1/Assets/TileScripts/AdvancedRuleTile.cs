using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

// Learned from "How To Make Custom Rule Tiles In Unity" by Vinark117: https://www.youtube.com/watch?v=FwOxLkJTXag

[CreateAssetMenu] // [CreateAssetMenu(menuName = "VinTools/Custom Tiles/Advanced Rule Tile")]  or any filepath you want
public class AdvancedRuleTile : RuleTile<AdvancedRuleTile.Neighbor> {
    public bool alwaysConnect; // bool variable
    public TileBase[] tilesToConnect;
    public bool checkSelf;

    public class Neighbor : RuleTile.TilingRule.Neighbor {
        // This is default 1
        // NotThis is default 2
        public const int Any = 3;
        public const int Specified = 4;
        public const int Nothing = 5;
    }

    public override bool RuleMatch(int neighbor, TileBase tile) {
        switch (neighbor) {
            case Neighbor.This: return Check_This(tile);
            case Neighbor.NotThis: return Check_NotThis(tile);
            case Neighbor.Any: return Check_Any(tile);
            case Neighbor.Specified: return Check_Specified(tile);
            case Neighbor.Nothing: return Check_Nothing(tile);
            
        }
        return base.RuleMatch(neighbor, tile);
    }
    
    // Bool methods to check each tile configuration
    bool Check_This(TileBase tile)
    {
        if (!alwaysConnect) return tile == this;
        else return tilesToConnect.Contains(tile) || tile == this; //.Contain requres: using System.Linq;
    }
    bool Check_NotThis(TileBase tile)
    {   return tile != this; }
    
    bool Check_Any(TileBase tile) // checks the current space for a tile, if there is any tile it will be true.
    {   if (checkSelf) return tile != null;
        else return tile != null && tile != this; 
    }
    bool Check_Specified(TileBase tile)
    {   return tilesToConnect.Contains(tile);}
    bool Check_Nothing(TileBase tile) // checks for an empty space
    {   return tile == null; }


}


