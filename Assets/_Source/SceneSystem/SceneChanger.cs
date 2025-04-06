using UnityEngine.SceneManagement;

namespace SceneSystem
{
    public static class SceneChanger
    { 
        public static void ChangeScene(int index)
        {
            SceneManager.LoadScene(index);
        }
    }
}