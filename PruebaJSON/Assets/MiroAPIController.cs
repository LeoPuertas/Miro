using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System.Linq;
using System;
using UnityEngine.UI;
using TMPro;

namespace Miro.Apis
{
    public class MiroAPIController : MonoBehaviour
    {
        public GameObject cube;
        public TextMeshPro text;

        private readonly string url = "https://api.miro.com/v1/boards";
        private readonly string token = "Bearer sP3JbsbAFxTUT4x2JzSkQ1wMqJY";
        private readonly string idBoard = "o9J_lbre-C8=";
        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(GetBoardInfo(idBoard));
            StartCoroutine(GetWidgets(idBoard));
        }

        // Update is called once per frame
        void Update()
        {

        }

        public IEnumerator GetWidgets(string idBoard)
        {
            Widgets response;
            #region llamadaAPIMiro

            var resource = string.Format(url + "/" + idBoard + "/widgets");
            UnityWebRequest miroRequest = UnityWebRequest.Get(resource);

            miroRequest.SetRequestHeader("Authorization", token);
            miroRequest.SetRequestHeader("Content-Type", "application/json");

            yield return miroRequest.SendWebRequest();

            #endregion
            if (miroRequest.isNetworkError || miroRequest.isHttpError)
            {
                Debug.LogError(miroRequest.error);
                yield break;
            }
            else
            {
                var jsonResponse = miroRequest.downloadHandler.text;
                response = JsonUtility.FromJson<Widgets>(jsonResponse);
                Color color;
                float x = 1, y = 1, z = 1;
                foreach (Datum widget in response.data.Where(x => x.type == "sticker").ToList())
                {
                    GameObject cubotemp = Instantiate(cube);
                    ColorUtility.TryParseHtmlString(widget.style.backgroundColor, out color);
                    cubotemp.GetComponent<Renderer>().material.color = color;
                    x = (widget.x / 150);
                    y = Math.Abs(widget.y / 150);

                    cubotemp.transform.localScale = new Vector3(widget.scale, widget.scale, widget.scale);
                    cubotemp.transform.position = new Vector3(x, y, z);

                    #region addText
                    Text texto = cubotemp.GetComponentInChildren<Text>();
                    if (texto != null)
                    {
                        texto.text = widget.text.Replace("<p>", "").Replace("</p>", "");
                    }
                    #endregion
                }

                #region TextWidgets
                //foreach (Datum widget in response.data.Where(x => x.type == "text").ToList())
                //{
                //    TextMeshPro textTemp = Instantiate(text);
                //    ColorUtility.TryParseHtmlString(widget.style.backgroundColor, out color);
                //    textTemp.GetComponent<Renderer>().material.color = color;

                //    x = (widget.x / 150);
                //    y = Math.Abs(widget.y / 150);

                //    // textTemp.transform.localScale = new Vector3(widget.scale, widget.scale, widget.scale);
                //    textTemp.transform.position = new Vector3(x, y, z);
                //    textTemp.transform.Rotate(widget.rotation, 0, 0);

                //    textTemp.text = widget.text.Replace("<p>", "").Replace("</p>", "");
                //    textTemp.fontSize = widget.style.fontSize;

                //}
                #endregion

                Debug.Log(response);
            }
        }

        public IEnumerator GetBoardInfo(string idBoard)
        {
            Board response;
            #region llamadaAPIMiro

            var resource = string.Format(url + "/" + idBoard);
            UnityWebRequest miroRequest = UnityWebRequest.Get(resource);

            miroRequest.SetRequestHeader("Authorization", token);
            miroRequest.SetRequestHeader("Content-Type", "application/json");

            yield return miroRequest.SendWebRequest();

            #endregion
            if (miroRequest.isNetworkError || miroRequest.isHttpError)
            {
                Debug.LogError(miroRequest.error);
                yield break;
            }
            else
            {
                var jsonResponse = miroRequest.downloadHandler.text;
                response = JsonUtility.FromJson<Board>(jsonResponse);
            }
        }
    }
}