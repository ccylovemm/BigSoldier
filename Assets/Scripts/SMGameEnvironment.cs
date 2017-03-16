//
// Copyright (c) 2013 Ancient Light Studios
// All Rights Reserved
// 
// http://www.ancientlightstudios.com
//

using UnityEngine;
using System.Collections;

public class SMGameEnvironment {
    private static SMGameEnvironment instance; 
    private SMSceneManager sceneManager; 
    public static SMGameEnvironment Instance { 
        get { 
            if (instance == null) { 
                instance = new SMGameEnvironment(); 
            } 
            return instance; 
        } 
    } 
    
   public SMSceneManager SceneManager { 
       get { 
           return sceneManager; 
       } 
   } 
 
   public SMGameEnvironment() { 
       sceneManager = new SMSceneManager(SMSceneConfigurationLoader.LoadActiveConfiguration("LevelConfig"));     
       sceneManager.LevelProgress = new SMLevelProgress(sceneManager.ConfigurationName); 
   }
}
