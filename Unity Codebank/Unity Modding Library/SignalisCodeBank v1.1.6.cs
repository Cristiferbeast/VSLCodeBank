using MelonLoader;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;


namespace VSLSignalisCodeBank
{
    public class SignalisCodeBank
    {
        public static Material TextureFind(GameObject desiredObject)
        {
            //Used in mods that swap textures without use of SURS
            SkinnedMeshRenderer renderer = desiredObject.GetComponent<SkinnedMeshRenderer>();
            if (renderer != null)
            {
                MelonLoader.MelonLogger.Msg("Texture Loaded");
                Material material = renderer.material;
                return material;
            }
            else
            {
                return null;
            }
        }
        public bool SURSTextureSet(bool state, string path, GameObject parent)
        {
            if (!state)
            {
                return false;
            }
            Texture2D evaTexture = SignalisCodeBank.SURSImageCall(path);
            SkinnedMeshRenderer renderer = parent.GetComponent<SkinnedMeshRenderer>();
            renderer.material.mainTexture = evaTexture;
            return true;
        }
        public static Texture2D SURSImageCall(string filename)
        {
            //Used in SURS (Signalis Universal ReSkin Mod)
            byte[] imageData = System.IO.File.ReadAllBytes(filename);
            Texture2D SURStexture = new Texture2D(2, 2);
            ImageConversion.LoadImage(SURStexture, imageData);
            return SURStexture;
        }
                public static void CustomCamera(GameObject MainCamera, GameObject CharRoot, Vector3 coords, Quaternion position, bool initialize = false)
        {
            CameraToggle(MainCamera, CharRoot, initialize);
            MainCamera.transform.localPosition = coords;
            MainCamera.transform.localRotation = position;
        }
        public static void CameraToggle(GameObject MainCamera, GameObject CharRoot, bool initialize = false)
        {
            MainCamera.transform.parent = CharRoot.transform;
            MelonLoader.MelonLogger.Msg("Modded Camera State Enabled");
            MainCamera.GetComponent<AngledCamControl>().enabled = initialize;
            UnityEngine.Camera cameraComponent = MainCamera.GetComponent<UnityEngine.Camera>();
            cameraComponent.orthographic = initialize;
            GameObject VHS = MainCamera.transform.Find("VHS UI").gameObject;
            UnityEngine.Camera VHSComponent = VHS.GetComponent<UnityEngine.Camera>();
            VHSComponent.orthographic = initialize;
        }

        public static void CameraControl(GameObject MainCamera, bool vChange, bool dChange, float degreeChange = 0.01f)
        {
            Quaternion customRotate = MainCamera.transform.localRotation;
            if ((vChange == dChange) && dChange)
            {
                customRotate.x += degreeChange;
                MainCamera.transform.localRotation = customRotate;
            }
            if ((vChange == dChange) && !dChange)
            {
                customRotate.y -= degreeChange;
                MainCamera.transform.localRotation=customRotate;
            }
            if ((vChange != dChange) && dChange)
            {
                customRotate.x -= degreeChange;
                MainCamera.transform.localRotation = customRotate;
            }
            if ((vChange != dChange) && !dChange)
            {
                customRotate.y += degreeChange;
                MainCamera.transform.localRotation = customRotate;
            }

        }
        public static void CameraRestore(GameObject CharRoot, GameObject LocalSpace)
        {
            GameObject NewCamera = CharRoot.transform.Find("Main Camera").gameObject;
            Vector3 coords = new Vector3(-1073, 0.8987f, -172.2069f);
            Quaternion position = Quaternion.Euler(0, 0, 0);
            SignalisCodeBank.CustomCamera(NewCamera, LocalSpace, coords, position, true);
            MelonLoader.MelonLogger.Msg("Default Camera Restored");
        }
        public static bool GOErrorCatch(string ObjectName, GameObject parent, bool logger = true)
        {
            try
            {
                GameObject AngCamRig = parent.transform.Find(ObjectName).gameObject;
                return true;
            }
            catch
            {
                if (logger)
                {
                    MelonLoader.MelonLogger.Msg("Error", ObjectName, "Not Found");
                }
                return false;
            }
        }
    }
    public class SUMA
    {
        public static GameObject ModelCall(string mainFileBranch, string modelName)
        {
            string customreplika = Path.Combine(mainFileBranch, modelName);
            if (!File.Exists(customreplika))
            {
                MelonLoader.MelonLogger.Msg(modelName, " Model Not Found ");
                return null;
            }
            GameObject model = Resources.Load<GameObject>(modelName);
            if (model == null)
            {
                MelonLoader.MelonLogger.Msg(modelName, " Model Could Not Load ");
                return null;
            }
            return model;
        }
        public static MeshRenderer ModelCall(GameObject model)
        {
            MeshRenderer renderer = new MeshRenderer();
            renderer = model.GetComponent<MeshRenderer>();
            if (renderer == null)
            {
                MelonLoader.MelonLogger.Msg("Render Not Found, Check that File is Proper");
                return null;
            }
            return renderer;
        }
        public static void Outfit (GameObject parent, GameObject model, float scaleFactor)
        {
            //Needs Model to be Insatiated Before Use, Insatatation can be done by SUMA.Spawn or normal Insatiation
            if (parent == null) { MelonLoader.MelonLogger.Msg("Parent Not Found, Check that File is Proper");}
            if (model == null) { MelonLoader.MelonLogger.Msg("Model Not Found, Check that File is Proper"); }
            //Offset Coords are Experimental
            Vector3 offset = new Vector3(1f, 2f, 3f);
            model.transform.position = parent.transform.position + offset;
            model.transform.rotation = parent.transform.rotation;
            model.transform.localScale *= scaleFactor;
            model.transform.parent = parent.transform;
        }
        public static void Spawn (GameObject model, GameObject parent, Vector3 localposition, Quaternion rotation)
        {
            GameObject spawned = GameObject.Instantiate(model);
            spawned.transform.parent = parent.transform;
            model.transform.position = parent.transform.position + localposition;
            model.transform.rotation = rotation;
        }
    }
}