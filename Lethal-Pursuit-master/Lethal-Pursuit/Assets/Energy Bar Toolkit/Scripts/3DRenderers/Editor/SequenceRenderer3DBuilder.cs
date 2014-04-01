/*
* Energy Bar Toolkit by Mad Pixel Machine
* http://www.madpixelmachine.com
*/

using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

namespace EnergyBarToolkit {

public class SequenceRenderer3DBuilder {

    // ===========================================================
    // Static Methods
    // ===========================================================
    
    public static SequenceRenderer3D Create() {
        var panel = MadPanel.UniqueOrNull();
        
        if (panel == null) {
            if (EditorUtility.DisplayDialog(
                "Init Scene?",
                "Scene not initialized for 3D bars. You cannot place new bar without proper initialization. Do it now?",
                "Yes", "No")) {
                MadInitTool.ShowWindow();
                return null;
            }
            
            panel = MadPanel.UniqueOrNull();
        }
    
        var bar = MadTransform.CreateChild<SequenceRenderer3D>(panel.transform, "sequence progress bar");
        TryApplyExampleTextures(bar);
        Selection.activeObject = bar.gameObject;
        
        return bar;
    }
    
    static void TryApplyExampleTextures(SequenceRenderer3D bar) {
        var gridTexture = AssetDatabase.LoadAssetAtPath(
            "Assets/Energy Bar Toolkit/Example/Textures/SequenceBar/Grid/sequenceBarTexture.png", typeof(Texture2D)) as Texture2D;
        
        if (gridTexture != null) {
            bar.gridTexture = gridTexture;
            bar.gridWidth = 7;
            bar.gridHeight = 9;
            bar.gridFrameCountManual = true;
            bar.gridFrameCount = 59;
        } else {
            Debug.LogWarning("Failed to locate example textures. This is not something bad, but have you changed "
                             + "your Energy Bar Toolkit directory location?");
        }
    }
    
    // ===========================================================
    // Inner and Anonymous Classes
    // ===========================================================

}

} // namespace