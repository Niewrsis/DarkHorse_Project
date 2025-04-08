//using UnityEngine;
//using UnityEngine.UI;
//using System.Collections;

//namespace CharacterSystem
//{
//    public class CharacterSwitcher : MonoBehaviour
//    {
//        [SerializeField] private Image image;
//        [SerializeField] private Sprite[] clientSprites;
//        [SerializeField] private Sprite finalSprite;
//        private float globalTimer = 10f;

//        private void Start()
//        {
//            image.sprite = null;
//            StartCoroutine(GlobalTimerCoroutine());
//        }

//        public void SwitchToRandomClientSprite()
//        {
//            if (clientSprites.Length > 0)
//            {
//                int randomIndex = Random.Range(0, clientSprites.Length);
//                image.sprite = clientSprites[randomIndex];
//            }
//        }

//        private IEnumerator GlobalTimerCoroutine()
//        {
//            yield return new WaitForSeconds(globalTimer);
//            SetFinalCharacter();
//        }

//        private void SetFinalCharacter()
//        {
//            image.sprite = finalSprite;
//        }

//        private void Update()
//        {
//            if (Input.GetKeyDown(KeyCode.Space))
//            {
//                SwitchToRandomClientSprite();
//            }
//        }
//    }
//}
