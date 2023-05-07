using UnityEngine;
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
        public static Texture2D SURSImageCall(string filename)
        {
            //Used in SURS (Signalis Universal ReSkin Mod)
            byte[] imageData = System.IO.File.ReadAllBytes(filename);
            Texture2D SURStexture = new Texture2D(2, 2);
            ImageConversion.LoadImage(SURStexture, imageData);
            return SURStexture;
        }

        public static GameObject SUMAModelCall(string mainFileBranch, string modelName)
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
        public static MeshRenderer SUMAModelCall (GameObject model)
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
           
}
}